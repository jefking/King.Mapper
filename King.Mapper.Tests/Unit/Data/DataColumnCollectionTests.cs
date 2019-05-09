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
        public void ToArrayCollectionNull()
        {
            DataColumnCollection col = null;
            Assert.That(() => col.ToArray(), Throws.TypeOf<ArgumentNullException>());
        }
    }
}