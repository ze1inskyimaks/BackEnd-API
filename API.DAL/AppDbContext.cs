using Microsoft.EntityFrameworkCore;

namespace API.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Item> Items { set; get; }
    public DbSet<User> Users { set; get; }

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
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(32);
            entity.Property(e => e.HashPassword)
                .IsRequired();
        });
        
        base.OnModelCreating(modelBuilder);
    }
}