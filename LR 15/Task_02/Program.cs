
internal class Program
{
    static void Main(string[] args)
    {
        string file = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\text.txt";
        string outputFile = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\output.txt";
        string[] lines = File.ReadAllLines(file);
        string[] outputLines = new string[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            outputLines[i] = "Line " + (i + 1) + ": " + lines[i];
            int countLetters = 0;
            int countPunctuation = 0;  
            foreach(char c in lines[i])
            {
                if (char.IsLetter(c))
                {
                    countLetters++;
                }
                else if (char.IsPunctuation(c))
                {
                    countPunctuation++;
                }
            }
            outputLines[i] += "(" + countLetters + ")(" + countPunctuation + ")";
        }
        File.WriteAllLines(outputFile, outputLines);
    }
}

