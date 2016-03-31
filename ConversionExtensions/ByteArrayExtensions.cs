using System.Text;

namespace IG.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string AsString(this byte[] arr) => new UTF8Encoding().GetString(arr);

    }
}
