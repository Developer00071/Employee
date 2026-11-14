namespace Infrastructure.Repositories;

using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

public class LeaveRequestRepository(AppDbContext _AppDbContext) : ILeaveRequestRepository
{
    private AppDbContext _AppDbContext = _AppDbContext;

    public async Task<bool> AddLeaveRequest(LeaveRequest LeaveRequest)
    {
        var connection = _AppDbContext.Connection();
        var query = "insert into LeaveRequest(EmployeeId, LeaveType, StartDate, EndDate, Status, Reason, CreatedAt) values(@EmployeeId, @LeaveType, @StartDate, @EndDate, @Status, @Reason, @CreatedAt)";
        var res = await connection.ExecuteAsync(query, LeaveRequest);
        return res > 0;
    }

    public async Task<bool> DeleteLeaveRequest(int id)
    {
        var connection = _AppDbContext.Connection();
        var query = "delete from LeaveRequest where id=@id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<LeaveRequest> GetLeaveRequest(int id)
    {
        var connection = _AppDbContext.Connection();
        var query = "select * from LeaveRequest where id=@id";
        var res = await connection.QuerySingleOrDefaultAsync<LeaveRequest>(query, new { id });
        return res!;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequests()
    {
        var connection = _AppDbContext.Connection();
        var query = "select * from LeaveRequest";
        var res = await connection.QueryAsync<LeaveRequest>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateLeaveRequest(LeaveRequest LeaveRequest)
    {
        var connection = _AppDbContext.Connection();
        var query = "update LeaveRequest set EmployeeId=@EmployeeId, LeaveType=@LeaveType, StartDate=@StartDate, EndDate=@EndDate, Status=@Status, Reason=@Reason, CreatedAt=@CreatedAt where id=@id";
        var res = await connection.ExecuteAsync(query, LeaveRequest);
        return res > 0;
    }
}
