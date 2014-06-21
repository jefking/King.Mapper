namespace King.Mapper.Integration
{
    using King.Mapper.Data;
    using King.Mapper.Data.Sql;
    using King.Mapper.Integration.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    [TestClass]
    public class ExecutorTests
    {
        #region Members
        private readonly string connectionString = ConfigurationManager.AppSettings["database"];
        #endregion

        [TestMethod]
        public async void Insert()
        {
            var random = new Random();
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = new SimulatedInsertStatement()
                {
                    TestInt = random.Next(),
                };

                var executor = new Executor(con);
                var results = await executor.NonQuery(sproc);

                Assert.AreEqual(1, results);
            }
        }

        [TestMethod]
        public async void Select()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var executor = new Executor(con);
                var data = await executor.Execute(sproc);

                Assert.IsNotNull(data);

                var obj = data.LoadObject<SelectData>();

                Assert.IsNotNull(obj);
                Assert.AreEqual<int>(sproc.TestInt, obj.Identifier);
                Assert.AreEqual<long>(sproc.TestBigInt, obj.BigInt);
                Assert.AreEqual<bool>(sproc.TestBit, obj.Bit);
                Assert.AreEqual<DateTime>(sproc.TestDate.Date, obj.Date.Date);
                Assert.AreEqual<DateTime>(sproc.TestDateTime, obj.DateTime);
                Assert.AreEqual<DateTime>(sproc.TestDateTime2, obj.DateTime2);
                Assert.AreEqual<decimal>(sproc.TestDecimal, obj.Decimal);
                Assert.AreEqual<float>(sproc.TestFloat, obj.Float);
                Assert.AreEqual<decimal>(sproc.TestMoney, obj.Money);
                Assert.AreEqual<char>(sproc.TestNChar, obj.NChar);
                Assert.AreEqual<string>(sproc.TestNText, obj.NText);
                Assert.AreEqual<string>(sproc.TestText, obj.Text);
                Assert.AreEqual<byte[]>(sproc.TestBinary, obj.Binary);
                Assert.AreEqual<byte[]>(sproc.TestImage, obj.Image);
                Assert.AreEqual<Guid>(sproc.TestGuid, obj.Unique);
            }
        }
    }
}