using LasmartTest.Database;
using LasmartTest.Models;
using Microsoft.EntityFrameworkCore;

namespace LasmartTest.Services;

public class PointService : IPointService
{
    public PointService(IAppDatabase database)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
    }

    public async Task<Point?> GetByIdAsync(int id)
    {
        return await _database.Points.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Point>> GetAllAsync()
    {
        return await _database.Points.Include(p => p.Comments).ToListAsync();
    }

    public async Task<Point> InsertAsync(Point point)
    {
        if (point == null)
            throw new ArgumentNullException(nameof(point));

        await _database.Points.AddAsync(point);
        await _database.SaveChangesAsync();

        return point;
    }

    public async Task<int> DeleteAsync(Point point)
    {
        if (point == null)
            throw new ArgumentNullException(nameof(point));

        _database.Points.Remove(point);
        return await _database.SaveChangesAsync();
    }

    private readonly IAppDatabase _database;
}