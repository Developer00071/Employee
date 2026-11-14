namespace Infrastructure.Repositories;

using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

public class PositionRepository(AppDbContext _AppDbContext) : IPositionRepository
{
    private AppDbContext _AppDbContext = _AppDbContext;

    public async Task<bool> AddPosition(Position Position)
    {
        var connection = _AppDbContext.Connection();
        var query = "insert into Position(Title, MinSalary, MaxSalary) values(@Title, @MinSalary, @MaxSalary)";
        var res = await connection.ExecuteAsync(query, Position);
        return res > 0;
    }

    public async Task<bool> DeletePosition(int id)
    {
        var connection = _AppDbContext.Connection();
        var query = "delete from Position where id=@id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Position> GetPosition(int id)
    {
        var connection = _AppDbContext.Connection();
        var query = "select * from Position where id=@id";
        var res = await connection.QuerySingleOrDefaultAsync<Position>(query, new { id });
        return res!;
    }

    public async Task<List<Position>> GetPositions()
    {
        var connection = _AppDbContext.Connection();
        var query = "select * from Position";
        var res = await connection.QueryAsync<Position>(query);
        return res.ToList();
    }

    public async Task<bool> UpdatePosition(Position Position)
    {
        var connection = _AppDbContext.Connection();
        var query = "update Position set Title=@Title, MinSalary=@MinSalary, MaxSalary=@MaxSalary where id=@id";
        var res = await connection.ExecuteAsync(query, Position);
        return res > 0;
    }
}
