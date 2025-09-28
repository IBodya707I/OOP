using System;
interface IPriceCalculator
{
    string TotalPrice { get; }
}
enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
enum DiscountType
{
    VIP,
    SecondVisit,
    None
}
class PriceCalculator : IPriceCalculator
{
    private float price;
    private float days;
    private Season season;
    private DiscountType discount;
    public PriceCalculator(float price, float days, Season season, DiscountType discount)
    {
        this.price = price;
        this.days = days;
        this.season = season;
        this.discount = discount;
    }
    public string TotalPrice
    {
        get
        {
            float x = 1;
            switch (season)
            {
                case Season.Spring: x = 2; break;
                case Season.Summer: x = 4; break;
                case Season.Autumn: x = 1; break;
                case Season.Winter: x = 3; break;
            }
            float x1 = 1;
            switch(discount)
            {
                case DiscountType.VIP: x1 = 0.8f; break;
                case DiscountType.SecondVisit: x1 = 0.9f; break;
                case DiscountType.None: x1 = 1; break;
            }
            float totalPrice = price * days * x * x1;
            return totalPrice.ToString("F2");
        }
    }
}
    internal class Program
    {
        static void Main()
        {
        string[] text = Console.ReadLine().Split(" ");
        float price = float.Parse(text[0]);
        float days = float.Parse(text[1]);
        Season season = Enum.Parse<Season>(text[2]);
        DiscountType discount = DiscountType.None;
        if(text.Length > 3)
        {
            discount = Enum.Parse<DiscountType>(text[3]);
        }
        PriceCalculator totalPrice = new PriceCalculator(price, days, season, discount);
        Console.WriteLine("Total price: " + totalPrice.TotalPrice);


        }
    }

