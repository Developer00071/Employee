using Domain.Models;

namespace Domain.Interfaces;

public interface ILeaveRequestRepository
{
    Task<bool> AddLeaveRequest(LeaveRequest LeaveRequest);
    Task<bool> UpdateLeaveRequest(LeaveRequest LeaveRequest);
    Task<bool> DeleteLeaveRequest(int id);
    Task<LeaveRequest> GetLeaveRequest(int id);
    Task<List<LeaveRequest>> GetLeaveRequests();
}
