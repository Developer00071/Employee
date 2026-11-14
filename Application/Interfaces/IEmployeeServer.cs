namespace Application.Interfaces;
using Domain.Models;
public interface IEmployeeServer
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(int id);
    Task<bool> AddEmployee(Employee Employee);
    Task<bool> UpdateEmployee(Employee Employee);
    Task<bool> DeleteEmployee(int id);
    
}
