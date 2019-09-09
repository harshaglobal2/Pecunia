using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryWriterReaderExample
{
    class Program
    {
        static void Main()
        {
            string personName = "Scott";
            int age = 20;
            char gender = 'M';
            bool isRegistered = true;

            string filePath = @"c:\Capg\person.txt";
            FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs1);
            bw.Write(personName);
            bw.Write(age);
            bw.Write(gender);
            bw.Write(isRegistered);
            bw.Close();
            Console.WriteLine("File created");
            Console.ReadKey();

            FileStream fs2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fs2);
            string pn = binaryReader.ReadString();
            int ag = binaryReader.ReadInt32();
            char gen = binaryReader.ReadChar();
            bool reg = binaryReader.ReadBoolean();
            binaryReader.Close();
            Console.WriteLine("Person name: " + pn);
            Console.WriteLine("Age: " + ag);
            Console.WriteLine("Gender: " + gen);
            Console.WriteLine("Is Registered: " + reg);
            Console.ReadKey();
        }
    }
}
