namespace Infrastructure.Repositories;

using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

public class EmployeeReposiyory(AppDbContext _AppDbContext) : IEmployeeRepository
{
    private AppDbContext _AppDbContext = _AppDbContext;

    public async Task<bool> AddEmployee(Employee Employee)
    {
        var connection = _AppDbContext.Connection();
        var query = "insert into Employee(FirstName, LastName, Email, Phone, Hiredate, Salary, IsActive, DepartmentId, PositionId) values(@FirstName, @LastName, @Email, @Phone, @Hiredate, @Salary, @IsActive, @DepartmentId, @PositionId)";
        var res = await connection.ExecuteAsync(query, Employee);
        return res > 0;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var connection = _AppDbContext.Connection();
        var query = "delete from Employee where id=@id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Employee> GetEmployee(int id)
    {
        var connection = _AppDbContext.Connection();
        var query = "select * from Employee where id=@id";
        var res = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { id });
        return res!;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var connection = _AppDbContext.Connection();
        var query = "select * from Employee";
        var res = await connection.QueryAsync<Employee>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateEmployee(Employee Employee)
    {
        var connection = _AppDbContext.Connection();
        var query = "update Employee set FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, Hiredate=@Hiredate, Salary=@Salary, IsActive=@IsActive, DepartmentId=@DepartmentId, PositionId=@PositionId where id=@id";
        var res = await connection.ExecuteAsync(query, Employee);
        return res > 0;
    }
}
