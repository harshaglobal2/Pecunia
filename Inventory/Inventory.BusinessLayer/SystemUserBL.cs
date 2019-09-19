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
    /// Contains data access layer methods for inserting, updating, deleting systemUsers from SystemUsers collection.
    /// </summary>
    public class SystemUserBL : BLBase<SystemUser>, ISystemUserBL, IDisposable
    {
        //fields
        SystemUserDALBase systemUserDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SystemUserBL()
        {
            this.systemUserDAL = new SystemUserDAL();
        }

        /// <summary>
        /// Adds new systemUser to SystemUsers collection.
        /// </summary>
        /// <param name="newSystemUser">Contains the systemUser details to be added.</param>
        /// <returns>Determinates whether the new systemUser is added.</returns>
        public async Task<bool> AddSystemUserBL(SystemUser newSystemUser)
        {
            bool systemUserAdded = false;
            try
            {
                if (Validate(newSystemUser))
                {
                    await Task.Run(() =>
                    {
                        this.systemUserDAL.AddSystemUserDAL(newSystemUser);
                        systemUserAdded = true;
                        Serialize();
                    });
                }
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
        public List<SystemUser> GetAllSystemUsersBL()
        {
            List<SystemUser> systemUsersList = null;
            try
            {
                systemUsersList = systemUserDAL.GetAllSystemUsersDAL();
            }
            catch (Exception)
            {
                throw;
            }
            return systemUsersList;
        }

        /// <summary>
        /// Gets systemUser based on SystemUserID.
        /// </summary>
        /// <param name="searchSystemUserID">Represents SystemUserID to search.</param>
        /// <returns>Returns SystemUser object.</returns>
        public SystemUser GetSystemUserBySystemUserIDBL(Guid searchSystemUserID)
        {
            SystemUser matchingSystemUser = null;
            try
            {
                matchingSystemUser = systemUserDAL.GetSystemUserBySystemUserIDDAL(searchSystemUserID);
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
        public List<SystemUser> GetSystemUsersByNameBL(string systemUserName)
        {
            List<SystemUser> matchingSystemUsers = new List<SystemUser>();
            try
            {
                matchingSystemUsers = systemUserDAL.GetSystemUsersByNameDAL(systemUserName);
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
        public SystemUser GetSystemUserByEmailAndPasswordBL(string email, string password)
        {
            SystemUser matchingSystemUser = null;
            try
            {
                matchingSystemUser = systemUserDAL.GetSystemUserByEmailAndPasswordDAL(email, password);
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
        public bool UpdateSystemUserBL(SystemUser updateSystemUser)
        {
            bool systemUserUpdated = false;
            try
            {
                if (Validate(updateSystemUser) && GetSystemUserBySystemUserIDBL(updateSystemUser.SystemUserID) != null)
                {
                    this.systemUserDAL.AddSystemUserDAL(updateSystemUser);
                    systemUserUpdated = true;
                    Serialize();
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
        public bool DeleteSystemUserBL(Guid deleteSystemUserID)
        {
            bool systemUserDeleted = false;
            try
            {
                systemUserDeleted = systemUserDAL.DeleteSystemUserDAL(deleteSystemUserID);
                Serialize();
            }
            catch (Exception)
            {
                throw;
            }
            return systemUserDeleted;
        }

        /// <summary>
        /// Disposes DAL object(s).
        /// </summary>
        public void Dispose()
        {
            ((SystemUserDAL)systemUserDAL).Dispose();
        }

        /// <summary>
        /// Invokes Serialize method of DAL.
        /// </summary>
        public void Serialize()
        {
            try
            {
                SystemUserDAL.Serialize();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///Invokes Deserialize method of DAL.
        /// </summary>
        public void Deserialize()
        {
            try
            {
                SystemUserDAL.Deserialize();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}



