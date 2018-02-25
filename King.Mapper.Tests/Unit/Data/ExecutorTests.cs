namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
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
            new Executor(connection);
        }

        [TestMethod]
        public void IsIExecutor()
        {
            var connection = new SqlConnection();
            Assert.IsNotNull(new Executor(connection) as IExecutor);
        }

        [TestMethod]
        public void ConstructorConnectionNull()
        {
            var sproc = Substitute.For<IStoredProcedure>();
            Assert.ThrowsException<ArgumentNullException>(() => new Executor(null));
        }

        [TestMethod]
        public void NonQuerySprocNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await e.NonQuery((IStoredProcedure)null));
        }

        [TestMethod]
        public void NonQueryCommandNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await e.NonQuery((SqlCommand)null));
        }

        [TestMethod]
        public void NonQueryStatementNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await e.NonQuery((string)null));
        }

        [TestMethod]
        public void QuerySprocNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await e.Query((IStoredProcedure)null));
        }

        [TestMethod]
        public void QueryCommandNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await e.Query((SqlCommand)null));
        }

        [TestMethod]
        public void QueryStatementNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await e.Query((string)null));
        }

        [TestMethod]
        public void DataReader()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await e.DataReader(null));
        }
    }
}