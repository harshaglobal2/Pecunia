using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SymmetricEncryptionExample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your message here to encrypt:");
            string message = Console.ReadLine();

            // Call the encryptText method to encrypt the a string and save the result to a file   
            byte[] iv = Encrypt(message, "c:\\Capg\\personinfo.txt");
            Decrypt(iv, "c:\\Capg\\personinfo.txt");
            Console.ReadKey();
        }

        static byte[] Encrypt(string message, string fileName)
        {
            // Create a new instance of the AesManaged
            AesManaged aesAlgorithm = new AesManaged();
            aesAlgorithm.Key = Encoding.ASCII.GetBytes("abcdefghijklmnop");

            ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(cs))
                    {
                        writer.WriteLine(message);
                    }
                }

                byte[] encrypedData = ms.ToArray();
                File.WriteAllBytes(fileName, encrypedData);
            }
            return aesAlgorithm.IV;
        }

        static void Decrypt(byte[] iv, string fileName)
        {
            AesManaged aesAlgorithm = new AesManaged();
            aesAlgorithm.Key = Encoding.ASCII.GetBytes("abcdefghijklmnop");
            aesAlgorithm.IV = iv;

            ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, aesAlgorithm.IV);

            byte[] encryptedDataBuffer = File.ReadAllBytes(fileName);
            using (MemoryStream ms = new MemoryStream(encryptedDataBuffer))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cs))
                    {
                        // Reutrn all the data from the streamreader   
                        string actualMessage = reader.ReadToEnd();
                        Console.WriteLine("\nYour Message:");
                        Console.WriteLine(actualMessage);
                    }
                }
            }

        }
    }
}
