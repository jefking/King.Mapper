namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    class ObjectTests
    {

        [TestMethod]
        public void ObjectParameter()
        {
            var obj = new object();
            Assert.AreEqual<int>(0, obj.Parameters().Length);
        }

        [TestMethod]
        public void ObjectParameters()
        {
            var obj = new TestActionNames();
            Assert.AreEqual<int>(3, obj.Parameters().Length);
            foreach (var property in obj.Parameters())
            {
                switch (property)
                {
                    case "id":
                    case "band":
                    case "song":
                        continue;
                    default:
                        Assert.Fail();
                        break;
                }
            }
        }
    }
}
