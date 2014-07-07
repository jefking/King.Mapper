namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using NSubstitute;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ExecuteSprocNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            await e.Query((IStoredProcedure)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ExecuteCommandNull()
        {
            var connection = new SqlConnection();
            var e = new Executor(connection);
            await e.Query((SqlCommand)null);
        }
    }
}