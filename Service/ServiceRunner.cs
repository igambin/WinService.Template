using System.ServiceProcess;
using Microsoft.Practices.Unity;
using WinService.Implementation;
using WinService.UnitySetup;
using WinService.Logging;

namespace WinService.Service
{
    public partial class ServiceRunner : ServiceBase
    {
        #region private instance fields
        /// <summary>
        /// Die Implementierung wird in ein eigenes Assembly ausgelagert, damit
        /// der Testreiber dieses ebenfalls verwenden kann. 
        /// Das vereinfacht das Debuggen der Funktionalität.
        /// </summary>
        private ServiceImpl ServiceImpl { get; set; }
        private IUnityContainer UnityContainer { get; }

        #endregion

        public ServiceRunner()
        {
            InitializeComponent();
            UnityContainer = UnityConfig.Container;
        }

        protected override void OnStart(string[] args)
        {
            // start JobConsumer
            this.FileLogger().Debug($"{ServiceName} starting");
            ServiceImpl = UnityContainer.Resolve<ServiceImpl>();
            ServiceImpl.OnStart(args);
        }

        protected override void OnPause()
        {
            this.FileLogger().Debug($"{ServiceName} pausing");
            ServiceImpl.OnPause();
        }

        protected override void OnContinue()
        {
            this.FileLogger().Debug($"{ServiceName} continuing");
            ServiceImpl.OnContinue();
        }

        protected override void OnStop()
        {
            this.FileLogger().Debug($"{ServiceName} stopping");
            ServiceImpl.OnStop();
        }

        protected override void OnShutdown()
        {
            this.FileLogger().Debug($"{ServiceName} shutting down");
            ServiceImpl.OnShutdown();
        }
    }
}
