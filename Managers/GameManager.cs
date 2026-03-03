
public class GameManager : IGameManager
{
    private readonly IGameRepository _repo;

    public GameManager(IGameRepository repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
    public async Task<IEnumerable<Game>> GetGamesByStatusAsync(Status status)
    {
        var games = await _repo.GetAllAsync();
        return games.Where(g => g.Status == status);
    }
    public async Task CreateGameAsync(Game game)
    {
        if (string.IsNullOrWhiteSpace(game.GameTitle))
        {
            throw new ArgumentException("Game title is required");
        }

        var existing = await _repo.GetAllAsync();
        if(existing.Any(g => g.GameTitle == game.GameTitle))
        {
            throw new InvalidOperationException("a game with this title already exists");
        }
        await _repo.AddAsync(game);
    }
    public async Task UpdateGameAsync(Game game)
    {
        var existing = await _repo.GetByIdAsync(game.Id);
        if(existing == null)
        {
            throw new KeyNotFoundException($"Game with ID  {game.Id} not found");
        }
        await _repo.UpdateAsync(game);
    }

    public async Task DeleteGameAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null)
        {
            throw new KeyNotFoundException($"Game with ID  {id} not found");
        }

        await _repo.DeleteAsync(id);
    }
    public async Task PublishGameAsync(int id)
    {
        var game = await _repo.GetByIdAsync(id);
        if(game == null)
        {
            throw new KeyNotFoundException($"Game with ID  {id} not found");
        }

        if(game.Status == Status.Released)
        {
            throw new InvalidOperationException("Game is already published");
        }

        game.Status = Status.Released;
        game.ReleaseDate = DateTime.UtcNow;
        await _repo.UpdateAsync(game);
    }

}