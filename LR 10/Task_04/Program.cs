using System;
using Task_04.Classes;
internal class Program
{
    static void Main()
    {
        var peopleByName = new SortedSet<Person>(new NameComporator());
        var peopleByAge = new SortedSet<Person>(new AgeComporator());
        int n = int.Parse(Console.ReadLine());
        if(n < 0 || n > 100)
        {
            Console.WriteLine("Error: Invalid number of people.");
            return;
        }
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ");
            string name = input[0];
            int age = int.Parse(input[1]);
            try
            {
                Person person = new Person(name, age);
                peopleByName.Add(person);
                peopleByAge.Add(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("People sorted by name:");
        foreach (var person in peopleByName)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine("People sorted by age:");
        foreach (var person in peopleByAge)
        {
            Console.WriteLine(person);
        }
    }
}

