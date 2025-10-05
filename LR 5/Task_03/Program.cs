using System;
class Dough
{
    string flourType;
    string bakingTechnique;
    int weight;
    public string FlourType
    {
        get
        {
            return flourType;
        }
        private set
        {
            if(value.ToLower() != "white" && value.ToLower() != "wholegrain")
                throw new ArgumentException("Invalid type of dough.");
            flourType = value;
        }
    }
    public string BakingTechnique
    {
        get
        {
            return bakingTechnique;
        }
        private set
        {
            if(value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                throw new ArgumentException("Invalid type of dough.");
            bakingTechnique = value;
        }
    }
    public int Weight
    {
        get
        {
            return weight;
        }
        private set
        {
            if(value < 1 || value > 200)
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            weight = value;
        }
    }
    public Dough(string flourType, string bakingTechnique, int weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }
    public double CalculateCalories
    {
        get
        {
            double calories = 2 * weight;
            switch (flourType.ToLower())
            {
                case "white": calories *= 1.5; break;
                case "wholegrain": calories *= 1.0; break;
            }
            switch (bakingTechnique.ToLower())
            {
                case "crispy": calories *= 0.9; break;
                case "chewy": calories *= 1.1; break;
                case "homemade": calories *= 1.0; break;
            }
            return calories;
        }
    }
}
class Topping
{
    string toppingType;
    int weight;
    public string ToppingType
    {
        get
        {
            return toppingType;
        }
        private set
        {
            if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                throw new ArgumentException("Cannot place " + value + " on top of your pizza.");
            toppingType = value;
        }
    }
    public int Weight
    {
        get
        {
            return weight;
        }
        private set
        {
            if(value < 1 || value > 50)
                throw new ArgumentException(toppingType + " weight should be in the range [1..50].");
            weight = value;
        }
    }
    public Topping(string toppingType, int weight)
    {
        ToppingType = toppingType;
        Weight = weight;
    }
    public double CalculateCalories
    {
        get
        {
            double calories = 2 * weight;
            switch (toppingType.ToLower())
            {
                case "meat": calories *= 1.2; break;
                case "veggies": calories *= 0.8; break;
                case "cheese": calories *= 1.1; break;
                case "sauce": calories *= 0.9; break;
            }
            return calories;
        }
    }
}
class Pizza
{
    string name;
    Dough dough;
    List<Topping> toppings = new List<Topping>();
    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if(value.Length < 1 || value.Length > 15)
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            name = value;
        }
    }
    public Dough Dough
    {
        get
        {
            return dough;
        }
        set
        {
            dough = value;
        }
    }
    public void AddTopping(Topping topping)
    {
        if(toppings.Count >= 10)
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        toppings.Add(topping);
    }
    public Pizza(string name)
    {
        Name = name;
    }
    public double CalculateCalories
    {
        get
        {
            double calories = dough.CalculateCalories;
            for (int i = 0; i < toppings.Count; i++)
            {
                calories += toppings[i].CalculateCalories;
            }
            return calories;
        }
    }
}
    internal class Program
    {
        static void Main()
        {
            List<Pizza> pizzas = new List<Pizza>();
            try
            {
                while (true)
                {
                    string[] text = Console.ReadLine().Split(" ");
                    if (text[0] == "END")
                    {
                        for(int i = 0; i < pizzas.Count;i++)
                        {
                            Console.WriteLine(pizzas[i].Name + " - " + pizzas[i].CalculateCalories);
                        }
                        break;
                    }
                    else if (text[0].ToLower() == "pizza")
                    {
                        Pizza pizza = new Pizza(text[1]);
                        pizzas.Add(pizza);
                    }
                    else if (text[0].ToLower() == "dough")
                    {
                        Dough dough = new Dough(text[1], text[2], int.Parse(text[3]));
                        pizzas[pizzas.Count - 1].Dough = dough;
                    }
                    else if (text[0].ToLower() == "topping")
                    {
                        Topping topping = new Topping(text[1], int.Parse(text[2]));
                        pizzas[pizzas.Count - 1].AddTopping(topping);
                    }
                    else
                    {
                        Console.WriteLine("Dont found command");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

