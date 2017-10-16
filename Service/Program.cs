using System;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;
using Microsoft.Practices.Unity;

namespace WinService.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                string parameter = string.Concat(args);
                switch (parameter)
                {
                    case "--install":
                        ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
                        break;
                    case "--uninstall":
                        ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
                        break;
                }
            }
            else
            {
                var container = UnitySetup.UnityConfig.Container;
                ServiceBase.Run(
                    new ServiceBase[]
                    {
                        container.Resolve<ServiceRunner>()
                    });
            }
        }
    }
}
