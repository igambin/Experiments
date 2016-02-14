using CodingInterview.Interfaces;
using NUnit.Framework;

namespace CodingInterview.Tests
{
    public partial class CodingInterviewTests
    {
        [TestFixture]
        public class StringQuestionsTests
        {
            private readonly IStringQuestions _areAnagramsWorker = new Solutions.StringQuestions();

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
