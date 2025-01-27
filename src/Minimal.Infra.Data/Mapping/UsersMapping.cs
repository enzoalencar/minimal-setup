using Microsoft.EntityFrameworkCore;
using Minimal.Domain.Users;

namespace Minimal.Infra.Data.Mapping;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(o => o.Id);
            
            entity.Property(o => o.Name).HasMaxLength(150);
            entity.Property(o => o.Status).IsRequired();
            entity.Property(o => o.Email).HasMaxLength(150);
            entity.Property(o => o.PhoneNumber).HasMaxLength(150);
            entity.Property(o => o.CreatedAt).IsRequired().HasColumnType("timestamptz"); 
        });
    }
}