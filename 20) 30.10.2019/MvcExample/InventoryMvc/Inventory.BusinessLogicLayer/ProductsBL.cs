using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Inventory.DataAccessLayer;
using Inventory.Entities;

namespace Capgemini.GreatOutdoors.BusinessLogicLayer
{
    public class PersonsBL : IDisposable
    {
        public (bool, Guid) AddPerson(Person person)
        {
            using (PersonsDAL personsDAL = new PersonsDAL())
            {
                return personsDAL.AddPerson(person);
            }
        }

        public bool UpdatePerson(Person person)
        {
            using (PersonsDAL personsDAL = new PersonsDAL())
            {
                return personsDAL.UpdatePerson(person);
            }
        }

        public bool DeletePerson(Person person)
        {
            using (PersonsDAL personsDAL = new PersonsDAL())
            {
                return personsDAL.DeletePerson(person);
            }
        }

        public List<Person> GetPersons()
        {
            using (PersonsDAL personsDAL = new PersonsDAL())
            {
                return personsDAL.GetPersons();
            }
        }


        public Person GetPersonByPersonID(Guid PersonID)
        {
            using (PersonsDAL personsDAL = new PersonsDAL())
            {
                return personsDAL.GetPersonByPersonID(PersonID);
            }
        }

        public void Dispose()
        {
        }
    }
}



