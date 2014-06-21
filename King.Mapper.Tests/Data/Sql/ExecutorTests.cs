namespace King.Mapper.Tests.Data.Sql
{
    using King.Mapper.Data.Sql;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using System.Data.SqlClient;
    
    [TestClass]
    public class ExecutorTests
    {
        [TestMethod]
        public void Constructor()
        {
            var connection = Substitute.For<SqlConnection>();
            var sproc = Substitute.For<IStoredProcedure>();
            new Executor(connection, sproc);
        }
    }
}