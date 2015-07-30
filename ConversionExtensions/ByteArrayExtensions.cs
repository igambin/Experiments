using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionExtensions
{
    public static class ByteArrayExtensions
    {
        public static string AsString(this byte[] arr) => new UTF8Encoding().GetString(arr);

    }
}
