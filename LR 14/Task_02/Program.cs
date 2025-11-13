namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ").ToList();
            Action<string> PrintName = name => Console.WriteLine("Sir " + name);    
            foreach (string name in names)
            {
                PrintName(name);
            }
        }
    }
}
