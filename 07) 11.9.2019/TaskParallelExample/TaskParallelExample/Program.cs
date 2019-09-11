using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskParallelExample
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

            List<Task> tasks = new List<Task>()
            {
                new Task(sample.Method1),
                new Task(sample.Method2)
            };

            tasks[0].Start();
            tasks[1].Start();

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Done");

            Console.ReadKey();
        }
    }
}
