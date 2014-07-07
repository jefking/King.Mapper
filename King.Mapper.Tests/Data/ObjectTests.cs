namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ObjectTests
    {
        [Test]
        public void IsNotNullObjectNull()
        {
            object obj = null;
            Assert.IsFalse(obj.IsNotNull());
        }
        
        [Test]
        public void IsNotNullObjectNotNull()
        {
            var obj = new object();
            Assert.IsTrue(obj.IsNotNull());
        }

        [Test]
        public void IsNotNullObjectDBNull()
        {
            var obj = DBNull.Value;
            Assert.IsFalse(obj.IsNotNull());
        }
    }
}