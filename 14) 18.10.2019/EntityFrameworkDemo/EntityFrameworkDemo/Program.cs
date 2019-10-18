using Company.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            companyEntities entites = new companyEntities();
            List<Employee> employees = entites.Employees.ToList();

            foreach (var item in employees)
            {
                Console.WriteLine($"{item.EmpID},{item.EmpName}");
            }

            Console.ReadKey();
        }
    }
}
