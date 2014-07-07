namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using NSubstitute;
    using System;
    using System.Data.SqlClient;

    [TestFixture]
    public class IStoredProcedureTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildSprocNull()
        {
            IStoredProcedure sproc = null;
            var connection = new SqlConnection();
            sproc.Build(connection);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildConnectionNull()
        {
            var sproc = Substitute.For<IStoredProcedure>();
            sproc.Build(null);
        }
    }
}