using System;

namespace PatternMatchingExample
{
    interface ICustomer
    {
        string CustomerName { get; set; }
        string Mobile { get; set; }
    }

    class PrepaidCustomer : ICustomer
    {
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string LatestRecharge { get; set; }
    }

    class PostpaidCustomer : ICustomer
    {
        public string CustomerName { get; set; }
        public string Mobile { get; set; }

        public void CalculateBill()
        {
            Square(5);

            int Square(int n)
            {
                return n * n;
            }
        }

        
    }

    class Program
    {
        static void Main()
        {
            ICustomer prepaidCustomer = new PrepaidCustomer() { CustomerName = "Scott", Mobile = "9999999999", LatestRecharge = "100" };
            if (prepaidCustomer is PrepaidCustomer pc)
            {
                Console.WriteLine(pc.LatestRecharge);
            }


            int x = default(int); //C# 6.0 or earlier
            int y = default; //C# 7.1
            

            Console.ReadKey();
        }
    }
}

