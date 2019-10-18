using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample7
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Create data source 1
            List<Customer> customers = new List<Customer>()
            {
                new Customer() { CustomerID = 101, CustomerName = "Scott", Location = "Pune" },
                new Customer() { CustomerID = 102, CustomerName = "Smith", Location = "Bangalore" },
                new Customer() { CustomerID = 103, CustomerName = "Allen", Location = "Bangalore" },
                new Customer() { CustomerID = 104, CustomerName = "Jones", Location = "Pune" }
            };

            //Step 2: Create the LINQ Query (Extensions Methods and Lambda Expressions)
            Customer result =
                customers.ElementAtOrDefault(4);

            //Step 3: Execute the query --> get results
            if (result != null)
            {
                Console.WriteLine($"{result.CustomerID}, {result.CustomerName}, {result.Location}");
            }
            else
            {
                Console.WriteLine("No customer found");
            }
            

            Console.ReadKey();
        }
    }
}


