using Microsoft.VisualBasic;

public class User
{
    public int Id {get; set;}
    public required string userName {get; set;}
    public required string userEmail {get; set;}
    
    public  required string userHashPassword {get; set;}

    public userRoles userRoles {get; set;}

    public DateTime? CreatedAt {get; set;} 
}