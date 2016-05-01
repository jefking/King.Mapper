namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    //using NSubstitute;
    using NUnit.Framework;
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    
    [TestFixture]
    public class ExecutorTests
    {
        [Test]
        public void Constructor()
        {
            var connection = new SqlConnection();
            new Executor(connection);
        }

        [Test]
        public void IsIExecutor()
        {
            var connection = new SqlConnection();
            Assert.IsNotNull(new Executor(connection) as IExecutor);
        }

        [Test]
        public void ConstructorConnectionNull()
        {
            //var sproc = Substitute.For<IStoredProcedure>();
            //Assert.That(() => new Executor(null), Throws.TypeOf<ArgumentNullException>());
            Assert.Inconclusive();
        }

        [Test]
        public void NonQuerySprocNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.That(async () => await e.NonQuery((IStoredProcedure)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void NonQueryCommandNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.That(async () => await e.NonQuery((SqlCommand)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void NonQueryStatementNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.That(async () => await e.NonQuery((string)null), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void QuerySprocNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.That(async () => await e.Query((IStoredProcedure)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void QueryCommandNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.That(async () => await e.Query((SqlCommand)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void QueryStatementNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.That(async () => await e.Query((string)null), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void DataReader()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            Assert.That(async () => await e.DataReader(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}