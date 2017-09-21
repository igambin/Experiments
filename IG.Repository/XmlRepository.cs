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
    public class XmlRepository : IRepository
    {
        private readonly string _xmlLocation;

        public XmlRepository(string xmlLocation)
        {
            _xmlLocation = xmlLocation;
        }

        public List<T> LoadXml<T>(string key) {

            string path = Path.Combine(_xmlLocation, key);

            var input = File.ReadAllText(path, Encoding.UTF8);

            var data = Serialization.Deserialize<List<T>>(input);

            return data;
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            var type = typeof(T);
            var key = type.Name + ".xml";

            MemoryCaching cachable = new MemoryCaching();

            List<T> _data = cachable.GetOrSet<List<T>>(key, () => LoadXml<T>(key));

            return _data;
        }

        public IEnumerable<T> GetRecords<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return GetAll<T>().Where(predicate.Compile());
            }
            return GetAll<T>();
        }

        public IQueryable<T> GetQuery<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return GetAll<T>().AsQueryable().Where(predicate);
            }
            return GetAll<T>().AsQueryable();
        }

        public T GetFirstOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return GetAll<T>().FirstOrDefault(predicate.Compile());
            }
            return GetAll<T>().FirstOrDefault();
        }

        public int Count<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return GetAll<T>().Count(predicate.Compile());
            }
            return GetAll<T>().Count();
        }

        public bool Any<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return GetAll<T>().Any(predicate.Compile());
            }
            return GetAll<T>().Any();
        }

    }
}
