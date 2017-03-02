using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;

namespace CommonLogging
{
    public static class GenericLoggingExtensions
    {
        public static ILogger Log<TClass>(this TClass klass, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
            where TClass : class
        {
            ThreadContext.Properties["caller"] = $"[{file}:{line}({member})]";
            return LogManager.GetLogger<TClass>();
        }

        public static void DebugDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Debug($"{typeof(TEntity).Name}::{JsonConvert.SerializeObject(entity)}");

        public static void DebugFormat<TEntity>(this ILogger logger, TEntity entity, string format, params Func<TEntity, object>[] accessorFuncs)
            => logger.DebugFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void InfoDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Info($"{typeof(TEntity).Name}::{JsonConvert.SerializeObject(entity)}");

        public static void InfoFormat<TEntity>(this ILogger logger, TEntity entity, string format, params Func<TEntity, object>[] accessorFuncs)
            => logger.InfoFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void WarnDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Warn($"{typeof(TEntity).Name}::{JsonConvert.SerializeObject(entity)}");

        public static void WarnFormat<TEntity>(this ILogger logger, TEntity entity, string format, params Func<TEntity, object>[] accessorFuncs)
            => logger.WarnFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void ErrorDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Error($"{typeof(TEntity).Name}::{JsonConvert.SerializeObject(entity)}");

        public static void ErrorFormat<TEntity>(this ILogger logger, TEntity entity, string format, params Func<TEntity, object>[] accessorFuncs)
            => logger.ErrorFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void FatalDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Fatal($"{typeof(TEntity).Name}::{JsonConvert.SerializeObject(entity)}");

        public static void FatalFormat<TEntity>(this ILogger logger, TEntity entity, string format, params Func<TEntity, object>[] accessorFuncs)
            => logger.FatalFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());

    }
}
