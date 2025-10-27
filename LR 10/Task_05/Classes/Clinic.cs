using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05.Classes
{
    internal class Clinic
    {
        private string name;
        private Pet[] pets;
        private int capacity;
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
        public int Capacity
        {
            get { return capacity; }
            private set 
            { 
                if(value % 2 == 0 || value < 1 || value > 101)
                {
                    throw new ArgumentException("Invalid clinic capacity. Capacity must be an odd number between 1 and 101.");
                }
                capacity = value; 
            }
        }
        public Clinic(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            pets = new Pet[capacity];
        }
        public bool AddPet(Pet pet)
        {
            int centerIndex = capacity / 2;
            for (int offset = 0; offset <= centerIndex; offset++)
            {
                int leftIndex = centerIndex - offset;
                if (leftIndex >= 0 && pets[leftIndex] == null)
                {
                    pets[leftIndex] = pet;
                    return true;
                }
                int rightIndex = centerIndex + offset;
                if (rightIndex < capacity && pets[rightIndex] == null)
                {
                    pets[rightIndex] = pet;
                    return true;
                }
            }
            return false;
        }
        public bool ReleasePet()
        {
            int centerIndex = capacity / 2;
            for (int i = 0; i < capacity; i++)
            {
                int index = (centerIndex + i) % capacity;
                if (pets[index] != null)
                {
                    pets[index] = null;
                    return true;
                }
            }
            return false;
        }
        public bool HasEmptyRooms()
        {
            foreach (var pet in pets)
            {
                if (pet == null)
                {
                    return true;
                }
            }
            return false;
        }
        public void Print()
        {
            foreach (var pet in pets)
            {
                if (pet == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(pet);
                }
            }
        }
        public void Print(int roomNumber)
        {
            if (roomNumber < 1 || roomNumber > capacity)
            {
                throw new ArgumentOutOfRangeException("Invalid room number.");
            }
            var pet = pets[roomNumber - 1];
            if (pet == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(pet);
            }
        }
    }
}
