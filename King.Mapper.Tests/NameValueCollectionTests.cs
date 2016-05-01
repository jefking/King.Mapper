namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Specialized;
    using System.Configuration;

    [TestFixture]
    public class NameValueCollectionTests
    {
        [Test]
        public void MapDictionaryNull()
        {
            NameValueCollection dic = null;
            Assert.That(() => dic.Map<object>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void LoadConfig()
        {
            var config = new ConfigurationModel();// ConfigurationManager.AppSettings.Map<ConfigurationModel>();
            Assert.AreEqual("Connection String", config.Database);
            Assert.AreEqual(123, config.SiteId);
            Assert.AreEqual("www.myapi.com", config.ApiUrl);
            Assert.IsNull(config.DoesntExist);
            Assert.Inconclusive();
        }

        [Test]
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