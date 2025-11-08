using System;
public class King
{
    private string name;
    public event Action atackKing;
    public List<IDefender> Defenders = new List<IDefender>();
    public King(string name)
    {
        this.name = name;
    }
    public void Atack()
    {
        Console.WriteLine($"King {name} is under attack!");
        atackKing?.Invoke();
    }
    public void AddDefender(IDefender defender)
    {
        Defenders.Add(defender);
        atackKing += defender.React;
        defender.DefenderKilled += RemoveDefender;
    }
    public void Kill(string name)
    {
        IDefender defenderToRemove = null;
        foreach (var defender in Defenders)
        {
            if (defender is RoyalGuard rg && rg.Name == name)
            {
                defenderToRemove = defender;
                break;
            }
            else if (defender is Footman fm && fm.Name == name)
            {
                defenderToRemove = defender;
                break;
            }
        }
        if (defenderToRemove != null)
        {
            defenderToRemove.TakeDamage();
        }
    }
    public void RemoveDefender(IDefender defender)
    {
        atackKing -= defender.React;
        Defenders.Remove(defender);
    }
}
public interface IDefender
{
    void React();
    void TakeDamage();
    event Action<IDefender> DefenderKilled;
}
public class RoyalGuard: IDefender
{
    private string name;
    private int defensePower = 3;
    public event Action<IDefender> DefenderKilled;
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
    public void TakeDamage()
    {
        defensePower--;
        if (defensePower <= 0)
        {
            DefenderKilled?.Invoke(this);
        }
    }
}
public class Footman: IDefender
{
    private string name;
    private int health = 2;
    public event Action<IDefender> DefenderKilled;
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
    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            DefenderKilled?.Invoke(this);
        }
    }
}
internal class Program
{
    static void Main()
    {
        string kingName = Console.ReadLine();
        King king = new King(kingName);
        string[] royalGuardsNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var guardName in royalGuardsNames)
        {
            IDefender guard = new RoyalGuard(guardName);
            king.AddDefender(guard);
        }
        string[] footmansNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var footmanName in footmansNames)
        {
            IDefender footman = new Footman(footmanName);
            king.AddDefender(footman);
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
                king.Kill(name);
            }
        }

    }
}

