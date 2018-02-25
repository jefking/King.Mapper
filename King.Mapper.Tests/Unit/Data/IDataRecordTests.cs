namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using System;
    using System.Data;

    [TestClass]
    public class IDataRecordTests
    {
        [TestMethod]
        public void GetNull()
        {
            IDataRecord item = null;
            Assert.ThrowsException<ArgumentNullException>(() => item.Get<object>("yippy"));
        }

        [TestMethod]
        public void GetColumnIvalid()
        {
            var item = Substitute.For<IDataRecord>();
            Assert.ThrowsException<ArgumentException>(() => item.Get<object>(null));
        }

        [TestMethod]
        public void GetGuid()
        {
            var column = "column";
            var data = Guid.NewGuid();
            var item = Substitute.For<IDataRecord>();
            item[column].Returns(data);

            var returned = item.Get<Guid>(column);

            Assert.AreEqual(data, returned);

            var x = item.Received(3)[column];
        }

        [TestMethod]
        public void GetGuidByDefault()
        {
            var column = "column";
            var data = Guid.NewGuid();
            var item = Substitute.For<IDataRecord>();
            item[column].Returns(null);

            var returned = item.Get<Guid>(column, data);

            Assert.AreEqual(data, returned);

            var x = item.Received(1)[column];
        }
    }
}