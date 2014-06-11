namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    [TestClass]
    public class IDataReaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectReaderNull()
        {
            IDataReader reader = null;
            reader.LoadObject<object>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectsReaderNull()
        {
            IDataReader reader = null;
            reader.LoadObjects<object>();
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