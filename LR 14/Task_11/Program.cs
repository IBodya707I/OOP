namespace Task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ").ToList();
            Predicate<string> criterion;
            List<string> commands = new List<string>();
            while (true)
            {
                string[] text = Console.ReadLine().Split(";");
                if (text[0].ToLower() == "print")
                    break;
                else if (text[0].ToLower() == "add filter")
                {
                    string command = text[1] + ";" + text[2]; 
                    commands.Add(command);
                }
                else if(text[0].ToLower() == "remove filter")
                {
                    string command = text[1] + ";" + text[2];
                    commands.Remove(command);
                }
            }
            foreach (string command in commands)
            {
                string[] c = command.Split(";");
                criterion = null;
                switch (c[0].ToLower())
                {
                    case "starts with": criterion = name => name.StartsWith(c[1]); break;
                    case "ends with": criterion = name => name.EndsWith(c[1]); break;
                    case "length": criterion = name => name.Length == int.Parse(c[1]); break;
                    case "contains": criterion = name => name.Contains(c[1]); break;
                }
                guests.RemoveAll(criterion);
            }
            if (guests.Count == 0)
                Console.WriteLine("Nobody is going to the party!");
            else
                Console.WriteLine(string.Join(", ", guests) + " are going to the party");
        }
    }
}
