using System;
class Student
{
    private string fisrtName;
    private string lastName;
    private int group;
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
    public int Group
    {
        get { return group; }
        set { group = value; }
    }
    public Student(string firstName, string lastName, int group)
    {
        FisrtName = firstName;
        LastName = lastName;
        Group = group;
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
            Student person = new Student(text[0], text[1], int.Parse(text[2]));
            students.Add(person);
        }
        var result = students.Where(p => p.Group == 2).OrderBy(p => p.FisrtName).ToList();
        foreach (var person in result)
        {
            Console.WriteLine(person);
        }
    }
}

