using GameStore.API.DTOs.Games;
using GameStore.Domain.Entities;
using GameStore.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers;

[ApiController]
[Route("games")]
[Tags("Games")]
public class GameController : ControllerBase
{
    private readonly GameStoreDbContext _context;

    public GameController(GameStoreDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create a new game (only Admin)
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateGame(GameRequest request)    
    {
        try
        {
            var game = Game.Create(request.Title, request.Price);

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return Ok(GameResponse.FromEntity(game));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
