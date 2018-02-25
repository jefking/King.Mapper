namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data;

    [TestClass]
    public class DynamicLoaderTests
    {
        [TestMethod]
        public void Constructor()
        {
            new DynamicLoader();
        }

        [TestMethod]
        public void DictionariesIDbCommandNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dictionaries((IDbCommand)null));
        }

        [TestMethod]
        public void DictionaryIDbCommandNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dictionary((IDbCommand)null));
        }

        [TestMethod]
        public void DynamicsIDbCommandNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dynamics((IDbCommand)null));
        }

        [TestMethod]
        public void DynamicIDbCommandNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dynamic((IDbCommand)null));
        }

        [TestMethod]
        public void DictionaryDataTableNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dictionary((DataTable)null));
        }

        [TestMethod]
        public void DictionariesDataTableNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dictionaries((DataTable)null));
        }

        [TestMethod]
        public void DictionaryDataSetNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dictionary((DataSet)null));
        }

        [TestMethod]
        public void DictionariesDataSetNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dictionaries((DataSet)null));
        }

        [TestMethod]
        public void DictionaryIDataReaderNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dictionary((IDataReader)null));
        }

        [TestMethod]
        public void DictionariesIDataReaderNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dictionaries((IDataReader)null));
        }

        [TestMethod]
        public void DynamicDataSetNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dynamic((DataSet)null));
        }

        [TestMethod]
        public void DynamicsDataSetNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dynamics((DataSet)null));
        }

        [TestMethod]
        public void DynamicIDataReaderNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dynamic((IDataReader)null));
        }

        [TestMethod]
        public void DynamicsIDataReaderNull()
        {
            var l = new DynamicLoader();
            Assert.ThrowsException<ArgumentNullException>(() => l.Dynamics((IDataReader)null));
        }
    }
}