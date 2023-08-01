using LasmartTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LasmartTest.Database;

public class AppDatabase : DbContext, IAppDatabase
{
    public DbSet<Point> Points { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}