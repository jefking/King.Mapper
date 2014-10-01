namespace King.Mapper.Integration
{
    using King.Mapper.Data;
    using King.Mapper.Generated.Sql;
    using King.Mapper.Integration.Model;
    using NUnit.Framework;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    [TestFixture]
    public class DynamicLoaderTests
    {
        #region Members
        private readonly string connectionString = ConfigurationManager.AppSettings["database"];
        #endregion

        [Test]
        public async Task DataTableDictionary()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var cmd = sproc.Build(con);

                var loader = new DynamicLoader();
                await con.OpenAsync();
                var adapter = new SqlDataAdapter(cmd);

                var ds = new DataSet();
                adapter.Fill(ds);
                var table = ds.Tables[0];
                var obj = loader.Dictionary(table);

                Assert.IsNotNull(obj);
                Assert.AreEqual(sproc.TestInt, obj["Identifier"]);
                Assert.AreEqual(sproc.TestBigInt, obj["BigInt"]);
                Assert.AreEqual(sproc.TestBit, obj["Bit"]);
                Assert.AreEqual(sproc.TestDate.Value.Date, ((DateTime)obj["Date"]).Date);
                Assert.AreEqual(sproc.TestDateTime.Value.Date, ((DateTime)obj["DateTime"]).Date);
                Assert.AreEqual(sproc.TestDateTime2.Value.Date, ((DateTime)obj["DateTime2"]).Date);
                Assert.AreEqual(sproc.TestDecimal, obj["Decimal"]);
                Assert.AreEqual(sproc.TestFloat, obj["Float"]);
                Assert.AreEqual(Math.Round((decimal)sproc.TestMoney, 4), obj["Money"]);
                Assert.AreEqual(sproc.TestNChar, ((string)obj["NChar"])[0]);
                Assert.AreEqual(sproc.TestNText, obj["NText"]);
                Assert.AreEqual(sproc.TestText, obj["Text"]);
                CollectionAssert.AreEqual(sproc.TestBinary, obj["Binary"] as byte[]);
                CollectionAssert.AreEqual(sproc.TestImage, obj["Image"] as byte[]);
                Assert.AreEqual(sproc.TestGuid, obj["Unique"]);
            }
        }

        [Test]
        public async Task DataTableDictionaries()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = new dboSelectMultipleStatement();

                var cmd = sproc.Build(con);

                var loader = new DynamicLoader();
                await con.OpenAsync();
                var adapter = new SqlDataAdapter(cmd);

                var ds = new DataSet();
                adapter.Fill(ds);
                var objs = loader.Dictionaries(ds.Tables[0]);

                Assert.IsNotNull(objs);

                var i = 0;
                foreach (var obj in objs)
                {
                    Assert.AreEqual(i, obj["Identifier"]);
                    i++;
                }
            }
        }
    }
}