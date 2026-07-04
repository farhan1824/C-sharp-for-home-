using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class AuthorsVm
    {
        [Key]
        public string AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
