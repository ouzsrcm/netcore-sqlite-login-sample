using users.DataAccess.DataContexts;
using users.DataAccess.DataStore.Repos;
using users.DataAccess.DataStore.UnitOfWorks.Abstract;
using users.Models.DatabaseEntities;
using users.Models.DataTransferObjects.Users;

namespace users.DataAccess.DataStore.UnitOfWorks.Concrete;

public class UserUnitOfWork : IUserUnitOfWork
{
    private readonly Repo<User> usersRepo;
    private readonly Repo<UserLoginLog> userLoginsRepo;
    private readonly Repo<UserAuthToken> userAuthRepo;

    public UserUnitOfWork(UserContext userContext)
    {
        // burasi DI olmali ama zamanim olmadi.
        this.usersRepo = new Repo<User>(userContext);
        this.userLoginsRepo = new Repo<UserLoginLog>(userContext);
        this.userAuthRepo = new Repo<UserAuthToken>(userContext);
    }

    public async Task<AuthUserModel> AuthUserAsync(CreateUserModel model)
    {
        var res = usersRepo.Where(x => x.Username == model.Username && x.Password == model.Password);
        if (!res.Any())
            throw new ArgumentNullException(nameof(model.Username));

        var user = res.FirstOrDefault() ?? throw new ArgumentNullException(nameof(model.Username));

        var bytes = System.Text.Encoding.UTF8.GetBytes($"{user.Id}:{user.Username}:{Guid.NewGuid()}:{model.ClientIp}");
        var token = System.Convert.ToBase64String(bytes);
        var lifeTime = DateTime.UtcNow.AddHours(1);
        var userLogin = new UserLoginLog()
        {
            CreatedAt = DateTime.UtcNow,
            CreatedBy = user.Id,
            IsDeleted = false,
            ProccessDate = DateTime.UtcNow,
            UserId = user.Id,
            UserName = model.Username,
            ClientIp = model.ClientIp,
        };
        await userLoginsRepo.AddAsync(userLogin);

        var userAuth = new UserAuthToken()
        {
            CreatedAt = DateTime.UtcNow,
            CreatedBy = user.Id,
            IsDeleted = false,
            Token = token,
            RefreshToken = token,
            TokenLimeTime = lifeTime,
            TokenCreationDate = DateTime.UtcNow,
            UserId = user.Id
        };
        await userAuthRepo.AddAsync(userAuth);

        await userLoginsRepo.SaveAsync();

        await userAuthRepo.SaveAsync();

        return new AuthUserModel()
        {
            RefreshToken = token,
            Token = token,
            TokenLifeTime = lifeTime,
            ClientIp = model.ClientIp,
            Username = model.Username,
        };
    }

    public async Task CreateUserAsync(CreateUserModel model)
    {
        await usersRepo.AddAsync(new User()
        {
            CreatedAt = DateTime.UtcNow,
            CreatedBy = Guid.NewGuid(),
            IsActive = true,
            IsDeleted = false,
            Password = model.Password,
            Username = model.Username,
            IsLocked = false,
        });
        await usersRepo.SaveAsync();
    }

    public async Task RemoveUserAsync(RemoveUserModel model)
    {
        var user = await usersRepo.FindAsync(model.Id);

        if (user is null)
            throw new ArgumentNullException(nameof(model.Id));

        usersRepo.Delete(user.Id);

        await usersRepo.SaveAsync();
    }

    public async Task UpdateUserAsync(UpdateUserModel model)
    {
        var res = await usersRepo.FindAsync(model.Id);

        res.Username = model.Username;
        res.Password = model.Password;

        usersRepo.Update(res);

        await usersRepo.SaveAsync();

    }
}
