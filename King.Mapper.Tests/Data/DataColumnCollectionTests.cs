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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToArrayCollectionNull()
        {
            DataColumnCollection col = null;
            col.ToArray();
        }
    }
}