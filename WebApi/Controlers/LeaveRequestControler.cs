using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveRequestController(
    ILeaveRequestServer leaveRequestServer,
    ILogger<LeaveRequestController> logger) : ControllerBase
{
    private readonly ILeaveRequestServer _leaveRequestServer = leaveRequestServer;
    private readonly ILogger<LeaveRequestController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<LeaveRequest>>> GetLeaveRequests()
    {
        _logger.LogInformation("Getting all leave requests.");
        var leaveRequests = await _leaveRequestServer.GetLeaveRequests();
        _logger.LogInformation("Retrieved {Count} leave requests.", leaveRequests.Count);
        return new ApiResponse<List<LeaveRequest>>(HttpStatusCode.OK, "Leave requests retrieved.", leaveRequests);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<LeaveRequest>> GetLeaveRequest(int id)
    {
        _logger.LogInformation("Getting leave request with ID {LeaveRequestId}.", id);
        var leaveRequest = await _leaveRequestServer.GetLeaveRequest(id);
        if (leaveRequest is null)
        {
            _logger.LogWarning("Leave request with ID {LeaveRequestId} was not found.", id);
            return new ApiResponse<LeaveRequest>(HttpStatusCode.NotFound, "Leave request not found.", null);
        }

        return new ApiResponse<LeaveRequest>(HttpStatusCode.OK, "Leave request retrieved.", leaveRequest);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddLeaveRequest([FromBody] LeaveRequest leaveRequest)
    {
        var result = await _leaveRequestServer.AddLeaveRequest(leaveRequest);
        _logger.LogInformation("Add leave request operation completed with result {Result}.", result);
        var statusCode = result ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
        var message = result ? "Leave request added." : "Leave request was not added.";
        return new ApiResponse<bool>(statusCode, message, result);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateLeaveRequest(int id, [FromBody] LeaveRequest leaveRequest)
    {
        leaveRequest.Id = id;
        var result = await _leaveRequestServer.UpdateLeaveRequest(leaveRequest);
        _logger.LogInformation("Update leave request operation for ID {LeaveRequestId} completed with result {Result}.", id, result);
        var statusCode = result ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        var message = result ? "Leave request updated." : "Leave request was not found.";
        return new ApiResponse<bool>(statusCode, message, result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteLeaveRequest(int id)
    {
        var result = await _leaveRequestServer.DeleteLeaveRequest(id);
        _logger.LogInformation("Delete leave request operation for ID {LeaveRequestId} completed with result {Result}.", id, result);
        var statusCode = result ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        var message = result ? "Leave request deleted." : "Leave request was not found.";
        return new ApiResponse<bool>(statusCode, message, result);
    }
}
