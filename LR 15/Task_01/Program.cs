internal class Program
{
    static void Main(string[] args)
    {
        string file = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\text.txt";
        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            int lineCount = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (lineCount % 2 == 0)
                {
                    char[] chars = { '-', ',', '.', '!', '?' };
                    foreach (char c in chars)
                    {
                        line = line.Replace(c, '@');
                    }
                    string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Array.Reverse(words);
                    Console.WriteLine(string.Join(' ', words));
                }
                lineCount++;
            }
        }
    }
}

