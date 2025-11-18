
internal class Program
{
    static void Main(string[] args)
    {
        string directory = "C:\\Users\\Admin\\Desktop";
        var dirInfo = new DirectoryInfo(directory);
        var allFiles = dirInfo.GetFiles();
        var groupedFiles = allFiles.GroupBy(file => file.Extension).OrderByDescending(s => s.Count()).ThenByDescending(s => s.Key);
        string report = "";
        foreach (var group in groupedFiles)
        {
            var group1 = group.OrderBy(g => g.Length);
            report += group.Key + '\n';
            foreach (var file in group1)
            {
                report += "--" + file.Name + " - " + (file.Length / 1024.0).ToString("F3") + "kb" + '\n';
            }
        }
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string reportFile = Path.Combine(desktopPath, "report.txt");
        File.WriteAllText(reportFile, report);
    }
}
