using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using IG.CommonLogging.LogModels;
using IG.CommonLogging.Serializers;
using IG.SettingsReaders;
using log4net;

namespace IG.CommonLogging
{
    public static class GenericLoggingExtensions
    {
        public static ILogger Logger<TClass>(this TClass klass, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
            where TClass : class
        {
            ThreadContext.Properties["caller"] = $"[{file}:{line}({member})]";
            if (Settings.Logging.EvaluateStackTraces)
            {
                ThreadContext.Properties["stacktrace"] = Environment.StackTrace;
            }
            return LogManager.GetLogger<TClass>();
        }

        public static ILogger FileLogger<TClass>(this TClass klass, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
            where TClass : class
        {
            ThreadContext.Properties["caller"] = $"[{file}:{line}({member})]";
            if (Settings.Logging.EvaluateStackTraces)
            {
                ThreadContext.Properties["stacktrace"] = Environment.StackTrace;
            }
            return LogManager.GetLogger("FileLogger");
        }

        public static ILogger MailLogger<TClass>(this TClass klass, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
            where TClass : class
        {
            ThreadContext.Properties["caller"] = $"[{file}:{line}({member})]";
            if (Settings.Logging.EvaluateStackTraces)
            {
                ThreadContext.Properties["stacktrace"] = Environment.StackTrace;
            }
            ThreadContext.Properties["notifyEMailRecipients"] = "1";

            return LogManager.GetLogger("MailNotifier");
        }

        public static void DebugDump<TEntity>(this ILogger logger, ISerializingLogItem<TEntity> logItem, Exception ex = null, params string[] errors)
        {
            if (logger.IsDebugEnabled)
            {
                PrepareMessageAndLogToBlobStorage<TEntity>(logItem, ex, errors, logger.Debug);
            }
        }

        public static void DebugFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());
            }
        }


        public static void InfoDump<TEntity>(this ILogger logger, ISerializingLogItem<TEntity> logItem, Exception ex = null, params string[] errors)
        {
            if (logger.IsInfoEnabled)
            {
                PrepareMessageAndLogToBlobStorage<TEntity>(logItem, ex, errors, logger.Info);
            }
        }

        public static void InfoFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
            => logger.InfoFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void WarnDump<TEntity>(this ILogger logger, ISerializingLogItem<TEntity> logItem, Exception ex = null, params string[] errors)
        {
            if (logger.IsWarnEnabled)
            {
                PrepareMessageAndLogToBlobStorage<TEntity>(logItem, ex, errors, logger.Warn);
            }
        }

        public static void WarnFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
            => logger.WarnFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void ErrorDump<TEntity>(this ILogger logger, ISerializingLogItem<TEntity> logItem, Exception ex = null, params string[] errors)
        {
            if (logger.IsErrorEnabled)
            {
                PrepareMessageAndLogToBlobStorage<TEntity>(logItem, ex, errors, logger.Error);
            }
        }

        public static void ErrorFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
            => logger.ErrorFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void FatalDump<TEntity>(this ILogger logger, ISerializingLogItem<TEntity> logItem, Exception ex = null, params string[] errors)
        {
            if (logger.IsFatalEnabled)
            {
                PrepareMessageAndLogToBlobStorage<TEntity>(logItem, ex, errors, logger.Fatal);
            }
        }

        public static void FatalFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
            => logger.FatalFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        private static void PrepareMessageAndLogToBlobStorage<TEntity>(ISerializingLogItem<TEntity> logItem, Exception ex,
            IEnumerable<string> errors, Action<string, Exception> logAction)
        {
            logItem.Errors = errors;
            logItem.Exception = ex;

            if (logItem.IsNotifyEMailRecipients)
            {
                ThreadContext.Properties["notifyEMailRecipients"] = "1";
            }

            var message = logItem.SimpleLogMessage;

            ThreadContext.Properties["logItem"] = logItem;

            logAction(message, ex);
        }

    }
}
