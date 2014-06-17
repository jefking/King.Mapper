namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data;

    [TestClass]
    public class DataMapperAttributeTest
    {
        #region Valid Cases
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorInvalidParameterName()
        {
            new DataMapperAttribute(null, DbType.Binary);
        }
        #endregion

        #region Valid Cases
        [TestMethod]
        public void Constructor()
        {
            new DataMapperAttribute(Guid.NewGuid().ToString(), DbType.Currency);
        }

        [TestMethod]
        public void ParameterName()
        {
            var data = Guid.NewGuid().ToString();
            var mapper = new DataMapperAttribute(data, DbType.DateTimeOffset);
            Assert.AreEqual<string>(data, mapper.ParameterName);
        }

        [TestMethod]
        public void Type()
        {
            var data = DbType.Single;
            var mapper = new DataMapperAttribute(Guid.NewGuid().ToString(), data);
            Assert.AreEqual<DbType>(data, mapper.DatabaseType);
        }
        #endregion
    }
}
