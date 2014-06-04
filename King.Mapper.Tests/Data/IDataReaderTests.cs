namespace King.Mapper.Tests.Data
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data;
    using King.Mapper.Data;

    [TestClass]
    public class IDataReaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectReaderNull()
        {
            IDataReader reader = null;
            reader.LoadObject<object>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectsReaderNull()
        {
            IDataReader reader = null;
            reader.LoadObjects<object>();
        }
    }
}