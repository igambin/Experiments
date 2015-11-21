using System;
using System.Runtime.Serialization;

namespace IG.Extensions
{
    public static class GenericConversion
    { 
        public static T GetTOrDefault<T>(this string input) where T : IConvertible
        {
            T x;
            try
            {
                x = (T)Convert.ChangeType(input, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
            return x;
        }

        public static object GetTOrNull<T>(this string input) where T : IConvertible
        {
            T x;
            try
            {
                x = (T)Convert.ChangeType(input, typeof(T));
            }
            catch (Exception)
            {
                return null;
            }
            return x;
        }

        public static object GetTOrThrowException<T>(this string input) where T : IConvertible
        {
            T x;
            try
            {
                x = (T) Convert.ChangeType(input, typeof (T));
            }
            catch (Exception ex)
            {
                throw new ConversionException($"Conversion of value '{input}' to type '{typeof(T)}' caused an Exception of type '{ex.GetType()}'.", ex);
            }
            return x;
        }

        public class ConversionException : Exception
        {
            public ConversionException()
            {
            }

            public ConversionException(string message) : base(message)
            {
            }

            public ConversionException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ConversionException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }

}
