using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Entities
{
    public interface IEmployee
    {
         string EmployeeID { get; set; }
         string EmployeeName { get; set; }
         string EmployeeCode { get; set; }
         string EmployeeEmail { get; set; }
         string EmployeePassword { get; set; }
         string EmployeeMobile { get; set; }
    }
    [Serializable]
    public class Employee:IEmployee
    {
       //properties of Employee
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeMobile { get; set; }

        //Employee Constructor
        public Employee()
        {
            EmployeeID = string.Empty;
            EmployeeName = string.Empty;
            EmployeeCode = string.Empty;
            EmployeeEmail = string.Empty;
            EmployeePassword = string.Empty;
            EmployeeMobile = string.Empty;

        }
    }
}
