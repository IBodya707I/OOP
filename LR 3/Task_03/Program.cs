using System;
class Person
{
    private string name;
    private int age;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public Person()
    {
        name = "-";
        age = 0;
    }
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public void Show()
    {
        Console.WriteLine("Name: " + name + ", age: " + age);
    }
}
class Family
{
    private List<Person> members = new List<Person>();
    public void AddMember(Person member)
    {
        members.Add(member);
    }
    public void getOldestMember()
    {
        if (members.Count==0)
        {
            Console.WriteLine("No members in the family.");
            return;
        }
        Person oldest = members[0];
        for(int i = 1; i < members.Count; i++)
        {
            if(members[i].Age > oldest.Age)
            {
                oldest = members[i];
            }
        }
        Console.WriteLine("The oldest member is:");
        oldest.Show();
    }
}
internal class Program
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Person p = new Person(name, age);
            family.AddMember(p);
        }
        family.getOldestMember();
    }
}

