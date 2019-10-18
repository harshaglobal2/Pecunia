using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer() { CustomerID = 101, CustomerName = "Scott", Location = "Mumbai" },
                new Customer() { CustomerID = 102, CustomerName = "Smith", Location = "Bangalore" },
                new Customer() { CustomerID = 103, CustomerName = "Allen", Location = "Pune" },
                new Customer() { CustomerID = 104, CustomerName = "Jones", Location = "Bangalore" }
            };

            customers.FindAll((customer) => customer.Location == "Bangalore");

            //Standard Query Syntax
            List<Customer> matchingCustomers =
                (from c
                in customers
                where c.Location == "Bangalore"
                orderby c.CustomerName
                select c).ToList();

            //Extension Methods and Lambda Expression Syntax
            List<Customer> matchingCustomers2 =
                customers
                .Where(c => c.Location == "Bangalore")
                .OrderBy(c => c.CustomerName)
                .ToList();

            foreach (var item in matchingCustomers)
            {
                Console.WriteLine($"{item.CustomerID},{item.CustomerName},{item.Location}");
            }

            Console.ReadKey();
        }
    }
}
