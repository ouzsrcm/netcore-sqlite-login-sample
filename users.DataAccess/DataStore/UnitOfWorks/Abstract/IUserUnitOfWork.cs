using users.Models.DataTransferObjects.Users;

namespace users.DataAccess.DataStore.UnitOfWorks.Abstract;

public interface IUserUnitOfWork
{
    Task<AuthUserModel> AuthUserAsync(CreateUserModel model);
    Task CreateUserAsync(CreateUserModel model);
    Task UpdateUserAsync(UpdateUserModel model);
    Task RemoveUserAsync(RemoveUserModel model);
}
