
internal class Program
{
    static void Main(string[] args)
    {
        string file = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\pexels-lukas-hartmann-304281-1557652.jpg";
        string outputFile = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\Copy.jpg";
        using (FileStream inputStream = new FileStream(file, FileMode.Open))
        {
            using (FileStream outputStream = new FileStream(outputFile, FileMode.Create))
            {
                int bytesRead;
                while((bytesRead = inputStream.ReadByte()) != -1)
                {
                    outputStream.WriteByte((byte)bytesRead);
                }
            }
        }
    }
}

