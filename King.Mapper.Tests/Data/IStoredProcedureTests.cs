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
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildSprocNull()
        {
            IStoredProcedure sproc = null;
            var connection = new SqlConnection();
            sproc.Build(connection);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildConnectionNull()
        {
            var sproc = Substitute.For<IStoredProcedure>();
            sproc.Build(null);
        }
    }
}