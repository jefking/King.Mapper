namespace King.Mapper.Tests
{
    using King.Mapper;
    using King.Mapper.Tests.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ActionNameAttributeTests
    {
        #region Error Cases
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorInvalidName()
        {
            new ActionNameAttribute(null);
        }
        #endregion

        #region Valid Cases
        [Test]
        public void Constructor()
        {
            new ActionNameAttribute(Guid.NewGuid().ToString(), ActionFlags.Execute);
        }

        [Test]
        public void Name()
        {
            var data = Guid.NewGuid().ToString();
            var actionName = new ActionNameAttribute(data, ActionFlags.Load);
            Assert.AreEqual(data, actionName.Name);
        }

        [Test]
        public void Action()
        {
            var data = ActionFlags.Execute;
            var actionName = new ActionNameAttribute(Guid.NewGuid().ToString(), data);
            Assert.AreEqual(data, actionName.Action);
        }

        [Test]
        public void ActionDefault()
        {
            var actionName = new ActionNameAttribute(Guid.NewGuid().ToString());
            Assert.AreEqual(ActionFlags.Load, actionName.Action);
        }

        [Test]
        public void ValueMappingTestActionNames()
        {
            var random = new Random();
            var getValues = new TestActionNames()
            {
                Band = Guid.NewGuid().ToString(),
                Id = random.Next(),
                Song = Guid.NewGuid(),
            };

            var mappings = getValues.ValueMapping(new string[] { "Id", "Band", "Song" }, ActionFlags.Load);
            Assert.AreEqual(5, mappings.Count);
            Assert.AreEqual(getValues.Band, (string)mappings["Band"]);
            Assert.AreEqual(getValues.Band, (string)mappings["CheckBandDude"]);
            Assert.AreEqual(getValues.Id, (int)mappings["Id"]);
            Assert.AreEqual(getValues.Song, (Guid)mappings["Song"]);
            Assert.AreEqual(getValues.Song, (Guid)mappings["GuidGuid"]);
        }
        #endregion
    }
}