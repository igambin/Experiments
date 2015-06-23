using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionExtensions
{
    public static class StringExtensions
    {

        public static byte[] ToByteArray(this string str)
        {
            var enc = new UTF8Encoding();
            return enc.GetBytes(str);
        }
    }
}
