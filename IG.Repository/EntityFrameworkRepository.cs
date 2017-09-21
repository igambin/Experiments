using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace IG.Repository
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        protected Type ContextType;
        protected string ConnectionString;
        protected DbContext Context;

        public EntityFrameworkRepository(Type dbContext, string connectionString)
        {
            ContextType = dbContext;
            ConnectionString = connectionString;
            Context = CreateContext();
        }

        private DbContext CreateContext()
        {
            var constructor = ContextType.GetConstructor(new[] { typeof(string) });
            if (constructor != null)
            {
                return (DbContext)constructor.Invoke(new object[] { ConnectionString });
            }
            return null;
        }

        public IEnumerable<TEntity> GetRecords(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return Context.Set<TEntity>().Where(predicate);
            }
            return Context.Set<TEntity>();
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return Context.Set<TEntity>().FirstOrDefault(predicate);
            }
            return Context.Set<TEntity>().FirstOrDefault();
        }


        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return Context.Set<TEntity>().Where(predicate);
            }
            return Context.Set<TEntity>();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null) 
        {
            if (predicate != null)
            {
                return Context.Set<TEntity>().Count(predicate);
            }
            return Context.Set<TEntity>().Count();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return Context.Set<TEntity>().Any(predicate);
            }
            return Context.Set<TEntity>().Any();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

    }
}
