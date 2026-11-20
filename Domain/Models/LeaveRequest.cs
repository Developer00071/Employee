using Domain.Enums;

namespace Domain.Models;

public class LeaveRequest
{
    public int Id {get; set; }
    public int EmployeeId {get; set;}
    public LeaveTypeEnum LeaveType {get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public LeaveStatusEnum Status {get; set;}
    public string ? Reason {get; set;}
    public DateTime CreatedAt {get; set;}

}
