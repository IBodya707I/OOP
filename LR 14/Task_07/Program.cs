namespace Task_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ").ToList();
            Predicate<string> CheckLenght = name => name.Length <= n;
            foreach (string name in names)
            {
                if(CheckLenght(name))
                    Console.WriteLine(name);
            }

        }
    }
}
