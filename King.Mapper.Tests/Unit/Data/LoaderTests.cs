namespace King.Mapper.Tests.Data
{
    using System;
    using System.Data;
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoaderTests
    {
        [TestMethod]
        public void Constructor()
        {
            new Loader<object>();
        }

        [TestMethod]
        public void IsILoader()
        {
            Assert.IsNotNull(new Loader<object>() as ILoader<object>);
        }

        [TestMethod]
        public void ModelsIDbCommandNull()
        {
            var l = new Loader<object>();
            Assert.ThrowsException<ArgumentNullException>(() => l.Models((IDbCommand)null));
        }

        [TestMethod]
        public void ModelIDbCommandNull()
        {
            var l = new Loader<object>();
            Assert.ThrowsException<ArgumentNullException>(() => l.Model((IDbCommand)null));
        }

        [TestMethod]
        public void ModelsIDataReaderNull()
        {
            var l = new Loader<object>();
            Assert.ThrowsException<ArgumentNullException>(() => l.Models((IDataReader)null));
        }

        [TestMethod]
        public void ModelIDataReaderNull()
        {
            var l = new Loader<object>();
            Assert.ThrowsException<ArgumentNullException>(() => l.Model((IDataReader)null));
        }

        [TestMethod]
        public void ModelDataSetNull()
        {
            var l = new Loader<object>();
            Assert.ThrowsException<ArgumentNullException>(() => l.Model((DataSet)null));
        }

        [TestMethod]
        public void ModelDataTableNull()
        {
            var l = new Loader<object>();
            Assert.ThrowsException<ArgumentNullException>(() => l.Model((DataTable)null));
        }

        [TestMethod]
        public void ModelsDataSetNull()
        {
            var l = new Loader<object>();
            Assert.ThrowsException<ArgumentNullException>(() => l.Models((DataSet)null));
        }

        [TestMethod]
        public void ModelsDataTableNull()
        {
            var l = new Loader<object>();
            Assert.ThrowsException<ArgumentNullException>(() => l.Models((DataTable)null));
        }
    }
}