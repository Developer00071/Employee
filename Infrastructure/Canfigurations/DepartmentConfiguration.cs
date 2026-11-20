using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Canfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("department");
        builder.HasKey(department => department.Id);
        builder.Property(department => department.Id).HasColumnName("id");
        builder.Property(department => department.Name).HasColumnName("name");
        builder.Property(department => department.Description).HasColumnName("description");
        builder.Property(department => department.CreatedAt).HasColumnName("createdat");
    }
}
