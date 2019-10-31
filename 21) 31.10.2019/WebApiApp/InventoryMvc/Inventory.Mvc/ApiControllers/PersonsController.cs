using Capgemini.GreatOutdoors.BusinessLogicLayer;
using Inventory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inventory.Mvc.ApiControllers
{
    public class PersonsController : ApiController
    {
        private PersonsBL personsBL;

        public PersonsController()
        {
            personsBL = new PersonsBL();
        }

        //      api/persons
        public List<Person> GetPersons()
        {
            return this.personsBL.GetPersons();
        }

        //      api/persons?id=101
        public Person GetPersonByPersonID(Guid id)
        {
            return this.personsBL.GetPersonByPersonID(id);
        }

        //      api/persons
        public bool PostPerson(Person person)
        {
            return this.personsBL.AddPerson(person).Item1;
        }

        //      api/persons
        public bool PutPerson(Person person)
        {
            return this.personsBL.UpdatePerson(person);
        }

        //      api/persons?id=101
        [HttpDelete]
        public bool Abc(Guid id)
        {
            return this.personsBL.DeletePerson(id);
        }
    }
}


