using System;
abstract class Food
{
    protected int happinessPoint;
    public int HappinessPoint
    {
        get { return happinessPoint; }
        protected set 
        { 
            happinessPoint = value; 
        }
    }
}
class Cram : Food
{
    public Cram()
    {
        happinessPoint = 2;
    }
}
class Lembas : Food
{
    public Lembas()
    {
        happinessPoint = 3;
    }
}
class Apple : Food
{
    public Apple()
    {
        happinessPoint = 1;
    }
}
class Melon : Food
{
    public Melon()
    {
        happinessPoint = 1;
    }
}
class HoneyCake : Food
{
    public HoneyCake()
    {
        happinessPoint = 5;
    }
}
class Mushrooms : Food
{
    public Mushrooms()
    {
        happinessPoint = -10;
    }
}
class OtherFood : Food
{
    public OtherFood()
    {
        happinessPoint = -1;
    }
}
abstract class Mood
{
    protected string moodName;
    public string MoodName
    {
        get { return moodName; }
        protected set 
        { 
            moodName = value; 
        }
    }
}
class Angry : Mood
{
    public Angry()
    {
        moodName = "Angry";
    }
}
class Sad : Mood
{
    public Sad()
    {
        moodName = "Sad";
    }
}
class Happy : Mood
{
    public Happy()
    {
        moodName = "Happy";
    }
}
class JavaScript : Mood
{
    public JavaScript()
    {
        moodName = "JavaScript";
    }
}
class FoodFactory
{
    public Food createFood(string name)
    {
        switch(name.ToLower())
        {
            case "cram": return new Cram();
            case "lembas": return new Lembas();
            case "apple": return new Apple();
            case "melon": return new Melon();
            case "honeycake": return new HoneyCake();
            case "mushrooms": return new Mushrooms();
            default: return new OtherFood();
        }
    }
}
class MoodFactory
{
    public Mood GetMood(int points)
    {
        if (points < -5)
            return new Angry();
        else if (points >= -5 && points <= 0)
            return new Sad();
        else if (points > 0 && points <= 15)
            return new Happy();
        else
            return new JavaScript();
    }
}
class Gandalf
{
    private int happinessPoints;
    public int HappinessPoints
    {
        get { return happinessPoints; }
        private set { happinessPoints = value; }
    }
    public Mood CurrentMood
    {
        get
        {
            MoodFactory moodFactory = new MoodFactory();
            return moodFactory.GetMood(happinessPoints);
        }
    }
    public Gandalf()
    {
        HappinessPoints = 0;
    }
    public void Eat(Food food)
    {
        happinessPoints += food.HappinessPoint;
    }
}
    internal class Program
    {
        static void Main()
        {
        Gandalf gandalf = new Gandalf();
        Console.WriteLine("Food:\n Cram: 2 points of happiness;\r\n• Lembas: 3 points of happiness;\r\n• Apple: 1 point of happiness;\r\n• Melon: 1 point of happiness;\r\n• HoneyCake: 5 points of happiness;\r\n• Mushrooms: -10 points of happiness;\r\n• Everything else: -1 point of happiness;");
        string[] foodNames = Console.ReadLine().Split(" ");
        for(int i = 0; i < foodNames.Length; i++)
        {
            FoodFactory foodFactory = new FoodFactory();
            Food food = foodFactory.createFood(foodNames[i]);
            gandalf.Eat(food);
        }
        Console.WriteLine(gandalf.HappinessPoints);
        Console.WriteLine(gandalf.CurrentMood.MoodName);
    }
    }

