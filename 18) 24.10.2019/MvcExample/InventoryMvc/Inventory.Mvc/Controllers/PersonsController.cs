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

            //Creating object of PersonsBL
            PersonsBL personBL = new PersonsBL();

            //Getting list of persons from PersonsBL
            List<Person> persons = personBL.GetPersons();

            //Add Persons to ViewBag
            ViewBag.PersonsList = new SelectList(persons, "PersonID", "PersonName");

            //Calling view & passing viewmodel object to view
            return View(personViewModel);
        }

        // URL: Persons/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel personVM)
        {
            //Create object of PersonsBL
            PersonsBL personBL = new PersonsBL();

            //Creating object of Person EntityModel
            Person person = new Person();
            person.PersonName = personVM.PersonName;
            person.Email = personVM.Email;
            person.Age = personVM.Age;

            //Invoke the AddPerson method BL
            (bool isAdded, Guid newGuid) = personBL.AddPerson(person);
            if (isAdded)
            {
                //Go to Index action method of Persons Controller
                return RedirectToAction("Index");
            }
            else
            {
                //Return plain html / plain string
                return Content("Person not added");
            }
        }

        public ActionResult Index()
        {
            //Creating object of PersonsBL
            PersonsBL personBL = new PersonsBL();

            //Getting list of persons from PersonsBL
            List<Person> persons = personBL.GetPersons();

            //Create an empty collection of PersonViewModel
            List<PersonViewModel> personsVM = new List<PersonViewModel>();

            //Migrate (copy) data from EntityModel collection to ViewModel collection
            foreach (var item in persons)
            {
                PersonViewModel personVM = new PersonViewModel() { PersonID = item.PersonID, PersonName = item.PersonName, Email = item.Email, Age = item.Age };
                personsVM.Add(personVM);
            }

            //Call view & pass personVM collection to view
            return View(personsVM);
        }

        // URL: Persons/Edit
        public ActionResult Edit(Guid id)
        {
            //Creating object of PersonsBL
            PersonsBL personBL = new PersonsBL();
            Person person = personBL.GetPersonByPersonID(id);


            //Creating object of Person into PersonViewModel
            PersonViewModel personVM = new PersonViewModel();
            personVM.PersonName = person.PersonName;
            personVM.Email = person.Email;
            personVM.Age = person.Age;
            
            //Getting list of persons from PersonsBL
            List<Person> persons = personBL.GetPersons();

            //Add Persons to ViewBag
            ViewBag.PersonsList = new SelectList(persons, "PersonID", "PersonName");

            return View(personVM);
        }
    }
}


