using System;
using Task_03.Classes;
internal class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        while (true)
        {
            string[] text = Console.ReadLine().Split(" ");
            if (text[0].ToLower() == "end")
                break;
            string animalType = text[0];
            Animal animal = null;
            if (animalType.ToLower() == "cat")
            {
                animal = new Cat(text[1], double.Parse(text[2]), text[3], text[4]);
            }
            else if (animalType.ToLower() == "tiger")
            {
                animal = new Tiger(text[1], double.Parse(text[2]), text[3], text[4]);
            }
            else if (animalType.ToLower() == "mouse")
            {
                animal = new Mouse(text[1], double.Parse(text[2]), text[3]);
            }
            else if (animalType.ToLower() == "dog")
            {
                animal = new Dog(text[1], double.Parse(text[2]), text[3]);
            }
            else if (animalType.ToLower() == "owl")
            {
                animal = new Owl(text[1], double.Parse(text[2]), double.Parse(text[3]));
            }
            else if (animalType.ToLower() == "hen")
            {
                animal = new Hen(text[1], double.Parse(text[2]), double.Parse(text[3]));
            }
            animals.Add(animal);
            animal.MakeSound();
            Food food = null;
            text = Console.ReadLine().Split(" ");
            string foodType = text[0];
            if (foodType.ToLower() == "vegetable")
            {
                food = new Vegetable(int.Parse(text[1]));
            }
            else if (foodType.ToLower() == "fruit")
            {
                food = new Fruit(int.Parse(text[1]));
            }
            else if (foodType.ToLower() == "meat")
            {
                food = new Meat(int.Parse(text[1]));
            }
            else if (foodType.ToLower() == "seeds")
            {
                food = new Seeds(int.Parse(text[1]));
            }
            animal.Eat(food);
        }
        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}


