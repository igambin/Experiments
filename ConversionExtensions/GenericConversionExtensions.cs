using System;

namespace ConversionExtensions
{
    public static class GenericConversionExtensions
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
    }

}
