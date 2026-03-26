using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentManager _manager;
    private readonly IUserManager _userManager;

    public CommentController(ICommentManager manager, IUserManager userManager)
    {
        _manager = manager;
        _userManager = userManager;
    }

    [HttpGet("game/{gameId}")]
    public async Task<IActionResult> GetByGameId(int gameId)
    {
        var comments = await _manager.GetCommentByGameId(gameId);
        return Ok(comments.Select(c => new CommentResponseDTO
        {
            Id = c.Id,
            Content = c.Content,
            UserName = c.User.userName,
            CreatedAt = c.CreatedAt,
            GameId = c.GameId
        }));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentRequestDTO request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await _userManager.GetUserById(userId);

        var comment = new Comment
        {
            Content = request.Content,
            GameId = request.GameId,
            UserId = userId,
            User = user!,
            CreatedAt = DateTime.UtcNow
        };

        await _manager.CreateCommentAsync(comment);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _manager.DeleteCommentAsync(id);
        return NoContent();
    }
}