using System;
class Car
{
    private string model;
    private float fuel;
    private float consumption;
    private float distance;
    public string Model
    {
        get { return model; }
    }
    public Car(string model, float fuel, float consumption)
    {
        this.model = model;
        this.fuel = fuel;
        this.consumption = consumption;
        distance = 0;
    }
    public void Drive(float km)
    {
        float neededFuel = consumption * km;
        if(neededFuel > fuel)
        {
            Console.WriteLine("Not enough fuel");
        }
        else
        {
            fuel -= neededFuel;
            distance += km;
        }
    }
    public void Show()
    {
        Console.WriteLine(model + " " + fuel + " " + distance);
    }
}
internal class Program
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model = input[0];
            float fuel = float.Parse(input[1]);
            float consumption = float.Parse(input[2]);
            bool found = false;
            for (int j = 0; j < cars.Count; j++)
            {
                if (cars[j].Model == model)
                {
                    Console.WriteLine("such a car already exists, try again");
                    i--;
                    found = true;
                }
            }
            if (!found)
            {
                Car car = new Car(model, fuel, consumption);
                cars.Add(car);
            }
        }
        while (true)
        {
            string command = Console.ReadLine();
            string[] parts = command.Split();
            if (parts[0] == "End")
            {
                break;
            }
            else if (parts[0] == "Drive")
            {

                string model = parts[1];
                float km = float.Parse(parts[2]);
                Car car = null;
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Model == model)
                    {
                        car = cars[i];
                    }
                }
                if (car != null)
                {
                    car.Drive(km);
                }
            }
            else
            {
                Console.WriteLine("Dont found command");
            }
            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].Show();
            }
        }
    }
}




