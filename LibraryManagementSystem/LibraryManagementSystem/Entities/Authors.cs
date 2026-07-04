using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class Authors
    {
        [Key]
        public string AuthorId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
