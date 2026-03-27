public interface ICommentManager
{
    Task<Comment> GetCommentByIdAsync(int id);
    Task<IEnumerable<Comment>> GetCommentByGameId(int gameId);
    Task CreateCommentAsync(Comment comment);
    Task DeleteCommentAsync(int id);
}