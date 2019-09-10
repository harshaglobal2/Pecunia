using System;
using System.Reflection;
using SampleNamespace;

namespace AssemblyExample
{
    class Program
    {
        static void Main()
        {
            Customer customer = new Customer();
            customer.CustomerName = "Scott";
            Console.WriteLine(customer.GetCustomerNameUpperCase());

            /* Reflection: Obtaining types from assembly */
            Assembly assembly = Assembly.GetAssembly(typeof(Customer));
            Console.WriteLine("Full Name: " + assembly.FullName);
            Console.WriteLine("Code Base: " + assembly.CodeBase);

            Type[] classes = assembly.GetTypes();
            foreach (Type cls in classes)
            {
                Console.WriteLine("\n");
                Console.WriteLine(cls.Name);
                Console.WriteLine(cls.FullName);

                Console.WriteLine("\nProperties:");
                foreach (PropertyInfo prop in cls.GetProperties())
                {
                    Console.WriteLine(prop);
                }

                Console.WriteLine("\nMethods:");
                foreach (MethodInfo met in cls.GetMethods())
                {
                    Console.WriteLine(met);
                }

                Console.WriteLine("\nFields:");
                foreach (FieldInfo fie in cls.GetFields())
                {
                    Console.WriteLine(fie);
                }

                Console.WriteLine("\nAttributes:");
                foreach (Attribute attr in cls.GetCustomAttributes())
                {
                    Console.WriteLine(attr);
                }
            }

            Console.ReadKey();
        }
    }
}

