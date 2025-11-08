using System;
class Student
{
    private string fisrtName;
    private string lastName;
    private string gmail;
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
    public string Gmail
    {
        get { return gmail; }
        set { gmail = value; }
    }
    public Student(string firstName, string lastName, string gmail)
    {
        FisrtName = firstName;
        LastName = lastName;
        Gmail = gmail;
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
            Student person = new Student(text[0], text[1], text[2]);
            students.Add(person);
        }
        var result = students.Where(p => p.Gmail.EndsWith("@gmail.com")).ToList();
        foreach (var person in result)
        {
            Console.WriteLine(person);
        }
    }
}

