
using Microsoft.EntityFrameworkCore;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;
    public GameRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _context.games.ToListAsync();
    }
    public async Task<Game?> GetByIdAsync(int id)
    {
        return await _context.games.FindAsync(id);
    }
    public async Task AddAsync(Game game)
    {
        await _context.games.AddAsync(game);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var game = await _context.games.FindAsync(id);
        if (game != null)
        {
            _context.games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
    public async Task UpdateAsync(Game game)
    {
        var existing = await _context.games.FindAsync(game.Id);
        if (existing == null) return;

        existing.GameTitle = game.GameTitle;
        existing.Description = game.Description;
        existing.Status = game.Status;

        await _context.SaveChangesAsync();
    }
}