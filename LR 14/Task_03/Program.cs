namespace Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            Func<List<int>, int> Min = numbers => numbers.Min();
            Console.WriteLine(Min(numbers));
        }
    }
}
