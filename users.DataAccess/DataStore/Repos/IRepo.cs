using System.Linq.Expressions;
using users.Models;

namespace users.DataAccess.DataStore.Repos;

public interface IRepo<TEntity> 
    where TEntity : DefaultEntity, 
    new()
{
    ValueTask<TEntity> FindAsync(Guid id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(Guid id);
    Task SoftDeleteAsync(Guid id);
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

    Task SaveAsync();
}
