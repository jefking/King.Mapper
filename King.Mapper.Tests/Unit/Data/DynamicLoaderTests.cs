namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using System;
    using System.Data;

    [TestFixture]
    public class DynamicLoaderTests
    {
        [Test]
        public void Constructor()
        {
            new DynamicLoader();
        }

        [Test]
        public void DictionariesIDbCommandNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dictionaries((IDbCommand)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionaryIDbCommandNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dictionary((IDbCommand)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DynamicsIDbCommandNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dynamics((IDbCommand)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DynamicIDbCommandNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dynamic((IDbCommand)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionaryDataTableNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dictionary((DataTable)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionariesDataTableNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dictionaries((DataTable)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionaryDataSetNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dictionary((DataSet)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionariesDataSetNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dictionaries((DataSet)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionaryIDataReaderNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dictionary((IDataReader)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionariesIDataReaderNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dictionaries((IDataReader)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DynamicDataSetNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dynamic((DataSet)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DynamicsDataSetNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dynamics((DataSet)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DynamicIDataReaderNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dynamic((IDataReader)null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DynamicsIDataReaderNull()
        {
            var l = new DynamicLoader();
            Assert.That(() => l.Dynamics((IDataReader)null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}