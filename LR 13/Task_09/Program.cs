using System;
class Student
{
    private string code;
    private List<int> marks;
    public string Code
    {
        get { return code; }
        set { code = value; }
    }
    public List<int> Marks
    {
        get { return marks; }
        set { marks = value; }
    }
    public Student(string code, List<int> marks)
    {
        Code = code;
        Marks = marks;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        while (true)
        {
            string[] text = Console.ReadLine().Split(" ");
            if (text[0].ToLower() == "end")
                break;
            List<int> marks = new List<int>();
            for (int i = 1; i < text.Length; i++)
            {
                marks.Add(int.Parse(text[i]));
            }
            Student person = new Student(text[0], marks);
            students.Add(person);
        }    
        var result = students.Where(s => s.Code.EndsWith("14") || s.Code.EndsWith("15")).Select(s => s.Marks).ToList();
        foreach (var marks in result)
        {
            Console.WriteLine(string.Join(" ", marks));
        }
    }
}

