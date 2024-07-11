using Microsoft.EntityFrameworkCore;
using NavigationSystem.Models;

namespace NavigationSystem
{
    public class AppDbContext : DbContext
    {
        public DbSet<NavigationItem> NavigationItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<NavigationItem>()
                .HasOne(n => n.Parent)
                .WithMany(n => n.Children)
                .HasForeignKey(n => n.ParentId);
        }
    }

}
