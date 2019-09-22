using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface IDistributorBL : IDisposable
    {
        Task<bool> AddDistributorBL(Distributor newDistributor);
        Task<List<Distributor>> GetAllDistributorsBL();
        Task<Distributor> GetDistributorByDistributorIDBL(Guid searchDistributorID);
        Task<List<Distributor>> GetDistributorsByNameBL(string distributorName);
        Task<Distributor> GetDistributorByEmailBL(string email);
        Task<Distributor> GetDistributorByEmailAndPasswordBL(string email, string password);
        Task<bool> UpdateDistributorBL(Distributor updateDistributor);
        Task<bool> UpdateDistributorPasswordBL(Distributor updateDistributor);
        Task<bool> DeleteDistributorBL(Guid deleteDistributorID);
    }
}


