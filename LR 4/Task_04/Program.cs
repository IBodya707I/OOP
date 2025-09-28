using System;
interface IBag
{
    int Capacity { get; set; }
    void tryToAdd(Item item);
    void printBag();
}
class Item
{
    public string name;
    public int size;
    public Item(string name, int size)
    {
        this.name = name;
        this.size = size;
    }
}
class Bag : IBag
{
    private int capacity;
    private int size = 0;
    private int sizeGold = 0;
    private int sizeGem = 0;
    private int sizeCash = 0;
    private List<Item> Gold = new List<Item>();
    private List<Item> Gem = new List<Item>();
    private List<Item> Cash = new List<Item>();
    public int Capacity 
    { 
        get 
        { 
            return capacity; 
        }
        set
        {
            capacity = value;
        }
    }
    public void tryToAdd(Item item)
    {
        if(item.name.ToLower() == "gold" && size + item.size <= capacity)
        {
            Gold.Add(item);
            size += item.size;
            sizeGold += item.size;
        }
        else if (item.name.Length == 3 && size + item.size <= capacity && sizeCash + item.size <= sizeGem)
        {
            Cash.Add(item);
            sizeCash += item.size;
            size += item.size;
        }
        else if (item.name.Length >= 4 && size + item.size <= capacity && sizeGem + item.size <= sizeGold)
        {
            string text = item.name.ToLower();
            string test = "gem";
            int x = 2;
            int n = text.Length;
            bool check = true;
            for(int i = n - 1; i >= n-4 && x >= 0; i--)
            {
                if (text[i] == test[x])
                {
                    x--;
                }
                else
                {
                    check = false; 
                    break;
                }
            }
            if(check)
            {
                Gem.Add(item);
                size += item.size;
                sizeGem += item.size;
            }
        }
    }
    public void printBag()
    {
        Console.WriteLine("<Gold> " + sizeGold);
        for(int i = 0; i < Gold.Count - 1; i++)
        {
            for(int j = 1; j < Gold.Count; j++)
            {
                if (Gold[i].size > Gold[j].size)
                {
                    Item item = Gold[i];
                    Gold[i] = Gold[j];
                    Gold[j] = item;
                }
            }
        }
        for(int i = 0; i < Gold.Count; i++)
        {
            Console.WriteLine("##" + Gold[i].name + " - " + Gold[i].size);
        }
        Console.WriteLine("<Gem> " + sizeGem);
        for(int i = 0;i < Gem.Count - 1; i++)
        {
            for (int j = 1; j < Gem.Count; j++)
            {
                if (string.Compare(Gem[i].name, Gem[j].name , StringComparison.OrdinalIgnoreCase) < 0)
                {
                    Item item = Gem[i];
                    Gem[i] = Gem[j];
                    Gem[j] = item;
                }
                else if(string.Compare(Gem[i].name, Gem[j].name, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (Gem[i].size > Gem[j].size)
                    {
                        Item item = Gem[i];
                        Gem[i] = Gem[j];
                        Gem[j] = item;
                    }
                }
            }
        }
        for (int i = 0; i < Gem.Count; i++)
        {
            Console.WriteLine("##" + Gem[i].name + " - " + Gem[i].size);
        }
        Console.WriteLine("<Cash> " + sizeCash);
        for (int i = 0; i < Cash.Count - 1; i++)
        {
            for (int j = 1; j < Cash.Count; j++)
            {
                if (string.Compare(Cash[i].name, Cash[j].name, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    Item item = Cash[i];
                    Cash[i] = Cash[j];
                    Cash[j] = item;
                }
                else if (string.Compare(Cash[i].name, Cash[j].name, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (Cash[i].size > Cash[j].size)
                    {
                        Item item = Cash[i];
                        Cash[i] = Cash[j];
                        Cash[j] = item;
                    }
                }
            }
        }
        for (int i = 0; i < Cash.Count; i++)
        {
            Console.WriteLine("##" + Cash[i].name + " - " + Cash[i].size);
        }
    }

}
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter capacity: ");
            int n = int.Parse(Console.ReadLine());
            if(n < 0)
            {
                Console.WriteLine("error");
                return;
            }
            Bag bag = new Bag();
            bag.Capacity = n;
            string[] text = Console.ReadLine().Split(" ");
            for(int i =0; i < text.Length; i = i + 2)
            {
                string name = text[i];
                int size = int.Parse(text[i + 1]);
                Item item = new Item(name, size);
                bag.tryToAdd(item);

            }
            bag.printBag();
        }

    }
