using System;
using System.Collections.Generic;
using Pecunia.Entities;
using Pecunia.Exceptions;
using System.Text.RegularExpressions;

namespace Pecunia.DataAccessLayer
{
    public class CustomerDAL
    {
        public static List<CustomerEntities> Customers; // list of customers is created by passing CustomerEntities class as data type 
        public bool AddCustomerDAL(CustomerEntities c)
        {
            try
            {
                DateTime Time = DateTime.Now;
                string customerID = Time.ToString("yyyyMMddhhmmss");
                c.CustomerID = customerID;
                Customers.Add(c);  //Customer is added in the list

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveCustomerDAL(string CustomerID)
        {
            try
            {
                //foreach(dataType variable in collectionName)
                foreach (CustomerEntities cust in Customers)
                {
                    if (cust.CustomerID.Equals(CustomerID) == true)
                    {
                        Customers.Remove(cust);
                        break;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public CustomerEntities GetCustomerByCustomerID_DAL(string CustomerID)
        {
            try
            {
                foreach (CustomerEntities cust in Customers)
                {
                    if (cust.CustomerID.Equals(CustomerID) == true)
                    {
                        Console.WriteLine("Customer Name :-" + cust.CustomerName);
                        Console.WriteLine("Customer Address :-" + cust.CustomerAddress);
                        Console.WriteLine("Customer Mobile no :-" + cust.CustomerMobile);
                        Console.WriteLine("Customer Email :-" + cust.CustomerEmail);
                        Console.WriteLine("Customer Pan :-" + cust.CustomerPan);
                        return cust;
                    }
                }
                //if customerID not found
                CustomerEntities c = new CustomerEntities();
                return c;
            }
            catch (Exception e)
            {
                CustomerEntities c = new CustomerEntities();
                return c;
            }
        }
        public void DisplayAllCustomerDAL()
        {
            foreach (CustomerEntities cust in Customers)
            {
                Console.WriteLine("Customer ID :-" + cust.CustomerID);
                Console.WriteLine("Customer Name :-" + cust.CustomerName);
                Console.WriteLine("Customer Address :-" + cust.CustomerAddress);
                Console.WriteLine("Customer Mobile no :-" + cust.CustomerMobile);
                Console.WriteLine("Customer Email :-" + cust.CustomerEmail);
                Console.WriteLine("Customer Pan :-" + cust.CustomerPan);
            }
        }

        public void UpdateCustomerByCustomerID_DAL(string CustomerID)
        {
            try
            {
                foreach (CustomerEntities cust in Customers)
                {
                    if (cust.CustomerID.Equals(CustomerID) == true)
                    {
                        Console.WriteLine("Enter Customer Name ");
                        cust.CustomerName = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerName, "^[a-zA-Z]$") == false)
                        {
                            throw new InvalidStringException("not a valid name");
                        }

                        Console.WriteLine("Enter Customer Address");
                        cust.CustomerAddress = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerAddress, @"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$") == false)
                        {
                            throw new InvalidStringException("not a valid address");
                        }

                        Console.WriteLine("Enter Customer Mobile");
                        cust.CustomerMobile = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerMobile, @"\+?[0-9]{10}") == false)
                        {
                            throw new InvalidStringException("not a valid mobile");
                        }

                        Console.WriteLine("Enter Customer Email");
                        cust.CustomerEmail = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerEmail, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == false)
                        {
                            throw new InvalidStringException("not a valid email");
                        }

                        Console.WriteLine("Enter Customer PAN");
                        cust.CustomerPan = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerPan, @"^([A - Z]{ 5}\d{ 4}[A-Z]{1})$") == false)
                        {
                            throw new InvalidStringException("not a valid pan ");
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("cannot update");
            }
        }
    }
}
