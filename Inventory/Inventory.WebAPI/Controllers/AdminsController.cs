using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Capgemini.Inventory.BusinessLayer;
using Capgemini.Inventory.Contracts.BLContracts;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;

namespace Inventory.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AdminsController : ApiController
    {
        private IAdminBL adminBL;

        public AdminsController()
        {
            adminBL = new AdminBL();
        }
        
        [HttpPost]
        [Route("Admins/GetAdminByEmailAndPassword")]
        public async Task<Admin> GetAdminByEmailAndPassword(string email, string password)
        {
            try
            {
                return await adminBL.GetAdminByEmailAndPasswordBL(email, password);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                throw;
            }
        }
    }
}


