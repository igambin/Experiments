﻿using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using CommonLogging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPerimentsTest.CommonLoggingTests.Environment;

namespace XPerimentsTest.CommonLoggingTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class CommonLoggingTests
    {
        public CommonLoggingTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_Debug_Overrides()
        {
            var person = new Person() {Id = 1, Name = "Ingo Gambin"};
            this.Log().DebugDump(person);
            this.Log().Info("message");
            this.Log().Warn("message with exception", new NullReferenceException());
            this.Log().ErrorFormat("{0} {1} {2} {3} {4}", "a", "b", "c", "d", "e");
            this.Log().FatalFormat("Hello {0} ({1})", person, p => p.Name, p => p.Id);
        }

    }
}
