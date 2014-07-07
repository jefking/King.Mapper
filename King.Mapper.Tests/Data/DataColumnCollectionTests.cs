namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using System;
    using System.Data;

    [TestFixture]
    public class DataColumnCollectionTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToArrayCollectionNull()
        {
            DataColumnCollection col = null;
            col.ToArray();
        }
    }
}