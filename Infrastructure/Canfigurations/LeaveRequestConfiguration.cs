using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Canfigurations;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.ToTable("leaverequest");
        builder.HasKey(leaveRequest => leaveRequest.Id);
        builder.Property(leaveRequest => leaveRequest.Id).HasColumnName("id");
        builder.Property(leaveRequest => leaveRequest.EmployeeId).HasColumnName("employeeid");
        builder.Property(leaveRequest => leaveRequest.LeaveType).HasColumnName("leavetype");
        builder.Property(leaveRequest => leaveRequest.StartDate).HasColumnName("startdate");
        builder.Property(leaveRequest => leaveRequest.EndDate).HasColumnName("enddate");
        builder.Property(leaveRequest => leaveRequest.Status).HasColumnName("status");
        builder.Property(leaveRequest => leaveRequest.Reason).HasColumnName("reason");
        builder.Property(leaveRequest => leaveRequest.CreatedAt).HasColumnName("createdat");
    }
}
