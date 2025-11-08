using System;
class Orders
{
    private string company;
    private string product;
    private int amount; 
    public string Company
    {
        get { return company; }
        set { company = value; }
    }
    public string Product
    {
        get { return product; }
        set { product = value; }
    }
    public int Amount
    {
        get { return amount; }
        set { amount = value; }
    }
    public Orders(string company, string product, int amount)
    {
        Company = company;
        Product = product;
        Amount = amount;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        List<Orders> orders = new List<Orders>();  
        int n = int.Parse(Console.ReadLine());
        for(uint i = 0; i < n; i++)
        {
            string[] text = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            text = text[0].Split(" - ");
            Orders order = new Orders(text[0], text[2], int.Parse(text[1]));
            orders.Add(order);
        }
        var result = orders.GroupBy(o => new {o.Product, o.Company}).Select(g => new
        {
            Company = g.Key.Company,
            Product = g.Key.Product,
            TotalAmount = g.Sum(x => x.Amount)
        }).ToList();
        foreach(var order in result)
        {
            Console.WriteLine($"{order.Company}: {order.Product} - {order.TotalAmount}");
        }
    }
}

