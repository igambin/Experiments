using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IG.Repository
{
    public class EntityFrameworkRepository : IRepository, IDisposable
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

        public IEnumerable<T> GetRecords<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return Queryable.Where(Context.Set<T>(), predicate);
            }
            return Context.Set<T>();
        }

        public T GetFirstOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return Queryable.FirstOrDefault(Context.Set<T>(), predicate);
            }
            return Queryable.FirstOrDefault<T>(Context.Set<T>());
        }


        public IQueryable<T> GetQuery<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return Queryable.Where(Context.Set<T>(), predicate);
            }
            return Context.Set<T>();
        }

        public int Count<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return Queryable.Count(Context.Set<T>(), predicate);
            }
            return Queryable.Count<T>(Context.Set<T>());
        }

        public bool Any<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return Queryable.Any(Context.Set<T>(), predicate);
            }
            return Queryable.Any<T>(Context.Set<T>());
        }

        public void Dispose()
        {
            Context.Dispose();
        }

    }
}
