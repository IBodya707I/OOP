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
        name = "No name";
        age = 1;
    }
    public Person(int age)
    {
        name = "No name";
        this.age = age;
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
internal class Program
{
    static void Main()
    {
        Person a1 = new Person();
        a1.Show();
        Person a2 = new Person(18);
        a2.Show();
        Person a3 = new Person("Ivan", 22);
        a3.Show();
    }
}
