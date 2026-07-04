using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Entities
{
    public class Registrations: IdentityUser
    {
        //public int id { get; set; }
        public string StudentId { get; set; }
        public string FullName { get; set; }
    }
}
