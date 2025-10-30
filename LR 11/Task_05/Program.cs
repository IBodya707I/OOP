using System;
using Task_05.Classes;
internal class Program
{
    static void Main()
    {
        while(true)
        {
            Type type = typeof(Weapon);
            var attribute = type.GetCustomAttributes(false).OfType<CustomAttribute>().FirstOrDefault();
            string text = Console.ReadLine();
            if (text.ToLower() == "end")
            {
                break;
            }
            switch(text)
            {
                case "Author":
                    Console.WriteLine("Author: " + attribute.Author);
                    break;
                case "Revision":
                    Console.WriteLine("Revision: " + attribute.Revision);
                    break;
                case "Description":
                    Console.WriteLine("Class description" + attribute.Description);
                    break;
                case "Reviewers":
                    Console.WriteLine("Reviewers: " + string.Join(", ", attribute.Reviewers));
                    break;
            }
        }
    }
}

