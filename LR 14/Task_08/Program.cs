namespace Task_08
{
    internal class Program
    {
        static int Comporator(int x, int y)
        {
            if(x % 2 == 0 && y % 2 != 0)
                return -1;
            else if(x % 2 != 0 && y % 2 == 0)
                return 1;
            return x.CompareTo(y);
        }
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Array.Sort(numbers, Comporator);
            foreach(int number in numbers)
                Console.Write(number + " ");
        }
    }
}
