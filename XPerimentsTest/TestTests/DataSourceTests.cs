using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XPerimentsTest.TestTests
{
    [TestClass]
    public class DataSourceTests
    {
        public TestContext TestContext { get; set; }

        private dynamic ExtractRowDataFromContext() => new
        {
            Name = TestContext.DataRow["Name"],
            Alter = Convert.ToInt32(TestContext.DataRow["Alter"], CultureInfo.CurrentCulture),
            Gehalt = Convert.ToInt32(TestContext.DataRow["Gehalt"], CultureInfo.CurrentCulture),
            Bonus = Convert.ToDecimal(TestContext.DataRow["Bonus"], CultureInfo.CurrentCulture)
        };

        private void PrintData()
        {
            dynamic row = ExtractRowDataFromContext();
            Console.WriteLine($"{row.Name} ist {row.Alter} Jahre alt und verdient {row.Gehalt:c} bei einem bonus von {row.Bonus / 100:p}");
        }

        [DataSource("System.Data.OleDb", 
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TestData.xlsx;Extended Properties=Excel 12.0 Xml",
                    "TestInput", DataAccessMethod.Sequential)]
        [DeploymentItem("TestData.xlsx")]
        [TestMethod]
        public void XlsxDataSourceTest() => PrintData();
        
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TestData.xml", "TestData", DataAccessMethod.Sequential)]
        [DeploymentItem("TestData.xml")]
        [TestMethod]
        public void XmlDataSourceTest() => PrintData();

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [DeploymentItem("TestData.csv")] // Both .csv and .ini File have to be ANSI or UTF8 without BOM
        [DeploymentItem("schema.ini")]   // Important to define Delimiter ';'
        [TestMethod]
        public void CsvDataSourceTest() => PrintData();
        
        [DataSource("System.Data.OleDb",
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TestData.accdb",
                    "TestData", DataAccessMethod.Sequential )]
        [DeploymentItem("TestData.accdb")]
        [TestMethod]
        public void AccessAccdbFileDataSourceTest() => PrintData();

        [DataSource("System.Data.OleDb",
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TestData.mdb",
                    "TestData", DataAccessMethod.Sequential)]
        [DeploymentItem("TestData.mdb")]
        [TestMethod]
        public void AccessMdbFileDataSourceTest() => PrintData();

        [DataSource("System.Data.SqlClient",
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=XPerimentsTest.TestTests.TestDataContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                    "dbo.TestDatas", DataAccessMethod.Sequential)]
        [TestMethod]
        public void LocalDbDataSourceTest() => PrintData();

        [DataSource("System.Data.SqlServerCe.4.0",
                    "Data Source=TestData.sdf",
                    "TestDatas", DataAccessMethod.Sequential)]
        [DeploymentItem("TestData.sdf")]
        [TestMethod]
        public void SqlServerCeDataSourceTest() => PrintData();

    }
}
