using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommonLogging.Enums;
using IG.Extensions;
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

        public static ILogger RequestDump<TClass>(this TClass klass, HttpRequestMessage request, DumpType dumpType, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
            where TClass : class
        {
            ThreadContext.Properties["caller"] = $"[{file}:{line}({member})]";
            ThreadContext.Properties["request"] = request;
            ThreadContext.Properties["dumpType"] = dumpType.ToString();
            ThreadContext.Properties["blobDump"] = 1;
            return LogManager.GetLogger<TClass>();
        }

        private static Func<object, string> DefaultLogSerializer { get; } = LogSerializer.SerializeJson;

        public static void DebugDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.DebugDump(entity, DefaultLogSerializer);

        public static void DebugDump<TEntity>(this ILogger logger, TEntity entity, Func<object, string> serializerFunc)
            => logger.Debug($"{typeof(TEntity).Name}::{serializerFunc(entity)}");

        public static void DebugTxtDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Debug($"{typeof(TEntity).Name}::{LogSerializer.SerializeTxt(entity)}");

        public static void DebugJsonDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Debug($"{typeof(TEntity).Name}::{LogSerializer.SerializeJson(entity)}");

        public static void DebugXmlDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Debug($"{typeof(TEntity).Name}::{LogSerializer.SerializeXml(entity)}");

        public static void DebugFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
            => logger.DebugFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void InfoDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.InfoDump(entity, DefaultLogSerializer);

        public static void InfoDump<TEntity>(this ILogger logger, TEntity entity, Func<object, string> serializerFunc)
            => logger.Info($"{typeof(TEntity).Name}::{serializerFunc(entity)}");

        public static void InfoTxtDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Info($"{typeof(TEntity).Name}::{LogSerializer.SerializeTxt(entity)}");

        public static void InfoJsonDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Info($"{typeof(TEntity).Name}::{LogSerializer.SerializeJson(entity)}");

        public static void InfoXmlDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Info($"{typeof(TEntity).Name}::{LogSerializer.SerializeXml(entity)}");

        public static void InfoFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
            => logger.InfoFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void WarnDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.WarnDump(entity, DefaultLogSerializer);

        public static void WarnDump<TEntity>(this ILogger logger, TEntity entity, Func<object, string> serializerFunc)
            => logger.Warn($"{typeof(TEntity).Name}::{serializerFunc(entity)}");

        public static void WarnTxtDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Warn($"{typeof(TEntity).Name}::{LogSerializer.SerializeTxt(entity)}");

        public static void WarnJsonDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Warn($"{typeof(TEntity).Name}::{LogSerializer.SerializeJson(entity)}");

        public static void WarnXmlDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Warn($"{typeof(TEntity).Name}::{LogSerializer.SerializeXml(entity)}");

        public static void WarnFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
            => logger.WarnFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void ErrorDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.ErrorDump(entity, DefaultLogSerializer);

        public static void ErrorDump<TEntity>(this ILogger logger, TEntity entity, Func<object, string> serializerFunc)
            => logger.Error($"{typeof(TEntity).Name}::{serializerFunc(entity)}");

        public static void ErrorTxtDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Error($"{typeof(TEntity).Name}::{LogSerializer.SerializeTxt(entity)}");

        public static void ErrorJsonDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Error($"{typeof(TEntity).Name}::{LogSerializer.SerializeJson(entity)}");

        public static void ErrorXmlDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Error($"{typeof(TEntity).Name}::{LogSerializer.SerializeXml(entity)}");

        public static void ErrorFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
            => logger.ErrorFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());


        public static void FatalDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.FatalDump(entity, DefaultLogSerializer);

        public static void FatalDump<TEntity>(this ILogger logger, TEntity entity, Func<object, string> serializerFunc)
            => logger.Fatal($"{typeof(TEntity).Name}::{serializerFunc(entity)}");

        public static void FatalTxtDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Fatal($"{typeof(TEntity).Name}::{LogSerializer.SerializeTxt(entity)}");

        public static void FatalJsonDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Fatal($"{typeof(TEntity).Name}::{LogSerializer.SerializeJson(entity)}");

        public static void FatalXmlDump<TEntity>(this ILogger logger, TEntity entity)
            => logger.Fatal($"{typeof(TEntity).Name}::{LogSerializer.SerializeXml(entity)}");

        public static void FatalFormat<TEntity>(this ILogger logger, string format, TEntity entity, params Func<TEntity, object>[] accessorFuncs)
            => logger.FatalFormat($"{typeof(TEntity).Name}::({format})", accessorFuncs.Select(x => x(entity)).ToArray());
    }
}
