using System;
using System.Reflection;

namespace SampleNamespace
{
    public class SampleAttribute : Attribute
    {
        public SampleAttribute()
        {
            Console.WriteLine("Constructor of SampleAttribute");
        }
    }

    [Sample]
    public class Customer
    {
        public int x;

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string GetCustomerNameUpperCase()
        {
            Type type = typeof(Customer);
            if (type.GetCustomAttribute(typeof(SampleAttribute)) != null)
            {
                return CustomerName.ToUpper();
            }
            else
            {
                return CustomerName;
            }
        }
    }
    public class Supplier
    {
    }
}