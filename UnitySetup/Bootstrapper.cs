using Microsoft.Practices.Unity;

namespace UnitySetup
{
    public class Bootstrapper : UnityContainer
    {
        public static Bootstrapper Instance { get; } = new Bootstrapper();

        static Bootstrapper() { }

        private Bootstrapper()
        {
            RegisterTypes();
        }

        private void RegisterTypes()
        {
        }

    }
}
