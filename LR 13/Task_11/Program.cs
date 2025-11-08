using System;
using System.ComponentModel.DataAnnotations;
class StudentSpecialty
{
    private string name;
    private string id;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public StudentSpecialty(string name, string id)
    {
        Name = name;
        Id = id;
    }
}
class Student
{
    private string firstname;
    private string lastname;
    private string id;
    public string Firstname
    {
        get { return firstname; }
        set { firstname = value; }
    }
    public string Lastname
    {
        get { return lastname; }
        set { lastname = value; }
    }
    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public Student(string  firstname, string lastname, string id)
    {
        Firstname = firstname;
        Lastname = lastname;
        Id = id;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        List<StudentSpecialty> specialties = new List<StudentSpecialty>();
        List<Student> students = new List<Student>();
        while(true)
        {
            string[] text = Console.ReadLine().Split(" ");
            if (text[0].ToLower() == "students:")
                break;
            string name = text[0] + " " + text[1];
            StudentSpecialty specialty = new StudentSpecialty(name, text[2]);
            specialties.Add(specialty);
        }
        while(true)
        {
            string[] text = Console.ReadLine().Split(" ");
            if(text[0].ToLower() == "end")
                break;
            Student student = new Student(text[1], text[2], text[0]);
            students.Add(student);
        }
        var result = students.Join(specialties, student => student.Id, specialty => specialty.Id,
            (student, specialty) => new
            {
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Id = student.Id,
                SpecialtyName = specialty.Name
            }).OrderBy(s => s.Firstname).ToList();
        if(result.Count == 0)
            Console.WriteLine("No matching students found.");
        foreach (var person in result)
        {
            Console.WriteLine($"{person.Firstname} {person.Lastname} {person.Id} {person.SpecialtyName}");
        }
    }
}

