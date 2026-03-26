using System.ComponentModel.DataAnnotations;

public class CreateCommentRequestDTO
{
    [Required]
    public int GameId { get; set; }
    [Required]
    public string Content { get; set; } = null!;
}