using System;
using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;
using Task_01.ProgramInterface;
namespace P01_HospitalDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new HospitalContext();
            Console.WriteLine("Welcome to the Hospital Management System");
            Console.WriteLine("Please select your interface:");
            Console.WriteLine("1. Doctor Interface");
            Console.WriteLine("2. Hospital Interface");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
                DoctorInterface.Run(db);
            else if (choice == 2)
                HospitalInterface.Run(db);
            else
                Console.WriteLine("Invalid choice. Exiting...");
        }
    }
}
