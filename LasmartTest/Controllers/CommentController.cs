using LasmartTest.ModelBinders;
using LasmartTest.Services;
using LasmartTest.ViewModels;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace LasmartTest.Controllers;

[Route("api/comments")]
public class CommentController : ControllerBase
{
    public CommentController(IMapper mapper, ICommentService commentService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync(
        [FromQuery(Name = "pointIds")][ModelBinder(typeof(SeparatedStringToArrayBinder))] IEnumerable<int>? pointIds = default
        )
    {
        if (pointIds == null || pointIds.Count() == 0)
            return BadRequest();

        var comments = await _commentService.SearchAsync(pointIds);

        return Ok(comments.Select(_mapper.Map<CommentViewModel>));
    }

    private readonly IMapper _mapper;
    private readonly ICommentService _commentService;
}