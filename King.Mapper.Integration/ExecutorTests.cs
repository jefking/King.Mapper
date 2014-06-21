namespace King.Mapper.Integration
{
    using King.Mapper.Data.Sql;
    using King.Mapper.Integration.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    [TestClass]
    public class ExecutorTests
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["database"];

        [TestMethod]
        public async void Insert()
        {
            var random = new Random();
            var con = new SqlConnection(connectionString);
            var sproc = new SimulatedInsertStatement()
            {
                TestInt = random.Next(),
            };

            var executor = new Executor(con);
            var results = await executor.NonQuery(sproc);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void Select()
        {
            var con = new SqlConnection(connectionString);
        }
    }
}