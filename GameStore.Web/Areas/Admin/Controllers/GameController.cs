using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using GameStore.Bll.Interfaces;
using GameStore.Bll.ModelsDto;
using Newtonsoft.Json;

namespace GameStore.Areas.Admin.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("new")]
        public JsonResult NewGame(string jsonGame)
        {
            var gameDto = JsonConvert.DeserializeObject<CreatingGameDto>(jsonGame);

            var result = _gameService.Create(gameDto);

            return Json(result.Message);
        }

        [HttpPost]
        [ActionName("updates")]
        public ActionResult EditGame(string jsonGame)
        {
            var gameDto = JsonConvert.DeserializeObject<CreatingGameDto>(jsonGame);

            _gameService.Update(gameDto);

            return new HttpStatusCodeResult(HttpStatusCode.OK) ;
        }

        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public JsonResult Details(string key)
        {
            var game = _gameService.GetByKey(key);

            var result = JsonConvert.SerializeObject(game);

            return Json(game, "application/json", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public JsonResult GetAll()
        {
            var games = _gameService.GetAll();

            var result = JsonConvert.SerializeObject(games);

            return Json(result, "application/json", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("remove")]
        public ActionResult DeleteGame(int id)
        {
            _gameService.Delete((int)id);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [ActionName("newcomment")]
        public ActionResult NewComment(string key, string commentJson, int? id)
        {
            var game = _gameService.GetByKey(key).First();

            var commentDto = JsonConvert.DeserializeObject<CommentDto>(commentJson);

            if (id != null)
            {
                commentDto.ParentCommentId = id;
            }

            _gameService.AddComment(game.Id, commentDto);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [ActionName("comments")]
        public JsonResult NewComment(string key)
        {
            var game = _gameService.GetByKey(key).First();

            var comments = game.Comments;

            var result = JsonConvert.SerializeObject(comments);

            return Json(result, "application/json");
        }

        [ActionName("download")]
        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public FileResult DownloadGame(string key)
        {
            string filePath = @"~/Content/MC.bin";
            string filetype = "application/unknown";
            var file = File(filePath, filetype, filePath);

            return file;
        }
    }
}