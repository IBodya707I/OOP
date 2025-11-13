namespace Task_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] x = Console.ReadLine().Split(" ");
            int min = int.Parse(x[0]);
            int max = int.Parse(x[1]);
            List<int> numbers = new List<int>();
            for(int i = min; i <= max; i++)
            {
                numbers.Add(i);
            }
            Predicate<int> even = number => number % 2 == 0;
            Predicate<int> odd = number => number % 2 == 1;
            string command = Console.ReadLine();
            switch(command)
            {
                case "even": 
                    foreach(int number in numbers)
                    {
                        if(even(number))
                            Console.Write(number + " ");
                    }
                    break;
                case "odd":
                    foreach(int number in numbers)
                    {
                        if(odd(number))
                            Console.Write(number + " ");
                    }
                    break;
            }
        }
    }
}
