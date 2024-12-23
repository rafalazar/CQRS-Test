using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        string connectionString)
    {
        services.AddScoped<AtenaDbContextInitializer>();

        // services.AddHttpClient();

        #region Repositories

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ISalaryAdvanceRepository, SalaryAdvanceRepository>();
        services.AddScoped<IEventLogRepository, EventLogRepository>();

        #endregion
        
        services.AddDbContext<AtenaDbContext>((sp, options) =>
        {
            var configuration = sp.GetService<IConfiguration>();
            options.UseLazyLoadingProxies();
        });
        
        return services;
    }
}