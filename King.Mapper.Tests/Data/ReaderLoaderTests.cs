namespace King.Mapper.Tests.Data
{
    using System;
    using System.Data;
    using King.Mapper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;

    [TestClass]
    public class ReaderLoaderTests
    {
        [TestMethod]
        public void Constructor()
        {
            var mock = Substitute.For<IDataReader>();
            new ReaderLoader<object>(mock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorIDataReaderNull()
        {
            new ReaderLoader<object>(null);
        }
    }
}