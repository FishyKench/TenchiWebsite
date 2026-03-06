public class LoginResponseDTO
{
    public int Id {get; set;}
    public string Token {get; set;} = string.Empty;
    public string UserName {get; set;} = string.Empty;
    public string UserEmail {get; set;} = string.Empty;
}