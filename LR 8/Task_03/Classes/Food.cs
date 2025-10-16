using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Classes
{
    abstract class Food
    {
        public int quantity;
        public int Quantity
        {
            get { return quantity; }
            protected set 
            { 
                if(value < 0)
                {
                    Console.WriteLine("Quantity must be a positive number");
                }
                quantity = value; 
            }
        }
        public Food(int quantity)
        {
            Quantity = quantity;
        }
        public override abstract string ToString();
    }
    class Vegetable: Food
    {
        public Vegetable(int quantity) : base(quantity) { }
        public override string ToString()
        {
            return "Vegetable";
        }
    }
    class Fruit: Food
    {
        public Fruit(int quantity) : base(quantity) { }
        public override string ToString()
        {
            return "Fruit";
        }
    }
    class Meat: Food
    {
        public Meat(int quantity) : base(quantity) { }
        public override string ToString()
        {
            return "Meat";
        }
    }
    class Seeds: Food
    {
        public Seeds(int quantity) : base(quantity) { }
        public override string ToString()
        {
            return "Seeds";
        }
    }
}
