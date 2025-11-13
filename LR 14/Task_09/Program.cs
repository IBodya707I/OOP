namespace Task_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
                numbers.Add(i);
            Predicate<int> DivisionByDividers = n =>
            {
                foreach(int d in dividers)
                {
                    if (n % d != 0) return false;
                }
                return true;
            };
            Func<List<int>, List<int>> FindNumbers = numbers =>
            {
                List<int> result = new List<int>();
                foreach (int n in numbers)
                {
                    if (DivisionByDividers(n))
                        result.Add(n);
                }
                return result;
            };
            List<int> result = FindNumbers(numbers);
            foreach(int number in result)   
                Console.Write(number + " ");
        }
    }
}
