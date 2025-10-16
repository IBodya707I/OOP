using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Classes
{
    abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public double Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }
        public int FoodEaten
        {
            get { return foodEaten; }
            protected set { foodEaten = value; }
        }
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }
        public abstract void MakeSound();
        public abstract void Eat(Food food);
        public abstract override string ToString();
    }
    abstract class Bird: Animal
    {
        private double wingSize;
        public double WingSize
        {
            get { return wingSize; }
            protected set { wingSize = value; }
        }
        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }
    }
    abstract class Mammal: Animal
    {
        private string livingRegion;
        public string LivingRegion
        {
            get { return livingRegion; }
            protected set { livingRegion = value; }
        }
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
    }
    abstract class Feline: Mammal
    {
        private string breed;
        public string Breed
        {
            get { return breed; }
            protected set { breed = value; }
        }
        public Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }
    }
    class Owl: Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize) { }
        public override void MakeSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.25;
            }
            else
            {
                Console.WriteLine("Owl does not eat " + food);
            }
        }
        public override string ToString()
        {
            return "Owl [" + Name + ", " + WingSize +", " + Weight + ", " + FoodEaten + "]";
        }
    }
    class Hen: Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize) { }
        public override void MakeSound()
        {
            Console.WriteLine("Cluck");
        }
        public override void Eat(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.35;
        }
        public override string ToString()
        {
            return "Hen [" + Name + ", " + WingSize + ", " + Weight + ", " + FoodEaten + "]";
        }
    }
    class Mouse: Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }
        public override void MakeSound()
        {
            Console.WriteLine("Squeak");
        }
        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.10;
            }
            else
            {
                Console.WriteLine("Mouse does not eat " + food);
            }
        }
        public override string ToString()
        {
            return "Mouse [" + Name + ", " + Weight + ", " + LivingRegion + ", " + FoodEaten + "]";
        }
    }
    class Dog: Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.40;
            }
            else
            {
                Console.WriteLine("Dog does not eat " + food);
            }
        }
        public override string ToString()
        {
            return "Dog [" + Name + ", " + Weight + ", " + LivingRegion + ", " + FoodEaten + "]";
        }
    }
    class Cat: Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }
        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.30;
            }
            else
            {
                Console.WriteLine("Cat does not eat " + food);
            }
        }
        public override string ToString()
        {
            return "Cat [" + Name + ", " + Breed + ", " + Weight + ", " + LivingRegion + ", " + FoodEaten + "]";
        }
    }
    class Tiger: Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }
        public override void MakeSound()
        {
            Console.WriteLine("ROAR!!!");
        }
        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 1.00;
            }
            else
            {
                Console.WriteLine("Tiger does not eat " + food);
            }
        }
        public override string ToString()
        {
            return "Tiger [" + Name + ", " + Breed + ", " + Weight + ", " + LivingRegion + ", " + FoodEaten + "]";
        }
    }
}
