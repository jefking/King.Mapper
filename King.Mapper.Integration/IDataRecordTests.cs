namespace King.Mapper.Integration
{
    using King.Mapper.Data;
    using King.Mapper.Data.Sql;
    using King.Mapper.Integration.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    [TestClass]
    public class IDataRecordTests
    {
        #region Members
        private readonly string connectionString = ConfigurationManager.AppSettings["database"];
        #endregion

        [TestMethod]
        public async Task Get()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var cmd = sproc.Build(con);
                await con.OpenAsync();

                var reader = await cmd.ExecuteReaderAsync();

                Assert.IsTrue(reader.Read());

                Assert.AreEqual<int>(sproc.TestInt, reader.Get<int>("Identifier"));
                Assert.AreEqual<long>(sproc.TestBigInt, reader.Get<long>("BigInt"));
                Assert.AreEqual<bool>(sproc.TestBit, reader.Get<bool>("Bit"));
                Assert.AreEqual<DateTime>(sproc.TestDate.Date, reader.Get<DateTime>("Date").Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime.Date, reader.Get<DateTime>("DateTime").Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime2.Date, reader.Get<DateTime>("DateTime2").Date);
                Assert.AreEqual<decimal>(sproc.TestDecimal, reader.Get<decimal>("Decimal"));
                Assert.AreEqual<float>(sproc.TestFloat, reader.Get<float>("Float"));
                Assert.AreEqual<decimal>(Math.Round(sproc.TestMoney, 4), reader.Get<decimal>("Money"));
                Assert.AreEqual<char>(sproc.TestNChar, reader.Get<char>("NChar"));
                Assert.AreEqual<string>(sproc.TestNText, reader.Get<string>("NText"));
                Assert.AreEqual<string>(sproc.TestText, reader.Get<string>("Text"));
                Assert.AreEqual<Guid>(sproc.TestGuid, reader.Get<Guid>("Unique"));
                CollectionAssert.AreEqual(sproc.TestBinary, reader.Get<byte[]>("Binary"));
                CollectionAssert.AreEqual(sproc.TestImage, reader.Get<byte[]>("Image"));
            }
        }
    }
}