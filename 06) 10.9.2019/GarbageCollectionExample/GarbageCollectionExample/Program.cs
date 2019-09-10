using System;
using System.Collections.Generic;
using System.IO;

namespace GarbageCollectionExample
{
    public class Customer : IDisposable
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        private FileStream fs;

        //constructor
        public Customer()
        {
            fs = new FileStream(@"c:\Capg\something.txt", FileMode.Create, FileAccess.Write);
            Console.WriteLine("File Opened");
            byte[] barray = System.Text.Encoding.ASCII.GetBytes("Hello");
            fs.Write(barray, 0, barray.Length);
        }

        public void SomeMetho()
        {

        }

        //Dipose
        public void Dispose()
        {
            fs.Close();
            Console.WriteLine("File Closed");
        }
    }
    class Program
    {
        static void Main()
        {
            //Create object --> Constructor --> File opened
            using (Customer customer = new Customer())
            {
                //some work
                //We want to close the file & delete the file.
            }
            
            int x;
            x = 10;

        }
    }
}
