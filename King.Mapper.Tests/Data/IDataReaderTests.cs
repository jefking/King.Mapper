namespace King.Mapper.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;

    [TestClass]
    public class IDataReaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelReaderNull()
        {
            IDataReader reader = null;
            reader.Model<object>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsReaderNull()
        {
            IDataReader reader = null;
            reader.Models<object>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFieldNamesReaderNull()
        {
            IDataReader reader = null;
            reader.GetFieldNames();
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
                Assert.AreEqual(columns[i], fields[i]);
            }
        }
    }
}