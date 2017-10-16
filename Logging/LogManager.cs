using System;
using System.IO;
using WinService.Extensions;

namespace WinService.Logging
{
    public class LogManager : ILogManager
    {
        private static ILogManager Instance { get; }
        public MailNotificationLevel MailNotificationLevel { get; set; }
        public bool AlwaysNotifyByMailOnException { get; set; }

        static LogManager()
        {
            var configFile = new FileInfo(Path.Combine(typeof(LogManager).AssemblyDirectory(), "log4net.config"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFile);
            Instance = new LogManager();
            
        }
        
        public static ILogger GetLogger<T>() 
            => Instance.GetLogger(typeof(T));

        public ILogger GetLogger(Type type) 
            => new LoggerAdapter(log4net.LogManager.GetLogger(type));

        public static ILogger GetLogger(string name)
            => new LoggerAdapter(log4net.LogManager.GetLogger(name));
    }
}
