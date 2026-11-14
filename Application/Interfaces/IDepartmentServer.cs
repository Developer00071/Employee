namespace Application.Interfaces;
using Domain.Models;
using Application.DTOs;

public interface IDepartmentServer
{
    Task<List<Department>> GetDepartments();
    Task<Department> GetDepartment(int id);
    Task<bool> AddDepartment(DepartmentDto DepartmentDto);
    Task<bool> UpdateDepartment(DepartmentDto DepartmentDto);
    Task<bool> DeleteDepartment(int id);
    

}
