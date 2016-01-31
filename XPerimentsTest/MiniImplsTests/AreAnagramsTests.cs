using System;
using Experiments.MiniImpls;
using NUnit.Framework;

namespace XPerimentsTest.MiniImplsTests
{
    [TestFixture]
    public class AreAnagramsTests
    {
        [Test]
        public void Test_momdad_dadmom_true()
        {
            Assert.IsTrue(AreAnagrams.AreStringsAnagrams("momdad", "dadmom"));
        }

        [Test]
        public void Test_monday_manday_false()
        {
            Assert.IsFalse(AreAnagrams.AreStringsAnagrams("monday", "manday"));
        }

    }
}
