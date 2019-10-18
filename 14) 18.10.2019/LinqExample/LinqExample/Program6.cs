using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample6
{
    public interface IPerson
    {
        string Name { get; set; }
    }

    public class Customer : IPerson
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class Employee : IPerson
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Create data source 1
            List<IPerson> persons = new List<IPerson>()
            {
                new Customer() { CustomerID = 101, Name = "Scott", Location = "Pune" },
                new Employee() { EmployeeID = 102, Name = "Smith", Salary = 4000 },
                new Customer() { CustomerID = 103, Name = "Allen", Location = "Bangalore" },
                new Customer() { CustomerID = 104, Name = "Jones", Location = "Pune" },
                new Employee() { EmployeeID = 107, Name = "Peter", Salary = 6000 }
            };

            //Step 2: Create the LINQ Query (Extensions Methods and Lambda Expressions)
            IPerson[] result =
                persons.ToArray();

            //Step 3: Execute the query --> get results
            foreach (var item in result)
            {
                if (item is Customer cust)
                {
                    Console.WriteLine($"{cust.CustomerID}, {cust.Name}, {cust.Location}");
                }
                else if (item is Employee emp)
                {
                    Console.WriteLine($"{emp.EmployeeID}, {emp.Name}, {emp.Salary}");
                }
            }

            Console.ReadKey();
        }
    }

    public class CustomerEqualityComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            //Check all properties of both objects
            if (x.CustomerID == y.CustomerID && x.Name.Equals(y.Name) && x.Location.Equals(y.Location))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Customer obj)
        {
            return obj.CustomerID.GetHashCode();
        }
    }
}


