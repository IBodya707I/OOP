using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    internal class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(50)] 
        public string Name { get; set; }    
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
