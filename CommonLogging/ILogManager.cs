using System;

namespace CommonLogging
{
    public interface ILogManager
    {
        ILogger GetLogger(Type type);
    }
}