using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;

namespace Capgemini.Inventory.DataAccessLayer
{
    public class PersonsDAL : IDisposable
    {
        public (bool, Guid) AddPerson(Person person)
        {
            //New Guid
            person.PersonID = Guid.NewGuid();

            //Invoke stored procedure
            using (company2Entities db = new company2Entities())
            {
                int affectedRowsCount = db.usp_CreatePersons(person.PersonID, person.PersonName, person.Email, person.Password, person.Age, person.DateOfJoining, person.Gender, person.IsRegistered, person.State);

                //return no. of rows effected
                if (affectedRowsCount >= 1)
                {
                    return (true, person.PersonID);
                }
                else
                {
                    return (false, person.PersonID);
                }
            }
        }

        public bool UpdatePerson(Person person)
        {
            //Invoke stored procedure
            using (company2Entities db = new company2Entities())
            {
                int affectedRowsCount = db.usp_UpdatePerson(person.PersonID, person.PersonName, person.Email, person.Age, person.DateOfJoining, person.Gender, person.IsRegistered, person.State);

                //return no. of rows effected
                if (affectedRowsCount >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeletePerson(Person person)
        {
            //Invoke stored procedure
            using (company2Entities db = new company2Entities())
            {
                int affectedRowsCount = db.usp_DeletePerson(person.PersonID);

                //return no. of rows effected
                if (affectedRowsCount >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Person> GetPersons()
        {
            //Invoke stored procedure
            using (company2Entities db = new company2Entities())
            {
                List<Person> persons = db.usp_GetPersons().ToList();
                return persons;
            }
        }


        public Person GetPersonByPersonID(Guid PersonID)
        {
            //Invoke stored procedure
            using (company2Entities db = new company2Entities())
            {
                Person person = db.usp_GetPersonByPersonID(PersonID).FirstOrDefault();
                return person;
            }
        }

        public void Dispose()
        {
        }
    }
}




