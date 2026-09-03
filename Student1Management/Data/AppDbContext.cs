using Microsoft.EntityFrameworkCore;
using Student1Management.Controllers;
using Student1Management.Model;

namespace Student1Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    public DbSet<Student> StudentDbSet { get; set; }

    }
}
