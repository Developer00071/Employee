namespace Infrastructure.Repositories;

using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class PositionRepository(AppDbContext appDbContext) : IPositionRepository
{
    public async Task<bool> AddPosition(Position Position)
    {
        await appDbContext.Positions.AddAsync(Position);
        return await appDbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletePosition(int id)
    {
        var position = await appDbContext.Positions.FindAsync(id);
        if (position is null)
        {
            return false;
        }

        appDbContext.Positions.Remove(position);
        return await appDbContext.SaveChangesAsync() > 0;
    }

    public async Task<Position> GetPosition(int id)
    {
        return (await appDbContext.Positions.FindAsync(id))!;
    }

    public async Task<List<Position>> GetPositions()
    {
        return await appDbContext.Positions.ToListAsync();
    }

    public async Task<bool> UpdatePosition(Position Position)
    {
        appDbContext.Positions.Update(Position);
        return await appDbContext.SaveChangesAsync() > 0;
    }
}
