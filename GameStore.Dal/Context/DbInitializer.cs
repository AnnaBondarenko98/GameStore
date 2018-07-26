using System.Data.Entity;
using GameStore.Dal.Models;

namespace GameStore.Dal.Context
{
    public class DbInitializer : CreateDatabaseIfNotExists<GameStoreContext>
    {
        protected override void Seed(GameStoreContext db)
        {
            var strategy = new Genre
            {
                Name = "Strategy",
                ParentGenre = null
            };
            var rts = new Genre
            {
                Name = "RTS",
                ParentGenre = strategy
            };
            var tbs = new Genre
            {
                Name = "tbs",
                ParentGenre = strategy
            };

            var sports = new Genre
            {
                Name = "Sports",
                ParentGenre = null
            };

            var races = new Genre
            {
                Name = "Races",
                ParentGenre = null
            };
            var rally = new Genre
            {
                Name = "Rally",
                ParentGenre = races
            };
            var arcade = new Genre
            {
                Name = "Arcade",
                ParentGenre = races
            };
            var formula = new Genre
            {
                Name = "Formula",
                ParentGenre = races
            };
            var offRoad = new Genre
            {
                Name = "Off-road",
                ParentGenre = races
            };

            var action = new Genre
            {
                Name = "Action",
                ParentGenre = null
            };
            var fps = new Genre
            {
                Name = "FPS",
                ParentGenre = action
            };
            var tps = new Genre
            {
                Name = "TPS",
                ParentGenre = action
            };
            var miscCh = new Genre
            {
                Name = "Misc",
                ParentGenre = action
            };

            var adventure = new Genre
            {
                Name = "Adventure",
                ParentGenre = null
            };

            var puzzleSkill = new Genre
            {
                Name = "Puzzle & Skill",
                ParentGenre = null
            };

            var misc = new Genre
            {
                Name = "Misc",
                ParentGenre = null
            };

            db.Genres.Add(strategy);
            db.Genres.Add(rts);
            db.Genres.Add(tbs);
            db.Genres.Add(sports);
            db.Genres.Add(races);
            db.Genres.Add(rally);
            db.Genres.Add(arcade);
            db.Genres.Add(formula);
            db.Genres.Add(offRoad);
            db.Genres.Add(action);
            db.Genres.Add(fps);
            db.Genres.Add(tps);
            db.Genres.Add(miscCh);
            db.Genres.Add(misc);
            db.Genres.Add(adventure);
            db.Genres.Add(puzzleSkill);

            var desctop = new PlatformType()
            {
                Type = "Desktop"
            };

            var browser = new PlatformType()
            {
                Type = "Browser"
            };

            var console = new PlatformType()
            {
                Type = "Console"
            };

            var mobile = new PlatformType()
            {
                Type = "Mobile"
            };

            db.PlatformTypes.Add(desctop);
            db.PlatformTypes.Add(browser);
            db.PlatformTypes.Add(console);
            db.PlatformTypes.Add(mobile);

            base.Seed(db);
        }
    }
}
