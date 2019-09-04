using System;
using System.Collections.Generic;

namespace EventExample
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string GetCustomerNameUpperCase() => CustomerName.ToUpper();
    }

    //Provider (or) Publisher
    class CustomersService
    {
        public List<Customer> Customers;

        public CustomersService() => Customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            CustomerAdded(); //raise event
        }

        //event
        public event Action CustomerAdded;
    }

    //Subscriber
    class CustomersCounter
    {
        public int CustomersCount { get; set; }
        public CustomersService customersService = new CustomersService();

        public CustomersCounter() =>
            customersService.CustomerAdded += () =>
            {
                CustomersCount++;
            };        
    }

    class Program
    {
        static void Main()
        {
            CustomersCounter customersCounter = new CustomersCounter();
        }
    }
}
