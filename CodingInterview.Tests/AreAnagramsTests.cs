using CodingInterview.Interfaces;
using Solutions = CodingInterview.Solutions;
using Tasks = CodingInterview.Tasks;
using NUnit.Framework;

namespace CodingInterview.Tests
{
    public class CodingInterviewTests
    {
        [TestFixture]
        public class AreAnagramsTests
        {
            private readonly IAreAnagrams _areAnagramsWorker = new Solutions.AreAnagrams();

            [Test]
            public void Test_momdad_dadmom_true()
            {
                Assert.IsTrue(_areAnagramsWorker.AreStringsAnagrams("momdad", "dadmom"));
            }

            [Test]
            public void Test_monday_manday_false()
            {
                Assert.IsFalse(_areAnagramsWorker.AreStringsAnagrams("monday", "manday"));
            }
        }
    }
}
