using ACD.Domain.Interfaces;
using ACD.Domain.Models;
using ACD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace ACD.Infrastructure.Repository;



/// <summary>
/// Repository class for managing BalanceServiceProvider entities, 
/// implementing specific data access methods for the object 
/// BalanceServiceProvider
/// </summary>
public class BalanceServiceProviderRepository : Repository<BalanceServiceProvider>, IBalanceServiceProviderRepository
{



    /// <summary>
    /// Initializes a new instance of the <see cref="BalanceServiceProviderRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">The logger.</param>
    public BalanceServiceProviderRepository(ACDDbContext context, ILogger<Repository<BalanceServiceProvider>> logger) : base(context, logger)
    {
        
    }
    


    /// <summary>
    /// Retrieves a collection of BalanceServiceProvider entities by the specified country.
    /// </summary>
    /// <param name="country">The country to filter the BalanceServiceProviders by.</param>
    /// <returns>A collection of BalanceServiceProvider entities.</returns>
    public async Task<IEnumerable<BalanceServiceProvider>> GetBalanceServiceProvidersByCountry(string country)
    {

        try
        {

            return await _dbSet.Where(x => x.Country == country).ToListAsync();

        }
        catch (Exception e)
        {

            _logger.LogError(e, "Error getting balance service providers by country");
            throw;

        }

    }

    

    /// <summary>
    /// Retrieves a BalanceServiceProvider entity by the specified business ID.
    /// </summary>
    /// <param name="businessId">The business ID to filter the BalanceServiceProvider by.</param>
    /// <returns>A BalanceServiceProvider entity.</returns>
    public async Task<BalanceServiceProvider> GetByBusinessId(string businessId)
    {
        
        try
        {

            return await _dbSet.FirstOrDefaultAsync(x => x.BusinessId == businessId);
        
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting balance service provider by business id");
            throw;
        }

    }



    /// <summary>
    /// Compares the current list of Balance Service Providers with the existing ones in the database
    /// and returns the providers that are not already in the database.
    /// This method ensures that no duplicate records are created in the database.
    /// </summary>
    /// <param name="currentProviders">The current list of Balance Service Providers fetched from the web.</param>
    /// <returns>A list of Balance Service Providers that do not exist in the database.</returns>
    public async Task<IEnumerable<BalanceServiceProvider>> GetNewProviders(List<BalanceServiceProvider> currentProviders)
    {
        try
        {
            var existingProviders = await _dbSet.ToListAsync();
            var existingBusinessIds = existingProviders.Select(p => p.BusinessId).ToHashSet();

            var newProviders = currentProviders.Where(p => !existingBusinessIds.Contains(p.BusinessId));

            if (newProviders.Any())
            {
                await _dbSet.AddRangeAsync(newProviders);
                await SaveChanges();
            }

            return newProviders;

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error comparing balance service providers");
            throw;
        }
    }



}