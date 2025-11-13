namespace Task_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ").ToList();
            Predicate<string> criterion;
            while (true)
            {
                string[] text = Console.ReadLine().Split(" ");
                if (text[0].ToLower() == "party!")
                    break;
                criterion = null;
                switch (text[1].ToLower())
                {
                    case "startswith": criterion = name => name.StartsWith(text[2]); break;
                    case "endswith": criterion = name => name.EndsWith(text[2]); break;
                    case "length": criterion = name => name.Length == int.Parse(text[2]); break;
                }
                Func<List<string>, List<string>> Double = list => {
                    List<string> result = new List<string>();
                    foreach(string name in list)
                    {
                        if(criterion(name))
                            result.Add(name);
                    }
                    return result;
                };
                if (criterion != null)
                {
                    if (text[0].ToLower() == "remove")
                        guests.RemoveAll(criterion);
                    else if (text[0].ToLower() == "double")
                    {
                        List<string> result = Double(guests);
                        guests.AddRange(result);
                    }
                }
            }
            guests.Sort();
            if (guests.Count == 0)
                Console.WriteLine("Nobody is going to the party!");
            else
                Console.WriteLine(string.Join(", ", guests) + " are going to the party");
        }
    }
}
