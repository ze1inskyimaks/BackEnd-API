using Microsoft.EntityFrameworkCore;

namespace API.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Item> Items { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Description)
                .HasMaxLength(500);
        });
        
        base.OnModelCreating(modelBuilder);
    }
}