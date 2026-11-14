namespace Application.Servers;

using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

public class PositionService : IPositionServer
{
    private readonly IPositionRepository _positionRepository;

    public PositionService(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task<List<Position>> GetPositions()
    {
        var positions = await _positionRepository.GetPositions();
        return positions;
    }

    public async Task<Position> GetPosition(int id)
    {
        var position = await _positionRepository.GetPosition(id);
        return position;
    }

    public async Task<bool> AddPosition(Position Position)
    {
        var result = await _positionRepository.AddPosition(Position);
        return result;
    }

    public async Task<bool> UpdatePosition(Position Position)
    {
        var result = await _positionRepository.UpdatePosition(Position);
        return result;
    }

    public async Task<bool> DeletePosition(int id)
    {
        var result = await _positionRepository.DeletePosition(id);
        return result;
    }
}
