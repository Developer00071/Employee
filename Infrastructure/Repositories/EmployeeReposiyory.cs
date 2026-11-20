namespace Infrastructure.Repositories;

using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class EmployeeReposiyory(AppDbContext appDbContext) : IEmployeeRepository
{
    public async Task<bool> AddEmployee(Employee Employee)
    {
        await appDbContext.Employees.AddAsync(Employee);
        return await appDbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employee = await appDbContext.Employees.FindAsync(id);
        if (employee is null)
        {
            return false;
        }

        appDbContext.Employees.Remove(employee);
        return await appDbContext.SaveChangesAsync() > 0;
    }

    public async Task<Employee> GetEmployee(int id)
    {
        return (await appDbContext.Employees.FindAsync(id))!;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        return await appDbContext.Employees.ToListAsync();
    }

    public async Task<bool> UpdateEmployee(Employee Employee)
    {
        appDbContext.Employees.Update(Employee);
        return await appDbContext.SaveChangesAsync() > 0;
    }
}
