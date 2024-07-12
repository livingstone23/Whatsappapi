using ACD.Domain.Interfaces;
using ACD.Domain.Models;
using Microsoft.Extensions.Logging;



namespace ACD.Domain.Services;



/// <summary>
/// Service class responsible for managing operations related to BalanceServiceProvider entities, 
/// such as retrieval, addition, updating, and removal.
/// </summary>
public class BalanceServiceProviderService : IBalanceServiceProviderService
{


    private readonly IBalanceServiceProviderRepository _balanceServiceProviderRepository;
    private readonly ILogger<BalanceServiceProviderService> _logger;


    /// <summary>
    /// Initializes a new instance of the <see cref="BalanceServiceProviderService"/> class.
    /// </summary>
    /// <param name="balanceServiceProviderRepository">The repository used for data access operations.</param>
    public BalanceServiceProviderService(IBalanceServiceProviderRepository balanceServiceProviderRepository, ILogger<BalanceServiceProviderService> logger
    )
    {
        _balanceServiceProviderRepository = balanceServiceProviderRepository;
        _logger = logger;
    }


    /// <summary>
    /// Adds a new BalanceServiceProvider to the data repository.
    /// </summary>
    /// <param name="balanceServiceProvider">The BalanceServiceProvider to add.</param>
    /// <returns>The added BalanceServiceProvider.</returns>
    public async Task<BalanceServiceProvider> Add(BalanceServiceProvider balanceServiceProvider)
    {
        try
        {

            await _balanceServiceProviderRepository.Add(balanceServiceProvider);
            return balanceServiceProvider;

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while adding BalanceServiceProvider");
            throw;
        }
    }


    /// <summary>
    /// Updates an existing BalanceServiceProvider in the data repository.
    /// </summary>
    /// <param name="balanceServiceProvider">The BalanceServiceProvider to update.</param>
    /// <returns>The updated BalanceServiceProvider.</returns>
    public async Task<BalanceServiceProvider> Update(BalanceServiceProvider balanceServiceProvider)
    {
        try
        {

            await _balanceServiceProviderRepository.Update(balanceServiceProvider);
            return balanceServiceProvider;

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while updating BalanceServiceProvider");
            throw;
        }
    }



    /// <summary>
    /// Retrieves all BalanceServiceProviders from the data repository.
    /// </summary>
    /// <returns>A collection of BalanceServiceProviders.</returns>
    public async Task<Result<IEnumerable<BalanceServiceProvider>>> GetAll()
    {
        try
        {

            var providers = await _balanceServiceProviderRepository.GetAll();
            return Result<IEnumerable<BalanceServiceProvider>>.Success(providers);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting all BalanceServiceProviders");
            return Result<IEnumerable<BalanceServiceProvider>>.Failure("Error retrieving all balance service providers");
        }
    }


    /// <summary>
    /// Retrieves BalanceServiceProviders by country from the data repository.
    /// </summary>
    /// <param name="country">The country associated with the BalanceServiceProviders.</param>
    /// <returns>A collection of BalanceServiceProviders from the specified country.</returns>
    public async Task<IEnumerable<BalanceServiceProvider>> GetBalanceServiceProviderByCountry(string country)
    {
        try
        {

            return await _balanceServiceProviderRepository.GetBalanceServiceProvidersByCountry(country);
        
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting BalanceServiceProviders by country");
            throw;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="balanceServiceProvider"></param>
    /// <returns></returns>
    public async Task<bool> Remove(BalanceServiceProvider balanceServiceProvider)
    {
        try
        {

            await _balanceServiceProviderRepository.Remove(balanceServiceProvider);
            return true;

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while removing BalanceServiceProvider");
            throw;
        }
    }


    public async Task<BalanceServiceProvider> GetBalanceServiceProviderGetByBusinessId(string businessId)
    {
        try
        {

            return await _balanceServiceProviderRepository.GetByBusinessId(businessId);
        
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting BalanceServiceProviders by businessId");
            throw;
        }
    }

    


    public async Task<Result<BalanceServiceProvider>> GetById(int id)
    {
        try
        {

            //return await _balanceServiceProviderRepository.GetById(id);
            var provider = await _balanceServiceProviderRepository.GetById(id);
            return provider == null ? Result<BalanceServiceProvider>.Failure("Provider not found") : Result<BalanceServiceProvider>.Success(provider);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting BalanceServiceProviders by businessId");
            return Result<BalanceServiceProvider>.Failure("Error retrieving balance service provider by ID");
        }
    }


    public async Task<IEnumerable<BalanceServiceProvider>> GetNewProviders(List<BalanceServiceProvider> currentProviders)
    {
        try
        {
            return await _balanceServiceProviderRepository.GetNewProviders(currentProviders);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting BalanceServiceProviders in method GetNewProviders");
            throw;
        }
    }


}

