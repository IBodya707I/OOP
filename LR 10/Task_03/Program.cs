using System;
using Task_03.Classes;
internal class Program
{
    static void Main(string[] args)
    {
        List<Person> peoples = new List<Person>();
        while(true)
        {
            string[] input = Console.ReadLine().Split(" ");
            if (input[0].ToLower() == "end")
                break;
            string name = input[0];
            int age = int.Parse(input[1]);
            string city = input[2];
            try
            {
                Person person = new Person(name, age, city);
                peoples.Add(person);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        int n = int.Parse(Console.ReadLine());
        if(n < 0 || n >= peoples.Count)
        {
            Console.WriteLine("No matches");
            return;
        }
        Person targetPerson = peoples[n];
        int equalCount = 0;
        int differentCount = 0;
        foreach(var person in peoples)
        {
            if(person.CompareTo(targetPerson) == 0)
            {
                equalCount++;
            }
            else
            {
                differentCount++;
            }
        }
        if(equalCount == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine(equalCount + " " + differentCount + " " + peoples.Count);
        }
    }
}

