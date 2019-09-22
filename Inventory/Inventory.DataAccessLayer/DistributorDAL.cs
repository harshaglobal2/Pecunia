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
    /// Contains data access layer methods for inserting, updating, deleting distributors from Distributors collection.
    /// </summary>
    public class DistributorDAL : DistributorDALBase, IDisposable
    {
        /// <summary>
        /// Adds new distributor to Distributors collection.
        /// </summary>
        /// <param name="newDistributor">Contains the distributor details to be added.</param>
        /// <returns>Determinates whether the new distributor is added.</returns>
        public override bool AddDistributorDAL(Distributor newDistributor)
        {
            bool distributorAdded = false;
            try
            {
                newDistributor.DistributorID = Guid.NewGuid();
                newDistributor.CreationDateTime = DateTime.Now;
                newDistributor.LastModifiedDateTime = DateTime.Now;
                distributorList.Add(newDistributor);
                distributorAdded = true;
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
        public override List<Distributor> GetAllDistributorsDAL()
        {
            return distributorList;
        }

        /// <summary>
        /// Gets distributor based on DistributorID.
        /// </summary>
        /// <param name="searchDistributorID">Represents DistributorID to search.</param>
        /// <returns>Returns Distributor object.</returns>
        public override Distributor GetDistributorByDistributorIDDAL(Guid searchDistributorID)
        {
            Distributor matchingDistributor = null;
            try
            {
                //Find Distributor based on searchDistributorID
                matchingDistributor = distributorList.Find(
                    (item) => { return item.DistributorID == searchDistributorID; }
                );
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
        public override List<Distributor> GetDistributorsByNameDAL(string distributorName)
        {
            List<Distributor> matchingDistributors = new List<Distributor>();
            try
            {
                //Find All Distributors based on distributorName
                matchingDistributors = distributorList.FindAll(
                    (item) => { return item.DistributorName.Equals(distributorName, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributors;
        }

        /// <summary>
        /// Gets distributor based on email.
        /// </summary>
        /// <param name="email">Represents Distributor's Email Address.</param>
        /// <returns>Returns Distributor object.</returns>
        public override Distributor GetDistributorByEmailDAL(string email)
        {
            Distributor matchingDistributor = null;
            try
            {
                //Find Distributor based on Email and Password
                matchingDistributor = distributorList.Find(
                    (item) => { return item.Email.Equals(email); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributor;
        }

        /// <summary>
        /// Gets distributor based on Email and Password.
        /// </summary>
        /// <param name="email">Represents Distributor's Email Address.</param>
        /// <param name="password">Represents Distributor's Password.</param>
        /// <returns>Returns Distributor object.</returns>
        public override Distributor GetDistributorByEmailAndPasswordDAL(string email, string password)
        {
            Distributor matchingDistributor = null;
            try
            {
                //Find Distributor based on Email and Password
                matchingDistributor = distributorList.Find(
                    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                );
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
        public override bool UpdateDistributorDAL(Distributor updateDistributor)
        {
            bool distributorUpdated = false;
            try
            {
                //Find Distributor based on DistributorID
                Distributor matchingDistributor = GetDistributorByDistributorIDDAL(updateDistributor.DistributorID);

                if (matchingDistributor != null)
                {
                    //Update distributor details
                    ReflectionHelpers.CopyProperties(updateDistributor, matchingDistributor, new List<string>() { "DistributorName", "DistributorMobile", "Email" });
                    matchingDistributor.LastModifiedDateTime = DateTime.Now;

                    distributorUpdated = true;
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
        public override bool DeleteDistributorDAL(Guid deleteDistributorID)
        {
            bool distributorDeleted = false;
            try
            {
                //Find Distributor based on searchDistributorID
                Distributor matchingDistributor = distributorList.Find(
                    (item) => { return item.DistributorID == deleteDistributorID; }
                );

                if (matchingDistributor != null)
                {
                    //Delete Distributor from the collection
                    distributorList.Remove(matchingDistributor);
                    distributorDeleted = true;
                }
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
        public override bool UpdateDistributorPasswordDAL(Distributor updateDistributor)
        {
            bool passwordUpdated = false;
            try
            {
                //Find Distributor based on DistributorID
                Distributor matchingDistributor = GetDistributorByDistributorIDDAL(updateDistributor.DistributorID);

                if (matchingDistributor != null)
                {
                    //Update distributor details
                    ReflectionHelpers.CopyProperties(updateDistributor, matchingDistributor, new List<string>() { "Password" });
                    matchingDistributor.LastModifiedDateTime = DateTime.Now;

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



