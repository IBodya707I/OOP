using System;
using Task_05.Classes;
internal class Program
{
    static void Main()
    {
        List<Clinic> clinics = new List<Clinic>();
        List<Pet> pets = new List<Pet>();
        int n = int.Parse(Console.ReadLine());
        if(n < 1 || n > 1000)
        {
            return;
        }
        for (int i = 0; i < n; i++)
        {
            string[] text = Console.ReadLine().Split(" ");
            string command = text[0];
            switch (command.ToLower())
            {
                case "create":
                    if (text[1].ToLower() == "pet")
                    {
                        string name = text[2];
                        int age = int.Parse(text[3]);
                        string type = text[4];
                        try
                        {
                            Pet petCreate = new Pet(name, age, type);
                            pets.Add(petCreate);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (text[1].ToLower() == "clinic")
                    {
                        string name = text[2];
                        int capacity = int.Parse(text[3]);
                        try
                        {
                            Clinic clinicCreate = new Clinic(name, capacity);
                            clinics.Add(clinicCreate);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case "add":
                    string petName = text[1];
                    string clinicName = text[2];
                    Pet pet = pets.Find(p => p.Name == petName);
                    Clinic clinic = clinics.Find(c => c.Name == clinicName);
                    Console.WriteLine(clinic.AddPet(pet));
                    break;
                case "release":
                    string clinicToReleaseName = text[1];
                    Clinic clinicToRelease = clinics.Find(c => c.Name == clinicToReleaseName);
                    Console.WriteLine(clinicToRelease.ReleasePet());
                    break;
                case "hasemptyrooms":
                    string clinicToCheckName = text[1];
                    Clinic clinicToCheck = clinics.Find(c => c.Name == clinicToCheckName);
                    Console.WriteLine(clinicToCheck.HasEmptyRooms());
                    break;
                case "print":
                    if (text.Length == 3)
                    {
                        string clinicToPrintRoomName = text[1];
                        int roomNumber = int.Parse(text[2]);
                        Clinic clinicToPrintRoom = clinics.Find(c => c.Name == clinicToPrintRoomName);
                        clinicToPrintRoom.Print(roomNumber);
                    }
                    else
                    {
                        string clinicToPrintName = text[1];
                        Clinic clinicToPrint = clinics.Find(c => c.Name == clinicToPrintName);
                        clinicToPrint.Print();
                    }
                    break;
            }
        }
    }
}

