using LasmartTest.Services;
using LasmartTest.ViewModels;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace LasmartTest.Controllers;

[Route("api/points")]
public class PointController : ControllerBase
{
    public PointController(IMapper mapper, ILogger<PointController> logger, IPointService pointService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _pointService = pointService ?? throw new ArgumentNullException(nameof(pointService));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var points = await _pointService.GetAllAsync();

        return Ok(points.Select(_mapper.Map<PointViewModel>));
    }

    [HttpDelete("{pointId:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int pointId)
    {
        var point = await _pointService.GetByIdAsync(pointId);

        if (point == null)
            return BadRequest();

        await _pointService.DeleteAsync(point);

        _logger.LogInformation($"Point with id {point.Id} has been deleted");

        return Ok();
    }

    private readonly IMapper _mapper;
    private readonly ILogger<PointController> _logger;
    private readonly IPointService _pointService;
}