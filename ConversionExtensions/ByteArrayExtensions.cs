using System.Text;

namespace IG.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string AsString<TEncoding>(this byte[] arr) where TEncoding : Encoding, new() => new TEncoding().GetString(arr);

        public static string AsString(this byte[] arr) => new UTF8Encoding().GetString(arr);
    }
}
