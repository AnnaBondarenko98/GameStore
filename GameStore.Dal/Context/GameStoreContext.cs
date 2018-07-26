using System.Data.Entity;
using GameStore.Dal.Interfaces;
using GameStore.Dal.Models;

namespace GameStore.Dal.Context
{
    public class GameStoreContext : DbContext, IGameStoreContext
    {
        static GameStoreContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public GameStoreContext(string connection) : base(connection)
        {

        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<PlatformType> PlatformTypes { get; set; }
    }
}
