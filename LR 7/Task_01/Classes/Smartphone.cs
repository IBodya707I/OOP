using System;
using Task_01.Interfaces;

namespace Task_01.Classes
{
    class Smartphone: ICalling, IBrowsing
    {
        public void Call(string number)
        {
            foreach(char x in number)
            {
                if (!Char.IsDigit(x))
                {
                    throw new ArgumentException("Invalid number");
                }
            }
            Console.WriteLine("Calling... " + number);
        }
        public void Browse(string link)
        {
            foreach(char x in link)
            {
                if(Char.IsDigit(x))
                {
                    throw new ArgumentException("Invalid link");
                }
            }
            Console.WriteLine("Browsing: " + link + "!");
        }

    }
}
