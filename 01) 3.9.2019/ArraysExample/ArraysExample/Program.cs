using System;

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
        
        Student[] students = new Student[3]
        {
            new Student(101, "Scott", 50),
            new Student(102, "Smith", 95),
            new Student(103, "Allen", 71)
        };

        for (int i = 0; i < students.Length; i++)
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
