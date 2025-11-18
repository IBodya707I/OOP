using System;
using System.IO.Compression;

internal class Program
{
    static void Main(string[] args)
    {
        string file = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\pexels-lukas-hartmann-304281-1557652.jpg";
        string zipFile = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\Archive.zip";
        using(var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
        {
            archive.CreateEntryFromFile(file, "photo.jpg");
        }
        string extractPath = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\Extracted";
        ZipFile.ExtractToDirectory(zipFile, extractPath);
    }
}
