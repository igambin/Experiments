using System;
using NUnit.Framework;

namespace XPerimentsTest.BoundariesTests
{
    /// <summary>
    /// Summary description for BoundaryTests
    /// </summary>
    [TestFixture]
    public class BoundaryTests
    {
        [Test]
        public void CallMethodThatCallsAMethodOfAnotherDLLThatThrowsAnInternalException()
        {
            try
            {
                BoundariesI.Class1.DoSomething1();
            }
            catch (Exception)
            {
                // nothing
            }
        }
    }
}
