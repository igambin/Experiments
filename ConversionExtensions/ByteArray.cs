using System.Text;

namespace IG.Extensions
{
    public static class ByteArray
    {
        public static string AsString(this byte[] arr) => new UTF8Encoding().GetString(arr);

    }
}
