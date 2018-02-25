namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using System;
    using System.Data.SqlClient;

    [TestClass]
    public class IStoredProcedureTests
    {
        [TestMethod]
        public void BuildSprocNull()
        {
            IStoredProcedure sproc = null;
            var connection = new SqlConnection();
            Assert.ThrowsException<ArgumentNullException>(() => sproc.Build(connection));
        }

        [TestMethod]
        public void BuildConnectionNull()
        {
            var sproc = Substitute.For<IStoredProcedure>();
            Assert.ThrowsException<ArgumentNullException>(() => sproc.Build(null));
        }
    }
}