using System;
class InvalidSongException : Exception
{
    public InvalidSongException(string message = "invalid song") : base(message) { }
}
class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException(string message = "Artist name should be between 3 and 20 symbols.") : base(message) { }
}
class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException(string message = "Song name should be between 3 and 30 symbols.") : base(message) { }
}
class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException(string message = "Invalid song length.") : base(message) { }
}
class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException(string message = "Song minutes should be between 0 and 14.") : base(message) { }
}
class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException(string message = "Song seconds should be between 0 and 59.") : base(message) { }
}
class Song
{
    private string artist;
    private string name;
    private int minutes;
    private int seconds;
    public string Artist
    {
        get { return artist; }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new InvalidArtistNameException();
            artist = value;
        }
    }
    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
                throw new InvalidSongNameException();
            name = value;
        }
    }
    public int Minutes
    {
        get { return minutes; }
        private set
        {
            if (value < 0 || value > 14)
                throw new InvalidSongMinutesException();
            minutes = value;
        }
    }
    public int Seconds
    {
        get { return seconds; }
        private set
        {
            if (value < 0 || value > 59)
                throw new InvalidSongSecondsException();
            seconds = value;
        }
    }
    public Song(string artist, string name, int minutes, int seconds)
    {
        Artist = artist;
        Name = name;
        Minutes = minutes;
        Seconds = seconds;
    }

}
internal class Program
    {
        static void Main()
        {
            Console.Write("Enten n: ");
            int n = int.Parse(Console.ReadLine());
            int totalSeconds = 0;
            int songsAdded = 0;
            Console.WriteLine("Artist;SongName;Minutes:Seconds");
        for (int i = 0; i < n; i++)
            {
                string[] text = Console.ReadLine().Split(";");
                string[] time = text[2].Split(":");
                int minutes = int.Parse(time[0]);
                int seconds = int.Parse(time[1]);
                try
                {
                    Song song = new Song(text[0], text[1], minutes, seconds);
                    Console.WriteLine("Song added.");
                    totalSeconds += minutes * 60 + seconds;
                    songsAdded++;
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Songs added: " + songsAdded);
            int hours = totalSeconds / 3600;
            int minutesTotal = (totalSeconds % 3600) / 60;
            int secondsTotal = totalSeconds % 60;
            Console.WriteLine("Playlist length: " + hours + "h " + minutesTotal + "m " + secondsTotal + "s");
        }
    }

