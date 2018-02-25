namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Specialized;
    using System.Configuration;

    [TestClass]
    public class NameValueCollectionTests
    {
        [TestMethod]
        public void MapDictionaryNull()
        {
            NameValueCollection dic = null;
            Assert.ThrowsException<ArgumentNullException>(() => dic.Map<object>());
        }

        [TestMethod]
        public void LoadConfig()
        {
            var config = ConfigurationManager.AppSettings.Map<ConfigurationModel>();
            Assert.AreEqual("Connection String", config.Database);
            Assert.AreEqual(123, config.SiteId);
            Assert.AreEqual("www.myapi.com", config.ApiUrl);
            Assert.IsNull(config.DoesntExist);
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
            dic.Add(Guid.NewGuid().ToString(), null);

            var returned = dic.Map<FillObject>();

            Assert.IsNotNull(returned);
            Assert.AreEqual(expected.Id, returned.Id);
            Assert.AreEqual(expected.Band, returned.Band);
            Assert.AreEqual(expected.NullableByte, returned.NullableByte);
            Assert.AreEqual(expected.SuperEnum, returned.SuperEnum);
            Assert.AreEqual(expected.NullableEnum, returned.NullableEnum);
        }
    }
}