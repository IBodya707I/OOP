using System;
using System.Globalization;
using Task_03.Classes;
using Task_03.Interfaces;
internal class Program
    {
        static void Main()
        {
            List<IPrivate> privates = new List<IPrivate>();
            List<ISoldier> soldiers = new List<ISoldier>();
            while(true)
        {
            string[]text = Console.ReadLine().Split(" ");
            if(text[0].ToLower() == "end")
            {
                break;
            }
            else if(text[0].ToLower() == "private")
            {
                IPrivate privateS = new Private(text[1], text[2], text[3], double.Parse(text[4]));
                privates.Add(privateS);
                soldiers.Add(privateS);
            }
            else if(text[0].ToLower() == "spy")
            {
                ISpy spy = new Spy(text[1], text[2], text[3], text[4]);
                soldiers.Add(spy);
            }
            else if(text[0].ToLower() == "leutenantgeneral")
            {
                ILeutenantGeneral lieutenantGeneral = new LeutenantGeneral(text[1], text[2], text[3], double.Parse(text[4]));
                for(int i = 5; i < text.Length; i++)
                {
                    foreach(IPrivate privateS in privates)
                    {
                        if(privateS.Id == text[i])
                        {
                            lieutenantGeneral.AddPrivate(privateS);
                        }
                    }
                }
                soldiers.Add(lieutenantGeneral);
            }
            else if(text[0].ToLower() == "engineer")
            {
                try
                {
                    IEngeneer engineer = new Engeneer(text[1], text[2], text[3], double.Parse(text[4]), text[5]);
                    for(int i = 6; i < text.Length; i+=2)
                    {
                        Repair repair = new Repair(text[i], int.Parse(text[i + 1]));
                        engineer.AddRepair(repair);
                    }
                    soldiers.Add(engineer);
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            else if(text[0].ToLower() == "commando")
            {
                try
                {
                    ICommando commando = new Commando(text[1], text[2], text[3], double.Parse(text[4]), text[5]);
                    for(int i = 6; i < text.Length; i+=2)
                    {
                        try
                        {
                            Mission mission = new Mission(text[i], text[i + 1]);
                            commando.AddMission(mission);
                        }
                        catch(ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                    }
                    soldiers.Add(commando);
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
            foreach(ISoldier soldier in soldiers)
            {
                Console.WriteLine(soldier);
        }
    }
    }

