using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDecoupled.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        TEntity GetById(TId id);
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
