﻿namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using System;
    using System.Data;

    [TestFixture]
    public class DynamicLoaderTests
    {
        [Test]
        public void Constructor()
        {
            new DynamicLoader();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionaryDataTableNull()
        {
            var l = new DynamicLoader();
            l.Dictionary((DataTable)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionariesDataTableNull()
        {
            var l = new DynamicLoader();
            l.Dictionaries((DataTable)null);
        }
    }
}