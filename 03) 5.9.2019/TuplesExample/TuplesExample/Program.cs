using System;

namespace TuplesExample
{
    class Program
    {
        static dynamic GetPersonDetails()
        {
            var person = new { personName = "Scott", age = 20, email = "scott@gmail.com", dateOfJoining = Convert.ToDateTime("2019-6-10") };
            return person;
        }

        static Tuple<string, int, string, DateTime> GetPersonDetails2()
        {
            var person = new Tuple<string, int, string, DateTime>("Scott", 20, "scott@gmail.com", Convert.ToDateTime("2019-6-10"));
            return person;
        }

        static (string, int, string, DateTime) GetPersonDetails3()
        {
            var person = (personName: "Scott", age: 20, email: "scott@gmail.com", dateOfJoining: Convert.ToDateTime("2019-6-10"));
            return person;
        }

        static void Sample(out int x)
        {
            x = 10;
        }

        static void Main()
        {
            (string personName, int age, _, DateTime dateOfJoining) = Program.GetPersonDetails3();
            Console.WriteLine(personName);
            
            Program.Sample(out _);
            Console.ReadKey();
        }
    }
}
