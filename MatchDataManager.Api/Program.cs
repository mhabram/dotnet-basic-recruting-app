using MatchDataManager.Api;
using MatchDataManager.Application;
using MatchDataManager.Infrastructure;
using MatchDataManager.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddApiServices()
        .AddApplicationServices()
        .AddInfrastructureServices(builder.Configuration);
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        using (var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

            await initializer.InitializeAsync(builder.Configuration);
        }
    }

    app.UseHttpsRedirection();
    app.MapControllers();

    await app.RunAsync();
}