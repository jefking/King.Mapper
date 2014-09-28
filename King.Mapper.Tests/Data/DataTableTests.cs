namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using System;
    using System.Data;

    [TestFixture]
    public class DataTableTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelsTableNull()
        {
            DataTable table = null;
            table.Models<object>();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelTableNull()
        {
            DataTable table = null;
            table.Model<object>();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelDictionaryTableNull()
        {
            DataTable table = null;
            table.Model();
        }
    }
}