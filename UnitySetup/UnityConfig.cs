using IG.Caching;
using Microsoft.Practices.Unity;

namespace UnitySetup
{
    public class UnityConfig : UnityContainer
    {
        public static UnityConfig Container { get; } = new UnityConfig();

        static UnityConfig() { }

        private UnityConfig()
        {
            RegisterTypes();
        }

        private void RegisterTypes()
        {
            this.RegisterType<ICachable, MemoryCaching>();
        }

    }
}
