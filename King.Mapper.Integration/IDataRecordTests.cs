namespace King.Mapper.Integration
{
    using King.Mapper.Data;
    using King.Mapper.Integration.Model;
    using NUnit.Framework;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    [TestFixture]
    public class IDataRecordTests
    {
        #region Members
        private readonly string connectionString = ConfigurationManager.AppSettings["database"];
        #endregion

        [Test]
        public async Task Get()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var cmd = sproc.Build(con);
                await con.OpenAsync();

                var reader = await cmd.ExecuteReaderAsync();

                Assert.IsTrue(reader.Read());

                Assert.AreEqual(sproc.TestInt, reader.Get<int>("Identifier"));
                Assert.AreEqual(sproc.TestBigInt, reader.Get<long>("BigInt"));
                Assert.AreEqual(sproc.TestBit, reader.Get<bool>("Bit"));
                Assert.AreEqual(sproc.TestDate.Value.Date, reader.Get<DateTime>("Date").Date);
                Assert.AreEqual(sproc.TestDateTime.Value.Date, reader.Get<DateTime>("DateTime").Date);
                Assert.AreEqual(sproc.TestDateTime2.Value.Date, reader.Get<DateTime>("DateTime2").Date);
                Assert.AreEqual(sproc.TestDecimal, reader.Get<decimal>("Decimal"));
                Assert.AreEqual(sproc.TestFloat, reader.Get<float>("Float"));
                Assert.AreEqual(Math.Round((decimal)sproc.TestMoney, 4), reader.Get<decimal>("Money"));
                Assert.AreEqual(sproc.TestNChar, reader.Get<char>("NChar"));
                Assert.AreEqual(sproc.TestNText, reader.Get<string>("NText"));
                Assert.AreEqual(sproc.TestText, reader.Get<string>("Text"));
                Assert.AreEqual(sproc.TestGuid, reader.Get<Guid>("Unique"));
                CollectionAssert.AreEqual(sproc.TestBinary, reader.Get<byte[]>("Binary"));
                CollectionAssert.AreEqual(sproc.TestImage, reader.Get<byte[]>("Image"));
            }
        }
    }
}