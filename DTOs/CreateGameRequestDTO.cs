using System.ComponentModel.DataAnnotations;

public class CreateGameRequestDTO
{
    [Required]
    [MaxLength(40)]
    public string GameTitle {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public DateTime ReleaseDate {get; set;}
    [Required]
    public Status Status {get; set;} 
    [Url]
    public string CoverImageUrl {get; set;} = string.Empty;
}