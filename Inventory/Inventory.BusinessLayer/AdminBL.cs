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
    /// Contains data access layer methods for inserting, updating, deleting admins from Admins collection.
    /// </summary>
    public class AdminBL : BLBase<Admin>, IAdminBL, IDisposable
    {
        //fields
        AdminDALBase adminDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AdminBL()
        {
            this.adminDAL = new AdminDAL();
        }

        /// <summary>
        /// Gets admin based on AdminID.
        /// </summary>
        /// <param name="searchAdminID">Represents AdminID to search.</param>
        /// <returns>Returns Admin object.</returns>
        public async Task<Admin> GetAdminByAdminIDBL(Guid searchAdminID)
        {
            Admin matchingAdmin = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingAdmin = adminDAL.GetAdminByAdminIDDAL(searchAdminID);
                });
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
        public async Task<Admin> GetAdminByEmailAndPasswordBL(string email, string password)
        {
            Admin matchingAdmin = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingAdmin = adminDAL.GetAdminByEmailAndPasswordDAL(email, password);
                });
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
        public async Task<bool> UpdateAdminBL(Admin updateAdmin)
        {
            bool adminUpdated = false;
            try
            {
                if ((await Validate(updateAdmin)) && (await GetAdminByAdminIDBL(updateAdmin.AdminID)) != null)
                {
                    this.adminDAL.UpdateAdminDAL(updateAdmin);
                    adminUpdated = true;
                    Serialize();
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
        public async Task<bool> UpdateAdminPasswordBL(Admin updateAdmin)
        {
            bool passwordUpdated = false;
            try
            {
                if ((await Validate(updateAdmin)) && (await GetAdminByAdminIDBL(updateAdmin.AdminID)) != null)
                {
                    this.adminDAL.UpdateAdminPasswordDAL(updateAdmin);
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
            ((AdminDAL)adminDAL).Dispose();
        }

        /// <summary>
        /// Invokes Serialize method of DAL.
        /// </summary>
        public void Serialize()
        {
            try
            {
                AdminDAL.Serialize();
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
                AdminDAL.Deserialize();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}



