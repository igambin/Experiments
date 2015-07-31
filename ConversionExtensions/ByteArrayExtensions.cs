using System.Text;

namespace ConversionExtensions
{
    public static class ByteArrayExtensions
    {
        public static string AsString(this byte[] arr) => new UTF8Encoding().GetString(arr);

    }
}
