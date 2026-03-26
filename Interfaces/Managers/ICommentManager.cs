public interface ICommentManager
{
    Task<IEnumerable<Comment>> GetCommentByGameId(int gameId);
    Task CreateCommentAsync(Comment comment);
    Task DeleteCommentAsync(int id);
}