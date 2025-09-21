using System;
class Employee
{
    private string name;
    private float salary;
    private string position;
    private string department;
    private string email;
    private int age;
    public string Department
    {
        get { return department; }
    }
    public float Salary
    {
        get { return salary; }
    }
    public Employee(string name, float salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        email = "n/a";
        age = -1;
    }
    public Employee(string name, float salary, string position, string department, string email)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        age = -1;
    }
    public Employee(string name, float salary, string position, string department, int age)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        email = "n/a";
        this.age = age;
    }
    public Employee(string name, float salary, string position, string department, string email, int age)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }
    public void Show()
    {
        Console.WriteLine("Name: " + name + ", Salary: " + salary + ", Position: " + position + ", Department: " + department + ", Email: " + email + ", Age: " + age);
    }

}
struct Departament
{
    public string name;
    public float averageSalary;
    public List<Employee> employees = new List<Employee>();
    public int count;
    public float totalSalary;
    public Departament(string name)
    {
        this.name = name;
        averageSalary = 0;
        count = 0;
        totalSalary = 0;
    }
    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
        count++;
        totalSalary += employee.Salary;
        averageSalary = totalSalary / count;
    }
}
internal class Program
    {
        static void Main()
        {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter employee data: ");
            string[] text = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = text[0];
            float salary = float.Parse(text[1]);
            string position = text[2];
            string department = text[3];
            if (text.Length == 4)
            {
                Employee x = new Employee(name, salary, position, department);
                employees.Add(x);
            }
            else if (text.Length == 5)
            {
                if (int.TryParse(text[4], out int age))
                {
                    Employee x = new Employee(name, salary, position, department, age);
                    employees.Add(x);
                }
                else
                {
                    string email = text[4];
                    Employee x = new Employee(name, salary, position, department, email);
                    employees.Add(x);
                }
            }
            else if (text.Length == 6)
            {
                string email = text[4];
                int age = int.Parse(text[5]);
                Employee x = new Employee(name, salary, position, department, email, age);
                employees.Add(x);
            }
        }
        List<Departament> departaments = new List<Departament>();
        bool found = false;
        int index = -1;
        for (int i = 0; i < employees.Count; i++)
        {
            string dep = employees[i].Department;
            for(int j = 0; j < departaments.Count; j++)
            {
                if (departaments[j].name == dep)
                {
                    found = true;
                    index = j;
                }
                else
                {
                    
                }
            }
            if (found)
            {
                departaments[index].AddEmployee(employees[i]);
                found = false;
                index = -1;
            }
            else
            {
                Departament newDep = new Departament(dep);
                newDep.AddEmployee(employees[i]);
                departaments.Add(newDep);
            }
        }
        

        Departament bestDepartament = departaments[0];
        for (int i = 0; i< departaments.Count; i++)
        {
            if(departaments[i].averageSalary > bestDepartament.averageSalary)
            {
                bestDepartament = departaments[i];
            }
        }
        for(int i = 0; i < bestDepartament.employees.Count; i++)
        {
            for(int j = i+1; j < bestDepartament.employees.Count; j++)
            {
                if(bestDepartament.employees[j].Salary > bestDepartament.employees[i].Salary)
                {
                    Employee temp = bestDepartament.employees[i];
                    bestDepartament.employees[i] = bestDepartament.employees[j];
                    bestDepartament.employees[j] = temp;
                }
            }
        }
        Console.WriteLine("Highest Average Salary: " + bestDepartament.name);
        for (int i = 0; i < bestDepartament.employees.Count; i++)
        {
            bestDepartament.employees[i].Show();
        }

    }
    }

