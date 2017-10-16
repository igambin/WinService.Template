using Microsoft.Practices.Unity;
using WinService.Caching;

namespace WinService.UnitySetup
{
    public class UnityConfig : UnityContainer
    {
        public static IUnityContainer Container { get; } = new UnityConfig();
        
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
