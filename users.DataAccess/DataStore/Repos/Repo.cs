using System.Linq.Expressions;
using users.DataAccess.DataContexts;
using users.Models;

namespace users.DataAccess.DataStore.Repos;

public class Repo<TEntity> : IRepo<TEntity>
    where TEntity : DefaultEntity,
    new()
{
    private readonly UserContext users;

    public Repo(UserContext userContext)
    {
        users = userContext;
    }

    public async Task AddAsync(TEntity entity)
        => await users.AddAsync(entity);

    public void Delete(Guid id)
    {
        var entity = Where(x => x.Id == id);

        if (entity != null)
            users.Remove(entity);
    }

    public async ValueTask<TEntity> FindAsync(Guid id)
        => await users.Set<TEntity>().FindAsync(id) ?? throw new ArgumentNullException(nameof(TEntity));

    public async Task SoftDeleteAsync(Guid id)
    {
        var entity = await FindAsync(id);

        if (entity is null)
            return;

        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;

        Update(entity);
    }

    public void Update(TEntity entity)
        => users.Set<TEntity>().Update(entity);

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        => users.Set<TEntity>().Where(expression);

    public async Task SaveAsync()
    {
        await users.SaveChangesAsync();
    }
}
