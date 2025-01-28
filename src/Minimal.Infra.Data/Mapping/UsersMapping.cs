using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minimal.Domain.Users;

namespace Minimal.Infra.Data.Mapping;

public class UsersMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Name).HasMaxLength(150);
        builder.Property(o => o.Status).IsRequired();
        builder.Property(o => o.Email).HasMaxLength(150);
        builder.Property(o => o.PhoneNumber).HasMaxLength(150);
        builder.Property(o => o.CreatedAt).IsRequired().HasColumnType("timestamptz");
    }
}