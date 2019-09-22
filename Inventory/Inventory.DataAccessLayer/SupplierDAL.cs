using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capgemini.Inventory.Contracts.DALContracts;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers;

namespace Capgemini.Inventory.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting suppliers from Suppliers collection.
    /// </summary>
    public class SupplierDAL : SupplierDALBase, IDisposable
    {
        /// <summary>
        /// Adds new supplier to Suppliers collection.
        /// </summary>
        /// <param name="newSupplier">Contains the supplier details to be added.</param>
        /// <returns>Determinates whether the new supplier is added.</returns>
        public override bool AddSupplierDAL(Supplier newSupplier)
        {
            bool supplierAdded = false;
            try
            {
                newSupplier.SupplierID = Guid.NewGuid();
                newSupplier.CreationDateTime = DateTime.Now;
                newSupplier.LastModifiedDateTime = DateTime.Now;
                supplierList.Add(newSupplier);
                supplierAdded = true;
            }
            catch (Exception)
            {
                throw;
            }
            return supplierAdded;
        }

        /// <summary>
        /// Gets all suppliers from the collection.
        /// </summary>
        /// <returns>Returns list of all suppliers.</returns>
        public override List<Supplier> GetAllSuppliersDAL()
        {
            return supplierList;
        }

        /// <summary>
        /// Gets supplier based on SupplierID.
        /// </summary>
        /// <param name="searchSupplierID">Represents SupplierID to search.</param>
        /// <returns>Returns Supplier object.</returns>
        public override Supplier GetSupplierBySupplierIDDAL(Guid searchSupplierID)
        {
            Supplier matchingSupplier = null;
            try
            {
                //Find Supplier based on searchSupplierID
                matchingSupplier = supplierList.Find(
                    (item) => { return item.SupplierID == searchSupplierID; }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplier;
        }

        /// <summary>
        /// Gets supplier based on SupplierName.
        /// </summary>
        /// <param name="supplierName">Represents SupplierName to search.</param>
        /// <returns>Returns Supplier object.</returns>
        public override List<Supplier> GetSuppliersByNameDAL(string supplierName)
        {
            List<Supplier> matchingSuppliers = new List<Supplier>();
            try
            {
                //Find All Suppliers based on supplierName
                matchingSuppliers = supplierList.FindAll(
                    (item) => { return item.SupplierName.Equals(supplierName, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSuppliers;
        }

        /// <summary>
        /// Gets supplier based on email.
        /// </summary>
        /// <param name="email">Represents Supplier's Email Address.</param>
        /// <returns>Returns Supplier object.</returns>
        public override Supplier GetSupplierByEmailDAL(string email)
        {
            Supplier matchingSupplier = null;
            try
            {
                //Find Supplier based on Email and Password
                matchingSupplier = supplierList.Find(
                    (item) => { return item.Email.Equals(email); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplier;
        }

        /// <summary>
        /// Gets supplier based on Email and Password.
        /// </summary>
        /// <param name="email">Represents Supplier's Email Address.</param>
        /// <param name="password">Represents Supplier's Password.</param>
        /// <returns>Returns Supplier object.</returns>
        public override Supplier GetSupplierByEmailAndPasswordDAL(string email, string password)
        {
            Supplier matchingSupplier = null;
            try
            {
                //Find Supplier based on Email and Password
                matchingSupplier = supplierList.Find(
                    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplier;
        }

        /// <summary>
        /// Updates supplier based on SupplierID.
        /// </summary>
        /// <param name="updateSupplier">Represents Supplier details including SupplierID, SupplierName etc.</param>
        /// <returns>Determinates whether the existing supplier is updated.</returns>
        public override bool UpdateSupplierDAL(Supplier updateSupplier)
        {
            bool supplierUpdated = false;
            try
            {
                //Find Supplier based on SupplierID
                Supplier matchingSupplier = GetSupplierBySupplierIDDAL(updateSupplier.SupplierID);

                if (matchingSupplier != null)
                {
                    //Update supplier details
                    ReflectionHelpers.CopyProperties(updateSupplier, matchingSupplier, new List<string>() { "SupplierName", "SupplierMobile", "Email" });
                    matchingSupplier.LastModifiedDateTime = DateTime.Now;

                    supplierUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return supplierUpdated;
        }

        /// <summary>
        /// Deletes supplier based on SupplierID.
        /// </summary>
        /// <param name="deleteSupplierID">Represents SupplierID to delete.</param>
        /// <returns>Determinates whether the existing supplier is updated.</returns>
        public override bool DeleteSupplierDAL(Guid deleteSupplierID)
        {
            bool supplierDeleted = false;
            try
            {
                //Find Supplier based on searchSupplierID
                Supplier matchingSupplier = supplierList.Find(
                    (item) => { return item.SupplierID == deleteSupplierID; }
                );

                if (matchingSupplier != null)
                {
                    //Delete Supplier from the collection
                    supplierList.Remove(matchingSupplier);
                    supplierDeleted = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return supplierDeleted;
        }

        /// <summary>
        /// Updates supplier's password based on SupplierID.
        /// </summary>
        /// <param name="updateSupplier">Represents Supplier details including SupplierID, Password.</param>
        /// <returns>Determinates whether the existing supplier's password is updated.</returns>
        public override bool UpdateSupplierPasswordDAL(Supplier updateSupplier)
        {
            bool passwordUpdated = false;
            try
            {
                //Find Supplier based on SupplierID
                Supplier matchingSupplier = GetSupplierBySupplierIDDAL(updateSupplier.SupplierID);

                if (matchingSupplier != null)
                {
                    //Update supplier details
                    ReflectionHelpers.CopyProperties(updateSupplier, matchingSupplier, new List<string>() { "Password" });
                    matchingSupplier.LastModifiedDateTime = DateTime.Now;

                    passwordUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return passwordUpdated;
        }

        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }
    }
}



