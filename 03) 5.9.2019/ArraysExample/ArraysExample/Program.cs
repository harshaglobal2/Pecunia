using System;
using System.Collections.Generic;
using System.Collections;

namespace ArraysExample
{
    class Program
    {
        static void Main()
        {
            /* Single Dim Array */
            int[] firstArray = new int[5] { 10, 20, 30, 40, 50};
            Console.WriteLine("Single Dim with For loop:");
            for (int i = 0; i < firstArray.Length; i++)
            {
                Console.WriteLine(firstArray[i]);
            }
            Console.WriteLine("\nSingle Dim with Foreach loop:");
            foreach (int n in firstArray)
            {
                Console.WriteLine(n);
            }

            /* Multi-Dim Array */
            int[,] secondArray = new int[4, 3] { { 10, 20, 30 }, { 40, 50, 60 }, { 70, 80, 90 }, { 100, 110, 120 } };
            Console.WriteLine("\nMulti Dim with For loop:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(secondArray[i, j] + " ");
                }
                Console.WriteLine();
            }

            /* Jagged Array */
            int[][] thirdArray = new int[4][];
            thirdArray[0] = new int[3] { 10, 20, 30 }; //row 0
            thirdArray[1] = new int[2] { 40, 50 }; //row 1
            thirdArray[2] = new int[5] { 60, 70, 80, 90, 110 }; //row 2
            thirdArray[3] = new int[4] { 120, 130, 140, 150 }; //row 3
            Console.WriteLine("\nJagged array with For loop:");
            foreach (var row in thirdArray)
            {
                foreach (var col in row)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }

            /* Dictionary */
            Console.WriteLine("\nDictionary:");
            Dictionary<string, int> marks = new Dictionary<string, int>() {
                { "Maths", 60 },
                { "Physics", 50 },
                { "Chemistry", 40 }
            };
            Console.WriteLine(marks["Physics"]); //Output: 50

            /* Hashtable */
            Console.WriteLine("\nHashtable:");
            Hashtable marks2 = new Hashtable() {
                { "Maths", 60 },
                { "Physics", 50 },
                { "Chemistry", 40 },
                { 100, 'A' },
                { 102, 'B' }
            };
            Console.WriteLine(marks2[100]); //Output: A
            foreach (var item in marks2.Keys)
            {
                Console.WriteLine(item); //key
                Console.WriteLine(marks2[item]); //value
            }

            Console.ReadKey();
        }
    }
}

