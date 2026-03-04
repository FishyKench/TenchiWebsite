

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

public class UserManager : IUserManager
{
    private readonly IUserRepository _repo;

    public UserManager(IUserRepository repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _repo.GetAllAsync();
    }
    public async Task<User> GetUserById(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
    public async Task CreateUserAsync(User user)
    {
        if (string.IsNullOrWhiteSpace(user.userName)  || string.IsNullOrWhiteSpace(user.userEmail) || string.IsNullOrWhiteSpace(user.userHashPassword) )
        {
            throw new ArgumentException("Username, email or password is empty");
        }

        var existing = await _repo.GetAllAsync();
        if(existing.Any(g => g.Id == user.Id))
        {
            throw new InvalidOperationException("a user with this Id already exists");
        }

        if(existing.Any(g => g.userEmail == user.userEmail))
        {
            throw new InvalidOperationException("a user with this email already exists");
        }
        var hasher = new PasswordHasher<User>();
        user.userHashPassword = hasher.HashPassword(user, user.userHashPassword);
        await _repo.AddAsync(user);
    }

    public async Task DeleteUserAysnc(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null)
        {
            throw new KeyNotFoundException($"User with ID  {id} not found");
        }

        await _repo.DeleteAsync(id);
    }
    public Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }



}