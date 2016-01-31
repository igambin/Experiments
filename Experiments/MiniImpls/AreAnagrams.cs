using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments.MiniImpls
{
    public class AreAnagrams
    {
        public static bool AreStringsAnagrams(string a, string b)
        {
            var strA = a.ToCharArray().OrderBy(x => x);
            var strB = b.ToCharArray().OrderBy(x => x);
            return strA.SequenceEqual(strB);
        }
    }

 
}
