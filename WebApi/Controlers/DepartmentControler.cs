using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController(
    IDepartmentServer departmentServer,
    ILogger<DepartmentController> logger) : ControllerBase
{
    private readonly IDepartmentServer _departmentServer = departmentServer;
    private readonly ILogger<DepartmentController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<DepartmentDto>>> GetDepartments()
    {
        _logger.LogInformation("Getting all departments.");
        var departments = await _departmentServer.GetDepartments();
        var departmentDtos = departments.Select(ToDto).ToList();
        _logger.LogInformation("Retrieved {Count} departments.", departmentDtos.Count);
        return new ApiResponse<List<DepartmentDto>>(HttpStatusCode.OK, "Departments retrieved.", departmentDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<DepartmentDto>> GetDepartment(int id)
    {
        _logger.LogInformation("Getting department with ID {DepartmentId}.", id);
        var department = await _departmentServer.GetDepartment(id);
        if (department is null)
        {
            _logger.LogWarning("Department with ID {DepartmentId} was not found.", id);
            return new ApiResponse<DepartmentDto>(HttpStatusCode.NotFound, "Department not found.", null);
        }

        return new ApiResponse<DepartmentDto>(HttpStatusCode.OK, "Department retrieved.", ToDto(department));
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddDepartment([FromBody] DepartmentDto department)
    {
        var result = await _departmentServer.AddDepartment(department);
        _logger.LogInformation("Add department operation completed with result {Result}.", result);
        var statusCode = result ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
        var message = result ? "Department added." : "Department was not added.";
        return new ApiResponse<bool>(statusCode, message, result);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateDepartment([FromBody] DepartmentDto department)
    {
        var result = await _departmentServer.UpdateDepartment(department);
        _logger.LogInformation("Update department operation completed with result {Result}.", result);
        var statusCode = result ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        var message = result ? "Department updated." : "Department was not found.";
        return new ApiResponse<bool>(statusCode, message, result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteDepartment(int id)
    {
        var result = await _departmentServer.DeleteDepartment(id);
        _logger.LogInformation("Delete department operation for ID {DepartmentId} completed with result {Result}.", id, result);
        var statusCode = result ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        var message = result ? "Department deleted." : "Department was not found.";
        return new ApiResponse<bool>(statusCode, message, result);
    }

    private static DepartmentDto ToDto(Domain.Models.Department department)
    {
        return new DepartmentDto
        {
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt
        };
    }
}
