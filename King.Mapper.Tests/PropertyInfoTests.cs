namespace King.Mapper.Tests
{
    using System;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPropertyNull()
        {
            PropertyInfo info = null;
            info.Set(new object());
        }
    }
}