namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NSubstitute;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorConnectionNull()
        {
            var sproc = Substitute.For<IStoredProcedure>();
            new Executor(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task NonQuerySprocNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            await e.NonQuery((IStoredProcedure)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task NonQueryCommandNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            await e.NonQuery((SqlCommand)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public async Task NonQueryStatementNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            await e.NonQuery((string)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task QuerySprocNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            await e.Query((IStoredProcedure)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task QueryCommandNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            await e.Query((SqlCommand)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public async Task QueryStatementNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            await e.Query((string)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task DataReader()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            await e.DataReader(null);
        }
    }
}