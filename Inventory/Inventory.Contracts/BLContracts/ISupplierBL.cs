using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface ISupplierBL : IDisposable
    {
        Task<bool> AddSupplierBL(Supplier newSupplier);
        Task<List<Supplier>> GetAllSuppliersBL();
        Task<Supplier> GetSupplierBySupplierIDBL(Guid searchSupplierID);
        Task<List<Supplier>> GetSuppliersByNameBL(string supplierName);
        Task<Supplier> GetSupplierByEmailBL(string email);
        Task<Supplier> GetSupplierByEmailAndPasswordBL(string email, string password);
        Task<bool> UpdateSupplierBL(Supplier updateSupplier);
        Task<bool> UpdateSupplierPasswordBL(Supplier updateSupplier);
        Task<bool> DeleteSupplierBL(Guid deleteSupplierID);
    }
}


