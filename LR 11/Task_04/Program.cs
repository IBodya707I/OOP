using System;
using Task_04.Classes;
internal class Program
{
    static void Main(string[] args)
    {
        List<Weapon> weapons = new List<Weapon>();
        while (true)
        {
            string[] text = Console.ReadLine().Split(";");
            if (text[0].ToLower() == "end")
            {
                break;
            }
            switch (text[0])
            {
                case "Create":
                    string[] weapon = text[1].Split(" ");
                    Weapon weapon1 = new Weapon(text[2], weapon[1], weapon[0]);
                    weapons.Add(weapon1);
                    break;
                case "Add":
                    string weaponName = text[1];
                    int socketIndex = int.Parse(text[2]);
                    string[] gemInfo = text[3].Split(" ");
                    Gem gem = new Gem(gemInfo[1], gemInfo[0]);
                    Weapon w = weapons.FirstOrDefault(x => x.Name == weaponName);
                    w.AddGem(gem, socketIndex);
                    break;
                case "Remove":
                    string wName = text[1];
                    int sIndex = int.Parse(text[2]);
                    Weapon weap = weapons.FirstOrDefault(x => x.Name == wName);
                    weap.RemoveGem(sIndex);
                    break;
                case "Print":
                    string wpnName = text[1];
                    Weapon wp = weapons.FirstOrDefault(x => x.Name == wpnName);
                    Console.WriteLine(wp.ToString());
                    break;
            }
        }
    }
}


