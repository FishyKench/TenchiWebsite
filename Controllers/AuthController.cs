using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserManager _manager;
    private readonly ITokenService _tokenService;

    public AuthController(IUserManager manager, ITokenService tokenService)
    {
        _manager = manager;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register ([FromBody] User user)
    {
            await _manager.CreateUserAsync(user);
            return Ok("User registred successfully");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login (string email, string password)
    {
        var user = await _manager.GetUserByEmail(email);
        if(user == null)
        {
            return NotFound();
        }
        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.userHashPassword, password);

        if(result == PasswordVerificationResult.Failed)
        {
            return Unauthorized();
        }

        var token = _tokenService.GenerateToken(user);
        return Ok(token);

    }
}