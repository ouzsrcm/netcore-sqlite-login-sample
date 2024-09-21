namespace users.Models.ApiModels;

public class CreateUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class CreateUserResponse : DefaultApiResponse { }

public class AuthUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class AuthUserResponse : DefaultApiResponse
{
    public string AuthToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime TokenLifeTime { get; set; }
}

public class RemoveUserRequest
{
    public Guid Id { get; set; }
}

public class RemoveUserResponse : DefaultApiResponse { }