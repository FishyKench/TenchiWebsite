public interface IUserManager
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserById(int id);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAysnc(int id);

}