namespace Infrastructure.Repositories;

using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
public class DepartmentRepository(AppDbContext _AppDbContext): IDepartmentRepository
{
        private AppDbContext _AppDbContext = _AppDbContext;

   
    public async Task<bool> AddDepartment(Department Department)
    {
        var connection = _AppDbContext.Connection();
        var query = "insert into Department(Name, Description, CreatedAt) values(@Name, @Description, @CreatedAt)";
        var res = await connection.ExecuteAsync(query, Department);
        return res>0;
    }


    public async Task<bool> DeleteDepartment(int id)
    {
        var connection = _AppDbContext.Connection();
        var query = "delete from Department where id=@id";
        var res = await connection.ExecuteAsync(query, new{id});
        return res>0;
    }

    


    public async Task<Department> GetDepartment(int id)
    {
        var connection = _AppDbContext.Connection();
        var query = "select * from Department where id=@id";
        var res = await connection.QuerySingleOrDefaultAsync<Department>(query, new{id});
        return res!;
    }

    


    public async Task<List<Department>> GetDepartments()
    {
        var connection = _AppDbContext.Connection();
        var query = "select * from Department";
        var res = await connection.QueryAsync<Department>(query);
        return res.ToList();    
    }

   


    public async Task<bool> UpdateDepartment(Department Departments)
    {
        var connection = _AppDbContext.Connection();
        var query = "update Departments set Name=@name, Description=@Description, CreatedAt=@CreatedAt where id=@id";
        var res = await connection.ExecuteAsync(query, Departments);
        return res>0;
    }
    
}
