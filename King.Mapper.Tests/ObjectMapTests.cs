namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ObjectMapTests
    {
        #region Error Cases
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapFromToFromNull()
        {
            object obj = null;
            obj.Map<object>(new Object());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapFromToToNull()
        {
            var obj = new object();
            obj.Map<object>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapFromFromNull()
        {
            object obj = null;
            obj.Map<object>();
        }
        #endregion

        #region Valid Cases
        [TestMethod]
        public void MapFromTo()
        {
            var item = new MappingTester()
            {
                Temp = Guid.NewGuid(),
            };

            var data = item.Map<MappingTester>(new MappingTester());
            Assert.IsNotNull(data);
            Assert.AreEqual<Guid>(item.Temp, data.Temp);
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
            Assert.AreEqual<Guid>(item.Temp, data.Temp);
        }
        #endregion
    }
}
