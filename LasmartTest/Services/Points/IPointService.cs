using LasmartTest.Models;

namespace LasmartTest.Services;

public interface IPointService
{
    Task<Point?> GetByIdAsync(int id);
    Task<IEnumerable<Point>> GetAllAsync();
    Task<Point> InsertAsync(Point point);
    Task<int> DeleteAsync(Point point);
}
