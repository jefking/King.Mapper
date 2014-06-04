namespace King.Mapper.Tests.Data
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data;
    using King.Mapper.Data;

    [TestClass]
    public class DataSetTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectsNull()
        {
            DataSet table = null;
            table.LoadObjects<object>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectNull()
        {
            DataTable table = null;
            table.LoadObject<object>();
        }
    }
}
