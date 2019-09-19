using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface ISystemUserBL
    {
        Task<bool> AddSystemUserBL(SystemUser newSystemUser);
        List<SystemUser> GetAllSystemUsersBL();
        SystemUser GetSystemUserBySystemUserIDBL(Guid searchSystemUserID);
        List<SystemUser> GetSystemUsersByNameBL(string supplierName);
        SystemUser GetSystemUserByEmailAndPasswordBL(string email, string password);
        bool UpdateSystemUserBL(SystemUser updateSystemUser);
        bool DeleteSystemUserBL(Guid deleteSystemUserID);
    }
}


