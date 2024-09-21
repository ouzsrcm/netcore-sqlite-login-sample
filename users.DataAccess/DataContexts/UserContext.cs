using Microsoft.EntityFrameworkCore;
using users.Models.DatabaseEntities;

namespace users.DataAccess.DataContexts;

public class UserContext : DbContext
{
    private readonly string dbPath;

    public UserContext()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        dbPath = Path.Join(path, "users.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserLoginLog> Logins { get; set; }
    public DbSet<UserAuthToken> UserAuthTokens { get; set; }

}