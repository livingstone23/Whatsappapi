using ACD.Domain.Models;



namespace ACD.Domain.Interfaces;



/// <summary>
/// Service interface for managing BalanceServiceProvider entities.
/// The service is focused on business logic and coordinating operations.
/// </summary>
public interface IBalanceServiceProviderService
{   


    /// <summary>
    /// Retrieves all BalanceServiceProviders.
    /// </summary>
    /// <returns>A collection of BalanceServiceProviders.</returns>
    Task<Result<IEnumerable<BalanceServiceProvider>>> GetAll();


    /// <summary>
    /// Retrieves a BalanceServiceProvider by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the BalanceServiceProvider.</param>
    /// <returns>The BalanceServiceProvider with the specified identifier.</returns>
    Task<Result<BalanceServiceProvider>> GetById(int id);


    /// <summary>
    /// Adds a new BalanceServiceProvider.
    /// </summary>
    /// <param name="balanceServiceProvider">The BalanceServiceProvider to add.</param>
    /// <returns>The added BalanceServiceProvider.</returns>
    Task<BalanceServiceProvider> Add(BalanceServiceProvider balanceServiceProvider);


    /// <summary>
    /// Updates an existing BalanceServiceProvider.
    /// </summary>
    /// <param name="balanceServiceProvider">The BalanceServiceProvider to update.</param>
    /// <returns>The updated BalanceServiceProvider.</returns>
    Task<BalanceServiceProvider> Update(BalanceServiceProvider balanceServiceProvider);
    
    
    /// <summary>
    /// Removes a BalanceServiceProvider.
    /// </summary>
    /// <param name="balanceServiceProvider">The BalanceServiceProvider to remove.</param>
    /// <returns>True if the BalanceServiceProvider was removed successfully; otherwise, false.</returns>
    Task<bool> Remove(BalanceServiceProvider balanceServiceProvider);


    /// <summary>
    /// Retrieves List of BalanceServiceProviders by country.
    /// </summary>
    /// <param name="country">The country associated with the BalanceServiceProviders.</param>
    /// <returns>A collection of BalanceServiceProviders from the specified country.</returns>
    Task<IEnumerable<BalanceServiceProvider>> GetBalanceServiceProviderByCountry(string country);


    /// <summary>
    /// Retrieve a BalanceServiceProviders by business identifier.
    /// </summary>
    /// <param name="businessId">The business identifier associated with the BalanceServiceProviders.</param>
    /// <returns>A collection of BalanceServiceProviders with the specified business identifier.</returns>
    Task<BalanceServiceProvider> GetBalanceServiceProviderGetByBusinessId(string businessId);
    
        

    /// <summary>
    /// Retrieve List of BalanceServiceProviders that are not already in the database.
    /// </summary>
    /// <param name="currentProviders"></param>
    /// <returns></returns>
    Task<IEnumerable<BalanceServiceProvider>> GetNewProviders(List<BalanceServiceProvider> currentProviders);

}
