using System.Web.Mvc;

namespace GameStore.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("GamesCommon",
                "admin/{controller}s/{action}",
                new { action = "GetAll" });

            context.MapRoute("GameCommon",
                "admin/{controller}/{key}/{action}",
                new { controller = "Game", action = "Details" });
        }
    }
}