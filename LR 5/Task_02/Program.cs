using System;   
class Product
{
    private string name;
    private double price;
    public string Name
    {
        get { return name; }
        private set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            name = value; 
        }
    }
    public double Price
    {
        get { return price; }
        private set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
            price = value; 
        }
    }
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}
class Person
{
    private string name;
    private double money;
    private List<Product> products = new List<Product>();
    public string Name
    {
        get { return name; }
        private set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            name = value; 
        }
    }
    public double Money
    {
        get { return money; }
        private set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative.");
            }
            money = value; 
        }
    }
    public Person(string name, double money)
    {
        Name = name;
        Money = money;
    }
    public bool Buy(Product product)
    {
        if (Money - product.Price >= 0)
        {
            Money -= product.Price;
            products.Add(product);
            return true;
        }
        else
            return false;
    }
    public void PrintProducts()
    {
        Console.Write(Name + " - ");
        if (products.Count == 0)
        {
            Console.WriteLine("Nothing bought");
            return;
        }
        for(int i = 0; i < products.Count;i++)
        {
            Console.Write(products[i].Name);
            if (i != products.Count - 1)
                Console.Write(", ");
        }
        Console.WriteLine();
    }
}
internal class Program
    {
        static void Main()
        {
            try
            {
                int n;
                Console.Write("Enter n - products: ");
                n = int.Parse(Console.ReadLine());
                List<Product> products = new List<Product>();
                Console.WriteLine("name price ");
                for(int i = 0; i < n;i++)
                {
                    string[] text = Console.ReadLine().Split(" ");
                    string name = text[0];
                    float price = float.Parse(text[1]);
                    Product product = new Product(name, price);
                    products.Add(product);
                }
                Console.WriteLine("Enter n - Persons");
                n = int.Parse(Console.ReadLine());
                List<Person> persons = new List<Person>();
                for(int i = 0; i < n;i++)
                {
                    string[] text = Console.ReadLine().Split(" ");
                    string name = text[0];
                    float money = float.Parse(text[1]);
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                for(int i = 0; i < persons.Count;i++)
                {
                    Console.Write(persons[i].Name + " = " + persons[i].Money + "; ");
                }
                Console.WriteLine();
                for(int i = 0; i < products.Count ;i++)
                {
                    Console.Write(products[i].Name + " = " + products[i].Price + "; ");
                }
                Console.WriteLine();
                string result = "";
                while(true)
                {
                    string[] text = Console.ReadLine().Split(" ");
                    if (text[0] == "END")
                    {
                        break;
                    }
                    string personName = text[0];
                    int indexPerson = 0;
                    for(int i = 0; i < persons.Count;i++)
                    {
                        if(persons[i].Name == personName)
                        {
                            indexPerson = i; 
                            break;
                        }
                    }
                    string productName = text[1];
                    int indexProduct = 0;
                    for(int i = 0;i < products.Count;i++)
                    {
                        if(products[i].Name == productName)
                        {
                            indexProduct = i;
                            break;
                        }
                    }
                    result += personName + " ";
                    if (persons[indexPerson].Buy(products[indexProduct]))
                    {
                        result += "bought ";
                        result += products[indexProduct].Name;
                        result += "\n";
                    }
                    else
                    {
                        result += "cant afford ";
                        result += products[indexProduct].Name + "\n";
                    }
                }
                Console.WriteLine(result);
                for(int i = 0; i < persons.Count;i++)
                {
                    persons[i].PrintProducts();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

