using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Canfigurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("position");
        builder.HasKey(position => position.Id);
        builder.Property(position => position.Id).HasColumnName("id");
        builder.Property(position => position.Title).HasColumnName("title");
        builder.Property(position => position.MinSalary).HasColumnName("minsalary");
        builder.Property(position => position.MaxSalary).HasColumnName("maxsalary");
    }
}
