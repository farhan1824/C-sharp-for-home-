using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class Categories
    {
        [Key]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
