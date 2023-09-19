using Final_Project_Web_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Web_Application.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        // Forum Information.
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Models.Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}