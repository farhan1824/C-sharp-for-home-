using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Members> Members { get; set; }
        public DbSet<Entities.Authors> Authors { get; set; }
        public DbSet<Entities.Categories> Categories { get; set; }
        public DbSet<Entities.Books> Books { get; set; }
        public DbSet<Entities.BorrowBooks> BorrowBooks { get; set; }
        public DbSet<Entities.Registrations> Registrations { get; set; }
    }
}