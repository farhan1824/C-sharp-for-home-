using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class Books
    {
        [Key]
        public string BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryId { get; set; }
        public string AuthorId { get; set; }
    }
}
