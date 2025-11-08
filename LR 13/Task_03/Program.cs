using System;
class Student
{
    private string fisrtName;
    private string lastName;
    private int age;
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
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public Student(string firstName, string lastName, int age)
    {
        FisrtName = firstName;
        LastName = lastName;
        Age = age;
    }
    public override string ToString()
    {
        return $"{FisrtName} {LastName} {Age}";
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
            Student person = new Student(text[0], text[1], int.Parse(text[2]));
            students.Add(person);
        }
        var result = students.Where(p => p.Age >= 18 && p.Age <= 24).ToList();
        foreach (var person in result)
        {
            Console.WriteLine(person);
        }
    }
}

