using LasmartTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LasmartTest.Database.Configurations;

public class PointConfiguration : IEntityTypeConfiguration<Point>
{
    public void Configure(EntityTypeBuilder<Point> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.PositionX).IsRequired();
        builder.Property(p => p.PositionY).IsRequired();
        builder.Property(p => p.Radius).IsRequired();
        builder.Property(p => p.Color).IsRequired();

        builder.HasMany(p => p.Comments).WithOne(c => c.Point).HasForeignKey(c => c.PointId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
    }
}