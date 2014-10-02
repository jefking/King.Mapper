namespace King.Mapper.Tests.Data
{
    using System;
    using System.Data;
    using King.Mapper.Data;
    using NUnit.Framework;

    [TestFixture]
    public class LoaderTests
    {
        [Test]
        public void Constructor()
        {
            new Loader<object>();
        }

        [Test]
        public void IsILoader()
        {
            Assert.IsNotNull(new Loader<object>() as ILoader<object>);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsIDbCommandNull()
        {
            var l = new Loader<object>();
            l.Models((IDbCommand)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelIDbCommandNull()
        {
            var l = new Loader<object>();
            l.Model((IDbCommand)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsIDataReaderNull()
        {
            var l = new Loader<object>();
            l.Models((IDataReader)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelIDataReaderNull()
        {
            var l = new Loader<object>();
            l.Model((IDataReader)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelDataSetNull()
        {
            var l = new Loader<object>();
            l.Model((DataSet)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelDataTableNull()
        {
            var l = new Loader<object>();
            l.Model((DataTable)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsDataSetNull()
        {
            var l = new Loader<object>();
            l.Models((DataSet)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsDataTableNull()
        {
            var l = new Loader<object>();
            l.Models((DataTable)null);
        }
    }
}