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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsIDbCommandNull()
        {
            var l = new Loader<object>();
            l.Models((IDbCommand)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsIDataReaderNull()
        {
            var l = new Loader<object>();
            l.Models((IDataReader)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelIDbCommandNull()
        {
            var l = new Loader<object>();
            l.Model((IDbCommand)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelIDataReaderNull()
        {
            var l = new Loader<object>();
            l.Model((IDataReader)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelDataSetNull()
        {
            var l = new Loader<object>();
            l.Model((DataSet)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelDataTableNull()
        {
            var l = new Loader<object>();
            l.Model((DataTable)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsDataSetNull()
        {
            var l = new Loader<object>();
            l.Models((DataSet)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsDataTableNull()
        {
            var l = new Loader<object>();
            l.Models((DataTable)null);
        }
    }
}