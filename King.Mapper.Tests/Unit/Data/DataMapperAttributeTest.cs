namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data;

    [TestClass]
    public class DataMapperAttributeTest
    {
        [TestMethod]
        public void ConstructorInvalidParameterName()
        {
            Assert.ThrowsException<ArgumentException>(() => new DataMapperAttribute(null, DbType.Binary));
        }

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
            Assert.AreEqual(data, mapper.ParameterName);
        }

        [TestMethod]
        public void Type()
        {
            var data = DbType.Single;
            var mapper = new DataMapperAttribute(Guid.NewGuid().ToString(), data);
            Assert.AreEqual(data, mapper.DatabaseType);
        }
        #endregion
    }
}
