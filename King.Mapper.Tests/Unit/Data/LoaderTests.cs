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
        public void ModelsIDbCommandNull()
        {
            var l = new Loader<object>();
            Assert.That(() => l.Models((IDbCommand)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ModelIDbCommandNull()
        {
            var l = new Loader<object>();
            Assert.That(() => l.Model((IDbCommand)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ModelsIDataReaderNull()
        {
            var l = new Loader<object>();
            Assert.That(() => l.Models((IDataReader)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ModelIDataReaderNull()
        {
            var l = new Loader<object>();
            Assert.That(() => l.Model((IDataReader)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ModelDataSetNull()
        {
            var l = new Loader<object>();
            Assert.That(() => l.Model((DataSet)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ModelDataTableNull()
        {
            var l = new Loader<object>();
            Assert.That(() => l.Model((DataTable)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ModelsDataSetNull()
        {
            var l = new Loader<object>();
            Assert.That(() => l.Models((DataSet)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ModelsDataTableNull()
        {
            var l = new Loader<object>();
            Assert.That(() => l.Models((DataTable)null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}