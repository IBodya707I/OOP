using System;
class Student
{
    private string fisrtName;
    private string lastName;
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
    public Student(string firstName, string lastName)
    {
        FisrtName = firstName;
        LastName = lastName;
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
            Student person = new Student(text[0], text[1]);
            students.Add(person);
        }
        students = students.Where(p => p.FisrtName.CompareTo(p.LastName) < 0).ToList();
        foreach (var person in students)
        {
            Console.WriteLine(person);
        }
    }
}

