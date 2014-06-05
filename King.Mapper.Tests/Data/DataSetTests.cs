namespace King.Mapper.Tests.Data
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data;
    using King.Mapper.Data;
    using King.Mapper.Tests.Models;

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

        [TestMethod]
        public void LoadObjectFromDataSet()
        {
            var dataset = LoadDataSet();
            var toFill = dataset.LoadObject<FillObject>();
            Assert.AreEqual<int>(1, toFill.Id);
            Assert.AreEqual<string>("Breaking Benjamin", toFill.Band);
            Assert.AreNotEqual<Guid>(Guid.Empty, toFill.Song);
        }
        
        public DataSet LoadDataSet()
        {
            var SongDS = new DataSet();
            var songTable = SongDS.Tables.Add();

            //-- Add columns to the data table
            songTable.Columns.Add("Id", typeof(int));
            songTable.Columns.Add("Band", typeof(string));
            songTable.Columns.Add("Song", typeof(Guid));
            songTable.Columns.Add("filename", typeof(string));
            songTable.Columns.Add("message", typeof(string));

            //-- Add rows to the data table
            songTable.Rows.Add(1, "Breaking Benjamin", Guid.NewGuid(), "C:/temp", "Rock and Roll");
            songTable.Rows.Add(2, "Three Days Grace", new Guid("5B9A9EDA-1245-11E2-9660-789B6188709B"), "C:/temp", "Rock and Roll");
            songTable.Rows.Add(3, "Seether", Guid.NewGuid(), "C:/temp", "Rock and Roll");
            songTable.Rows.Add(4, "Finger Eleven", new Guid("E36F1C72-1728-11E2-A9C6-1F206188709B"), "C:/temp", "Rock and Roll");
            songTable.Rows.Add(5, "Three Doors Down", new Guid("F1D9AB7E-1728-11E2-94A3-2C206188709B"), "C:/temp", "Rock and Roll");

            return SongDS;
        }
    }
}
