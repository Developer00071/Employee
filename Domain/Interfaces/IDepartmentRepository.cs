using Domain.Models;
namespace Domain.Interfaces;
public interface IDepartmentRepository
{
    Task<bool> AddDepartment(Department Department);
    Task<bool> UpdateDepartment(Department Departments);
    Task<bool> DeleteDepartment(int id);
    Task<Department> GetDepartment(int id);
    Task<List<Department>> GetDepartments();
    
}
