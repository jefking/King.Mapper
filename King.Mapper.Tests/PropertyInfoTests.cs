namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestClass]
    public class PropertyInfoTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAttributesPropertyNull()
        {
            PropertyInfo info = null;
            info.GetAttributes<ActionNameAttribute>();
        }

        [TestMethod]
        public void GetAttributes()
        {
            var info = (from p in typeof(TestActionNames).GetProperties()
                        where p.Name == "Song"
                        select p).FirstOrDefault();

            Assert.IsNotNull(info);

            var attrs = info.GetAttributes<ActionNameAttribute>();
            Assert.AreEqual<int>(2, attrs.Count());
            var action = (from a in attrs
                          where a.Action == ActionFlags.Execute
                          && a.Name == "Insert"
                          select a).FirstOrDefault();
            Assert.IsNotNull(action);
            action = (from a in attrs
                      where a.Action == ActionFlags.Load
                      && a.Name == "GuidGuid"
                      select a).FirstOrDefault();
            Assert.IsNotNull(action);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAttributesNull()
        {
            PropertyInfo info = null;
            info.GetAttribute<ActionNameAttribute>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPropertyNull()
        {
            PropertyInfo info = null;
            info.Set(new object());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetOwnerNull()
        {
            var info = typeof(FillObject).GetProperties()[0];
            info.Set(null);
        }

        [TestMethod]
        public void SetPropertyNullableGuid()
        {
            var data = new FillObject();
            var info = (from p in data.GetType().GetProperties()
                        where p.Name == "TheGuid"
                        select p).FirstOrDefault();
            info.Set(data, null);
            Assert.IsNull(data.TheGuid);
        }

        [TestMethod]
        public void SetPropertyGuid()
        {
            var expected = Guid.NewGuid();
            var data = new FillObject();
            var info = (from p in data.GetType().GetProperties()
                        where p.Name == "Song"
                        select p).FirstOrDefault();
            info.Set(data, expected);

            Assert.AreEqual<Guid>(expected, data.Song);
        }

        [TestMethod]
        public void SetPropertyNullableEnum()
        {
            var data = new FillObject();
            var info = (from p in data.GetType().GetProperties()
                        where p.Name == "NullableEnum"
                        select p).FirstOrDefault();
            info.Set(data, null);
            Assert.IsNull(data.NullableEnum);
        }

        [TestMethod]
        public void SetPropertyEnum()
        {
            var expected = HappyLand.MarioLand;
            var data = new FillObject();
            var info = (from p in data.GetType().GetProperties()
                        where p.Name == "SuperEnum"
                        select p).FirstOrDefault();
            info.Set(data, expected);

            Assert.AreEqual<HappyLand>(expected, data.SuperEnum);
        }
    }
}