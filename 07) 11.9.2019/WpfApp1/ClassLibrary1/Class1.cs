using System;

namespace ClassLibrary1
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public string GetCustomerDetails()
        {
            return $"Customer Name: {CustomerName}\nMobile: {Mobile}\nEmail: {Email}";
        }
    }
}
