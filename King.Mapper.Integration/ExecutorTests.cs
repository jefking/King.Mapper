namespace King.Mapper.Integration
{
    using King.Mapper.Data;
    using King.Mapper.Data.Sql;
    using King.Mapper.Integration.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    [TestClass]
    public class ExecutorTests
    {
        #region Members
        private readonly string connectionString = ConfigurationManager.AppSettings["database"];
        #endregion

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
        public async void Select()
        {
            var random = new Random();
            var con = new SqlConnection(connectionString);
            var sproc = new SimulatedSelectStatement()
            {
                TestInt = random.Next(),
            };

            var executor = new Executor(con);
            var data = await executor.Execute(sproc);

            Assert.IsNotNull(data);

            var obj = data.LoadObject<SelectData>();

            Assert.IsNotNull(obj);
            Assert.AreEqual(sproc.TestInt, obj.Identifier);
        }
    }
}