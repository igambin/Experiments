using System.Linq;
using CodingInterview.Interfaces;

namespace CodingInterview.Solutions
{
    public class StringQuestions : IStringQuestions
    {
        public bool AreStringsAnagrams(string a, string b)
        {
            var strA = a.ToCharArray().OrderBy(x => x);
            var strB = b.ToCharArray().OrderBy(x => x);
            return strA.SequenceEqual(strB);
        }
    }
}
