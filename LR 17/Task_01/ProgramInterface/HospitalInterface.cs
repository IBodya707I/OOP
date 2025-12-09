using P01_HospitalDatabase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_HospitalDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Task_01.ProgramInterface
{
    internal static class HospitalInterface
    {
        public static void Run(HospitalContext db)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hospital Interface");
                Console.WriteLine("1.Print All Patients\n" + "2.Print full information about patient\n" +
                    "3.Print Visitations\n" + "4.Add Patient\n" + "5.Add Visition\n" + "6.Add diagnose\n" +
                    "7.Add medicament\n" + "0.Exit\n");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());
                if (option == 0)
                {
                    break;
                }
                switch (option)
                {
                    case 1:
                        PrintAllPatients(db);
                        break;
                    case 2:
                        PrintPatientInfo(db);
                        break;
                    case 3:
                        PrintVisitations(db);
                        break;
                    case 4:
                        AddPatient(db);
                        break;
                    case 5:
                        AddVisitation(db);
                        break;
                    case 6:
                        AddDiagnose(db);
                        break;
                    case 7:
                        AddMedicament(db);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void PrintAllPatients(HospitalContext db)
        {
            Console.Clear();
            Console.WriteLine("All Patients:");
            var patients = db.Patients.ToList();
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.FirstName} {patient.LastName} - {patient.Address} - {patient.Email} - Has Insurance: {patient.HasInsurance}");
            }
            Console.ReadKey();
        }
        private static void PrintPatientInfo(HospitalContext db)
        {
            Console.Clear();
            Console.WriteLine("Patient Information:");
            Console.Write("Enter patient ID or Last name and First name: ");
            string[] patientKey = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Patient patient = null;
            if (int.TryParse(patientKey[0], out int result))
            {
                int patientId = result;
                patient = db.Patients.Include(p => p.Diagnoses).Include(p => p.Visitations).Include(p => p.Prescriptions)
                    .Where(p => p.PatientId == patientId)
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
            if (patient != null)
            {
                Console.WriteLine($"{patient.FirstName} {patient.LastName} - {patient.Address} - {patient.Email} - Has Insurance: {patient.HasInsurance}");
                foreach (var diag in patient.Diagnoses)
                {
                    Console.WriteLine($"\tDiagnose: {diag.Name} - Comments: {diag.Comments}");
                }
                foreach (var visit in patient.Visitations)
                {
                    Console.WriteLine($"\tVisitation on {visit.Date.ToShortDateString()} - Comments: {visit.Comments}");
                }
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
            Console.ReadKey();
        }
        private static void PrintVisitations(HospitalContext db)
        {
            Console.Clear();
            Console.WriteLine("All Visitations:");
            var visitations = db.Visitations.Include(v => v.Patient).ToList();
            foreach (var visit in visitations)
            {
                Console.WriteLine($"{visit.Patient.FirstName} {visit.Patient.LastName} - Visitation on {visit.Date.ToShortDateString()} - Comments: {visit.Comments}");
            }
            Console.ReadKey();
        }
        private static void AddPatient(HospitalContext db)
        {
            Console.Clear();
            Console.WriteLine("Add New Patient:");
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Has Insurance (true/false): ");
            bool hasInsurance = bool.Parse(Console.ReadLine());
            var patient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email,
                HasInsurance = hasInsurance
            };
            db.Patients.Add(patient);
            db.SaveChanges();
            Console.WriteLine("Patient added successfully.");
            Console.ReadKey();
        }
        private static void AddVisitation(HospitalContext db)
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
            Console.Write("Enter Comments: ");
            string comments = Console.ReadLine();
            Console.Write("Enter Date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            var visitation = new Visitation
            {
                PatientId = patientId,
                Date = date,
                Comments = comments
            };
            db.Visitations.Add(visitation);
            db.SaveChanges();
            Console.WriteLine("Visitation added successfully.");
            Console.ReadKey();
        }
        private static void AddDiagnose(HospitalContext db)
        {
            Console.Clear();
            Console.WriteLine("Add New Diagnose:");
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
            Console.Write("Enter Diagnose Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Comments: ");
            string comments = Console.ReadLine();
            var diagnose = new Diagnose
            {
                PatientId = patientId,
                Name = name,
                Comments = comments
            };
            db.Diagnoses.Add(diagnose);
            db.SaveChanges();
            Console.WriteLine("Diagnose added successfully.");
            Console.ReadKey();
        }
        private static void AddMedicament(HospitalContext db)
        {
            Console.Clear();
            Console.WriteLine("Add New Medicament:");
            Console.Write("Enter Medicament Name: ");
            string name = Console.ReadLine();
            var medicament = new Medicament
            {
                Name = name
            };
            db.Medicaments.Add(medicament);
            db.SaveChanges();
            Console.WriteLine("Medicament added successfully.");
            Console.ReadKey();
        }
    }
}
