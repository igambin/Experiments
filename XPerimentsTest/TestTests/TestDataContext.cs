using System.ComponentModel.DataAnnotations;

namespace XPerimentsTest.TestTests
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TestDataContext : DbContext
    {
        // Your context has been configured to use a 'TestDataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'XPerimentsTest.TestTests.TestDataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TestDataContext' 
        // connection string in the application configuration file.
        public TestDataContext()
            : base("name=TestDataContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<TestData> TestDatas { get; set; }
    }

    public class TestData
    {
        [Key]
        public string Name { get; set; }
        public int Alter { get; set; }
        public int Gehalt { get; set; }
        public decimal Bonus { get; set; }
    }
}