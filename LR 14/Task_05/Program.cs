namespace Task_05
{
    internal class Program
    {
        static Func<List<int>, List<int>> Add = numbers => numbers.Select(n => n + 1).ToList();
        static Func<List<int>, List<int>> Subtract = numbers => numbers.Select(n => n - 1).ToList();
        static Func<List<int>, List<int>> Multiply = numbers => numbers.Select(n => n * 2).ToList();
        static Action<List<int>> PrintNumbers = numbers => Console.WriteLine(string.Join(" ", numbers));
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            while(true)
            {
                string command = Console.ReadLine();
                if(command.ToLower() == "end")
                    break;
                switch(command.ToLower())
                {
                    case "add":
                        numbers = Add(numbers);
                        break;
                    case "subtract":
                        numbers = Subtract(numbers);
                        break;
                    case "multiply":
                        numbers = Multiply(numbers);
                        break;
                    case "print":
                        PrintNumbers(numbers);
                        break;
                }
            }
        }
    }
}
