using Microsoft.AspNetCore.Mvc;
using System.Net;
using users.DataAccess.DataStore.UnitOfWorks.Abstract;
using users.RestApi.Models;
using users.Models.DataTransferObjects.Users;
using users.Models.ApiModels;

namespace users.RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IUserUnitOfWork uow;
    public AuthController(IUserUnitOfWork userUnitOfWork)
    {
        this.uow = userUnitOfWork;
    }

    // bu burda olmaz.
    private string ip
    {
        get
        {
            var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ?? HttpContext.Connection.RemoteIpAddress?.ToString();
            var ipAddressWithoutPort = ipAddress?.Split(':')[0];
            return ipAddressWithoutPort ?? "localhost";
        }
    }

    [HttpPost]
    [Route("auth-user")]
    public async Task<AuthUserResponse> UserLogin(AuthUserRequest request)
    {
        var res = await uow.AuthUserAsync(new CreateUserModel()
        {
            ClientIp = ip,
            Password = request.Password,
            Username = request.Username,
        });

        return new AuthUserResponse()
        {
            AuthToken = res.Token,
            HttpStatusCode = (int)HttpStatusCode.OK,
            RefreshToken = res.RefreshToken,
            HttpStatusMessage = nameof(HttpStatusCode.OK),
            Success = !string.IsNullOrEmpty(res.Token)
        };
    }

    [HttpPost]
    [Route("create-user")]
    public async Task CreateUser(CreateUserRequest request)
    {
        await uow.CreateUserAsync(new CreateUserModel()
        {
            ClientIp = ip,
            Password = request.Password,
            Username = request.Username,
        });
    }

    [HttpDelete]
    [Route("remove-user")]
    public async Task RemoveUser(RemoveUserRequest request)
    {
        await uow.RemoveUserAsync(new RemoveUserModel()
        {
            Id = request.Id,
            ClientIp = ip
        });
    }
}
