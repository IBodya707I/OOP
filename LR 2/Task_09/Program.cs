using System;
internal class Program
    {
        static void Main()
        {
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        string word = Console.ReadLine().ToLower();
        for(int i = 0; i < alphabet.Length; i++)
        {
            for(int j = 0; j < word.Length; j++)
            {
                if(alphabet[i] == word[j])
                {
                    Console.WriteLine(word[j]+" -> "+i);
                }
            }
        }
    }
    }

