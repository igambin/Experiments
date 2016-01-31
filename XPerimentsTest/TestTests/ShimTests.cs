using System;
using System.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XPerimentsTest.TestTests
{
    [TestClass]
    public class ShimTests
    {
        [TestMethod]
        public void ShimDateTimeTest()
        {
            using (var x = ShimsContext.Create())
            {
                ShimDateTime.NowGet = () => new DateTime(2015, 1, 1);
                Assert.AreEqual("01.01.2015", DateTime.Now.ToShortDateString());
            }
        }
    }
}