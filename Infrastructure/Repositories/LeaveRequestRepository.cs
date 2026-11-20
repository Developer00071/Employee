namespace Infrastructure.Repositories;

using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class LeaveRequestRepository(AppDbContext appDbContext) : ILeaveRequestRepository
{
    public async Task<bool> AddLeaveRequest(LeaveRequest LeaveRequest)
    {
        await appDbContext.LeaveRequests.AddAsync(LeaveRequest);
        return await appDbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteLeaveRequest(int id)
    {
        var leaveRequest = await appDbContext.LeaveRequests.FindAsync(id);
        if (leaveRequest is null)
        {
            return false;
        }

        appDbContext.LeaveRequests.Remove(leaveRequest);
        return await appDbContext.SaveChangesAsync() > 0;
    }

    public async Task<LeaveRequest> GetLeaveRequest(int id)
    {
        return (await appDbContext.LeaveRequests.FindAsync(id))!;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequests()
    {
        return await appDbContext.LeaveRequests.ToListAsync();
    }

    public async Task<bool> UpdateLeaveRequest(LeaveRequest LeaveRequest)
    {
        appDbContext.LeaveRequests.Update(LeaveRequest);
        return await appDbContext.SaveChangesAsync() > 0;
    }
}
