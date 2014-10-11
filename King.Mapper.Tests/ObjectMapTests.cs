namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ObjectMapTests
    {
        #region Error Cases
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapFromToFromNull()
        {
            object obj = null;
            obj.Map<object>(new Object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapFromToToNull()
        {
            var obj = new object();
            obj.Map<object>(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapFromFromNull()
        {
            object obj = null;
            obj.Map<object>();
        }
        #endregion

        #region Valid Cases
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
        #endregion
    }
}
