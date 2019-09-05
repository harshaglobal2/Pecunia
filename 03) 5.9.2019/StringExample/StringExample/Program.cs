using System;

namespace StringExample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello".ToUpper()); //2 objects created --> 20 bytes
            Console.WriteLine("Hello".ToLower()); //1 object created --> 10 bytes
            Console.WriteLine(("Hell" + "o").ToLower()); //4 objects created --> 30 bytes
            //String is Immutable (readonly). We can't modify the contents of string object

            //methods
            string s = "Capgemini";
            int result1 = s.Length;
            Console.WriteLine(result1); //Output: 9

            char result2 = s[0];
            Console.WriteLine(result2); //Output: C
            Console.WriteLine((int)result2); //Output: 67
            Console.WriteLine("" + result2 + s[1]); //Output: Ca

            string result3 = s.Substring(2); //Index of "p"
            Console.WriteLine(result3); //Output: pgemini

            string result4 = s.Substring(3, 3); //Index of "g"
            Console.WriteLine(result4); //Output: gem

            string result5 = s.Remove(3, 3); //Index of "g"
            Console.WriteLine(result5); //Output: Capini

            char[] ch = new char[] { (char)67, (char)97, (char)98 };
            string s2 = new string(ch);
            Console.WriteLine(s2); //Output: Cab

            int result6 = s.IndexOf("i", 7); //Searching for "i"
            Console.WriteLine(result6); //Output: 8

            string companyName = "Capgemini";
            string location = "Mumbai";

            string result7 = companyName + " is located at " + location;
            Console.WriteLine(result7); //Output: Capgemini is located at Mumbai

            string result8 = string.Format("{0} is located at {1}", companyName, location);
            Console.WriteLine(result8); //Output: Capgemini is located at Mumbai

            string result9 = $"{companyName} is located at {location}";
            Console.WriteLine(result8); //Output: Capgemini is located at Mumbai

            Console.ReadKey();
        }
    }
}
