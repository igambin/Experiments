using System.Text;

namespace IG.Extensions
{
    public static class StringExtensions
    {

        public static byte[] ToByteArray(this string str) => new UTF8Encoding().GetBytes(str);

    }
}
