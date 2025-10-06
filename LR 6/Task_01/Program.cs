using System;
using System.Text;
class Book
{
    private string author;
    private string title;
    private decimal price;
    public string Author
    {
        get
        {
            return this.author;
        }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Author not valid!");
            string[] name = value.Split(' ' , StringSplitOptions.RemoveEmptyEntries);
            if (name.Length > 1 && char.IsDigit(name[1][0]))
                throw new ArgumentException("Author not valid!");
            this.author = value;
        }
    }
    public string Title
    {
        get
        {
            return this.title;
        }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                throw new ArgumentException("Title not valid!");
            this.title = value;
        }
    }
    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        protected set
        {
            if(value <= 0)
                throw new ArgumentException("Price not valid!");
            this.price = value;
        }
    }
    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }
    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
        .AppendLine($"Title: {this.Title}")
        .AppendLine($"Author: {this.Author}")
        .AppendLine($"Price: {this.Price:f2}");
        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}
class GoldenEditionBook : Book
{
    public override decimal Price
    {
        get
        {
            return base.Price * 1.3m;
        }
    }
    public GoldenEditionBook(string author, string title, decimal price)
        : base(author, title, price)
    {
    }
}
internal class Program
    {
        static void Main()
        {
        try
        {
            Console.Write("author: ");
            string author = Console.ReadLine();
            Console.Write("title: ");
            string title = Console.ReadLine();
            Console.Write("price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Book book = new Book(author, title, price);
            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);
            Console.WriteLine(book + Environment.NewLine);
            Console.WriteLine(goldenEditionBook);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

    }
}

