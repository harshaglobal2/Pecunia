using System;
using System.Text;

//WelcometoCapgeminiMumbai
namespace StringBuilderExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Welcome ");
                sb.Append("to ");
                sb.Append("Capgemini ");
                sb.Append("Mumbai");
                string s = sb.ToString(); //Converts string builder to string
                Console.WriteLine(s);
            }
            catch (Exception)
            {
                Console.WriteLine("Some error");
            }
            
            Console.ReadKey();
        }
    }
}
