using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample2
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
                new Customer() { CustomerID = 101, CustomerName = "Scott", Location = "Pune" },
                new Customer() { CustomerID = 102, CustomerName = "Smith", Location = "Bangalore" },
                new Customer() { CustomerID = 103, CustomerName = "Allen", Location = "Bangalore" },
                new Customer() { CustomerID = 104, CustomerName = "Jones", Location = "Pune" },
                new Customer() { CustomerID = 105, CustomerName = "Jones", Location = "Pune" },
                new Customer() { CustomerID = 106, CustomerName = "Jones", Location = "Bangalore" }
            };
            

            //Standard Query Syntax
            List<IGrouping<string, Customer>> matchingCustomers =
                (from c
                in customers
                orderby c.Location
                group c by c.Location).ToList();

            //Extension Methods and Lambda Expression Syntax
            List<IGrouping<string, Customer>> matchingCustomers2 =
                customers
                .OrderBy(c=> c.Location)
                .GroupBy(c => c.Location)
                .ToList();

            foreach (var item in matchingCustomers)
            {
                Console.WriteLine(item.Key); //???
                foreach (var item2 in item)
                {
                    Console.WriteLine($"{item2.CustomerID},{item2.CustomerName},{item2.Location}");
                }
                Console.WriteLine();
            }
            

            Console.ReadKey();
        }
    }
}
