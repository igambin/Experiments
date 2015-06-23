using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            BoundariesI.Class1.DoSomething1();
        }
    }
}
