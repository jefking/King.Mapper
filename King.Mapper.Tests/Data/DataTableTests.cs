namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Data;
    using King.Mapper.Tests.Models;

    [TestFixture]
    public class DataTableTests
    {
        [Test]
        public void ModelsTableNull()
        {
            DataTable table = null;
            Assert.That(() => table.Models<object>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ModelTableNull()
        {
            DataTable table = null;
            Assert.That(() => table.Model<object>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Model()
        {
            var dataset = LoadData();
            var filled = dataset.Model<FillObject>();
            Assert.AreEqual(1, filled.Id);
            Assert.AreEqual("Breaking Benjamin", filled.Band);
            Assert.AreNotEqual(Guid.Empty, filled.Song);
        }

        [Test]
        public void Models()
        {
            var dataset = LoadData();
            var filled = dataset.Models<FillObject>();
            foreach (var item in filled)
            {
                var exists = (from DataRow d in dataset.Rows
                              where (int)d["Id"] == item.Id
                              && (string)d["Band"] == item.Band
                              && (Guid)d["Song"] == item.Song
                              select d).FirstOrDefault();
                Assert.IsNotNull(exists);
            }
        }

        [Test]
        public void DictionaryTableNull()
        {
            DataTable table = null;
            Assert.That(() => table.Dictionary(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DictionariesTableNull()
        {
            DataTable table = null;
            Assert.That(() => table.Dictionaries(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Dictionary()
        {
            var dataset = LoadData();
            var filled = dataset.Dictionary();
            Assert.AreEqual(1, filled["Id"]);
            Assert.AreEqual("Breaking Benjamin", filled["Band"]);
            Assert.AreNotEqual(Guid.Empty, filled["Song"]);
        }

        [Test]
        public void Dictionaries()
        {
            var dataset = LoadData();
            var filled = dataset.Dictionaries();
            foreach (var item in filled)
            {
                var exists = (from DataRow d in dataset.Rows
                              where (int)d["Id"] == (int)item["Id"]
                              && (string)d["Band"] == (string)item["Band"]
                              && (Guid)d["Song"] == (Guid)item["Song"]
                              select d).FirstOrDefault();
                Assert.IsNotNull(exists);
            }
        }

        [Test]
        public void DynamicTableNull()
        {
            DataTable table = null;
            Assert.That(() => table.Dynamic(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DynamicsTableNull()
        {
            DataTable table = null;
            Assert.That(() => table.Dynamics(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Dynamic()
        {
            var dataset = LoadData();
            var filled = dataset.Dynamic();
            Assert.AreEqual(1, filled.Id);
            Assert.AreEqual("Breaking Benjamin", filled.Band);
            Assert.AreNotEqual(Guid.Empty, filled.Song);
        }

        [Test]
        public void Dynamics()
        {
            var data = LoadData();
            var filled = data.Dynamics();
            foreach (var item in filled)
            {
                var exists = (from DataRow d in data.Rows
                              where (int)d["Id"] == (int)item.Id
                                  && (string)d["Band"] == (string)item.Band
                                  && (Guid)d["Song"] == (Guid)item.Song
                              select d).FirstOrDefault();
                Assert.IsNotNull(exists);
            }
        }

        public DataTable LoadData()
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

            return songTable;
        }
    }
}