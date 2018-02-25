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
        public void MapDictionaryNull()
        {
            IDictionary<string, int> dic = null;
            Assert.ThrowsException<ArgumentNullException>(() => dic.Map<object>());
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
            Assert.AreEqual(expected.Id, returned.Id);
            Assert.AreEqual(expected.Band, returned.Band);
            Assert.AreEqual(expected.Song, returned.Song);
            Assert.AreEqual(expected.Ecode, returned.Ecode);
            Assert.AreEqual(expected.NullableByte, returned.NullableByte);
            Assert.AreEqual(expected.SuperEnum, returned.SuperEnum);
            Assert.AreEqual(expected.NullableEnum, returned.NullableEnum);
            Assert.AreEqual(expected.TheGuid, returned.TheGuid);
        }

        [TestMethod]
        public void MapNull()
        {
            IDictionary<string, object> dic = null;
            Assert.ThrowsException<ArgumentNullException>(() => dic.Map());
        }

        [TestMethod]
        public void Map()
        {
            var random = new Random();
            var expected = new Dictionary<string, object>();
            expected.Add("Id", random.Next());
            expected.Add("Stringy", Guid.NewGuid().ToString());
            expected.Add("Wee", Guid.NewGuid());

            var returned = expected.Map();

            Assert.IsNotNull(returned);
            Assert.AreEqual(expected["Id"], returned.Id);
            Assert.AreEqual(expected["Stringy"], returned.Stringy);
            Assert.AreEqual(expected["Wee"], returned.Wee);
        }
    }
}