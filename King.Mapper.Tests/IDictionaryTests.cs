namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestFixture]
    public class IDictionaryTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapDictionaryNull()
        {
            IDictionary<string, int> dic = null;
            dic.Map<object>();
        }

        [Test]
        public void MapDictionary()
        {
            var random = new Random();
            var expected = new FillObject()
            {
                Id = random.Next(),
                Band = Guid.NewGuid().ToString(),
                Song = Guid.NewGuid(),
                Ecode = Encoding.BigEndianUnicode,
                NullableByte = null,
                NullableEnum = null,
                SuperEnum = HappyLand.MarioLand,
                TheGuid = null,
            };

            var dic = new Dictionary<string, object>();
            dic.Add("Id", expected.Id);
            dic.Add("Band", expected.Band);
            dic.Add("Song", expected.Song);
            dic.Add("Ecode", expected.Ecode);
            dic.Add("NullableByte", expected.NullableByte);
            dic.Add("NullableEnum", expected.NullableEnum);
            dic.Add("SuperEnum", expected.SuperEnum);
            dic.Add("TheGuid", expected.TheGuid);

            var returned = dic.Map<FillObject>();

            Assert.IsNotNull(returned);
            Assert.AreEqual(expected.Id, returned.Id);
            Assert.AreEqual(expected.Band, returned.Band);
            Assert.AreEqual(expected.Song, returned.Song);
            Assert.AreEqual(expected.Ecode, returned.Ecode);
            Assert.AreEqual(expected.NullableByte, returned.NullableByte);
            Assert.AreEqual(expected.SuperEnum, returned.SuperEnum);
            Assert.AreEqual(expected.NullableEnum, returned.NullableEnum);
            Assert.AreEqual(expected.TheGuid, returned.TheGuid);
        }
    }
}