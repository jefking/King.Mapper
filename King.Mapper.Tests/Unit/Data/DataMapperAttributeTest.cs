namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using System;
    using System.Data;

    [TestFixture]
    public class DataMapperAttributeTest
    {
        [Test]
        public void ConstructorInvalidParameterName()
        {
            Assert.That(() => new DataMapperAttribute(null, DbType.Binary), Throws.TypeOf<ArgumentException>());
        }

        #region Valid Cases
        [Test]
        public void Constructor()
        {
            new DataMapperAttribute(Guid.NewGuid().ToString(), DbType.Currency);
        }

        [Test]
        public void ParameterName()
        {
            var data = Guid.NewGuid().ToString();
            var mapper = new DataMapperAttribute(data, DbType.DateTimeOffset);
            Assert.AreEqual(data, mapper.ParameterName);
        }

        [Test]
        public void Type()
        {
            var data = DbType.Single;
            var mapper = new DataMapperAttribute(Guid.NewGuid().ToString(), data);
            Assert.AreEqual(data, mapper.DatabaseType);
        }
        #endregion
    }
}
