using Domain.Enums;

namespace Application.DTOs;

public class LeaveRequestDto
{
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Reason { get; set; }
    public LeaveTypeEnum LeaveType { get; set; }
    public LeaveStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }

}
