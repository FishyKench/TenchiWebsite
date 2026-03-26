public class Comment
{
    public int Id {get; set;}
    public required string Content {get; set;}
    public DateTime CreatedAt {get; set;}
    public Game Game {get; set;} = null!;
    public User User {get; set;} = null!;
    public int GameId {get; set;}
    public int UserId {get; set;}

}