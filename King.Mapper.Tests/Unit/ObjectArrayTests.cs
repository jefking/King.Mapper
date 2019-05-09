namespace King.Mapper.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ObjectArrayTests
    {
        [Test]
        public void GetAttributeAttributesNull()
        {
            object[] attrs = null;
            Assert.That(() => attrs.GetAttribute<ActionNameAttribute>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void GetAttribute()
        {
            var attrs = new Attribute[] { new ActionNameAttribute("test", ActionFlags.Execute), new ActionNameAttribute("fail") };
            var attr = attrs.GetAttribute<ActionNameAttribute>();

            Assert.IsNotNull(attr);
            Assert.AreEqual(ActionFlags.Execute, attr.Action);
            Assert.AreEqual("test", attr.Name);
        }
    }
}