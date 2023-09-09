using Final_Project_Web_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Web_Application.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<Forum> Forums { get; set; }
    }
}