using System;
class Student
{
    private string fisrtName;
    private string lastName;
    private List<int> marks;
    public string FisrtName
    {
        get { return fisrtName; }
        set { fisrtName = value; }
    }
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public List<int> Marks
    {
        get { return marks; }
        set { marks = value; }
    }
    public Student(string firstName, string lastName, List<int> marks)
    {
        FisrtName = firstName;
        LastName = lastName;
        Marks = marks;
    }
    public override string ToString()
    {
        return $"{FisrtName} {LastName}";
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
            for (int i = 2; i < text.Length; i++)
            {
                marks.Add(int.Parse(text[i]));
            }
            Student person = new Student(text[0], text[1], marks);
            students.Add(person);
        }
        var result = students.Where(s => s.Marks.Count(m => m <= 3) >= 2).ToList();
        foreach (var person in result)
        {
            Console.WriteLine(person);
        }
    }
}
