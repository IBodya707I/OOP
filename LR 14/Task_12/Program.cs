namespace Task_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<string> commands = new List<string>();
            while (true)
            {
                string[] text = Console.ReadLine().Split(";");
                if (text[0].ToLower() == "forge")
                    break;
                else if (text[0].ToLower() == "exclude")
                {
                    string command = text[1] + ";" + text[2];
                    commands.Add(command);
                }
                else if (text[0].ToLower() == "reverse")
                {
                    string command = text[1] + ";" + text[2];
                    commands.Remove(command);
                }
            }
            Predicate<int> criterion;
            List<int> indexes = new List<int>();
            foreach (string command in commands)
            {
                string[] c = command.Split(";");
                criterion = null;
                switch (c[0])
                {
                    case "Sum Left": criterion = n =>
                    {
                        int index = n;
                        int key;
                        if (index == 0)
                            key = 0;
                        else
                            key = numbers[index - 1];
                        int number = numbers[index];
                        if (key + number == int.Parse(c[1]))
                            return true;
                        return false;
                    };
                    break;
                    case "Sum Right": criterion = n =>
                    {
                        int index = n;
                        int key;
                        if (index == numbers.Count - 1)
                            key = 0;
                        else
                            key = numbers[index + 1];
                        int number = numbers[index];
                        if (key + number == int.Parse(c[1]))
                            return true;
                        return false;
                    };
                    break;
                    case "Sum Left Right": criterion = n =>
                    {
                        int index = n;
                        int key;
                        if (index == numbers.Count - 1)
                            key = 0;
                        else
                            key = numbers[index + 1];
                        int key1;
                        if (index == 0)
                            key1 = 0;
                        else
                            key1 = numbers[index - 1];
                        int number = numbers[index];
                        if (key + number + key1 == int.Parse(c[1]))
                            return true;
                        return false;
                    };
                    break;
                }
                for(int i = 0; i < numbers.Count; i++)
                {
                    if(criterion(i))
                    {
                        indexes.Add(i);
                    }
                }
            }
            indexes = indexes.Distinct().ToList();
            indexes = indexes.OrderByDescending(x => x).ToList();
            foreach (int i in indexes)
                numbers.RemoveAt(i);
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
