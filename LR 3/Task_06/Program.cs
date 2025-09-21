using System;
class Engine
{
    private string model;
    private int power;
    private string volume;
    private string efficiency;
    public string Model
    {
        get { return model; }
    }
    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        volume = "n/a";
        efficiency = "n/a";
    }
    public Engine(string model, int power, string volume)
    {
        this.model = model;
        this.power = power;
        this.volume = volume;
        efficiency = "n/a";
    }
    public Engine(string model, int power, string volume, string efficiency)
    {
        this.model = model;
        this.power = power;
        this.volume = volume;
        this.efficiency = efficiency;
    }
    public void Show()
    {
        Console.Write(" " + model + "\n  Power: " + power + "\n  Volume: " + volume + "\n  Efficiency: " + efficiency);
        Console.WriteLine();
    }
}
class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;
    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        weight = "n/a";
        color = "n/a";
    }
    public Car(string model, Engine engine, string weight)
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        color = "n/a";
    }
    public Car(string model, Engine engine, string weight, string color)
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }
    public void Show()
    {
        Console.Write(model + ":");
        engine.Show();
        Console.Write(" Weight: " + weight + "\n Color: " + color);
        Console.WriteLine();
    }
}

    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter number of engines: ");
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model = input[0];
            int power = int.Parse(input[1]);
            if (input.Length == 2)
            {
                Engine engine = new Engine(model, power);
                engines.Add(engine);
            }
            else if (input.Length == 3)
            {
                string volume = input[2];
                Engine engine = new Engine(model, power, volume);
                engines.Add(engine);
            }
            else if (input.Length == 4)
            {
                string volume = input[2];
                string efficiency = input[3];
                Engine engine = new Engine(model, power, volume, efficiency);
                engines.Add(engine);
            }
        }
            Console.WriteLine("Enter number of cars: ");
            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for(int j = 0; j < m; j++)
            {
                string[] carInput = Console.ReadLine().Split();
                string carModel = carInput[0];
                string engineModel = carInput[1];
                Engine carEngine = null;
                for (int k = 0; k < engines.Count; k++)
                {
                    if(engines[k].Model == engineModel)
                    {
                        carEngine = engines[k];
                    }
                }
                if (carInput.Length == 2)
                {
                    Car car = new Car(carModel, carEngine);
                    cars.Add(car);
                }
                else if(carInput.Length == 3)
                {
                    string weight = carInput[2];
                    Car car = new Car(carModel, carEngine, weight);
                    cars.Add(car);
                }
                else if(carInput.Length == 4)
                {
                    string weight = carInput[2];
                    string color = carInput[3];
                    Car car = new Car(carModel, carEngine, weight, color);
                    cars.Add(car);
                }
            }
            for(int i = 0; i < cars.Count; i++)
            {
                cars[i].Show();
            }
        
    }
    }

