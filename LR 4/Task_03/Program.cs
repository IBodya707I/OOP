using System;
using System.Diagnostics;
interface IRoom
{
    bool addPatient(Patient patient);
    void printPatient();
    void printPatientsByAlphabet();
}
interface IDepartament
{
    void AddPatient(Patient patient);
    void printPatientsInDepartament();

}
interface IDoctor
{
    void AddPatient(Patient patient);
    void printPatientsByAlphabet();
}

class Patient
{
    public string name;
    public Patient(string name)
    {
        this.name = name;
    }
}
class Room : IRoom
{
    public List<Patient> patients = new List<Patient>();
    public Room() 
    {

    }
    public bool addPatient(Patient patient)
    {
        if (patients.Count < 3)
        {
            patients.Add(patient);
            return true;
        }
        else
            return false;
        
    }
    public void printPatient()
    {
        for(int i = 0; i < patients.Count; i++)
            Console.WriteLine(patients[i].name);
    }
    public void printPatientsByAlphabet()
    {
        if (patients.Count >= 2)
        {
            for (int i = 0; i < patients.Count - 1; i++)
            {
                for (int j = i + 1; j < patients.Count; j++)
                {
                    if (string.Compare(patients[i].name, patients[j].name, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Patient patient = patients[i];
                        patients[i] = patients[j];
                        patients[j] = patient;
                    }
                }
            }

        }
        for (int i = 0; i < patients.Count; i++)
            Console.WriteLine(patients[i].name);
    }
}
class Departament : IDepartament
{
    public string departament;
    public List<Room> rooms = new List<Room>();
    public Departament(string name)
    {
        departament = name;
    }
    public void AddPatient(Patient patient)
    {
        if(rooms.Count <= 20)
        {
            int i = rooms.Count;
            if(i == 0)
            {
                Room room1 = new Room();
                rooms.Add(room1);
                rooms[0].addPatient(patient);
            }
            else if (rooms[i - 1].addPatient(patient))
                i = 0;
            else if (i + 1 <= 20)
            {
                Room room1 = new Room();
                rooms.Add(room1);
                rooms[i].addPatient(patient);
            }
            else
            {
                Console.WriteLine("Departament is full");
                return;
            }
        }
    }
        public void printPatientsInDepartament()
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                rooms[i].printPatient();
            }
        }
    }
    

class Doctor : IDoctor
{
    public string name;
    public List<Patient> patients = new List<Patient>();
    public Doctor(string name) 
    { 
        this.name = name; 
    }
    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
    }
    public void printPatientsByAlphabet()
    {
        if (patients.Count >= 2)
        {
            for (int i = 0; i < patients.Count - 1; i++)
            {
                for (int j = i + 1; j < patients.Count; j++)
                {
                    if (string.Compare(patients[i].name, patients[j].name, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Patient patient = patients[i];
                        patients[i] = patients[j];
                        patients[j] = patient;
                    }
                }
            }

        }
        for (int i = 0; i < patients.Count; i++)
            Console.WriteLine(patients[i].name);
    }
}
    internal class Program
    {
        static void Main()
        {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{Department} {Doctor} {Patient}");
        List<Doctor> doctors = new List<Doctor>();
        List<Patient> patients = new List<Patient>();
        List<Departament> departaments = new List<Departament>();
        for(int i = 0;i < n;i++)
        {
            string[] text = Console.ReadLine().Split(' ');
            string departament = text[0];
            string doctor1 = text[1];
            doctor1 += " ";
            doctor1 += text[2];
            string patient1 = text[3];
            patient1 += " ";
            patient1 += text[4];
            Patient patient = new Patient(patient1);
            bool check = false;
            for (int j = 0;j < patients.Count;j++)
            {
                if(patient.name ==  patients[j].name)
                {
                    Console.WriteLine("Try again");
                    i--;
                    continue;
                }
            }
            patients.Add(patient);
            Departament departament1 = new Departament(departament);
            check = false;
            for(int j = 0;j < departaments.Count;j++)
            {
                if (departament1.departament == departaments[j].departament)
                {  
                    check = true;
                    departaments[j].AddPatient(patient);
                } 
            }
            if(!check)
            {
                departaments.Add(departament1);
                departaments[departaments.Count - 1].AddPatient(patient);
            }
            Doctor doctor = new Doctor(doctor1);
            check = false;
            for( int j = 0; j < doctors.Count;j++)
            {
                if(doctors[j].name == doctor.name)
                {
                    check = true;
                    doctors[j].AddPatient(patient);
                }
            }
            if(!check)
            {
                doctors.Add(doctor);
                doctors[doctors.Count - 1].AddPatient(patient);
            }

        }
        Console.WriteLine("output");
        Console.WriteLine("• {Department} – You need to print all patients in this department in the order of receiving\r\n• {Department} {Room} – You need to print all patients in this room in alphabetical order\r\n• {Doctor} – you need to print all patients for this doctor in alphabetical order");
        while (true)
        {
            int x = 0;
            string[] text = Console.ReadLine().Split(" ");
            Stopwatch time = new Stopwatch();
            time.Start();
            if (text[0] == "End")
                return;
            if(text.Length == 1)
            {
                for( int j = 0;j < text.Length;j++)
                {
                    if (text[0] == departaments[j].departament)
                    {
                        departaments[j].printPatientsInDepartament();
                    }
                }

            }
            else if (int.TryParse(text[1], out x))
            {
                
                {
                    for (int j = 0; j < departaments.Count; j++)
                    {
                        if (text[0] == departaments[j].departament)
                        {
                            departaments[j].rooms[x - 1].printPatientsByAlphabet();
                        }
                    }
                }
            }
            else
            {
                string doctor = text[0] + " " + text[1];
                for( int j = 0;j < doctors.Count;j++)
                {
                    if(doctor == doctors[j].name)
                    {
                        doctors[j].printPatientsByAlphabet();
                    }
                }
            }
            time.Stop();
            Console.WriteLine(time.Elapsed);

        }
        }
    }
