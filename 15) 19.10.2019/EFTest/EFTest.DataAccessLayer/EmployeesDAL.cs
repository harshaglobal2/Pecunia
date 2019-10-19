using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.DataAccessLayer
{
    public class EmployeesDAL
    {
        public List<Employee> GetEmployees()
        {
            using (companyEntities db = new companyEntities())
            {
                List<Employee> emps = db.Employees.ToList();
                return emps;
            }
        }

        public Employee GetEmployeeByEmployeeID(int EmpID)
        {
            using (companyEntities db = new companyEntities())
            {
                Employee emp = db.Employees.Where(e => e.EmpID == EmpID).FirstOrDefault();
                return emp;
            }
        }

        public (bool, Guid) InsertEmployee(Employee emp)
        {
            using (companyEntities db = new companyEntities())
            {
                emp.EmpID = Guid.NewGuid();
                //db.Employees.Add(emp);
                //db.SaveChanges();
                int n = db.InsertEmployee(emp.EmpID, emp.EmpName, emp.Salary);
            }

            return (true, emp.EmpID);
        }

        public bool UpdateEmployee(Employee emp)
        {
            using (companyEntities db = new companyEntities())
            {
                Employee existingEmployee = db.Employees.Where(temp => temp.EmpID == emp.EmpID).FirstOrDefault();

                if (existingEmployee == null)
                {
                    return false;
                }
                else
                {
                    existingEmployee.EmpName = emp.EmpName;
                    existingEmployee.Salary = emp.Salary;
                    db.SaveChanges();
                    return true;
                }
            }
        }


        public bool DeleteEmployee(Employee emp)
        {
            using (companyEntities db = new companyEntities())
            {
                Employee existingEmployee = db.Employees.Where(temp => temp.EmpID == emp.EmpID).FirstOrDefault();

                if (existingEmployee == null)
                {
                    return false;
                }
                else
                {
                    db.Employees.Remove(existingEmployee);
                    db.SaveChanges();
                    return true;
                }
            }
        }
    }
}

