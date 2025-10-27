using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04.Classes
{
    internal class Person
    {
        private string name;
        private int age;
        public string Name
        {
            get { return name; }
            set 
            { 
                if(string.IsNullOrWhiteSpace(value) || value.Length > 50)
                {
                    throw new ArgumentException("Name cannot be null, empty, or longer than 50 characters.");
                }
                name = value; 
            }
        }
        public int Age
        { 
            get { return age; } 
            set 
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 0 and 120.");
                }
                age = value; 
            }
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
