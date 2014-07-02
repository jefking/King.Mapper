namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestClass]
    public class IDictionaryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapDictionaryNull()
        {
            IDictionary<string, int> dic = null;
            dic.Map<object>();
        }

        [TestMethod]
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
            Assert.AreEqual<int>(expected.Id, returned.Id);
            Assert.AreEqual<string>(expected.Band, returned.Band);
            Assert.AreEqual<Guid>(expected.Song, returned.Song);
            Assert.AreEqual<Encoding>(expected.Ecode, returned.Ecode);
            Assert.AreEqual<byte?>(expected.NullableByte, returned.NullableByte);
            Assert.AreEqual<HappyLand>(expected.SuperEnum, returned.SuperEnum);
            Assert.AreEqual<SadLand?>(expected.NullableEnum, returned.NullableEnum);
            Assert.AreEqual<Guid?>(expected.TheGuid, returned.TheGuid);
        }
    }
}