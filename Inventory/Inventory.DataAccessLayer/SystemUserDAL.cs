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
    /// Contains data access layer methods for inserting, updating, deleting systemUsers from SystemUsers collection.
    /// </summary>
    public class SystemUserDAL : SystemUserDALBase, IDisposable
    {
        /// <summary>
        /// Adds new systemUser to SystemUsers collection.
        /// </summary>
        /// <param name="newSystemUser">Contains the systemUser details to be added.</param>
        /// <returns>Determinates whether the new systemUser is added.</returns>
        public override bool AddSystemUserDAL(SystemUser newSystemUser)
        {
            bool systemUserAdded = false;
            try
            {
                newSystemUser.SystemUserID = Guid.NewGuid();
                newSystemUser.CreationDateTime = DateTime.Now;
                newSystemUser.LastModifiedDateTime = DateTime.Now;
                systemUserList.Add(newSystemUser);
                systemUserAdded = true;
            }
            catch (Exception)
            {
                throw;
            }
            return systemUserAdded;
        }

        /// <summary>
        /// Gets all systemUsers from the collection.
        /// </summary>
        /// <returns>Returns list of all systemUsers.</returns>
        public override List<SystemUser> GetAllSystemUsersDAL()
        {
            return systemUserList;
        }

        /// <summary>
        /// Gets systemUser based on SystemUserID.
        /// </summary>
        /// <param name="searchSystemUserID">Represents SystemUserID to search.</param>
        /// <returns>Returns SystemUser object.</returns>
        public override SystemUser GetSystemUserBySystemUserIDDAL(Guid searchSystemUserID)
        {
            SystemUser matchingSystemUser = null;
            try
            {
                //Find SystemUser based on searchSystemUserID
                matchingSystemUser = systemUserList.Find(
                    (item) => { return item.SystemUserID == searchSystemUserID; }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSystemUser;
        }

        /// <summary>
        /// Gets systemUser based on SystemUserName.
        /// </summary>
        /// <param name="systemUserName">Represents SystemUserName to search.</param>
        /// <returns>Returns SystemUser object.</returns>
        public override List<SystemUser> GetSystemUsersByNameDAL(string systemUserName)
        {
            List<SystemUser> matchingSystemUsers = new List<SystemUser>();
            try
            {
                //Find All SystemUsers based on systemUserName
                matchingSystemUsers = systemUserList.FindAll(
                    (item) => { return item.SystemUserName.Equals(systemUserName, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSystemUsers;
        }

        /// <summary>
        /// Gets systemUser based on Password.
        /// </summary>
        /// <param name="email">Represents SystemUser's Email Address.</param>
        /// <param name="password">Represents SystemUser's Password.</param>
        /// <returns>Returns SystemUser object.</returns>
        public override SystemUser GetSystemUserByEmailAndPasswordDAL(string email, string password)
        {
            SystemUser matchingSystemUser = null;
            try
            {
                //Find SystemUser based on Email and Password
                matchingSystemUser = systemUserList.Find(
                    (item) => { return item.SystemUserEmail.Equals(email) && item.SystemUserPassword.Equals(password); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSystemUser;
        }

        /// <summary>
        /// Updates systemUser based on SystemUserID.
        /// </summary>
        /// <param name="updateSystemUser">Represents SystemUser details including SystemUserID, SystemUserName etc.</param>
        /// <returns>Determinates whether the existing systemUser is updated.</returns>
        public override bool UpdateSystemUserDAL(SystemUser updateSystemUser)
        {
            bool systemUserUpdated = false;
            try
            {
                //Find SystemUser based on SystemUserID
                SystemUser matchingSystemUser = GetSystemUserBySystemUserIDDAL(updateSystemUser.SystemUserID);

                if (matchingSystemUser != null)
                {
                    //Update systemUser details
                    ReflectionHelpers.CopyProperties(updateSystemUser, matchingSystemUser, new List<string>() { "SystemUserName", "SystemUserMobile", "SystemUserEmail" });
                    matchingSystemUser.LastModifiedDateTime = DateTime.Now;

                    systemUserUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return systemUserUpdated;
        }

        /// <summary>
        /// Deletes systemUser based on SystemUserID.
        /// </summary>
        /// <param name="deleteSystemUserID">Represents SystemUserID to delete.</param>
        /// <returns>Determinates whether the existing systemUser is updated.</returns>
        public override bool DeleteSystemUserDAL(Guid deleteSystemUserID)
        {
            bool systemUserDeleted = false;
            try
            {
                //Find SystemUser based on searchSystemUserID
                SystemUser matchingSystemUser = systemUserList.Find(
                    (item) => { return item.SystemUserID == deleteSystemUserID; }
                );

                if (matchingSystemUser != null)
                {
                    //Delete SystemUser from the collection
                    systemUserList.Remove(matchingSystemUser);
                    systemUserDeleted = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return systemUserDeleted;
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



