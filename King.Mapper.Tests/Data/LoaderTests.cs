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
        public void LoadObjectsIDbCommandNull()
        {
            var l = new Loader<object>();
            l.LoadObjects((IDbCommand)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectsIDataReaderNull()
        {
            var l = new Loader<object>();
            l.LoadObjects((IDataReader)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectIDbCommandNull()
        {
            var l = new Loader<object>();
            l.LoadObject((IDbCommand)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectIDataReaderNull()
        {
            var l = new Loader<object>();
            l.LoadObject((IDataReader)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectDataSetNull()
        {
            var l = new Loader<object>();
            l.LoadObject((DataSet)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectDataTableNull()
        {
            var l = new Loader<object>();
            l.LoadObject((DataTable)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectsDataSetNull()
        {
            var l = new Loader<object>();
            l.LoadObjects((DataSet)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectsDataTableNull()
        {
            var l = new Loader<object>();
            l.LoadObjects((DataTable)null);
        }
    }
}