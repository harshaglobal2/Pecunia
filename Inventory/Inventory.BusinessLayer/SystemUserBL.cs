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
        /// Validations on data before adding or updating.
        /// </summary>
        /// <param name="entityObject">Represents object to be validated.</param>
        /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
        protected async override Task<bool> Validate(SystemUser entityObject)
        {
            //Create string builder
            StringBuilder sb = new StringBuilder();
            bool valid = await base.Validate(entityObject);

            //Email is Unique
            if ((await GetSystemUserByEmailBL(entityObject.Email)) != null)
            {
                valid = false;
                sb.Append(Environment.NewLine + $"Email {entityObject.Email} already exists");
            }

            if (valid == false)
                throw new InventoryException(sb.ToString());
            return valid;
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
                if (await Validate(newSystemUser))
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
        public async Task<List<SystemUser>> GetAllSystemUsersBL()
        {
            List<SystemUser> systemUsersList = null;
            try
            {
                await Task.Run(() =>
                {
                    systemUsersList = systemUserDAL.GetAllSystemUsersDAL();
                });
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
        public async Task<SystemUser> GetSystemUserBySystemUserIDBL(Guid searchSystemUserID)
        {
            SystemUser matchingSystemUser = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSystemUser = systemUserDAL.GetSystemUserBySystemUserIDDAL(searchSystemUserID);
                });
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
        public async Task<List<SystemUser>> GetSystemUsersByNameBL(string systemUserName)
        {
            List<SystemUser> matchingSystemUsers = new List<SystemUser>();
            try
            {
                await Task.Run(() =>
                {
                    matchingSystemUsers = systemUserDAL.GetSystemUsersByNameDAL(systemUserName);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSystemUsers;
        }

        /// <summary>
        /// Gets systemUser based on Email and Password.
        /// </summary>
        /// <param name="email">Represents SystemUser's Email Address.</param>
        /// <returns>Returns SystemUser object.</returns>
        public async Task<SystemUser> GetSystemUserByEmailBL(string email)
        {
            SystemUser matchingSystemUser = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSystemUser = systemUserDAL.GetSystemUserByEmailDAL(email);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSystemUser;
        }

        /// <summary>
        /// Gets systemUser based on Password.
        /// </summary>
        /// <param name="email">Represents SystemUser's Email Address.</param>
        /// <param name="password">Represents SystemUser's Password.</param>
        /// <returns>Returns SystemUser object.</returns>
        public async Task<SystemUser> GetSystemUserByEmailAndPasswordBL(string email, string password)
        {
            SystemUser matchingSystemUser = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSystemUser = systemUserDAL.GetSystemUserByEmailAndPasswordDAL(email, password);
                });
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
        public async Task<bool> UpdateSystemUserBL(SystemUser updateSystemUser)
        {
            bool systemUserUpdated = false;
            try
            {
                if ((await Validate(updateSystemUser)) && (await GetSystemUserBySystemUserIDBL(updateSystemUser.SystemUserID)) != null)
                {
                    this.systemUserDAL.UpdateSystemUserDAL(updateSystemUser);
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
        public async Task<bool> DeleteSystemUserBL(Guid deleteSystemUserID)
        {
            bool systemUserDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    systemUserDeleted = systemUserDAL.DeleteSystemUserDAL(deleteSystemUserID);
                    Serialize();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return systemUserDeleted;
        }

        /// <summary>
        /// Updates systemUser's password based on SystemUserID.
        /// </summary>
        /// <param name="updateSystemUser">Represents SystemUser details including SystemUserID, Password.</param>
        /// <returns>Determinates whether the existing systemUser's password is updated.</returns>
        public async Task<bool> UpdateSystemUserPasswordBL(SystemUser updateSystemUser)
        {
            bool passwordUpdated = false;
            try
            {
                if ((await Validate(updateSystemUser)) && (await GetSystemUserBySystemUserIDBL(updateSystemUser.SystemUserID)) != null)
                {
                    this.systemUserDAL.UpdateSystemUserPasswordDAL(updateSystemUser);
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



