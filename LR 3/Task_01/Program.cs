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
internal class Program
    {
        static void Main()
        {
            Person a1 = new Person("Pesho", 20);
            a1.Show();
            Person a2 = new Person("Gosho", 18);
            a2.Show();
            Person a3 = new Person();
            a3.Name = "Stamat";
            a3.Age = 43;
            a3.Show();
    }
    }
