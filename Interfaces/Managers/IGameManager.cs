public interface IGameManager
{
    Task<IEnumerable<Game>> GetAllGamesAsync();
    Task<Game> GetGameByIdAsync(int id);
    Task<IEnumerable<Game>> GetGamesByStatusAsync(Status status);
    Task CreateGameAsync(Game game);
    Task UpdateGameAsync(Game game);
    Task DeleteGameAsync(int id);
    Task PublishGameAsync(int id);

}