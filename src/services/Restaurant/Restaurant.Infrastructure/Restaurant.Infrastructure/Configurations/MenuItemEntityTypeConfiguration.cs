using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Infrastructure.Models;

namespace Restaurant.Infrastructure.Configurations;

public class MenuItemEntityTypeConfiguration : IEntityTypeConfiguration<MenuItemDbEntity>
{
    public void Configure(EntityTypeBuilder<MenuItemDbEntity> builder)
    {
        builder.Property(x => x.Price).HasPrecision(2).HasColumnType("decimal(4,2)");
    }
}
