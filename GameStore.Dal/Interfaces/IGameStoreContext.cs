using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GameStore.Dal.Interfaces
{
    public interface IGameStoreContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}