using System;
using Pecunia.Entities;
using Pecunia.Exceptions;
using Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;

namespace Pecunia.BusinessLayer
{
    public class CustomerBL
    {
        public bool AddCustomerBL(CustomerEntities cust)
        {
            if (Regex.IsMatch(cust.CustomerName, "^[a-zA-Z]$") == false)
            {
                throw new InvalidStringException("not a valid name");
            }

            if (Regex.IsMatch(cust.CustomerAddress, @"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$") == false)
            {
                throw new InvalidStringException("not a valid address");
            }

            if (Regex.IsMatch(cust.CustomerMobile, @"\+?[0-9]{10}") == false)
            {
                throw new InvalidStringException("not a valid mobile");
            }

            if (Regex.IsMatch(cust.CustomerEmail, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == false)
            {
                throw new InvalidStringException("not a valid email");
            }

            if (Regex.IsMatch(cust.CustomerPan, @"^([A - Z]{ 5}\d{ 4}[A-Z]{1})$") == false)
            {
                throw new InvalidStringException("not a valid pan ");
            }

            CustomerDAL obj = new CustomerDAL();
            return obj.AddCustomerDAL(cust);

        }

        public bool RemoveCustomerBL(string CustomerID)
        {
            if (Regex.IsMatch(CustomerID, "^[0-9]{14}$") == false)
            {
                throw new InvalidStringException("not a valid CustomerID");
            }

            CustomerDAL obj = new CustomerDAL();
            return obj.RemoveCustomerDAL(CustomerID);

        }

        public CustomerEntities GetCustomerByCustomerID_BL(string CustomerID)
        {
            if (Regex.IsMatch(CustomerID, "^[0-9]{14}$") == false)
            {
                throw new InvalidStringException("not a valid CustomerID");
            }

            CustomerDAL obj = new CustomerDAL();
            return obj.GetCustomerByCustomerID_DAL(CustomerID);

        }

        public void DisplayAllCustome_BL()
        {
            CustomerDAL obj = new CustomerDAL();
            obj.DisplayAllCustomerDAL();
        }

        public void UpdateCustomerByCustomerID_BL(string CustomerID)
        {
            CustomerDAL obj = new CustomerDAL();
            obj.UpdateCustomerByCustomerID_DAL(CustomerID);
        }

    }
}
