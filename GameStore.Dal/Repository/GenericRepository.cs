using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GameStore.Dal.Interfaces;
using GameStore.Dal.Models;

namespace GameStore.Dal.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IGameStoreContext _database;

        public GenericRepository(IGameStoreContext database)
        {
            _database = database;
        }

        public void Create(T item)
        {
            _database.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            var item = _database.Set<T>().Find(id);
            if (item != null)
            {
                item.IsDeleted = true;
                _database.Entry(item).State = EntityState.Modified;
            }
        }

        public T Get(int id)
        {
            var entity = _database.Set<T>().Find(id);

            if (entity != null)
            {
                return entity.IsDeleted ? null : entity;
            }

            return null;
        }

        public IEnumerable<T> GetAll()
        {
            return _database.Set<T>().ToList().Where(t => !t.IsDeleted);
        }

        public IEnumerable<T> GetAllDeleted()
        {
            return _database.Set<T>().ToList().Where(t => t.IsDeleted);
        }

        public void Update(T item)
        {
            _database.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _database.Set<T>().Where(predicate).Where(t => !t.IsDeleted).ToList();
        }
    }
}
