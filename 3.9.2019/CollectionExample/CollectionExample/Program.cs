using System;
using System.Collections.Generic;

class Student
{
    //fields
    private Nullable<int> _rollNo;
    private String _studentName;
    private int _marks;

    //constructor
    public Student(int rollNo, string studentName, int marks)
    {
        this._rollNo = rollNo;
        this._studentName = studentName;
        this._marks = marks;
    }

    //properties
    public int? RollNo { get => _rollNo; set => _rollNo = value; }
    public string StudentName { get => _studentName; set => _studentName = value; }
    public int Marks { get => _marks; set => _marks = value; }
}

class Program
{
    static void Main()
    {
        #region Arrays

        List<Student> students = new List<Student>()
        {
            new Student(101, "Scott", 50),
            new Student(102, "Smith", 95),
            new Student(103, "Allen", 71)
        };

        Console.WriteLine("-----------Initial------------");
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine(students[i].RollNo);
            Console.WriteLine(students[i].StudentName);
            Console.WriteLine(students[i].Marks);
            Console.WriteLine("----------------");
        }

        /*Add*/
        students.Add(new Student(104, "John", 52));

        students.AddRange(
            new List<Student>() {
                new Student(105, "Jones", 84),
                new Student(106, "Ford", 70)
            }
        );

        Console.WriteLine("\n-----------After Add Range------------");
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine(students[i].RollNo);
            Console.WriteLine(students[i].StudentName);
            Console.WriteLine(students[i].Marks);
            Console.WriteLine("----------------");
        }

        #endregion

        Console.ReadKey();
    }
}
