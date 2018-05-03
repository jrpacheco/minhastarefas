using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Interface
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        TEntity Get(Func<TEntity, bool> predicate);
        TEntity Find(params object[] key);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(Func<TEntity, bool> predicate);
        int Count();
    }
}
