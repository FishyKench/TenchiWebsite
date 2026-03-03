using Microsoft.VisualBasic;

public class User
{
    public int Id {get; set;}
    public string? userName {get; set;}
    public string? userEmail {get; set;}
    
    public string? userHashPassword {get; set;}

    public userRoles userRoles {get; set;}

    public DateTime? CreatedAt {get; set;} 
}