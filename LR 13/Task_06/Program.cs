using System;
class Student
{
    private string fisrtName;
    private string lastName;
    private string number;
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
    public string Number
    {
        get { return number; }
        set { number = value; }
    }
    public Student(string firstName, string lastName, string number)
    {
        FisrtName = firstName;
        LastName = lastName;
        Number = number;
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
        var result = students.Where(p => p.Number.StartsWith("02") || p.Number.StartsWith("+3592")).ToList();
        foreach (var person in result)
        {
            Console.WriteLine(person);
        }
    }
}
