namespace Application.Interfaces;
using Domain.Models;
public interface ILeaveRequestServer
{
    Task<List<LeaveRequest>> GetLeaveRequests();
    Task<LeaveRequest> GetLeaveRequest(int id);
    Task<bool> AddLeaveRequest(LeaveRequest LeaveRequest);
    Task<bool> UpdateLeaveRequest(LeaveRequest LeaveRequest);
    Task<bool> DeleteLeaveRequest(int id);
}
