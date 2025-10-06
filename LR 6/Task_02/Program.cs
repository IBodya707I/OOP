using System;
using System.Text;
class Person
{
    private string firstName;
    private string lastName;
    public string FirstName
    {
        get { return firstName; }
        protected set
        {
            if (value.Length <= 3)
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            if (!char.IsUpper(value[0]))
                throw new ArgumentException("Expected upper case letter! Argument:firstName");
            firstName = value;
        }
    }
    public string LastName
    {
        get { return lastName; }
        protected set
        {
            if (value.Length <= 2)
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            if (!char.IsUpper(value[0]))
                throw new ArgumentException("Expected upper case letter! Argument:lastName");
            lastName = value;
        }
    }
}
class Student : Person
{
    private string facultyNumber;
    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10)
                throw new ArgumentException("Invalid faculty number!");
            facultyNumber = value;
        }
    }
    public Student(string firstName, string lastName, string facultyNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        FacultyNumber = facultyNumber;
    }
    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
        .AppendLine($"First name: {this.FirstName}")
        .AppendLine($"Last name: {this.LastName}")
        .AppendLine($"Faculty number: {this.FacultyNumber}");
        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}
class Worker : Person
{
    private decimal weekSalary;
    private int workHoursPerDay;
    public decimal WeekSalary
    {
        get { return weekSalary; }
        private set
        {
            if (value <= 10)
                throw new ArgumentException("Expected value mismatch! Argument:weekSalary");
            weekSalary = value;
        }
    }
    public int WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        private set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException("Expected value mismatch! Argument:workHoursPerDay");
            workHoursPerDay = value;
        }
    }
    public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
    {
        FirstName = firstName;
        LastName = lastName;
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
    }
    public decimal SalaryPerHour()
    {
        return weekSalary / (workHoursPerDay * 5);
    }
    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
        .AppendLine($"First name: {this.FirstName}")
        .AppendLine($"Last name: {this.LastName}")
        .AppendLine($"Week salary: {this.WeekSalary:f2}")
        .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
        .AppendLine($"Salary per hour: {this.SalaryPerHour():f2}");
        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}
internal class Program
    {
    static void Main()
    {
        try
        {
            string[] studentData = Console.ReadLine().Split(" ");
            string[] workerData = Console.ReadLine().Split(" ");
            Student student = new Student(studentData[0], studentData[1], studentData[2]);
            Worker worker = new Worker(workerData[0], workerData[1], decimal.Parse(workerData[2]), int.Parse(workerData[3]));
            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    }

