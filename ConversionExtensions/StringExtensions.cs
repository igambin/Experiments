using System.Text;

namespace IG.Extensions
{
    public static class StringExtensions
    {

        public static byte[] ToByteArray(this string str) => new UTF8Encoding().GetBytes(str);
        public static byte[] ToByteArray<TEncoding>(this string str) where TEncoding : Encoding, new() => new TEncoding().GetBytes(str);

    }
}
