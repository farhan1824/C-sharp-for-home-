using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class RegistrationsVm
    {
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string StudentId { get; set; }
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        public string Password { get; set; }
    }
}
