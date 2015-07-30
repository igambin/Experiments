using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionExtensions
{
    public static class StringExtensions
    {

        public static byte[] ToByteArray(this string str) => new UTF8Encoding().GetBytes(str);

    }
}
