namespace King.Mapper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectArrayTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAttributeAttributesNull()
        {
            object[] attrs = null;
            attrs.GetAttribute<ActionNameAttribute>();
        }
    }
}