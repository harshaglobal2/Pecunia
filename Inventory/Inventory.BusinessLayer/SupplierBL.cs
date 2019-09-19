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
        /// Adds new supplier to Suppliers collection.
        /// </summary>
        /// <param name="newSupplier">Contains the supplier details to be added.</param>
        /// <returns>Determinates whether the new supplier is added.</returns>
        public bool AddSupplierBL(Supplier newSupplier)
        {
            bool supplierAdded = false;
            try
            {
                if (Validate(newSupplier))
                {
                    this.supplierDAL.AddSupplierDAL(newSupplier);
                    supplierAdded = true;
                    Serialize();
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
        public List<Supplier> GetAllSuppliersBL()
        {
            List<Supplier> suppliersList = null;
            try
            {
                suppliersList = supplierDAL.GetAllSuppliersDAL();
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
        public Supplier GetSupplierBySupplierIDBL(Guid searchSupplierID)
        {
            Supplier matchingSupplier = null;
            try
            {
                matchingSupplier = supplierDAL.GetSupplierBySupplierIDDAL(searchSupplierID);
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
        public List<Supplier> GetSuppliersByNameBL(string supplierName)
        {
            List<Supplier> matchingSuppliers = new List<Supplier>();
            try
            {
                matchingSuppliers = supplierDAL.GetSuppliersByNameDAL(supplierName);
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSuppliers;
        }

        /// <summary>
        /// Gets supplier based on Password.
        /// </summary>
        /// <param name="email">Represents Supplier's Email Address.</param>
        /// <param name="password">Represents Supplier's Password.</param>
        /// <returns>Returns Supplier object.</returns>
        public Supplier GetSupplierByEmailAndPasswordBL(string email, string password)
        {
            Supplier matchingSupplier = null;
            try
            {
                matchingSupplier = supplierDAL.GetSupplierByEmailAndPasswordDAL(email, password);
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
        public bool UpdateSupplierBL(Supplier updateSupplier)
        {
            bool supplierUpdated = false;
            try
            {
                if (Validate(updateSupplier) && GetSupplierBySupplierIDBL(updateSupplier.SupplierID) != null)
                {
                    this.supplierDAL.AddSupplierDAL(updateSupplier);
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
        public bool DeleteSupplierBL(Guid deleteSupplierID)
        {
            bool supplierDeleted = false;
            try
            {
                supplierDeleted = supplierDAL.DeleteSupplierDAL(deleteSupplierID);
                Serialize();
            }
            catch (Exception)
            {
                throw;
            }
            return supplierDeleted;
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



