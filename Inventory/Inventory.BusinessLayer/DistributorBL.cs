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
    /// Contains data access layer methods for inserting, updating, deleting distributors from Distributors collection.
    /// </summary>
    public class DistributorBL : BLBase<Distributor>, IDistributorBL, IDisposable
    {
        //fields
        DistributorDALBase distributorDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DistributorBL()
        {
            this.distributorDAL = new DistributorDAL();
        }

        /// <summary>
        /// Validations on data before adding or updating.
        /// </summary>
        /// <param name="entityObject">Represents object to be validated.</param>
        /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
        protected async override Task<bool> Validate(Distributor entityObject)
        {
            //Create string builder
            StringBuilder sb = new StringBuilder();
            bool valid = await base.Validate(entityObject);

            //Email is Unique
            var existingObject = await GetDistributorByEmailBL(entityObject.Email);
            if (existingObject != null && existingObject?.DistributorID != entityObject.DistributorID)
            {
                valid = false;
                sb.Append(Environment.NewLine + $"Email {entityObject.Email} already exists");
            }

            if (valid == false)
                throw new InventoryException(sb.ToString());
            return valid;
        }

        /// <summary>
        /// Adds new distributor to Distributors collection.
        /// </summary>
        /// <param name="newDistributor">Contains the distributor details to be added.</param>
        /// <returns>Determinates whether the new distributor is added.</returns>
        public async Task<bool> AddDistributorBL(Distributor newDistributor)
        {
            bool distributorAdded = false;
            try
            {
                if (await Validate(newDistributor))
                {
                    await Task.Run(() =>
                    {
                        this.distributorDAL.AddDistributorDAL(newDistributor);
                        distributorAdded = true;
                        Serialize();
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return distributorAdded;
        }

        /// <summary>
        /// Gets all distributors from the collection.
        /// </summary>
        /// <returns>Returns list of all distributors.</returns>
        public async Task<List<Distributor>> GetAllDistributorsBL()
        {
            List<Distributor> distributorsList = null;
            try
            {
                await Task.Run(() =>
                {
                    distributorsList = distributorDAL.GetAllDistributorsDAL();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return distributorsList;
        }

        /// <summary>
        /// Gets distributor based on DistributorID.
        /// </summary>
        /// <param name="searchDistributorID">Represents DistributorID to search.</param>
        /// <returns>Returns Distributor object.</returns>
        public async Task<Distributor> GetDistributorByDistributorIDBL(Guid searchDistributorID)
        {
            Distributor matchingDistributor = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingDistributor = distributorDAL.GetDistributorByDistributorIDDAL(searchDistributorID);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributor;
        }

        /// <summary>
        /// Gets distributor based on DistributorName.
        /// </summary>
        /// <param name="distributorName">Represents DistributorName to search.</param>
        /// <returns>Returns Distributor object.</returns>
        public async Task<List<Distributor>> GetDistributorsByNameBL(string distributorName)
        {
            List<Distributor> matchingDistributors = new List<Distributor>();
            try
            {
                await Task.Run(() =>
                {
                    matchingDistributors = distributorDAL.GetDistributorsByNameDAL(distributorName);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributors;
        }

        /// <summary>
        /// Gets distributor based on Email and Password.
        /// </summary>
        /// <param name="email">Represents Distributor's Email Address.</param>
        /// <returns>Returns Distributor object.</returns>
        public async Task<Distributor> GetDistributorByEmailBL(string email)
        {
            Distributor matchingDistributor = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingDistributor = distributorDAL.GetDistributorByEmailDAL(email);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributor;
        }

        /// <summary>
        /// Gets distributor based on Password.
        /// </summary>
        /// <param name="email">Represents Distributor's Email Address.</param>
        /// <param name="password">Represents Distributor's Password.</param>
        /// <returns>Returns Distributor object.</returns>
        public async Task<Distributor> GetDistributorByEmailAndPasswordBL(string email, string password)
        {
            Distributor matchingDistributor = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingDistributor = distributorDAL.GetDistributorByEmailAndPasswordDAL(email, password);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributor;
        }

        /// <summary>
        /// Updates distributor based on DistributorID.
        /// </summary>
        /// <param name="updateDistributor">Represents Distributor details including DistributorID, DistributorName etc.</param>
        /// <returns>Determinates whether the existing distributor is updated.</returns>
        public async Task<bool> UpdateDistributorBL(Distributor updateDistributor)
        {
            bool distributorUpdated = false;
            try
            {
                if ((await Validate(updateDistributor)) && (await GetDistributorByDistributorIDBL(updateDistributor.DistributorID)) != null)
                {
                    this.distributorDAL.UpdateDistributorDAL(updateDistributor);
                    distributorUpdated = true;
                    Serialize();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return distributorUpdated;
        }

        /// <summary>
        /// Deletes distributor based on DistributorID.
        /// </summary>
        /// <param name="deleteDistributorID">Represents DistributorID to delete.</param>
        /// <returns>Determinates whether the existing distributor is updated.</returns>
        public async Task<bool> DeleteDistributorBL(Guid deleteDistributorID)
        {
            bool distributorDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    distributorDeleted = distributorDAL.DeleteDistributorDAL(deleteDistributorID);
                    Serialize();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return distributorDeleted;
        }

        /// <summary>
        /// Updates distributor's password based on DistributorID.
        /// </summary>
        /// <param name="updateDistributor">Represents Distributor details including DistributorID, Password.</param>
        /// <returns>Determinates whether the existing distributor's password is updated.</returns>
        public async Task<bool> UpdateDistributorPasswordBL(Distributor updateDistributor)
        {
            bool passwordUpdated = false;
            try
            {
                if ((await Validate(updateDistributor)) && (await GetDistributorByDistributorIDBL(updateDistributor.DistributorID)) != null)
                {
                    this.distributorDAL.UpdateDistributorPasswordDAL(updateDistributor);
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
            ((DistributorDAL)distributorDAL).Dispose();
        }

        /// <summary>
        /// Invokes Serialize method of DAL.
        /// </summary>
        public static void Serialize()
        {
            try
            {
                DistributorDAL.Serialize();
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
                DistributorDAL.Deserialize();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}



