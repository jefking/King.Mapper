namespace King.Mapper.Tests.Data
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using King.Mapper.Data;
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
    }
}
