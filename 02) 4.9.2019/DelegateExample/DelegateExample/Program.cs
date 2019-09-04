using System;

namespace DelegateExample
{
    class Sample
    {
        //method 1
        public int Add(int a, int b)
        {
            int c = a + b;
            return c;
        }

        //method 2
        public int Multiply(int x, int y)
        {
            int z = x * y;
            return z;
        }
    }

    //delegate type
    public delegate int MyDelegate(int a, int b);

    class Program
    {
        static void Main()
        {
            Sample sample = new Sample();
            MyDelegate myDelegate = sample.Add; //store reference of Add into myDelegate
            myDelegate += sample.Multiply;
            int result = myDelegate(10, 3); //Add, Multiply

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
