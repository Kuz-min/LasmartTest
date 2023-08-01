using LasmartTest.Database;
using LasmartTest.Models;
using Microsoft.EntityFrameworkCore;

namespace LasmartTest.Services;

public class CommentService : ICommentService
{
    public CommentService(IAppDatabase database)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
    }

    public async Task<IEnumerable<Comment>> SearchAsync(IEnumerable<int> pointIds)
    {
        if (pointIds == null)
            throw new ArgumentNullException(nameof(pointIds));

        return await _database.Comments.Where(c => pointIds.Contains(c.PointId)).ToListAsync();
    }

    public async Task<Comment> InsertAsync(Comment comment)
    {
        if (comment == null)
            throw new ArgumentNullException(nameof(comment));

        await _database.Comments.AddAsync(comment);
        await _database.SaveChangesAsync();

        return comment;
    }

    private readonly IAppDatabase _database;
}