using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface ISupplierBL
    {
        bool AddSupplierBL(Supplier newSupplier);
        List<Supplier> GetAllSuppliersBL();
        Supplier GetSupplierBySupplierIDBL(Guid searchSupplierID);
        List<Supplier> GetSuppliersByNameBL(string supplierName);
        Supplier GetSupplierByEmailAndPasswordBL(string email, string password);
        bool UpdateSupplierBL(Supplier updateSupplier);
        bool DeleteSupplierBL(Guid deleteSupplierID);
    }
}


