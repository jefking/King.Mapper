namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ObjectMapTests
    {
        [TestMethod]
        public void MapFromToFromNull()
        {
            object obj = null;
            Assert.ThrowsException<ArgumentNullException>(() => obj.Map<object>(new Object()));
        }

        [TestMethod]
        public void MapFromToToNull()
        {
            var obj = new object();
            Assert.ThrowsException<ArgumentNullException>(() => obj.Map<object>(null));
        }

        [TestMethod]
        public void MapFromFromNull()
        {
            object obj = null;
            Assert.ThrowsException<ArgumentNullException>(() => obj.Map<object>());
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void MapNullObjectToString()
        {
            var item = new MappingObjectTester();

            var data = item.Map<MappingStringTester>();

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }

        [TestMethod]
        public void MapNullStringToObject()
        {
            var item = new MappingStringTester();

            var data = item.Map<MappingObjectTester>();

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }
    }
}