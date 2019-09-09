using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XmlSerializationExample
{
    [Serializable]
    public class Person
    {
        public string PersonName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public bool IsRegistered { get; set; }

        public Person()
        {
        }

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
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            xmlSerializer.Serialize(fs1, person);
            fs1.Close();
            Console.WriteLine("Serialization done");
            Console.ReadKey();

            /* Deserialization */
            Person person2;
            FileStream fs2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            person2 = (Person)xmlSerializer.Deserialize(fs2);
            Console.WriteLine("Person name: " + person2.PersonName);
            Console.WriteLine("Age: " + person2.Age);
            Console.WriteLine("Gender: " + person2.Gender);
            Console.WriteLine("Is Registered: " + person2.IsRegistered);
            Console.ReadKey();
        }
    }
}
