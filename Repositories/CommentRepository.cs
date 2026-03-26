
using Microsoft.EntityFrameworkCore;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;
    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments.FindAsync(id);
    }
    public async Task<IEnumerable<Comment>> GetByGameIdAsync(int gameId)
    {
        return await _context.Comments
            .Where(c => c.GameId == gameId)
            .Include(c => c.User)
            .ToListAsync();
}
    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }


}