namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using NSubstitute;
    using System;
    using System.Data;

    [TestFixture]
    public class IDataRecordTests
    {
        [Test]
        public void GetNull()
        {
            IDataRecord item = null;
            Assert.That(() => item.Get<object>("yippy"), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void GetColumnIvalid()
        {
            var item = Substitute.For<IDataRecord>();
            Assert.That(() => item.Get<object>(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
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

        [Test]
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