using System;
using System.Text.RegularExpressions;

namespace RegexExample
{
    class Customer
    {
        private string _customerName;
        private string _email;

        public string CustomerName
        {
            set
            {
                Regex regex = new Regex("^[a-zA-Z ]*$");
                bool b = regex.IsMatch(value);
                if (b == true)
                {
                    _customerName = value;
                }
                else
                {
                    throw new Exception("CustomerName should contain alphabets only");
                }
            }
            get
            {
                return _customerName;
            }
        }

        public string Email
        {
            set
            {
                Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                bool b = regex.IsMatch(value);
                if (b == true)
                {
                    _email = value;
                }
                else
                {
                    throw new Exception("Email is invalid");
                }
            }
            get
            {
                return _email;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            try
            {
                Customer customer = new Customer();
                Console.WriteLine("Customer Name:");
                customer.CustomerName = Console.ReadLine();
                Console.WriteLine(customer.CustomerName);

                Console.WriteLine("Email:");
                customer.Email = Console.ReadLine();
                Console.WriteLine(customer.Email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
