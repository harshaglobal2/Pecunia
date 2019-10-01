using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.BusinessLayer;
using Capgemini.Inventory.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Inventory.UnitTests
{
    [TestClass]
    public class AddSupplierBLTest
    {
        /// <summary>
        /// Add Supplier to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidSupplier()
        {
            //Arrange
            SupplierBL supplierBL = new SupplierBL();
            Supplier supplier = new Supplier() { SupplierName = "Scott", SupplierMobile = "9876543210", Password = "Scott123#", Email = "scott@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;
            
            //Act
            try
            {
                isAdded = await supplierBL.AddSupplierBL(supplier);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Supplier Name can't be null
        /// </summary>
        [TestMethod]
        public async Task SupplierNameCanNotBeNull()
        {
            //Arrange
            SupplierBL supplierBL = new SupplierBL();
            Supplier supplier = new Supplier() { SupplierName = null, SupplierMobile = "9988776655", Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;
            
            //Act
            try
            {
                isAdded = await supplierBL.AddSupplierBL(supplier);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Supplier Mobile can't be null
        /// </summary>
        [TestMethod]
        public async Task SupplierMobileCanNotBeNull()
        {
            //Arrange
            SupplierBL supplierBL = new SupplierBL();
            Supplier supplier = new Supplier() { SupplierName = "Smith", SupplierMobile = null, Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await supplierBL.AddSupplierBL(supplier);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Supplier Password can't be null
        /// </summary>
        [TestMethod]
        public async Task SupplierPasswordCanNotBeNull()
        {
            //Arrange
            SupplierBL supplierBL = new SupplierBL();
            Supplier supplier = new Supplier() { SupplierName = "Allen", SupplierMobile = "9877766554", Password = null, Email = "allen@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await supplierBL.AddSupplierBL(supplier);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Supplier Email can't be null
        /// </summary>
        [TestMethod]
        public async Task SupplierEmailCanNotBeNull()
        {
            //Arrange
            SupplierBL supplierBL = new SupplierBL();
            Supplier supplier = new Supplier() { SupplierName = "John", SupplierMobile = "9876543210", Password = "John123#", Email = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await supplierBL.AddSupplierBL(supplier);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SupplierName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task SupplierNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            SupplierBL supplierBL = new SupplierBL();
            Supplier supplier = new Supplier() { SupplierName = "J", SupplierMobile = "9877897890", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await supplierBL.AddSupplierBL(supplier);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SupplierMobile should be a valid mobile number
        /// </summary>
        [TestMethod]
        public async Task SupplierMobileRegExp()
        {
            //Arrange
            SupplierBL supplierBL = new SupplierBL();
            Supplier supplier = new Supplier() { SupplierName = "John", SupplierMobile = "9877", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await supplierBL.AddSupplierBL(supplier);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Password should be a valid password as per regular expression
        /// </summary>
        [TestMethod]
        public async Task SupplierPasswordRegExp()
        {
            //Arrange
            SupplierBL supplierBL = new SupplierBL();
            Supplier supplier = new Supplier() { SupplierName = "John", SupplierMobile = "9877897890", Password = "John", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await supplierBL.AddSupplierBL(supplier);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Email should be a valid email as per regular expression
        /// </summary>
        [TestMethod]
        public async Task SupplierEmailRegExp()
        {
            //Arrange
            SupplierBL supplierBL = new SupplierBL();
            Supplier supplier = new Supplier() { SupplierName = "John", SupplierMobile = "9877897890", Password = "John123#", Email = "john" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await supplierBL.AddSupplierBL(supplier);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }
    }
}


