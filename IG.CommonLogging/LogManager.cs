using System;
using System.IO;
using System.Reflection;

namespace IG.CommonLogging
{
    public class LogManager : ILogManager
    {
        private static ILogManager Instance { get; }

        static LogManager()
        {
            var configFile = new FileInfo(Path.Combine(AssemblyDirectory,"log4net.config"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFile);
            Instance = new LogManager();
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetAssembly(typeof(LogManager)).CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static ILogger GetLogger<T>() 
            => Instance.GetLogger(typeof(T));


        public ILogger GetLogger(Type type) 
            => new LoggerAdapter(log4net.LogManager.GetLogger(type));
        

        public static ILogger GetLogger(string name)
            => new LoggerAdapter(log4net.LogManager.GetLogger(name));
    }
}
