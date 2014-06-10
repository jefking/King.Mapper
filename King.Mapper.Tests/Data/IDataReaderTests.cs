namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data;

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFieldNamesReaderNull()
        {
            IDataReader reader = null;
            reader.GetFieldNames();
        }
    }
}