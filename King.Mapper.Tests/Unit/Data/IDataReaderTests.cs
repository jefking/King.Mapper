namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NSubstitute;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    [TestClass]
    public class IDataReaderTests
    {
        [TestMethod]
        public void ModelReaderNull()
        {
            IDataReader reader = null;
            Assert.ThrowsException<ArgumentNullException>(() => reader.Model<object>());
        }

        [TestMethod]
        public void ModelsReaderNull()
        {
            IDataReader reader = null;
            Assert.ThrowsException<ArgumentNullException>(() => reader.Models<object>());
        }

        [TestMethod]
        public void DictionaryReaderNull()
        {
            IDataReader reader = null;
            Assert.ThrowsException<ArgumentNullException>(() => reader.Dictionary());
        }

        [TestMethod]
        public void DictionariesReaderNull()
        {
            IDataReader reader = null;
            Assert.ThrowsException<ArgumentNullException>(() => reader.Dictionaries());
        }

        [TestMethod]
        public void DynamicReaderNull()
        {
            IDataReader reader = null;
            Assert.ThrowsException<ArgumentNullException>(() => reader.Dynamic());
        }

        [TestMethod]
        public void DynamicsReaderNull()
        {
            IDataReader reader = null;
            Assert.ThrowsException<ArgumentNullException>(() => reader.Dynamics());
        }

        [TestMethod]
        public void GetFieldNamesReaderNull()
        {
            IDataReader reader = null;
            Assert.ThrowsException<ArgumentNullException>(() => reader.GetFieldNames());
        }

        [TestMethod]
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