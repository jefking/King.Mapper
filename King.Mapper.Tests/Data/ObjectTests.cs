namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ObjectTests
    {
        [TestMethod]
        public void IsNotNullObjectNull()
        {
            object obj = null;
            Assert.IsFalse(obj.IsNotNull());
        }
        
        [TestMethod]
        public void IsNotNullObjectNotNull()
        {
            var obj = new object();
            Assert.IsTrue(obj.IsNotNull());
        }

        [TestMethod]
        public void IsNotNullObjectDBNull()
        {
            var obj = DBNull.Value;
            Assert.IsFalse(obj.IsNotNull());
        }
    }
}