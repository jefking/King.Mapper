namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NSubstitute;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    [TestFixture]
    public class IDataReaderTests
    {
        [Test]
        public void ModelReaderNull()
        {
            IDataReader reader = null;
            Assert.That(() => reader.Model<object>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ModelsReaderNull()
        {
            IDataReader reader = null;
            Assert.That(() => reader.Models<object>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionaryReaderNull()
        {
            IDataReader reader = null;
            Assert.That(() => reader.Dictionary(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionariesReaderNull()
        {
            IDataReader reader = null;
            Assert.That(() => reader.Dictionaries(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DynamicReaderNull()
        {
            IDataReader reader = null;
            Assert.That(() => reader.Dynamic(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DynamicsReaderNull()
        {
            IDataReader reader = null;
            Assert.That(() => reader.Dynamics(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void GetFieldNamesReaderNull()
        {
            IDataReader reader = null;
            Assert.That(() => reader.GetFieldNames(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void GetFieldNames()
        {
            var random = new Random();
            var columns = new List<string>();
            var total = random.Next(25) + 1;
            var reader = Substitute.For<IDataReader>();
            reader.FieldCount.Returns(total);
            for (var i = 0; i < total; i++)
            {
                var column = Guid.NewGuid().ToString();
                columns.Add(column);
                reader.GetName(i).Returns(column);
            }

            var fields = reader.GetFieldNames();

            for (var i = 0; i < total; i++)
            {
                reader.Received().GetName(i);
                Assert.AreEqual(columns[i], fields.ElementAt(i));
            }
        }
    }
}