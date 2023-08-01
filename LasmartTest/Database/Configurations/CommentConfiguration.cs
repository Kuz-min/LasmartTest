using LasmartTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LasmartTest.Database.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Text).IsRequired();
        builder.Property(c => c.Background).IsRequired();
        builder.Property(c => c.PointId).IsRequired();
    }
}