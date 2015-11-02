using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pretador.Api.Tests
{

    [TestClass]
    public class TestStaffService
    {
        [TestMethod]
        public void TestCreate()
        {
            var target = new StaffService();
            Assert.IsTrue(target.Create());
        }

        [TestMethod]
        public void TestRetrieve()
        {
            var target = new StaffService();
            Assert.IsTrue(target.Retrieve());
        }

        [TestMethod]
        public void TestUpdate()
        {
            var target = new StaffService();
            Assert.IsTrue(target.Update());
        }

        [TestMethod]
        public void TestDelete()
        {
            var target = new StaffService();
            Assert.IsTrue(target.Delete());
        }
    }

}
