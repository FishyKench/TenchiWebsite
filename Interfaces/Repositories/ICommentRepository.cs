public interface ICommentRepository
{
    Task<Comment?> GetByIdAsync(int id);
    Task<IEnumerable<Comment>> GetByGameIdAsync (int gameId);
    Task AddAsync(Comment comment);
    Task DeleteAsync(int id);
}