namespace Domain.Interfaces;
using Domain.Models;
public interface IEmployeeRepository
{
    Task<bool> AddEmployee(Employee Employee);
    Task<bool> UpdateEmployee(Employee Employee);
    Task<bool> DeleteEmployee(int id);
    Task<Employee> GetEmployee(int id);
    Task<List<Employee>> GetEmployees();
    
}
