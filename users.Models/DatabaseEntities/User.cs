namespace users.Models.DatabaseEntities;

public class User : DefaultEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public bool IsLocked { get; set; }

    public virtual IEnumerable<UserLoginLog> UserLoginLogs { get; set; }
}
