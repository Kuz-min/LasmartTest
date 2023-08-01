using LasmartTest.Database;
using LasmartTest.Services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace LasmartTest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Mapper
        builder.Services.AddSingleton((_) =>
        {
            var config = new TypeAdapterConfig();
            config.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);
            return config;
        });
        builder.Services.AddScoped<IMapper, ServiceMapper>();

        //Database configuration
        builder.Services.AddDbContext<AppDatabase>(options =>
        {
            options.UseInMemoryDatabase("AppDatabase");
        });
        builder.Services.AddScoped<IAppDatabase>(provider => provider.GetRequiredService<AppDatabase>());
        builder.Services.AddHostedService<TestDataLoader>();//add to the database set of points and comments

        //
        builder.Services.AddRazorPages();

        //My Services
        builder.Services.AddScoped<IPointService, PointService>();
        builder.Services.AddScoped<ICommentService, CommentService>();

        //Middlewares
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error");
        }

        app.UseStaticFiles();
        app.UseRouting();

        app.MapControllers();
        app.MapRazorPages();

        app.Run();
    }
}