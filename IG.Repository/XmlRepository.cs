using IG.Caching;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IG.XmlTools;

namespace IG.Repository
{
    public class XmlRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly string _xmlLocation;

        public XmlRepository(string xmlLocation)
        {
            _xmlLocation = xmlLocation;
        }
        public List<TEntity> LoadXml(string key) {

            string path = Path.Combine(_xmlLocation, key);

            var input = File.ReadAllText(path, Encoding.UTF8);

            var data = Serialization.Deserialize<List<TEntity>>(input);

            return data;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var type = typeof(TEntity);
            var key = type.Name + ".xml";

            MemoryCaching cachable = new MemoryCaching();

            List<TEntity> data = cachable.GetOrSet(key, () => LoadXml(key));

            return data;
        }

        public IEnumerable<TEntity> GetRecords(Expression<Func<TEntity, bool>> predicate = null) 
        {
            if (predicate != null)
            {
                return GetAll().Where(predicate.Compile());
            }
            return GetAll();
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null) 
        {
            if (predicate != null)
            {
                return GetAll().AsQueryable().Where(predicate);
            }
            return GetAll().AsQueryable();
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return GetAll().FirstOrDefault(predicate.Compile());
            }
            return GetAll().FirstOrDefault();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return GetAll().Count(predicate.Compile());
            }
            return GetAll().Count();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate = null) 
        {
            if (predicate != null)
            {
                return GetAll().Any(predicate.Compile());
            }
            return GetAll().Any();
        }

    }
}
