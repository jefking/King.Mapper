namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data;

    [TestClass]
    public class DataTableTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsTableNull()
        {
            DataTable table = null;
            table.Models<object>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelTableNull()
        {
            DataTable table = null;
            table.Model<object>();
        }
    }
}