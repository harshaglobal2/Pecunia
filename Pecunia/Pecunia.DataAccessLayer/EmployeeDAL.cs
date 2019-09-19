using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.Exceptions;
using System.Data.Common;
using Newtonsoft.Json;
using System.IO;

namespace Pecunia.DataAccessLayer
{
    public interface IEmployeeDAL
    {
        List<Employee> EmployeeList { get; set; }
        bool EmployeeLogInDAL(Employee employee);
        bool AddEmployeeDAL(Employee newEmployee);
        List<Employee> GetAllEmployeesDAL();
        Employee SearchEmployeeDAL(string searchEmployeeID);
        List<Employee> GetEmployeesByNameDAL(string employeeName);
        bool UpdateEmployeeDAL(Employee updateEmployee);
        bool DeleteEmployeeDAL(string deleteEmployeeID);
    }
    [Serializable]
    public class EmployeeDAL : IEmployeeDAL
    {        
       public List<Employee> EmployeeList { get; set; }
                  
        public bool EmployeeLogInDAL(Employee employee)
        {
            bool employeeLogin = false;
            try
            {
                foreach(Employee emp in EmployeeList)
                {
                    if (employee.EmployeeID == emp.EmployeeID && employee.EmployeeCode == emp.EmployeeCode && employee.EmployeePassword == emp.EmployeePassword)
                    {
                        employeeLogin = true;
                    }
                }                
            }
            catch (PecuniaException)
            {
                throw;
            }
            return employeeLogin;
        }

        public bool AddEmployeeDAL(Employee newEmployee)
        {
            DateTime time = DateTime.Now;
            string employeeID = "EMP" + time.ToString("yyyyMMddhhmmss");    //generating a unique employee ID
            newEmployee.EmployeeID = employeeID;
            string employeeCode = "EMC" + time.ToString("yyyyMMddhhmmss");  //generating a unique employee code
            newEmployee.EmployeeCode = employeeCode;

            bool employeeAdded = false;
            try
            {
                EmployeeList.Add(newEmployee);          //adding new employee to the list
                employeeAdded = true;
                string fileName = "EmployeeData.txt";
                SerializeIntoJSON(EmployeeList, fileName);
            }
            catch (PecuniaException)
            {
                throw;
            }
            return employeeAdded;

        }

        public List<Employee> GetAllEmployeesDAL()
        {
            string fileName = "EmployeeData.txt";
            DeserializeFromJSON(fileName);
            return EmployeeList;
        }

        public Employee SearchEmployeeDAL(string searchEmployeeID)
        {
            Employee searchEmployee = null;
            try
            {
                foreach (Employee item in EmployeeList)             //searching employee through employeeID in list
                {
                    if (item.EmployeeID == searchEmployeeID)
                    {
                        searchEmployee = item;
                    }
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            return searchEmployee;
        }

        public List<Employee> GetEmployeesByNameDAL(string employeeName)
        {
            List<Employee> searchEmployee = new List<Employee>();
            try
            {
                foreach (Employee item in EmployeeList)
                {
                    if (item.EmployeeName == employeeName)              //searching employee by employee name in list
                    {
                        searchEmployee.Add(item);
                    }
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            return searchEmployee;
        }

        public bool UpdateEmployeeDAL(Employee updateEmployee)
        {
            bool employeeUpdated = false;
            try
            {
                for (int i = 0; i < EmployeeList.Count; i++)
                {
                    if (EmployeeList[i].EmployeeID == updateEmployee.EmployeeID)               //matching employeeID in list with user provided employeeID
                    {
                        updateEmployee.EmployeeName = EmployeeList[i].EmployeeName;            //updating  employee name
                        updateEmployee.EmployeeEmail = EmployeeList[i].EmployeeEmail;          //updating  employee email
                        updateEmployee.EmployeePassword = EmployeeList[i].EmployeePassword;    //updating  employee password
                        updateEmployee.EmployeeMobile = EmployeeList[i].EmployeeMobile;        //updating  employee mobile

                        employeeUpdated = true;
                    }
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            return employeeUpdated;

        }

        public bool DeleteEmployeeDAL(string deleteEmployeeID)
        {
            bool employeeDeleted = false;
            try
            {
                Employee deleteEmployee = null;
                foreach (Employee item in EmployeeList)
                {
                    if (item.EmployeeID == deleteEmployeeID)       //matching employeeID in list with the user provided employeeID
                    {
                        deleteEmployee = item;
                    }
                }

                if (deleteEmployee != null)
                {
                    EmployeeList.Remove(deleteEmployee);         //removing employee from the list    
                    employeeDeleted = true;
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            return employeeDeleted;
        }

        public bool SerializeIntoJSON(List<Employee> EmployeeList, string fileName)
        {            
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(fileName))   //filename is used so that we can have access over our own file
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                jsonSerializer.Serialize(jsonWriter, EmployeeList); // Serialize Employee data in EmployeeData.txt
                return true;
            }                   
        }

        public List<Employee> DeserializeFromJSON(string fileName)
        {
            List<Employee> EmployeeList = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(fileName));// Done to read data from file
            using (StreamReader streamReader = File.OpenText(fileName))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                List<Employee> readEmployeeList = (List<Employee>)jsonSerializer.Deserialize(streamReader, typeof(List<Employee>));
                return readEmployeeList;
            }
        }

    }
}
