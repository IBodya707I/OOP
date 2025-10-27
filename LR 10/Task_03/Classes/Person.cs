using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Classes
{
    internal class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string city;
        public string Name
        {
            get { return name; }
            set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                name = value; 
            }
        }
        public int Age
        { 
            get { return age; } 
            set 
            {
                if(value < 2 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 2 and 100.");
                }
                age = value; 
            } 
        }
        public string City
        {
            get { return city; }
            set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("City cannot be null or empty.");
                }
                city = value; 
            }
        }
        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }
        public int CompareTo(Person other)
        {
            if(other == null) return 1;
            int nameComparison = this.Name.CompareTo(other.Name);
            if (nameComparison != 0)
            {
                return nameComparison;
            }
            int ageComparison = this.Age.CompareTo(other.Age);
            if (ageComparison != 0)
            {
                return ageComparison;
            }
            int cityComparison = this.City.CompareTo(other.City);
            return cityComparison;
        }
    }
}
