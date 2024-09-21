namespace users.Models.DatabaseEntities;

public class UserAuthToken : DefaultEntity
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime TokenLimeTime { get; set; }
    public DateTime TokenCreationDate { get; set; }
}
