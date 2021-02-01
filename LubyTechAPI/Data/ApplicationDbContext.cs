using Microsoft.EntityFrameworkCore;
using LubyTechAPI.Models;

namespace LubyTechAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Developers_Projects> Developers_Projects { get; set; }
    }
}