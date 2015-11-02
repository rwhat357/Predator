using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pretador.Api;

namespace Pretador.Api.Tests
{
    [TestClass]
    public class TestCheckService
    {
        [TestMethod]
        public void TestCreate()
        {
            var target = new CheckService();
            Assert.IsTrue(target.Create());
        }

        [TestMethod]
        public void TestRetrieve()
        {
            var target = new CheckService();
            Assert.IsTrue(target.Retrieve());
        }

        [TestMethod]
        public void TestUpdate()
        {
            var target = new CheckService();
            Assert.IsTrue(target.Update());
        }

        [TestMethod]
        public void TestDelete()
        {
            var target = new CheckService();
            Assert.IsTrue(target.Delete());
        }
    }

}
