using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(
    IEmployeeServer employeeServer,
    ILogger<EmployeeController> logger) : ControllerBase
{
    private readonly IEmployeeServer _employeeServer = employeeServer;
    private readonly ILogger<EmployeeController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<Employee>>> GetEmployees()
    {
        _logger.LogInformation("Getting all employees.");
        var employees = await _employeeServer.GetEmployees();
        _logger.LogInformation("Retrieved {Count} employees.", employees.Count);
        return new ApiResponse<List<Employee>>(HttpStatusCode.OK, "Employees retrieved.", employees);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Employee>> GetEmployee(int id)
    {
        _logger.LogInformation("Getting employee with ID {EmployeeId}.", id);
        var employee = await _employeeServer.GetEmployee(id);
        if (employee is null)
        {
            _logger.LogWarning("Employee with ID {EmployeeId} was not found.", id);
            return new ApiResponse<Employee>(HttpStatusCode.NotFound, "Employee not found.", null);
        }

        return new ApiResponse<Employee>(HttpStatusCode.OK, "Employee retrieved.", employee);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddEmployee([FromBody] Employee employee)
    {
        var result = await _employeeServer.AddEmployee(employee);
        _logger.LogInformation("Add employee operation completed with result {Result}.", result);
        var statusCode = result ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
        var message = result ? "Employee added." : "Employee was not added.";
        return new ApiResponse<bool>(statusCode, message, result);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateEmployee(int id, [FromBody] Employee employee)
    {
        employee.Id = id;
        var result = await _employeeServer.UpdateEmployee(employee);
        _logger.LogInformation("Update employee operation for ID {EmployeeId} completed with result {Result}.", id, result);
        var statusCode = result ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        var message = result ? "Employee updated." : "Employee was not found.";
        return new ApiResponse<bool>(statusCode, message, result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteEmployee(int id)
    {
        var result = await _employeeServer.DeleteEmployee(id);
        _logger.LogInformation("Delete employee operation for ID {EmployeeId} completed with result {Result}.", id, result);
        var statusCode = result ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        var message = result ? "Employee deleted." : "Employee was not found.";
        return new ApiResponse<bool>(statusCode, message, result);
    }
}
