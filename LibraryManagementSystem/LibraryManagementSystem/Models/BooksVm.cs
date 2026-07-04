using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class BooksVm
    {
        [Key]
        public string BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Catrgory")]
        public string CategoryId { get; set; }
        [Required]
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
    }
}
