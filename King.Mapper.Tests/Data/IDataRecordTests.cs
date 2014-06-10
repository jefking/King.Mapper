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
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNull()
        {
            IDataRecord item = null;
            item.Get<object>("yippy");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetColumnIvalid()
        {
            var item = Substitute.For<IDataRecord>();
            item.Get<object>(null);
        }

        [TestMethod]
        public void GetGuid()
        {
            var column = "column";
            var data = Guid.NewGuid();
            var item = Substitute.For<IDataRecord>();
            item[column].Returns(data);

            var returned = item.Get<Guid>(column);

            Assert.AreEqual<Guid>(data, returned);

            var x = item.Received(2)[column];
        }

        [TestMethod]
        public void GetGuidByDefault()
        {
            var column = "column";
            var data = Guid.NewGuid();
            var item = Substitute.For<IDataRecord>();
            item[column].Returns(null);

            var returned = item.Get<Guid>(column, data);

            Assert.AreEqual<Guid>(data, returned);

            var x = item.Received(1)[column];
        }
    }
}