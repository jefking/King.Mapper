﻿namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data;
    using System.Linq;

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
            DataSet table = null;
            table.LoadObject<object>();
        }

        [TestMethod]
        public void LoadObjectFromDataSet()
        {
            var dataset = LoadDataSet();
            var filled = dataset.LoadObject<FillObject>();
            Assert.AreEqual<int>(1, filled.Id);
            Assert.AreEqual<string>("Breaking Benjamin", filled.Band);
            Assert.AreNotEqual<Guid>(Guid.Empty, filled.Song);
        }

        [TestMethod]
        public void LoadObjectsFromDataSet()
        {
            var dataset = LoadDataSet();
            var filled = dataset.LoadObjects<FillObject>();
            foreach (var item in filled)
            {
                var exists = (from DataRow d in dataset.Tables[0].Rows
                              where (int)d["Id"] == item.Id
                              && (string)d["Band"] == item.Band
                              && (Guid)d["Song"] == item.Song
                              select d).FirstOrDefault();
                Assert.IsNotNull(exists);
            }
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
