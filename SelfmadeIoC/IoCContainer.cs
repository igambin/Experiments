using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SelfmadeIoC
{
    public class IoCContainer
    {

        private Dictionary<Type, object> providers = new Dictionary<Type, object>();

        #region LVL1 - provider-Instance-Registrations

        public void Register<T>(T instance)
        {
            if (providers.ContainsKey(typeof(T)))
            {
                throw new TypeAlreadyRegisteredException();
            }

            providers.Add(typeof(T), instance);
        }

        public void Reregister<T>(T instance)
        {
            if (!providers.ContainsKey(typeof(T)))
            {
                throw new TypeNotRegisteredException();
            }

            providers[typeof(T)] = instance;
        }
        
        #endregion

        #region LVL2 - provider-Type-Registrations

        public void Register<TKey, TType>() where TType : TKey
        {
            if (providers.ContainsKey(typeof(TKey)))
            {
                throw new TypeAlreadyRegisteredException();
            }

            providers.Add(typeof(TKey), typeof(TType));
            
        }

        public void Reregister<TKey, TType>() where TType : TKey
        {
            if (!providers.ContainsKey(typeof(TKey)))
            {
                throw new TypeNotRegisteredException();
            }

            providers[typeof(TKey)] = typeof(TType);
        }

        #endregion
        
        #region provider-Unregistration
        public void Unregister<T>()
        {
            if (!providers.ContainsKey(typeof(T)))
            {
                throw new TypeNotRegisteredException();
            }

            providers.Remove(typeof(T));
        }
        #endregion

        public T Resolve<T>(string name = null)
        {
            return (T)ResolveType(typeof(T), name);
        }

        private object ResolveType(Type t, string name = null)
        {
            if (!providers.ContainsKey(t))
            {
                throw new TypeNotRegisteredException();
            }

            object toResolve = providers[t];

            var type1 = toResolve as Type;

            if (type1 == null)
            {
                return toResolve;
            }

            ConstructorInfo cinfo;
            if (name != null)
            {
                cinfo = type1.GetConstructors().FindByName(name);
            }
            else
            {
                cinfo = type1.GetConstructors().FirstOrDefault();
            }

            ParameterInfo[] args = cinfo.GetParameters();

            if (args.Count() == 0)
            {
                return Activator.CreateInstance((Type)toResolve);
            }


            return cinfo.Invoke(args.Select(x => ResolveType(x.ParameterType)).ToArray());

            
        }
        
    }
}
