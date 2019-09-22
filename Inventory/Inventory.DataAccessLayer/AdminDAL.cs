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
    /// Contains data access layer methods for inserting, updating, deleting admins from Admins collection.
    /// </summary>
    public class AdminDAL : AdminDALBase, IDisposable
    {
        /// <summary>
        /// Constructor for AdminDAL
        /// </summary>
        public AdminDAL()
        {
            Serialize();
            Deserialize();
        }

        /// <summary>
        /// Gets admin based on AdminID.
        /// </summary>
        /// <param name="searchAdminID">Represents AdminID to search.</param>
        /// <returns>Returns Admin object.</returns>
        public override Admin GetAdminByAdminIDDAL(Guid searchAdminID)
        {
            Admin matchingAdmin = null;
            try
            {
                //Find Admin based on searchAdminID
                matchingAdmin = adminList.Find(
                    (item) => { return item.AdminID == searchAdminID; }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingAdmin;
        }
        
        /// <summary>
        /// Gets admin based on Password.
        /// </summary>
        /// <param name="email">Represents Admin's Email Address.</param>
        /// <param name="password">Represents Admin's Password.</param>
        /// <returns>Returns Admin object.</returns>
        public override Admin GetAdminByEmailAndPasswordDAL(string email, string password)
        {
            Admin matchingAdmin = null;
            try
            {
                //Find Admin based on Email and Password
                matchingAdmin = adminList.Find(
                    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingAdmin;
        }

        /// <summary>
        /// Updates admin based on AdminID.
        /// </summary>
        /// <param name="updateAdmin">Represents Admin details including AdminID, AdminName etc.</param>
        /// <returns>Determinates whether the existing admin is updated.</returns>
        public override bool UpdateAdminDAL(Admin updateAdmin)
        {
            bool adminUpdated = false;
            try
            {
                //Find Admin based on AdminID
                Admin matchingAdmin = GetAdminByAdminIDDAL(updateAdmin.AdminID);

                if (matchingAdmin != null)
                {
                    //Update admin details
                    ReflectionHelpers.CopyProperties(updateAdmin, matchingAdmin, new List<string>() { "AdminName", "Email" });
                    matchingAdmin.LastModifiedDateTime = DateTime.Now;

                    adminUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return adminUpdated;
        }

        /// <summary>
        /// Updates admin's password based on AdminID.
        /// </summary>
        /// <param name="updateAdmin">Represents Admin details including AdminID, Password.</param>
        /// <returns>Determinates whether the existing admin's password is updated.</returns>
        public override bool UpdateAdminPasswordDAL(Admin updateAdmin)
        {
            bool passwordUpdated = false;
            try
            {
                //Find Admin based on AdminID
                Admin matchingAdmin = GetAdminByAdminIDDAL(updateAdmin.AdminID);

                if (matchingAdmin != null)
                {
                    //Update admin details
                    ReflectionHelpers.CopyProperties(updateAdmin, matchingAdmin, new List<string>() { "Password" });
                    matchingAdmin.LastModifiedDateTime = DateTime.Now;

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



