using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface IAdminBL : IDisposable
    {
        Task<Admin> GetAdminByEmailAndPasswordBL(string email, string password);
        Task<bool> UpdateAdminBL(Admin updateAdmin);
        Task<bool> UpdateAdminPasswordBL(Admin updateAdmin);
    }
}


