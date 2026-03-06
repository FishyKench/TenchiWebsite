using System.ComponentModel;

public class Game
{
    public int Id {get; set;}
    
    public required string GameTitle {get; set;}

    public string? Description{get; set;}

    public DateTime? ReleaseDate {get; set;}

    public Status Status {get; set;}

    public DateTime CreatedAt {get; set;}

    public string? CoverImageUrl {get; set;}


}