public class CreateGameRequestDTO
{
    public string GameTitle {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public DateTime ReleaseDate {get; set;}
    public Status Status {get; set;} 
    public string CoverImageUrl {get; set;} = string.Empty;
}