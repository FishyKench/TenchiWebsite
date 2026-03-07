using System.ComponentModel.DataAnnotations;

public class RegisterRequestDTO
{
    [Required]
    [MinLength(3)]
    public string userName {get; set;} = string.Empty;
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string userEmail {get; set;} = string.Empty;
    [Required]
    [MinLength(8)]
    public string password {get; set;} = string.Empty;
}