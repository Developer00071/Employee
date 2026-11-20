namespace Infrastructure.Repositories;

using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class DepartmentRepository(AppDbContext _AppDbContext): IDepartmentRepository
{
    public async Task<bool> AddDepartment(Department Department)
    {
        await _AppDbContext.Departments.AddAsync(Department);
        return await _AppDbContext.SaveChangesAsync() > 0;
    }


    public async Task<bool> DeleteDepartment(int id)
    {
        var department = await _AppDbContext.Departments.FindAsync(id);
        if (department is null)
        {
            return false;
        }

        _AppDbContext.Departments.Remove(department);
        return await _AppDbContext.SaveChangesAsync() > 0;
    }

    


    public async Task<Department> GetDepartment(int id)
    {
        return (await _AppDbContext.Departments.FindAsync(id))!;
    }

    


    public async Task<List<Department>> GetDepartments()
    {
        return await _AppDbContext.Departments.ToListAsync();
    }

   


    public async Task<bool> UpdateDepartment(Department Departments)
    {
        _AppDbContext.Departments.Update(Departments);
        return await _AppDbContext.SaveChangesAsync() > 0;
    }
    
}
