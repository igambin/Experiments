using System.Text;

namespace ConversionExtensions
{
    public static class StringExtensions
    {

        public static byte[] ToByteArray(this string str) => new UTF8Encoding().GetBytes(str);

    }
}
