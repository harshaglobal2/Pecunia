using System;
using System.Threading.Tasks;
using Capgemini.Inventory.BusinessLayer;
using Capgemini.Inventory.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inventory.UnitTests
{
    [TestClass]
    public class AdminBLTest
    {
        [TestMethod]
        public async Task GetAdminByEmailAndPasswordBLTest()
        {
            //Arrange
            AdminBL adminBL = new AdminBL();

            //Act
            Admin admin = await adminBL.GetAdminByEmailAndPasswordBL("admin@capgemini.com", "manager");

            //Assert
            Assert.AreEqual(admin.AdminName, "Admin");
        }
    }
}


