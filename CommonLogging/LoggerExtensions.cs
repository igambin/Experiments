﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;

namespace CommonLogging
{
    public static class LoggerExtensions
    {

        public static void Debug(this ILogger log, Func<string> formattingCallback)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(formattingCallback());
            }
        }

        public static void Info(this ILogger log, Func<string> formattingCallback)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(formattingCallback());
            }
        }
        public static void Warn(this ILogger log, Func<string> formattingCallback)
        {
            if (log.IsWarnEnabled)
            {
                log.Warn(formattingCallback());
            }
        }
        public static void Error(this ILogger log, Func<string> formattingCallback)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(formattingCallback());
            }
        }
        public static void Fatal(this ILogger log, Func<string> formattingCallback)
        {
            if (log.IsFatalEnabled)
            {
                log.Fatal(formattingCallback());
            }
        }
    }
}
