using LasmartTest.Models;

namespace LasmartTest.Services;

public interface ICommentService
{
    Task<IEnumerable<Comment>> SearchAsync(IEnumerable<int> pointIds);
    Task<Comment> InsertAsync(Comment comment);
}