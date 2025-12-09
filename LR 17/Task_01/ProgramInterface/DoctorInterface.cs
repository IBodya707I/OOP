using P01_HospitalDatabase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_HospitalDatabase.Data.Models;
using Task_01.P01_HospitalDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Task_01.ProgramInterface
{
    internal static class DoctorInterface
    {
        public static void Run(HospitalContext db)
        {
            Console.Clear();
            Console.WriteLine("Doctor Interface");
            Doctor doctor = null;
            while (true)
            {
                if (doctor != null)
                {
                    Console.WriteLine($"Welcome Dr. {doctor.Name} ({doctor.Specialty})");
                    break;
                }
                Console.WriteLine("1.Log in as Doctor\n" + "2.Add Doctor\n" + "0.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string password = Console.ReadLine();
                        doctor = db.Doctors.FirstOrDefault(d => d.email == email && d.password == password);
                        if (doctor == null)
                        {
                            Console.WriteLine("Invalid email or password. Try again.");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Specialty:");
                        string specialty = Console.ReadLine();
                        Console.WriteLine("Enter email:");
                        string docEmail = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string docPassword = Console.ReadLine();
                        Doctor newDoctor = new Doctor
                        {
                            Name = name,
                            Specialty = specialty,
                            email = docEmail,
                            password = docPassword
                        };
                        db.Doctors.Add(newDoctor);
                        db.SaveChanges();
                        Console.WriteLine("Doctor added successfully.");
                        Console.ReadKey();
                        break;
                    case 0:
                        return;
                }
                Console.Clear();
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.View Visitations\n" + "2.Add Visitations\n" + "0.Log out");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        ViewVisitations(db, doctor);
                        break;
                    case 2:
                        AddVisitation(db, doctor);
                        break;
                    case 0:
                        return;
                }
            }
        }
        private static void ViewVisitations(HospitalContext db, Doctor doctor)
        {
            Console.Clear();
            Console.WriteLine("Your Visitations:");
            var visitations = db.Visitations.Include(v => v.Patient).Where(v => v.DoctorId == doctor.DoctorId).ToList();
            foreach (var visitation in visitations)
            {
                Console.WriteLine($"VisitationId: {visitation.VisitationId}, Patient: " +
                    $"{visitation.Patient.LastName}, {visitation.Patient.FirstName}, Date: " +
                    $"{visitation.Date}, Comments: {visitation.Comments}");
            }
            Console.ReadKey();
        }
        private static void AddVisitation(HospitalContext db, Doctor doctor)
        {
            Console.Clear();
            Console.WriteLine("Add New Visitation:");
            Console.Write("Enter patient ID or Last name and First name: ");
            string[] patientKey = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Patient patient = null;
            if (int.TryParse(patientKey[0], out int result))
            {
                int _patientId = result;
                patient = db.Patients
                    .Where(p => p.PatientId == _patientId)
                    .FirstOrDefault();
            }
            else if (patientKey.Length == 2)
            {
                string lastName = patientKey[0];
                string firstName = patientKey[1];
                patient = db.Patients
                    .Where(p => p.LastName == lastName && p.FirstName == firstName)
                    .FirstOrDefault();
            }
            int patientId = patient.PatientId;
            Console.WriteLine("Enter Date (yyyy-MM-dd):");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Comments:");
            string comments = Console.ReadLine();
            Visitation newVisitation = new Visitation
            {
                PatientId = patientId,
                DoctorId = doctor.DoctorId,
                Date = date,
                Comments = comments
            };
            db.Visitations.Add(newVisitation);
            db.SaveChanges();
            Console.WriteLine("Visitation added successfully.");
            Console.ReadKey();
        }
    }
}
