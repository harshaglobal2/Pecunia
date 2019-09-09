using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerializationExample
{
    [Serializable]
    class Person
    {
        public string PersonName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public bool IsRegistered { get; set; }

        public Person(string personName, int age, char gender, bool isRegistered)
        {
            PersonName = personName;
            Age = age;
            Gender = gender;
            IsRegistered = isRegistered;
        }
    }
    class Program
    {
        static void Main()
        {
            /* Serialization */
            Person person = new Person("Scott", 20, 'M', true);
            string filePath = "c:\\Capg\\person.txt";
            FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fs1, person);
            fs1.Close();
            Console.WriteLine("Serialization done");
            Console.ReadKey();

            /* Deserialization */
            Person person2;
            FileStream fs2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            person2 = (Person)binaryFormatter.Deserialize(fs2);
            Console.WriteLine("Person name: " + person2.PersonName);
            Console.WriteLine("Age: " + person2.Age);
            Console.WriteLine("Gender: " + person2.Gender);
            Console.WriteLine("Is Registered: " + person2.IsRegistered);
            Console.ReadKey();
        }
    }
}
