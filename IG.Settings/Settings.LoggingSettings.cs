using System;
using System.Configuration;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace IG.SettingsReaders
{
    public partial class Settings
    {
  
        public class LoggingSettings
        {
            public bool EvaluateStackTraces => GetInstance.ReadCfgSetting<bool>("Logging.EvaluateStackTraces");
        }
    }
}
