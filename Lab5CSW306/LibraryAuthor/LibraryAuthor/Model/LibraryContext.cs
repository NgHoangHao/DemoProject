using Microsoft.EntityFrameworkCore;


namespace LibraryAuthor.Model
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Carousel> Carousel { get; set; }

    }
}
