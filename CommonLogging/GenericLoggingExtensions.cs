using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommonLogging
{
    public static class GenericLoggingExtensions
    {
        public static ILogger Log<TEntity>(this TEntity entity) => LogManager.GetLogger<TEntity>();

        public static void Debug<TEntity>(this TEntity entity)
            => entity.Log().Debug(JsonConvert.SerializeObject(entity));

        public static void Debug<TEntity>(this TEntity entity, object message)
            => entity.Log().Debug(message);

        public static void Debug<TEntity>(this TEntity entity, object message, Exception exception)
            => entity.Log().Debug(message, exception);

        public static void DebugFormat<TEntity>(this TEntity entity, IFormatProvider provider, string format, params object[] args)
            => entity.Log().DebugFormat(provider, format, args);

        public static void DebugFormat<TEntity>(this TEntity entity, string format, params object[] args)
            => entity.Log().DebugFormat( format, args);

        public static void DebugFormat<TEntity>(this TEntity entity, string format, params Func<TEntity,object>[] accessorFuncs)
            => entity.Log().DebugFormat(format, accessorFuncs.Select(x => x(entity)).ToArray());

        public static void Info<TEntity>(this TEntity entity)
            => entity.Log().Info(JsonConvert.SerializeObject(entity));

        public static void Info<TEntity>(this TEntity entity, object message)
            => entity.Log().Info(message);

        public static void Info<TEntity>(this TEntity entity, object message, Exception exception)
            => entity.Log().Info(message, exception);

        public static void InfoFormat<TEntity>(this TEntity entity, IFormatProvider provider, string format, params object[] args)
            => entity.Log().InfoFormat(provider, format, args);

        public static void InfoFormat<TEntity>(this TEntity entity, string format, params object[] args)
            => entity.Log().InfoFormat(format, args);

        public static void InfoFormat<TEntity>(this TEntity entity, string format, params Func<TEntity, object>[] accessorFuncs)
            => entity.Log().InfoFormat(format, accessorFuncs.Select(x => x(entity)).ToArray());

        public static void Warn<TEntity>(this TEntity entity)
            => entity.Log().Warn(JsonConvert.SerializeObject(entity));

        public static void Warn<TEntity>(this TEntity entity, object message)
            => entity.Log().Warn(message);

        public static void Warn<TEntity>(this TEntity entity, object message, Exception exception)
            => entity.Log().Warn(message, exception);

        public static void WarnFormat<TEntity>(this TEntity entity, IFormatProvider provider, string format, params object[] args)
            => entity.Log().WarnFormat(provider, format, args);

        public static void WarnFormat<TEntity>(this TEntity entity, string format, params object[] args)
            => entity.Log().WarnFormat(format, args);

        public static void WarnFormat<TEntity>(this TEntity entity, string format, params Func<TEntity, object>[] accessorFuncs)
            => entity.Log().WarnFormat(format, accessorFuncs.Select(x => x(entity)).ToArray());

        public static void Error<TEntity>(this TEntity entity)
            => entity.Log().Error(JsonConvert.SerializeObject(entity));
        
        public static void Error<TEntity>(this TEntity entity, object message)
            => entity.Log().Error(message);

        public static void Error<TEntity>(this TEntity entity, object message, Exception exception)
            => entity.Log().Error(message, exception);

        public static void ErrorFormat<TEntity>(this TEntity entity, IFormatProvider provider, string format, params object[] args)
            => entity.Log().ErrorFormat(provider, format, args);

        public static void ErrorFormat<TEntity>(this TEntity entity, string format, params object[] args)
            => entity.Log().ErrorFormat(format, args);

        public static void ErrorFormat<TEntity>(this TEntity entity, string format, params Func<TEntity, object>[] accessorFuncs)
            => entity.Log().ErrorFormat(format, accessorFuncs.Select(x => x(entity)).ToArray());

        public static void Fatal<TEntity>(this TEntity entity)
            => entity.Log().Fatal(JsonConvert.SerializeObject(entity));

        public static void Fatal<TEntity>(this TEntity entity, object message)
            => entity.Log().Fatal(message);

        public static void Fatal<TEntity>(this TEntity entity, object message, Exception exception)
            => entity.Log().Fatal(message, exception);

        public static void FatalFormat<TEntity>(this TEntity entity, IFormatProvider provider, string format, params object[] args)
            => entity.Log().FatalFormat(provider, format, args);

        public static void FatalFormat<TEntity>(this TEntity entity, string format, params object[] args)
            => entity.Log().FatalFormat(format, args);

        public static void FatalFormat<TEntity>(this TEntity entity, string format, params Func<TEntity, object>[] accessorFuncs)
            => entity.Log().FatalFormat(format, accessorFuncs.Select(x => x(entity)).ToArray());


    }
}
