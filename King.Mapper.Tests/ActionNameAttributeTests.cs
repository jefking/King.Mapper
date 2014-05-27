namespace King.Mapper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using King.Mapper;

    [TestClass]
    public class ActionNameAttributeTests
    {
        #region Error Cases
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorInvalidName()
        {
            new ActionNameAttribute(ActionFlags.Load, null);
        }
        #endregion

        #region Valid Cases
        [TestMethod]
        public void Constructor()
        {
            new ActionNameAttribute(ActionFlags.Execute, Guid.NewGuid().ToString());
        }

        [TestMethod]
        public void Name()
        {
            var data = Guid.NewGuid().ToString();
            var actionName = new ActionNameAttribute(ActionFlags.Load, data);
            Assert.AreEqual<string>(data, actionName.Name);
        }

        [TestMethod]
        public void Action()
        {
            var data = ActionFlags.Execute;
            var actionName = new ActionNameAttribute(data, Guid.NewGuid().ToString());
            Assert.AreEqual<ActionFlags>(data, actionName.Action);
        }
        #endregion
    }
}
