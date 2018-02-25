namespace King.Mapper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectArrayTests
    {
        [TestMethod]
        public void GetAttributeAttributesNull()
        {
            object[] attrs = null;
            Assert.ThrowsException<ArgumentNullException>(() => attrs.GetAttribute<ActionNameAttribute>());
        }

        [TestMethod]
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