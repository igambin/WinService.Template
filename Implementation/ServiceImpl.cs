using System;
using System.ComponentModel;
using Microsoft.Owin.Hosting;
using WinService.Logging;
using WinService.Settings;

namespace WinService.Implementation
{
    public partial class ServiceImpl : Component
    {
        IDisposable SelfHostedApi { get; set; }

        private string ServiceDomain { get; } = SettingsReader.Service.Domain;
        private string ServicePort { get; } = SettingsReader.Service.ServicePort;
        private string ServiceAddress => $"{ServiceDomain}:{ServicePort}";

        public ServiceImpl()
        {
            InitializeComponent();
        }

        public void OnStart(string[] args)
        {
            this.Logger().Info("Received Start Command");
            SelfHostedApi = WebApp.Start<WebApiConfig>(url: ServiceAddress);
        }

        public void OnPause()
        {
            this.Logger().Info("Received Pause Command");
        }

        public void OnContinue()
        {
            this.Logger().Info("Received Continue Command");
        }

        public void OnStop()
        {
            this.Logger().Info("Received Stop Command");
            SelfHostedApi.Dispose();
        }

        public void OnShutdown()
        {
            this.Logger().Info("Received Shutdown Command");
            SelfHostedApi.Dispose();
        }
    }

}
