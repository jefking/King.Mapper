namespace King.Mapper.Integration
{
    using King.Mapper.Data;
    using King.Mapper.Data.Sql;
    using King.Mapper.Integration.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    [TestClass]
    public class LoaderTests
    {
        #region Members
        private readonly string connectionString = ConfigurationManager.AppSettings["database"];
        #endregion

        [TestMethod]
        public async Task ReaderLoadObject()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var cmd = sproc.Build(con);
                await con.OpenAsync();

                var reader = await cmd.ExecuteReaderAsync();

                Assert.IsTrue(reader.Read());

                var loader = new Loader<SelectData>();
                var obj = loader.LoadObject(reader);

                Assert.IsNotNull(obj);
                Assert.AreEqual<int>(sproc.TestInt, obj.Identifier);
                Assert.AreEqual<long>(sproc.TestBigInt, obj.BigInt);
                Assert.AreEqual<bool>(sproc.TestBit, obj.Bit);
                Assert.AreEqual<DateTime>(sproc.TestDate.Date, obj.Date.Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime.Date, obj.DateTime.Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime2.Date, obj.DateTime2.Date);
                Assert.AreEqual<decimal>(sproc.TestDecimal, obj.Decimal);
                Assert.AreEqual<float>(sproc.TestFloat, obj.Float);
                Assert.AreEqual<decimal>(Math.Round(sproc.TestMoney, 4), obj.Money);
                Assert.AreEqual<char>(sproc.TestNChar, obj.NChar);
                Assert.AreEqual<string>(sproc.TestNText, obj.NText);
                Assert.AreEqual<string>(sproc.TestText, obj.Text);
                CollectionAssert.AreEqual(sproc.TestBinary, obj.Binary);
                CollectionAssert.AreEqual(sproc.TestImage, obj.Image);
                Assert.AreEqual<Guid>(sproc.TestGuid, obj.Unique);
            }
        }

        [TestMethod]
        public async Task ReaderLoadObjects()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = new SelectMultipleStatement();

                var cmd = sproc.Build(con);
                await con.OpenAsync();

                var reader = await cmd.ExecuteReaderAsync();

                var loader = new Loader<SelectData>();
                var objs = loader.LoadObjects(reader);

                Assert.IsNotNull(objs);

                for (var i = 0; i <= 5; i++)
                {
                    Assert.AreEqual<int>(i, objs[i].Identifier);
                }
            }
        }

        [TestMethod]
        public async Task IDbCommandLoadObject()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var cmd = sproc.Build(con);

                var loader = new Loader<SelectData>();
                await con.OpenAsync();

                var obj = loader.LoadObject(cmd);

                Assert.IsNotNull(obj);
                Assert.AreEqual<int>(sproc.TestInt, obj.Identifier);
                Assert.AreEqual<long>(sproc.TestBigInt, obj.BigInt);
                Assert.AreEqual<bool>(sproc.TestBit, obj.Bit);
                Assert.AreEqual<DateTime>(sproc.TestDate.Date, obj.Date.Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime.Date, obj.DateTime.Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime2.Date, obj.DateTime2.Date);
                Assert.AreEqual<decimal>(sproc.TestDecimal, obj.Decimal);
                Assert.AreEqual<float>(sproc.TestFloat, obj.Float);
                Assert.AreEqual<decimal>(Math.Round(sproc.TestMoney, 4), obj.Money);
                Assert.AreEqual<char>(sproc.TestNChar, obj.NChar);
                Assert.AreEqual<string>(sproc.TestNText, obj.NText);
                Assert.AreEqual<string>(sproc.TestText, obj.Text);
                CollectionAssert.AreEqual(sproc.TestBinary, obj.Binary);
                CollectionAssert.AreEqual(sproc.TestImage, obj.Image);
                Assert.AreEqual<Guid>(sproc.TestGuid, obj.Unique);
            }
        }

        [TestMethod]
        public async Task IDbCommandLoadNothing()
        {
            var random = new Random();
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = new SimulatedInsertStatement()
                {
                    TestInt = random.Next(),
                };

                var cmd = sproc.Build(con);

                var loader = new Loader<SelectData>();
                await con.OpenAsync();

                var obj = loader.LoadObject(cmd);

                Assert.IsNull(obj);
            }
        }

        [TestMethod]
        public async Task IDbCommandLoadObjects()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = new SelectMultipleStatement();

                var cmd = sproc.Build(con);

                var loader = new Loader<SelectData>();
                await con.OpenAsync();

                var objs = loader.LoadObjects(cmd);

                Assert.IsNotNull(objs);

                for (var i = 0; i <= 5; i++)
                {
                    Assert.AreEqual<int>(i, objs[i].Identifier);
                }
            }
        }

        [TestMethod]
        public async Task DataTableLoadObject()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var cmd = sproc.Build(con);

                var loader = new Loader<SelectData>();
                await con.OpenAsync();
                var adapter = new SqlDataAdapter(cmd);

                var ds = new DataSet();
                adapter.Fill(ds);
                var table = ds.Tables[0];
                var obj = loader.LoadObject(table);

                Assert.IsNotNull(obj);
                Assert.AreEqual<int>(sproc.TestInt, obj.Identifier);
                Assert.AreEqual<long>(sproc.TestBigInt, obj.BigInt);
                Assert.AreEqual<bool>(sproc.TestBit, obj.Bit);
                Assert.AreEqual<DateTime>(sproc.TestDate.Date, obj.Date.Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime.Date, obj.DateTime.Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime2.Date, obj.DateTime2.Date);
                Assert.AreEqual<decimal>(sproc.TestDecimal, obj.Decimal);
                Assert.AreEqual<float>(sproc.TestFloat, obj.Float);
                Assert.AreEqual<decimal>(Math.Round(sproc.TestMoney, 4), obj.Money);
                Assert.AreEqual<char>(sproc.TestNChar, obj.NChar);
                Assert.AreEqual<string>(sproc.TestNText, obj.NText);
                Assert.AreEqual<string>(sproc.TestText, obj.Text);
                CollectionAssert.AreEqual(sproc.TestBinary, obj.Binary);
                CollectionAssert.AreEqual(sproc.TestImage, obj.Image);
                Assert.AreEqual<Guid>(sproc.TestGuid, obj.Unique);
            }
        }

        [TestMethod]
        public async Task DataTableLoadObjects()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = new SelectMultipleStatement();

                var cmd = sproc.Build(con);

                var loader = new Loader<SelectData>();
                await con.OpenAsync();
                var adapter = new SqlDataAdapter(cmd);

                var ds = new DataSet();
                adapter.Fill(ds);
                var table = ds.Tables[0];
                var objs = loader.LoadObjects(table);

                Assert.IsNotNull(objs);

                for (var i = 0; i <= 5; i++)
                {
                    Assert.AreEqual<int>(i, objs[i].Identifier);
                }
            }
        }

        [TestMethod]
        public async Task DataSetLoadObject()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var cmd = sproc.Build(con);

                var loader = new Loader<SelectData>();
                await con.OpenAsync();
                var adapter = new SqlDataAdapter(cmd);

                var ds = new DataSet();
                adapter.Fill(ds);
                var obj = loader.LoadObject(ds);

                Assert.IsNotNull(obj);
                Assert.AreEqual<int>(sproc.TestInt, obj.Identifier);
                Assert.AreEqual<long>(sproc.TestBigInt, obj.BigInt);
                Assert.AreEqual<bool>(sproc.TestBit, obj.Bit);
                Assert.AreEqual<DateTime>(sproc.TestDate.Date, obj.Date.Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime.Date, obj.DateTime.Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime2.Date, obj.DateTime2.Date);
                Assert.AreEqual<decimal>(sproc.TestDecimal, obj.Decimal);
                Assert.AreEqual<float>(sproc.TestFloat, obj.Float);
                Assert.AreEqual<decimal>(Math.Round(sproc.TestMoney, 4), obj.Money);
                Assert.AreEqual<char>(sproc.TestNChar, obj.NChar);
                Assert.AreEqual<string>(sproc.TestNText, obj.NText);
                Assert.AreEqual<string>(sproc.TestText, obj.Text);
                CollectionAssert.AreEqual(sproc.TestBinary, obj.Binary);
                CollectionAssert.AreEqual(sproc.TestImage, obj.Image);
                Assert.AreEqual<Guid>(sproc.TestGuid, obj.Unique);
            }
        }

        [TestMethod]
        public async Task DataSetLoadObjects()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = new SelectMultipleStatement();

                var cmd = sproc.Build(con);

                var loader = new Loader<SelectData>();
                await con.OpenAsync();
                var adapter = new SqlDataAdapter(cmd);

                var ds = new DataSet();
                adapter.Fill(ds);
                var objs = loader.LoadObjects(ds);

                Assert.IsNotNull(objs);

                for (var i = 0; i <= 5; i++)
                {
                    Assert.AreEqual<int>(i, objs[i].Identifier);
                }
            }
        }
    }
}