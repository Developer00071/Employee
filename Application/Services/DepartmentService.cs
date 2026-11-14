namespace Application.Servers;

using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

public class DepartmentService : IDepartmentServer
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<List<Department>> GetDepartments()
    {
        var departments = await _departmentRepository.GetDepartments();
        return departments;
    }

    public async Task<Department> GetDepartment(int id)
    {
        var department = await _departmentRepository.GetDepartment(id);
        return department;
    }

    public async Task<bool> AddDepartment(DepartmentDto department)
    {
        var result = await _departmentRepository.AddDepartment(ToDepartment(department));
        return result;
    }

    public async Task<bool> UpdateDepartment(DepartmentDto department)
    {
        var result = await _departmentRepository.UpdateDepartment(ToDepartment(department));
        return result;
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        var result = await _departmentRepository.DeleteDepartment(id);
        return result;
    }

    private static Department ToDepartment(DepartmentDto department)
    {
        return new Department
        {
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt
        };
    }
}