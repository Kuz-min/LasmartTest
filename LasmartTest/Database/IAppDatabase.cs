using LasmartTest.Models;
using Microsoft.EntityFrameworkCore;

namespace LasmartTest.Database;

public interface IAppDatabase
{
    public DbSet<Point> Points { get; }
    public DbSet<Comment> Comments { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}