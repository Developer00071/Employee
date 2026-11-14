namespace Application.Servers;

using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

public class EmployeeService : IEmployeeServer
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var employees = await _employeeRepository.GetEmployees();
        return employees;
    }

    public async Task<Employee> GetEmployee(int id)
    {
        var employee = await _employeeRepository.GetEmployee(id);
        return employee;
    }

    public async Task<bool> AddEmployee(Employee Employee)
    {
        var result = await _employeeRepository.AddEmployee(Employee);
        return result;
    }

    public async Task<bool> UpdateEmployee(Employee Employee)
    {
        var result = await _employeeRepository.UpdateEmployee(Employee);
        return result;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var result = await _employeeRepository.DeleteEmployee(id);
        return result;
    }
}
