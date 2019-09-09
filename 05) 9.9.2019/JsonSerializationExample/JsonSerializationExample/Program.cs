using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JsonSerializationExample
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
            StreamWriter sw = new StreamWriter(filePath);
            string content  = JsonConvert.SerializeObject(person);
            sw.Write(content);
            sw.Close();
            Console.WriteLine("Serialization done");
            Console.ReadKey();

            /* Deserialization */
            Person person2;
            StreamReader sr = new StreamReader(filePath);
            person2 = JsonConvert.DeserializeObject<Person>(sr.ReadToEnd());
            Console.WriteLine("Person name: " + person2.PersonName);
            Console.WriteLine("Age: " + person2.Age);
            Console.WriteLine("Gender: " + person2.Gender);
            Console.WriteLine("Is Registered: " + person2.IsRegistered);
            Console.ReadKey();
        }
    }
}
