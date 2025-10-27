using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05.Classes
{
    internal class Pet
    {
        private string name;
        private int age;
        private string type;
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
                    throw new ArgumentOutOfRangeException("Age must be between 0 and 100.");
                }
                age = value; 
            }
        }
        public string Type
        {
            get { return type; }
            set 
            { 
                if(string.IsNullOrWhiteSpace(value) || value.Length > 50)
                {
                    throw new ArgumentException("Type cannot be null, empty, or longer than 50 characters.");
                }
                type = value; 
            }
        }
        public Pet(string name, int age, string type)
        {
            Name = name;
            Age = age;
            Type = type;
        }
        public override string ToString()
        {
            return $"{Name} {Age} {Type}";
        }
    }
}
