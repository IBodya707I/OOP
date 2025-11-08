using System;
using System.Globalization;
class Student
{
    private string name;
    private int group;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Group
    {
        get { return group; }
        set { group = value; }
    }
    public Student(string name, int group)
    {
        Name = name;
        Group = group;
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
            string name = text[0] + " " + text[1];  
            Student person = new Student(name, int.Parse(text[2]));
            students.Add(person);
        }
        var result = students.GroupBy(s => s.Group).OrderBy(g => g.Key).ToList();
        foreach (var group in result)
        {
            Console.Write(group.Key + " - ");
            string[] names = group.Select(s => s.Name).ToArray();
            Console.WriteLine(string.Join(", ", names));
        }
    }
}
