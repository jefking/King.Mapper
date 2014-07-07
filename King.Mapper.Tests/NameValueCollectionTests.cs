namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Specialized;
    using System.Text;

    [TestFixture]
    public class NameValueCollectionTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapDictionaryNull()
        {
            NameValueCollection dic = null;
            dic.Map<object>();
        }

        [Test]
        public void LoadConfig()
        {
            var config = ConfigurationModel.Load();
            Assert.AreEqual("Connection String", config.Database);
            Assert.AreEqual(123, config.SiteId);
            Assert.AreEqual("www.myapi.com", config.ApiUrl);
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