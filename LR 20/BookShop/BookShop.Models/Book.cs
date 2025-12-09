using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }
    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }
    internal class Book
    {
        [Key]
        public int BookId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public EditionType EditionType { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public int Copies { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
