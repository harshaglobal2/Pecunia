using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capgemini.GreatOutdoors.BusinessLogicLayer;
using Inventory.Entities;
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

        // URL: Persons/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel personVM)
        {
            PersonsBL personBL = new PersonsBL();
            Person person = new Person();
            person.PersonName = personVM.PersonName;
            person.Email = personVM.Email;
            person.Age = personVM.Age;

            (bool isAdded, Guid newGuid) = personBL.AddPerson(person);
            if (isAdded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Person not added");
            }
        }

        public ActionResult Index()
        {
            PersonsBL personBL = new PersonsBL();
            List<Person> persons = personBL.GetPersons();
            List<PersonViewModel> personsVM = new List<PersonViewModel>();

            foreach (var item in persons)
            {
                PersonViewModel personVM = new PersonViewModel() { PersonID = item.PersonID, PersonName = item.PersonName, Email = item.Email, Age = item.Age };
                personsVM.Add(personVM);
            }
            return View(personsVM);
        }
    }
}


