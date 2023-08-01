using LasmartTest.Models;
using LasmartTest.Services;

namespace LasmartTest.Database;

public class TestDataLoader : IHostedService
{
    public TestDataLoader(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();

        var pointService = scope.ServiceProvider.GetRequiredService<IPointService>();
        var commentService = scope.ServiceProvider.GetRequiredService<ICommentService>();

        await pointService.InsertAsync(new Point
        {
            PositionX = 300,
            PositionY = 100,
            Radius = 25,
            Color = "pink",
        });

        await pointService.InsertAsync(new Point
        {
            PositionX = 100,
            PositionY = 100,
            Radius = 25,
            Color = "red",
            Comments = new[]
            {
                new Comment
                {
                    Text = "red point",
                    Background = "gray",
                }
            },
        });

        await pointService.InsertAsync(new Point
        {
            PositionX = 200,
            PositionY = 200,
            Radius = 50,
            Color = "green",
            Comments = new[]
            {
                new Comment
                {
                    Text = "green point",
                    Background = "gray",
                },
                new Comment
                {
                    Text = "very long comment!!!!!!!!!!!!!!!!!!!",
                    Background = "yellow",
                },
            },
        });
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private readonly IServiceProvider _serviceProvider;
}
