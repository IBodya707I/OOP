using System;
public class King
{
    private string name;
    public event Action atackKing;
    public King(string name)
    {
        this.name = name;
    }
    public void Atack()
    {
        Console.WriteLine($"King {name} is under attack!");
        atackKing?.Invoke();
    }
}
public class RoyalGuard
{
    private string name;
    public string Name
    {
        get { return name; }
    }
    public RoyalGuard(string name)
    {
        this.name = name;
    }
    public void React()
    {
        Console.WriteLine($"Royal Guard {name} is defending!");
    }
}
public class Footman
{
    private string name;
    public string Name
    {
               get { return name; }
    }
    public Footman(string name)
    {
        this.name = name;
    }
    public void React()
    {
        Console.WriteLine($"Footman {name} is defending!");
    }
}
internal class Program
{
    static void Main()
    {
        string kingName = Console.ReadLine();
        King king = new King(kingName);
        string[] royalGuardsNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<RoyalGuard> royalGuards = new List<RoyalGuard>();
        List<Footman> footmans = new List<Footman>();
        foreach (var guardName in royalGuardsNames)
        {
            RoyalGuard guard = new RoyalGuard(guardName);
            royalGuards.Add(guard);
            king.atackKing += guard.React;
        }
        string[] footmansNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var footmanName in footmansNames)
        {
            Footman footman = new Footman(footmanName);
            footmans.Add(footman);
            king.atackKing += footman.React;
        }
        while (true)
        {
            string[] command = Console.ReadLine().Split(" ");
            if (command[0].ToLower() == "end")
            {
                break;
            }
            if (command[0].ToLower() == "attack")
            {
                king.Atack();
            }
            if (command[0].ToLower() == "kill")
            {
                string name = command[1];
                RoyalGuard guardToRemove = royalGuards.FirstOrDefault(x => x.Name == name);
                if(guardToRemove != null)
                {
                    king.atackKing -= guardToRemove.React;
                    royalGuards.Remove(guardToRemove);
                }
                else
                {
                    Footman footmanToRemove = footmans.FirstOrDefault(x => x.Name == name);
                    if(footmanToRemove != null)
                    {
                        king.atackKing -= footmanToRemove.React;
                        footmans.Remove(footmanToRemove);
                    }
                }
            }
        }

    }
}

