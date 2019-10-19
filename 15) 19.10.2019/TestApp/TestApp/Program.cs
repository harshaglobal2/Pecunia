using System;

class A
{

}
class B : A
{

}
class Program
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        b = new A();
        Console.ReadKey();
    }
}