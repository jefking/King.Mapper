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
    }
}