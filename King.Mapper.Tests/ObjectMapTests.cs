namespace King.Mapper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectMapTests
    {
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
    }
}
