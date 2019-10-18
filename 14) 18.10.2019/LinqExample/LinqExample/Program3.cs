using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample3
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public double? Amount { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Create data source
            List<Customer> customers = new List<Customer>()
            {
                new Customer() { CustomerID = 101, CustomerName = "Scott", Location = "Pune", Amount = 4500 },
                new Customer() { CustomerID = 102, CustomerName = "Smith", Location = "Bangalore", Amount = 7800 },
                new Customer() { CustomerID = 103, CustomerName = "Allen", Location = "Bangalore", Amount = 2100 },
                new Customer() { CustomerID = 104, CustomerName = "Jones", Location = "Pune", Amount = 3355 },
                new Customer() { CustomerID = 105, CustomerName = "John", Location = "Pune", Amount = 9410 },
                new Customer() { CustomerID = 106, CustomerName = "Ford", Location = "Bangalore", Amount = null }
            };


            //Step 2: Create the LINQ Query (Extensions Methods and Lambda Expressions)

            //Select
            /*IEnumerable<string> result =
                customers
                .Select(c => c.CustomerName);*/

            //OrderBy
            /*IEnumerable<Customer> result =
                customers
                .OrderBy(c => c.CustomerName);*/

            //OrderByDescending
            IEnumerable<Customer> result =
                customers
                .OrderBy(c => c.Location)
                .ThenBy(c => c.CustomerName);

            //Reverse
            //customers.Reverse();

            //Aggregation
            /*double? sum = customers.Select(c => c.Amount).Sum();
            double? avg = customers.Select(c => c.Amount).Average();
            double? max = customers.Select(c => c.Amount).Max();
            double? min = customers.Select(c => c.Amount).Min();
            double? count = customers.Select(c => c.Amount).Count();

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {avg}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Count: {count}");*/

            //Step 3: Execute the query --> get results
            foreach (var item in customers)
            {
                Console.WriteLine($"{item.CustomerID}, {item.CustomerName}, {item.Location}");
            }

            Console.ReadKey();
        }
    }
}
