namespace Application.Interfaces;
using Domain.Models;
public interface IPositionServer
{
    Task<List<Position>> GetPositions();
    Task<Position> GetPosition(int id);
    Task<bool> AddPosition(Position Position);
    Task<bool> UpdatePosition(Position Position);
    Task<bool> DeletePosition(int id);
}
