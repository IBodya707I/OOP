class WordCount
{
    public string Word { get; set; }
    public int Count { get; set; }
    public WordCount(string word, int count)
    {
        Word = word;
        Count = count;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        string file = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\text.txt";
        string wordsFile = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\words.txt";
        string actualResultFile = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\actualResult.txt";
        string exceptedResultFile = "C:\\Users\\Admin\\Desktop\\C#\\LR 15\\expectedResult.txt";
        string text = File.ReadAllText(file).ToLower();
        string[] words = File.ReadAllLines(wordsFile);
        string[] textSplit = text.Split(new char[] { '.', ',', '!', '?', '-', '\n', '\r', ' '}, StringSplitOptions.RemoveEmptyEntries);
        List<WordCount> wordCounts = new List<WordCount>();
        foreach (string word in words)
        {
            int count = textSplit.Count(w => w == word.ToLower());
            wordCounts.Add(new WordCount(word, count));
        }
        string actualResultLines = "";
        foreach(var v in wordCounts)
        {
            actualResultLines += v.Word + " - " + v.Count + '\n';
        }
        File.WriteAllText(actualResultFile, actualResultLines);
        var sortedWordCounts = wordCounts.OrderByDescending(word => word.Count).ToList();
        string expectedResultLines = "";
        foreach(var v in sortedWordCounts)
        {
            expectedResultLines += v.Word + " - " + v.Count + '\n';
        }
        File.WriteAllText(exceptedResultFile, expectedResultLines);
    }
}

