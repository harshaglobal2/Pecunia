using System;
using System.Collections.Generic;
using System.IO;

namespace ExceptionHandlingExample
{
    class StringLengthException : Exception
    {
        public StringLengthException(string message) : base(message)
        {
        }
    }

    class Customer
    {
        //fields
        private string _customerName;
        private string _mobile;
        private int _age;

        //properties
        public string CustomerName
        {
            set
            {
                if (value.Length <= 30)
                {
                    _customerName = value;
                }
                else
                {
                    throw new StringLengthException("Customer name should be less than 30");
                }
            }
            get
            {
                return _customerName;
            }
        }

        public string Mobile
        {
            set
            {
                _mobile = value;
            }
            get
            {
                return _mobile;
            }
        }

        public int Age
        {
            set
            {
                _age = value;
            }
            get
            {
                return _age;
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
                Console.WriteLine("Customer Mobile:");
                customer.Mobile= Console.ReadLine();
                Console.WriteLine("Customer Age:");
                customer.Age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nCustomer Details:");
                Console.WriteLine("Customer Name: " + customer.CustomerName);
                Console.WriteLine("Customer Mobile: " + customer.Mobile);
                Console.WriteLine("Customer Age: " + customer.Age);
            }
            catch (FormatException ex)
            {
                FileInfo fi = new FileInfo(@"c:\Capg\Log.txt");
                if (fi.Exists == false)
                {
                    fi.Create();
                }

                
                string content = $"\n\n{DateTime.Now}" +
                    $"\nMessage: {ex.Message}" +
                    $"\nStack Trace: {ex.StackTrace}" +
                    $"\nInner Exception: {ex.InnerException?.Message}" +
                    $"\nType: {ex.GetType().ToString() }";

                //FileStream fs = new FileStream(@"c:\Capg\Log.txt", FileMode.Append, FileAccess.Write);
                //byte[] barray = System.Text.Encoding.ASCII.GetBytes(content);
                //fs.Write(barray, 0, barray.Length);
                //fs.Close();

                StreamWriter sw = new StreamWriter(@"c:\Capg\Log.txt", true);
                sw.Write(content);
                sw.Close();

                StreamReader sr = new StreamReader(@"c:\Capg\Log.txt");
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();

                Console.WriteLine("Unexpected error occurred, please try again.");
            }
            catch(OverflowException ex)
            {
                Console.WriteLine("Larger or smaller value is entered");
            }
            catch (Exception ex)
            {
                FileInfo fi = new FileInfo(@"c:\Capg\Log.txt");
                if (fi.Exists == false)
                {
                    fi.Create();
                }
                string content = $"\n\n{DateTime.Now}" +
                    $"\nMessage: {ex.Message}" +
                    $"\nStack Trace: {ex.StackTrace}" +
                    $"\nInner Exception: {ex.InnerException?.Message}" +
                    $"\nType: {ex.GetType().ToString() }";
                
                StreamWriter sw = new StreamWriter(@"c:\Capg\Log.txt", true);
                sw.Write(content);
                sw.Close();

                StreamReader sr = new StreamReader(@"c:\Capg\Log.txt");
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();
            }
            finally
            {
                Console.WriteLine("Thanks");
            }
            Console.ReadKey();
        }
    }
}
