using System;

/* Harsha */
class Student
{
    //fields
    private Nullable<int> _rollNo;
    private String _studentName;
    private int _marks;

    //methods
    public void GetData()
    {
        System.Console.WriteLine("Roll No: " + this.RollNo);
        System.Console.WriteLine("Student Name: " + this.StudentName);
    }

    //constructor
    public Student(int rollNo, string studentName)
    {
        this._rollNo = rollNo;
        this._studentName = studentName;
    }

    //properties
    public int? RollNo { get => _rollNo; set => _rollNo = value; }
    public string StudentName { get => _studentName; set => _studentName = value; }
    public int Marks { get => _marks; set => _marks = value; }
}

/* You */
static class SomeClass
{
    public static string GetResult(this Student stu)
    {
        if (stu.Marks < 35)
        {
            return "Fail";
        }
        else
        {
            return "Pass";
        }
    }
}

class Program
{
    static void Main()
    {
        dynamic x = 10;

        x = "capg";

        #region Structures
        var s1 = new Student(400, "Hello");
        s1.RollNo = null;
        s1.StudentName = null;
        System.Console.WriteLine(s1.RollNo);
        System.Console.WriteLine(s1.StudentName);
        s1.Marks = 60;
        System.Console.WriteLine(s1.GetResult());
        #endregion

        #region Boxing
        int a = 10; //int is value-type data type (structure)
        System.Object b; //System.Object is reference-type data type (class)
        b = a; //boxing (automatic)
        #endregion

        #region Unboxing
        System.Object c = 200; //System.Object is reference-type data type (class)
        int d; //int is value-type data type (structure)
        d = (int)c; //unboxing (manual)

        #endregion

        System.Console.ReadKey();
    }
}
