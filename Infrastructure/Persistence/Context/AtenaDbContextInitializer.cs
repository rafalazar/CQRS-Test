using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Context;

public class AtenaDbContextInitializer
{
    private readonly ILogger<AtenaDbContextInitializer> _logger;
    private readonly AtenaDbContext _context;

    public AtenaDbContextInitializer(ILogger<AtenaDbContextInitializer> logger, AtenaDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public async Task InitialiseAsync()
    {
        try
        {
            int attemps = 1;
            while (attemps <= 3)
            {
                try
                {
                    await _context.Database.MigrateAsync();
                    break;
                }
                catch
                {
                    _logger.LogWarning("Database attemp connection {attemps}", attemps);
                }

                attemps++;
                if (attemps == 3)
                {
                    throw new ApplicationException("Database is not available");
                }
                Thread.Sleep(2000);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }
}