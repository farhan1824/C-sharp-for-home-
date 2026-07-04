using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class CategoriesVm
    {
        [Key]
        public string CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
