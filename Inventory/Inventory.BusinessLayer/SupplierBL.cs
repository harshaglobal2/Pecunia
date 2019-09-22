using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Capgemini.Inventory.Contracts.BLContracts;
using Capgemini.Inventory.Contracts.DALContracts;
using Capgemini.Inventory.DataAccessLayer;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.BusinessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting suppliers from Suppliers collection.
    /// </summary>
    public class SupplierBL : BLBase<Supplier>, ISupplierBL, IDisposable
    {
        //fields
        SupplierDALBase supplierDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SupplierBL()
        {
            this.supplierDAL = new SupplierDAL();
        }

        /// <summary>
        /// Validations on data before adding or updating.
        /// </summary>
        /// <param name="entityObject">Represents object to be validated.</param>
        /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
        protected async override Task<bool> Validate(Supplier entityObject)
        {
            //Create string builder
            StringBuilder sb = new StringBuilder();
            bool valid = await base.Validate(entityObject);

            //Email is Unique
            if ((await GetSupplierByEmailBL(entityObject.Email)) != null)
            {
                valid = false;
                sb.Append(Environment.NewLine + $"Email {entityObject.Email} already exists");
            }

            if (valid == false)
                throw new InventoryException(sb.ToString());
            return valid;
        }

        /// <summary>
        /// Adds new supplier to Suppliers collection.
        /// </summary>
        /// <param name="newSupplier">Contains the supplier details to be added.</param>
        /// <returns>Determinates whether the new supplier is added.</returns>
        public async Task<bool> AddSupplierBL(Supplier newSupplier)
        {
            bool supplierAdded = false;
            try
            {
                if (await Validate(newSupplier))
                {
                    await Task.Run(() =>
                    {
                        this.supplierDAL.AddSupplierDAL(newSupplier);
                        supplierAdded = true;
                        Serialize();
                    });
                }
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
        public async Task<List<Supplier>> GetAllSuppliersBL()
        {
            List<Supplier> suppliersList = null;
            try
            {
                await Task.Run(() =>
                {
                    suppliersList = supplierDAL.GetAllSuppliersDAL();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return suppliersList;
        }

        /// <summary>
        /// Gets supplier based on SupplierID.
        /// </summary>
        /// <param name="searchSupplierID">Represents SupplierID to search.</param>
        /// <returns>Returns Supplier object.</returns>
        public async Task<Supplier> GetSupplierBySupplierIDBL(Guid searchSupplierID)
        {
            Supplier matchingSupplier = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSupplier = supplierDAL.GetSupplierBySupplierIDDAL(searchSupplierID);
                });
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
        public async Task<List<Supplier>> GetSuppliersByNameBL(string supplierName)
        {
            List<Supplier> matchingSuppliers = new List<Supplier>();
            try
            {
                await Task.Run(() =>
                {
                    matchingSuppliers = supplierDAL.GetSuppliersByNameDAL(supplierName);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSuppliers;
        }

        /// <summary>
        /// Gets supplier based on Email and Password.
        /// </summary>
        /// <param name="email">Represents Supplier's Email Address.</param>
        /// <returns>Returns Supplier object.</returns>
        public async Task<Supplier> GetSupplierByEmailBL(string email)
        {
            Supplier matchingSupplier = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSupplier = supplierDAL.GetSupplierByEmailDAL(email);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplier;
        }

        /// <summary>
        /// Gets supplier based on Password.
        /// </summary>
        /// <param name="email">Represents Supplier's Email Address.</param>
        /// <param name="password">Represents Supplier's Password.</param>
        /// <returns>Returns Supplier object.</returns>
        public async Task<Supplier> GetSupplierByEmailAndPasswordBL(string email, string password)
        {
            Supplier matchingSupplier = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSupplier = supplierDAL.GetSupplierByEmailAndPasswordDAL(email, password);
                });
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
        public async Task<bool> UpdateSupplierBL(Supplier updateSupplier)
        {
            bool supplierUpdated = false;
            try
            {
                if ((await Validate(updateSupplier)) && (await GetSupplierBySupplierIDBL(updateSupplier.SupplierID)) != null)
                {
                    this.supplierDAL.UpdateSupplierDAL(updateSupplier);
                    supplierUpdated = true;
                    Serialize();
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
        public async Task<bool> DeleteSupplierBL(Guid deleteSupplierID)
        {
            bool supplierDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    supplierDeleted = supplierDAL.DeleteSupplierDAL(deleteSupplierID);
                    Serialize();
                });
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
        public async Task<bool> UpdateSupplierPasswordBL(Supplier updateSupplier)
        {
            bool passwordUpdated = false;
            try
            {
                if ((await Validate(updateSupplier)) && (await GetSupplierBySupplierIDBL(updateSupplier.SupplierID)) != null)
                {
                    this.supplierDAL.UpdateSupplierPasswordDAL(updateSupplier);
                    passwordUpdated = true;
                    Serialize();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return passwordUpdated;
        }

        /// <summary>
        /// Disposes DAL object(s).
        /// </summary>
        public void Dispose()
        {
            ((SupplierDAL)supplierDAL).Dispose();
        }

        /// <summary>
        /// Invokes Serialize method of DAL.
        /// </summary>
        public static void Serialize()
        {
            try
            {
                SupplierDAL.Serialize();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///Invokes Deserialize method of DAL.
        /// </summary>
        public static void Deserialize()
        {
            try
            {
                SupplierDAL.Deserialize();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}



