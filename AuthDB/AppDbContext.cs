using AuthDB;
using Microsoft.EntityFrameworkCore;

namespace AuthDB;

public class AppDbContext : DbContext
{
    private readonly DBConfig config;
    public AppDbContext(DBConfig config)
    {
        this.config = config;
    }

    public DbSet<Entities.User> Users { get; set; } = null!;

    public DbSet<Entities.Admin> Admin { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(config.ConnectionString, x =>
        {
            x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
        });

        base.OnConfiguring(optionsBuilder);
    }

    public void Init()
    {
        Database.Migrate();
    }
}