using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class BorrowBooks
    {
        [Key]
        public string BorrowId { get; set; }
        public string UserId { get; set; }
        public string BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
