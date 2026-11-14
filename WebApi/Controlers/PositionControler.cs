using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController(
    IPositionServer positionServer,
    ILogger<PositionController> logger) : ControllerBase
{
    private readonly IPositionServer _positionServer = positionServer;
    private readonly ILogger<PositionController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<Position>>> GetPositions()
    {
        _logger.LogInformation("Getting all positions.");
        var positions = await _positionServer.GetPositions();
        _logger.LogInformation("Retrieved {Count} positions.", positions.Count);
        return new ApiResponse<List<Position>>(HttpStatusCode.OK, "Positions retrieved.", positions);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Position>> GetPosition(int id)
    {
        _logger.LogInformation("Getting position with ID {PositionId}.", id);
        var position = await _positionServer.GetPosition(id);
        if (position is null)
        {
            _logger.LogWarning("Position with ID {PositionId} was not found.", id);
            return new ApiResponse<Position>(HttpStatusCode.NotFound, "Position not found.", null);
        }

        return new ApiResponse<Position>(HttpStatusCode.OK, "Position retrieved.", position);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddPosition([FromBody] Position position)
    {
        var result = await _positionServer.AddPosition(position);
        _logger.LogInformation("Add position operation completed with result {Result}.", result);
        var statusCode = result ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
        var message = result ? "Position added." : "Position was not added.";
        return new ApiResponse<bool>(statusCode, message, result);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdatePosition(int id, [FromBody] Position position)
    {
        position.Id = id;
        var result = await _positionServer.UpdatePosition(position);
        _logger.LogInformation("Update position operation for ID {PositionId} completed with result {Result}.", id, result);
        var statusCode = result ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        var message = result ? "Position updated." : "Position was not found.";
        return new ApiResponse<bool>(statusCode, message, result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeletePosition(int id)
    {
        var result = await _positionServer.DeletePosition(id);
        _logger.LogInformation("Delete position operation for ID {PositionId} completed with result {Result}.", id, result);
        var statusCode = result ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        var message = result ? "Position deleted." : "Position was not found.";
        return new ApiResponse<bool>(statusCode, message, result);
    }
}
