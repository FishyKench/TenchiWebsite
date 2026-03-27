
public class CommentManager : ICommentManager
{
    private  readonly ICommentRepository _repo;

    public CommentManager(ICommentRepository repo)
    {
        _repo = repo;
    }
    public async Task<Comment> GetCommentByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
    public async Task<IEnumerable<Comment>> GetCommentByGameId(int gameId)
    {
        return await _repo.GetByGameIdAsync(gameId);
    }
    public  async Task CreateCommentAsync(Comment comment)
    {
        if (string.IsNullOrWhiteSpace(comment.Content))
        {
            throw new ArgumentException("Comment Content is required");
        }

        await _repo.AddAsync(comment);
    }

    public async Task DeleteCommentAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null)
        {
            throw new KeyNotFoundException($"Comment with ID  {id} not found");
        }

        await _repo.DeleteAsync(id);
    }

}