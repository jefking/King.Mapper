namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Specialized;
    using System.Text;

    [TestClass]
    public class NameValueCollectionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapDictionaryNull()
        {
            NameValueCollection dic = null;
            dic.Map<object>();
        }

        [TestMethod]
        public void LoadConfig()
        {
            var config = ConfigurationModel.Load();
            Assert.AreEqual<string>("Connection String", config.Database);
            Assert.AreEqual<int>(123, config.SiteId);
            Assert.AreEqual<string>("www.myapi.com", config.ApiUrl);
        }

        [TestMethod]
        public void Map()
        {
            var random = new Random();
            var expected = new FillObject()
            {
                Id = random.Next(),
                Band = Guid.NewGuid().ToString(),
                NullableByte = 123,
            };

            var dic = new NameValueCollection();
            dic.Add("Id", expected.Id.ToString());
            dic.Add("Band", expected.Band);
            dic.Add("NullableByte", expected.NullableByte.ToString());

            var returned = dic.Map<FillObject>();

            Assert.IsNotNull(returned);
            Assert.AreEqual<int>(expected.Id, returned.Id);
            Assert.AreEqual<string>(expected.Band, returned.Band);
            Assert.AreEqual<byte?>(expected.NullableByte, returned.NullableByte);
            Assert.AreEqual<HappyLand>(expected.SuperEnum, returned.SuperEnum);
            Assert.AreEqual<SadLand?>(expected.NullableEnum, returned.NullableEnum);
        }
    }
}