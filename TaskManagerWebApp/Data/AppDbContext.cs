using Microsoft.EntityFrameworkCore;
using TaskManagerWebApp.Models;

namespace TaskManagerWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
               .HasOne(c => c.User)
               .WithMany(c => c.Categories)
               .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Tasks>()
               .HasOne(t=>t.User)
               .WithMany(t => t.Tasks) 
               .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Tasks>()
               .HasOne(t => t.Category)
               .WithMany(t => t.Tasks)
               .HasForeignKey(t => t.CategoryID);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
