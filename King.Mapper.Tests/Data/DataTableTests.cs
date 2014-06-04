namespace King.Mapper.Tests.Data
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using King.Mapper.Data;
    using System.Data;

    [TestClass]
    public class DataTableTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectsTableNull()
        {
            DataTable table = null;
            table.LoadObjects<object>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadObjectTableNull()
        {
            DataTable table = null;
            table.LoadObject<object>();
        }
    }
}