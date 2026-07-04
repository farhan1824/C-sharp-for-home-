using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class Members
    {
        [Key]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
