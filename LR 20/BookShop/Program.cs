using BookShop.Data;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace BookShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("BookShop Menu");
                Console.WriteLine("2. Age Restriction");
                Console.WriteLine("3. Golden Books");
                Console.WriteLine("4. Books by Price");
                Console.WriteLine("5. Not Released In");
                Console.WriteLine("6. Book Titles by Category");
                Console.WriteLine("7. Released Before Date");
                Console.WriteLine("8. Author Search");
                Console.WriteLine("9. Book Search");
                Console.WriteLine("10. Book Search by Author");
                Console.WriteLine("11. Count Books");
                Console.WriteLine("12. Total Book Copies");
                Console.WriteLine("13. Profit by Category");
                Console.WriteLine("14. Most Recent Books");
                Console.WriteLine("15. Increase Prices");
                Console.WriteLine("16. Remove Books");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "2":
                        Console.Write("Enter age restriction (Minor, Teen, Adult): ");
                        string command2 = Console.ReadLine();
                        Console.WriteLine(GetBooksByAgeRestriction(context, command2));
                        break;

                    case "3":
                        Console.WriteLine(GetGoldenBooks(context));
                        break;

                    case "4":
                        Console.WriteLine(GetBooksByPrice(context));
                        break;

                    case "5":
                        Console.Write("Enter year: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine(GetBooksNotReleasedIn(context, year));
                        break;

                    case "6":
                        Console.Write("Enter categories: ");
                        string cats = Console.ReadLine();
                        Console.WriteLine(GetBooksByCategory(context, cats));
                        break;

                    case "7":
                        Console.Write("Enter date (dd-MM-yyyy): ");
                        string date = Console.ReadLine();
                        Console.WriteLine(GetBooksReleasedBefore(context, date));
                        break;

                    case "8":
                        Console.Write("Enter author name ending: ");
                        string ending = Console.ReadLine();
                        Console.WriteLine(GetAuthorNamesEndingIn(context, ending));
                        break;

                    case "9":
                        Console.Write("Enter book title part: ");
                        string titlePart = Console.ReadLine();
                        Console.WriteLine(GetBookTitlesContaining(context, titlePart));
                        break;

                    case "10":
                        Console.Write("Enter author last name start: ");
                        string start = Console.ReadLine();
                        Console.WriteLine(GetBooksByAuthor(context, start));
                        break;

                    case "11":
                        Console.Write("Enter title length: ");
                        int length = int.Parse(Console.ReadLine());
                        Console.WriteLine(CountBooks(context, length));
                        break;

                    case "12":
                        Console.WriteLine(CountCopiesByAuthor(context));
                        break;

                    case "13":
                        Console.WriteLine(GetTotalProfitByCategory(context));
                        break;

                    case "14":
                        Console.WriteLine(GetMostRecentBooks(context));
                        break;

                    case "15":
                        Console.WriteLine("Increasing prices...");
                        IncreasePrices(context);
                        Console.WriteLine("Done.");
                        break;

                    case "16":
                        Console.WriteLine("Removing books...");
                        int removed = RemoveBooks(context);
                        Console.WriteLine($"{removed} books were deleted.");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
                Console.ReadKey();
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse<AgeRestriction>(command, true, out var ageRestriction))
            {
                return null;
            }
            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();
            return String.Join(Environment.NewLine, books);
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();
            string BooksByPrice = "";
            foreach (var book in books)
            {
                BooksByPrice += book.Title + " - " + book.Price.ToString("F2") + "\n";
            }
            return BooksByPrice;
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateOnly.Parse(date);
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();
            string result = "";
            foreach (var book in books)
            {
                result += book.Title + " - " + book.EditionType + " - " + book.Price.ToString("F2") + "\n";
            }
            return result;
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();
            string result = "";
            foreach (var author in authors)
            {
                result += author.FirstName + " " + author.LastName + "\n";
            }
            return result;
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .ToList();
            string result = "";
            foreach (var book in books)
            {
                result += book.Title + " (" + book.Author.FirstName + book.Author.LastName + ")\n";
            }
            return result;
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors.Include(a => a.Books)
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.TotalCopies)
                .ToList();
            string result = "";
            foreach (var author in authors)
            {
                result += author.FullName + " - " + author.TotalCopies + "\n";
            }
            return result;
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories.Include(c => c.BookCategories).ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.BookCategories.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();
            string result = "";
            foreach (var category in categories)
            {
                result += category.Name + " $" + category.TotalProfit.ToString("F2") + "\n";
            }
            return result;
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories.Include(c => c.BookCategories).ThenInclude(cb => cb.Book)
                .OrderByDescending(c => c.BookCategories.Count)
                .Select(c => new
                {
                    c.Name,
                    MostRecentBooks = c.BookCategories
                        .Where(cb => cb.Book.ReleaseDate != null)
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => new { cb.Book.Title, cb.Book.ReleaseDate.Value.Year })
                        .ToList()
                })
                .ToList();
            string result = "";
            foreach (var category in categories)
            {
                result += "--" + category.Name + "\n";
                foreach (var mostRecentBook in category.MostRecentBooks)
                {
                    result += mostRecentBook.Title + " (" + mostRecentBook.Year + ")\n";
                }
            }
            return result;
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var cutoffDate = new DateOnly(2010, 1, 1);

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate < cutoffDate)
                .ToList();
            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();
            int count = booksToDelete.Count;
            context.Books.RemoveRange(booksToDelete);
            context.SaveChanges();
            return count;
        }
        public static void Seed(BookShopContext context)
        {
            if (context.Books.Any())
            {
                return;
            }
            var authors = new List<Author>
            {
                new Author { FirstName = "George", LastName = "Orwell" },
                new Author { FirstName = "Agatha", LastName = "Christie" },
                new Author { FirstName = "Stephen", LastName = "King" },
                new Author { FirstName = "J.K.", LastName = "Rowling" }
            };
            context.Authors.AddRange(authors);
            context.SaveChanges();
            var categories = new List<Category>
            {
                new Category { Name = "Sci-Fi" },
                new Category { Name = "Horror" },
                new Category { Name = "Mystery" },
                new Category { Name = "Drama" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
            var books = new List<Book>
            {
                new Book
                {
                    Title = "The Shining",
                    Description = "A horror masterpiece.",
                    ReleaseDate = new DateOnly(1977, 1, 28),
                    Copies = 3000,
                    Price = 25.50m,
                    EditionType = EditionType.Normal,
                    AgeRestriction = AgeRestriction.Adult,
                    AuthorId = authors[2].AuthorId
                },
                new Book
                {
                    Title = "Golden Mystery",
                    Description = "A very rare book.",
                    ReleaseDate = new DateOnly(1995, 5, 5),
                    Copies = 4000,
                    Price = 15.00m,
                    EditionType = EditionType.Gold,
                    AgeRestriction = AgeRestriction.Teen,
                    AuthorId = authors[1].AuthorId
                },
                new Book
                {
                    Title = "Expensive Tech",
                    Description = "Learn C# fast.",
                    ReleaseDate = new DateOnly(2020, 10, 10),
                    Copies = 10000,
                    Price = 55.00m,
                    EditionType = EditionType.Promo,
                    AgeRestriction = AgeRestriction.Minor,
                    AuthorId = authors[0].AuthorId
                },
                 new Book
                {
                    Title = "1984",
                    Description = "Dystopian social science fiction.",
                    ReleaseDate = new DateOnly(1949, 6, 8),
                    Copies = 50000,
                    Price = 12.00m,
                    EditionType = EditionType.Normal,
                    AgeRestriction = AgeRestriction.Adult,
                    AuthorId = authors[0].AuthorId
                }
            };
            context.Books.AddRange(books);
            context.SaveChanges();
            var bookCategories = new List<BookCategory>
            {
                new BookCategory { BookId = books[0].BookId, CategoryId = categories[1].CategoryId },
                new BookCategory { BookId = books[1].BookId, CategoryId = categories[2].CategoryId },
                new BookCategory { BookId = books[3].BookId, CategoryId = categories[0].CategoryId },
                new BookCategory { BookId = books[3].BookId, CategoryId = categories[3].CategoryId }
            };
            context.BookCategories.AddRange(bookCategories);
            context.SaveChanges();
        }
    };
}
