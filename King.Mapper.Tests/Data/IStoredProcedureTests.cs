namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    //using NSubstitute;
    using System;
    using System.Data.SqlClient;

    [TestFixture]
    public class IStoredProcedureTests
    {
        [Test]
        public void BuildSprocNull()
        {
            IStoredProcedure sproc = null;
            var connection = new SqlConnection();
            Assert.That(() => sproc.Build(connection), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void BuildConnectionNull()
        {
            //var sproc = Substitute.For<IStoredProcedure>();
            //Assert.That(() => sproc.Build(null), Throws.TypeOf<ArgumentNullException>());
            Assert.Inconclusive();
        }
    }
}