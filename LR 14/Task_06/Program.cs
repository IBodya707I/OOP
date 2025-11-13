namespace Task_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> Reverse = list => { list.Reverse(); return list; };
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            Predicate<int> DivisionByN = number => number % n == 0;
            numbers.RemoveAll(DivisionByN);
            List<int> result = Reverse(numbers);
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
