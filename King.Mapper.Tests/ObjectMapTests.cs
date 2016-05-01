namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ObjectMapTests
    {
        [Test]
        public void MapFromToFromNull()
        {
            object obj = null;
            Assert.That(() => obj.Map<object>(new Object()), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void MapFromToToNull()
        {
            var obj = new object();
            Assert.That(() => obj.Map<object>(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void MapFromFromNull()
        {
            object obj = null;
            Assert.That(() => obj.Map<object>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void MapFromTo()
        {
            var item = new MappingTester()
            {
                Temp = Guid.NewGuid(),
            };

            var data = item.Map<MappingTester>(new MappingTester());
            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }

        [Test]
        public void MapFrom()
        {
            var item = new MappingTester()
            {
                Temp = Guid.NewGuid(),
            };

            var data = item.Map<MappingTester>();

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }

        [Test]
        public void MapString()
        {
            var item = new MappingStringTester()
            {
                Temp = Guid.NewGuid().ToString(),
            };

            var data = item.Map<MappingStringTester>();

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }

        [Test]
        public void MapObject()
        {
            var item = new MappingObjectTester()
            {
                Temp = this,
            };

            var data = item.Map<MappingObjectTester>();

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }

        [Test]
        public void MapStringToObject()
        {
            var item = new MappingStringTester()
            {
                Temp = Guid.NewGuid().ToString(),
            };

            var data = item.Map<MappingObjectTester>();

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }

        [Test]
        public void MapNullObjectToString()
        {
            var item = new MappingObjectTester();

            var data = item.Map<MappingStringTester>();

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }

        [Test]
        public void MapNullStringToObject()
        {
            var item = new MappingStringTester();

            var data = item.Map<MappingObjectTester>();

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }
    }
}