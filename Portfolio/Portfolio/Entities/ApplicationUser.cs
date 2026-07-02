using Microsoft.AspNetCore.Identity;

namespace Portfolio.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string Phone { get; internal set; }
        public string Address { get; internal set; }
    }
}
