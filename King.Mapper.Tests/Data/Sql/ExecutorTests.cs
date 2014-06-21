namespace King.Mapper.Tests.Data.Sql
{
    using King.Mapper.Data.Sql;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using System;
    using System.Data.SqlClient;
    
    [TestClass]
    public class ExecutorTests
    {
        [TestMethod]
        public void Constructor()
        {
            var connection = new SqlConnection();
            var sproc = Substitute.For<IStoredProcedure>();
            new Executor(connection, sproc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorConnectionNull()
        {
            var sproc = Substitute.For<IStoredProcedure>();
            new Executor(null, sproc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorSprocNull()
        {
            var connection = new SqlConnection();
            new Executor(connection, null);
        }
    }
}