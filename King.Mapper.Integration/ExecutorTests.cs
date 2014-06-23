namespace King.Mapper.Integration
{
    using King.Mapper.Data;
    using King.Mapper.Integration.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    [TestClass]
    public class ExecutorTests
    {
        #region Members
        private readonly string connectionString = ConfigurationManager.AppSettings["database"];
        #endregion

        [TestMethod]
        public async Task Insert()
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
        public async Task Select()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var executor = new Executor(con);
                var data = await executor.Query(sproc);

                Assert.IsNotNull(data);

                var obj = data.Model<SelectData>();

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
    }
}