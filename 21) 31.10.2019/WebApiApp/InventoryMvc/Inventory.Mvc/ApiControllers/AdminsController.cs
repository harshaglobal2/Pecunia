using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Inventory.Mvc.ApiControllers
{
    public class AdminsController : ApiController
    {
        public object Get(string email, string password)
        {
            return new { AdminName = "Admin" };
        }
    }
}
