using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameManager _manager;

    public GameController(IGameManager manager)
    {
        _manager = manager;
    }

    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var games = await _manager.GetAllGamesAsync();
        return Ok(games);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var game = await _manager.GetGameByIdAsync(id);
        if(game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(Status status)
    {
        var games = await _manager.GetGamesByStatusAsync(status);
        return Ok(games);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Game game)
    {
        await _manager.CreateGameAsync(game);
        return CreatedAtAction(nameof(GetById), new {id = game.Id}, game);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update (int id, [FromBody] Game game)
    {
        if (id != game.Id)
        {
            return BadRequest("ID mismatch");
        }
        await _manager.UpdateGameAsync(game);
        return NoContent();
    }
    [Authorize]
    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await _manager.DeleteGameAsync(id);
        return NoContent();
    }
    [Authorize]
    [HttpPatch("{id}/publish")]

    public async Task<IActionResult> Publish (int id)
    {
        await _manager.PublishGameAsync(id);
        return NoContent();
    }
}