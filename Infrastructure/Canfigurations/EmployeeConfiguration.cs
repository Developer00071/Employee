using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Canfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employee");
        builder.HasKey(employee => employee.Id);
        builder.Property(employee => employee.Id).HasColumnName("id");
        builder.Property(employee => employee.FirstName).HasColumnName("firstname");
        builder.Property(employee => employee.LastName).HasColumnName("lastname");
        builder.Property(employee => employee.Email).HasColumnName("email");
        builder.Property(employee => employee.Phone).HasColumnName("phone");
        builder.Property(employee => employee.Hiredate).HasColumnName("hiredate");
        builder.Property(employee => employee.Salary).HasColumnName("salary");
        builder.Property(employee => employee.IsActive).HasColumnName("isactive");
        builder.Property(employee => employee.DepartmentId).HasColumnName("departmentid");
        builder.Property(employee => employee.PositionId).HasColumnName("positionid");
    }
}
