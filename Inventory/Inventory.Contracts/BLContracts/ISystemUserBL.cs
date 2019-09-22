using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface ISystemUserBL : IDisposable
    {
        Task<bool> AddSystemUserBL(SystemUser newSystemUser);
        Task<List<SystemUser>> GetAllSystemUsersBL();
        Task<SystemUser> GetSystemUserBySystemUserIDBL(Guid searchSystemUserID);
        Task<List<SystemUser>> GetSystemUsersByNameBL(string supplierName);
        Task<SystemUser> GetSystemUserByEmailBL(string email);
        Task<SystemUser> GetSystemUserByEmailAndPasswordBL(string email, string password);
        Task<bool> UpdateSystemUserBL(SystemUser updateSystemUser);
        Task<bool> UpdateSystemUserPasswordBL(SystemUser updateSystemUser);
        Task<bool> DeleteSystemUserBL(Guid deleteSystemUserID);
    }
}


