namespace WinService.Settings
{
    public partial class SettingsReader
    {
        public class ServiceSettings
        {
            public string ServicePort => GetInstance.ReadCfgSetting("Service.Port", "5000");
            public string Domain => GetInstance.ReadCfgSetting("Domain", "http://localhost");
        }

    }
}
