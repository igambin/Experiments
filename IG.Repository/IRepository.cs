using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IG.Repository
{
    public interface IRepository
    {

        IQueryable<T> GetQuery<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        IEnumerable<T> GetRecords<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        T GetFirstOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        int Count<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        bool Any<T>(Expression<Func<T, bool>> predicate = null) where T : class;
    }
}
