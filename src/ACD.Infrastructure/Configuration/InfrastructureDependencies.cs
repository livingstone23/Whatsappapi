using ACD.Domain.Interfaces;
using ACD.Domain.Services;
using ACD.Infrastructure.Context;
using ACD.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace ACD.Infrastructure.Configuration;



/// <summary>
/// Static class for registering infrastructure dependencies in the IServiceCollection.
/// Enables dependency injection of services and repositories.
/// </summary>
public static class InfrastructureDependencies
{

    public static IServiceCollection RegisterInfrastureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        

        // Register the ACDDbContext with SQL Server connection string from configuration
        services.AddDbContext<ACDDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
        });


        // Register the ACDDbContext for dependency injection
        services.AddScoped<ACDDbContext>();

        // Register all repositories for dependency injection
        services.AddScoped<IBalanceServiceProviderRepository, BalanceServiceProviderRepository>();

        // Register all services for dependency injection
        services.AddScoped<IBalanceServiceProviderService, BalanceServiceProviderService>();




        services.AddScoped<IWhatsAppMessageRepository, WhatsAppMessageRepository>();

        // Register all services for dependency injection
        services.AddScoped<IWhatsAppMessageService, WhatsAppMessageService>();




        return services;


    }


}


