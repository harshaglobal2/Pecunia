using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Mvc.Models;

namespace Inventory.Mvc.Controllers
{
    public class PersonsController : Controller
    {
        // URL: Persons/Create
        public ActionResult Create()
        {
            //Creating and initializing viewmodel object
            PersonViewModel personViewModel = new PersonViewModel()
            {
                PersonName = "Harsha",
                DateOfJoining = DateTime.Now
            };

            //Calling view & passing viewmodel object to view
            return View(personViewModel);
        }
    }
}