class Sample<T>
{
    public T a;

    public void Method1()
    {
        if (a is int)
        {
            //a++;
            a = (T)(System.Convert.ToInt32(a) + 1);
        }
    }
}

class Program
{
    static void Main()
    {
        Sample<int> variable1 = new Sample<int>() { a = 100 };
        Sample<string> variable2 = new Sample<string>() { a = "Hello" };
        System.Console.WriteLine(variable1.a);
        System.Console.WriteLine(variable2.a);
        System.Console.ReadKey();
    }
}
