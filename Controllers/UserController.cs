using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repo;
    public UserController(IUserRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task <IActionResult> GetAll()
    {
        var users = await _repo.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var users = await _repo.GetByIdAsync(id);
        if(users == null) return NotFound();
        return Ok(users);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User user)
    {
        user.Id = id;
        await _repo.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}