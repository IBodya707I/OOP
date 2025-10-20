using Classes;

    internal class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            if(int.TryParse(text, out int result))
            {
                var box = new Box<int>(result);
                Console.WriteLine(box);
            }
            else
            {
                var Box = new Box<string>(text);
                Console.WriteLine(Box);
            }
        }
    }
