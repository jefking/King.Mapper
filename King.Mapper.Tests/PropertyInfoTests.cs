namespace King.Mapper.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPropertyNull()
        {
            PropertyInfo info = null;
            info.Set(new object());
        }
    }
}