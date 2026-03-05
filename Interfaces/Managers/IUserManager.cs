public interface IUserManager
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserById(int id);
    Task<User> GetUserByEmail(string email);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAysnc(int id);

}