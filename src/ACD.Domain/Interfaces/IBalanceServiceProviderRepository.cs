using ACD.Domain.Models;
using System.Collections.Generic;



namespace ACD.Domain.Interfaces;



/// <summary>
/// Repository interface for managing BalanceServiceProvider entities.
/// The repository focuses on data persistence and retrieval.
/// </summary>
public interface IBalanceServiceProviderRepository: IRepository<BalanceServiceProvider>
{


    /// <summary>
    /// Retrieves all BalanceServiceProviders from the repository.
    /// </summary>
    /// <returns>A collection of BalanceServiceProviders.</returns>
    new Task<List<BalanceServiceProvider>> GetAll();


    /// <summary>
    /// Retrieves a BalanceServiceProvider by its unique identifier from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the BalanceServiceProvider.</param>
    /// <returns>The BalanceServiceProvider with the specified identifier.</returns>
    new Task<BalanceServiceProvider> GetById(int id);


    /// <summary>
    /// Retrieves a BalanceServiceProvider by its business identifier from the repository.
    /// </summary>
    /// <param name="businessId">The business identifier of the BalanceServiceProvider.</param>
    /// <returns>The BalanceServiceProvider with the specified business identifier.</returns>
    Task<BalanceServiceProvider> GetByBusinessId(string businessId);
    

    /// <summary>
    /// Retrieves BalanceServiceProviders by country from the repository.
    /// </summary>
    /// <param name="country">The country associated with the BalanceServiceProviders.</param>
    /// <returns>A collection of BalanceServiceProviders from the specified country.</returns>
    Task<IEnumerable<BalanceServiceProvider>> GetBalanceServiceProvidersByCountry(string country);



    /// <summary>
    /// Retrieves BalanceServiceProviders by country from the repository.
    /// </summary>
    /// <param name="country">The country associated with the BalanceServiceProviders.</param>
    /// <returns>A collection of BalanceServiceProviders from the specified country.</returns>
    Task<IEnumerable<BalanceServiceProvider>> GetNewProviders(List<BalanceServiceProvider> currentProviders);
}
