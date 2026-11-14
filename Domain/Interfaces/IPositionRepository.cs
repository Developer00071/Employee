namespace Domain.Interfaces;
using Domain.Models;
public interface IPositionRepository
{
      Task<bool> AddPosition(Position Position);
    Task<bool> UpdatePosition(Position Position);
    Task<bool> DeletePosition(int id);
    Task<Position> GetPosition(int id);
    Task<List<Position>> GetPositions();
}
