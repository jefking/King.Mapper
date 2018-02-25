namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data;

    [TestClass]
    public class DataColumnCollectionTests
    {
        [TestMethod]
        public void ToArrayCollectionNull()
        {
            DataColumnCollection col = null;
            Assert.ThrowsException<ArgumentNullException>(() => col.ToArray());
        }
    }
}