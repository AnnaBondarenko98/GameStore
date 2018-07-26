using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GameStore.Dal.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllDeleted();

        T Get(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}