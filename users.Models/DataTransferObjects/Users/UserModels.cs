namespace users.Models.DataTransferObjects.Users;

public class AuthUserModel : DefaultDataTransferObjectModel
{
    public string Username { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime TokenLifeTime { get; set; }
}

public class CreateUserModel : DefaultDataTransferObjectModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class UpdateUserModel : DefaultDataTransferObjectModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class RemoveUserModel : DefaultDataTransferObjectModel { }