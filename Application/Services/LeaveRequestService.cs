namespace Application.Servers;

using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

public class LeaveRequestService : ILeaveRequestServer
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequests()
    {
        var leaveRequests = await _leaveRequestRepository.GetLeaveRequests();
        return leaveRequests;
    }

    public async Task<LeaveRequest> GetLeaveRequest(int id)
    {
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequest(id);
        return leaveRequest;
    }

    public async Task<bool> AddLeaveRequest(LeaveRequest LeaveRequest)
    {
        var result = await _leaveRequestRepository.AddLeaveRequest(LeaveRequest);
        return result;
    }

    public async Task<bool> UpdateLeaveRequest(LeaveRequest LeaveRequest)
    {
        var result = await _leaveRequestRepository.UpdateLeaveRequest(LeaveRequest);
        return result;
    }

    public async Task<bool> DeleteLeaveRequest(int id)
    {
        var result = await _leaveRequestRepository.DeleteLeaveRequest(id);
        return result;
    }
}
