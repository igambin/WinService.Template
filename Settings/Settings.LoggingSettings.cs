﻿namespace WinService.Settings
{
    public partial class SettingsReader
    {
  
        public class LoggingSettings
        {
            public bool EvaluateStackTraces => GetInstance.ReadCfgSetting<bool>("Logging.EvaluateStackTraces");
        }

    }
}
