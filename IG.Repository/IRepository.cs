using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IG.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null);

        IEnumerable<TEntity> GetRecords(Expression<Func<TEntity, bool>> predicate = null);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null);

        int Count(Expression<Func<TEntity, bool>> predicate = null);

        bool Any(Expression<Func<TEntity, bool>> predicate = null);
    }
}
