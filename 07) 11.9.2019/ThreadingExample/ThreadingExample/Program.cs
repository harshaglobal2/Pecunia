using System;
using System.Threading;

namespace ThreadingExample
{
    class Sample
    {
        public void Method1()
        {
            for (int i = 1; i <= 1000; i++)
            {
                Console.Write($"i={i} ");
            }
        }

        public void Method2()
        {
            for (int j = 1; j <= 1000; j++)
            {
                Console.Write($"j={j} ");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Sample sample = new Sample();

            Thread thread1 = new Thread(sample.Method1);
            Thread thread2 = new Thread(sample.Method2);

            thread1.Start();
            thread2.Start();

            Console.WriteLine("Done");

            Console.ReadKey();
        }
    }
}
