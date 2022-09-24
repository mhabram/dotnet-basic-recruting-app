using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MatchDataManager.Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(
        ILogger<ApplicationDbContextInitializer> logger,
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitializeAsync(IConfiguration configuration)
    {
        try
        {
            string directoryPath = string.Concat(
                Environment.CurrentDirectory,
                "\\",
                configuration["DirectoryDatabase"]);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if (_context.Database.IsSqlite())
                await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }
}
