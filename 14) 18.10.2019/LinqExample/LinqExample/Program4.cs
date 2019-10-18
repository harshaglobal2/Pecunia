using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample4
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
            List<Customer> customers2019 = new List<Customer>()
            {
                new Customer() { CustomerID = 101, CustomerName = "Scott", Location = "Pune" },
                new Customer() { CustomerID = 102, CustomerName = "Smith", Location = "Bangalore" },
                new Customer() { CustomerID = 103, CustomerName = "Allen", Location = "Bangalore" },
                new Customer() { CustomerID = 104, CustomerName = "Jones", Location = "Pune" },
                new Customer() { CustomerID = 107, CustomerName = "Peter", Location = "Pune" }
            };

            //Step 1: Create data source 2
            List<Customer> customers2020 = new List<Customer>()
            {
                new Customer() { CustomerID = 104, CustomerName = "Jones", Location = "Pune" },
                new Customer() { CustomerID = 105, CustomerName = "John", Location = "Pune" },
                new Customer() { CustomerID = 106, CustomerName = "Ford", Location = "Bangalore" },
                new Customer() { CustomerID = 107, CustomerName = "Peter", Location = "Pune" },
            };


            //Step 2: Create the LINQ Query (Extensions Methods and Lambda Expressions)

            //Concat
            /*IEnumerable<Customer> result =
                customers2019
                .Concat(customers2020);*/


            //Distinct
            /*IEnumerable<string> result =
                customers2019
                .Select(c => c.Location)
                .Distinct();*/

            //Union
            /*IEnumerable<Customer> result =
                customers2019
                .Union(customers2020, new CustomerEqualityComparer());
            */

            IEnumerable<Customer> result =
                customers2019.AsEnumerable();

            //Step 3: Execute the query --> get results
            foreach (var item in result)
            {
                Console.WriteLine($"{item.CustomerID}, {item.CustomerName}, {item.Location}, {item.GetHashCode()}");
            }

            /*foreach (var item in result)
            {
                Console.WriteLine(item);
            }*/

            Console.ReadKey();
        }
    }

    public class CustomerEqualityComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            //Check all properties of both objects
            if (x.CustomerID == y.CustomerID && x.CustomerName.Equals(y.CustomerName) && x.Location.Equals(y.Location))
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


