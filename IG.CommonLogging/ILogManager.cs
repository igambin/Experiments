using System;

namespace IG.CommonLogging
{
    public interface ILogManager
    {
        ILogger GetLogger(Type type);
    }
}