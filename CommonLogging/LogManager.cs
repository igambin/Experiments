using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;

namespace CommonLogging
{
    public class LogManager : ILogManager
    {
        private static readonly ILogManager _logManager;

        static LogManager()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            _logManager = new LogManager();
        }

        public static ILogger GetLogger<T>()
        {
            return _logManager.GetLogger(typeof(T));
        }

        public ILogger GetLogger(Type type)
        {
            var logger = log4net.LogManager.GetLogger(type);
            return new LoggerAdapter(logger);
        }
    }
}
