using System.ComponentModel.DataAnnotations;
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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Game game)
    {
        try
        {
            await _manager.CreateGameAsync(game);
            return CreatedAtAction(nameof(GetById), new {id = game.Id}, game);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update (int id, [FromBody] Game game)
    {
        if (id != game.Id)
        {
            return BadRequest("ID mismatch");
        }

        try
        {
            await _manager.UpdateGameAsync(game);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _manager.DeleteGameAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpPatch("{id}/publish")]

    public async Task<IActionResult> Publish (int id)
    {
        try
        {
            await _manager.PublishGameAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex )
        {
            return NotFound(ex.Message);
        }
        catch(InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
}