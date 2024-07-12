using ACD.Api.Dto;
using ACD.Domain.Models;
using AutoMapper;
using Newtonsoft.Json;



namespace ACD.Api.Helper;



/// <summary>
/// The ACDHelper class is a utility class for multiple functionalities. 
/// </summary>
public class AcdHelper
{


    private readonly HttpClient _httpClient;

    private readonly IMapper _mapper;

    private readonly ILogger<AcdHelper> _logger;



    /// <summary>
    /// Constructor of ACDHelper
    /// </summary>
    /// <param name="httpClient"></param>
    public AcdHelper(HttpClient httpClient, IMapper mapper, ILogger<AcdHelper> logger)
    {
        _httpClient = httpClient;
        _mapper = mapper;
        _logger = logger;
    }



    /// <summary>
    /// GetAllFromWeb
    /// The method calls the endpoint https://api.opendata.esett.com/EXP01/BalanceResponsibleParties
    /// and retrieves information about Balance Service Providers
    /// which is then saved to the database.
    /// This method is called by the endpoint GetAllFromWebPage.
    /// </summary>
    public async Task<IEnumerable<BalanceServiceProviderDTO>> GetAllFromWeb()
    {
        try
        {

            var response = await _httpClient.GetAsync("https://api.opendata.esett.com/EXP01/BalanceResponsibleParties");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var balanceServiceProvidersResponse = JsonConvert.DeserializeObject<IEnumerable<BalanceServiceProviderResponse>>(content);
                var balanceServiceProviders = _mapper.Map<IEnumerable<BalanceServiceProviderDTO>>(balanceServiceProvidersResponse);

                return balanceServiceProviders;
            }

            return null;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method GetAllFromWeb");
            throw;
        }
    }



    /// <summary>
    /// Compares the current list of Balance Service Providers with the existing ones in the database
    /// and returns the providers that are not already in the database.
    /// </summary>
    /// <param name="currentProviders">The current list of Balance Service Providers fetched from the web.</param>
    /// <param name="existingProviders">The existing list of Balance Service Providers from the database.</param>
    /// <returns>A list of Balance Service Providers that do not exist in the database.</returns>
    public IEnumerable<BalanceServiceProvider> GetNewProviders(IEnumerable<BalanceServiceProvider> currentProviders, IEnumerable<BalanceServiceProvider> existingProviders)
    {
        try
        {

            var existingBusinessIds = existingProviders.Select(p => p.BusinessId).ToHashSet();
            return currentProviders.Where(p => !existingBusinessIds.Contains(p.BusinessId));

        }
        catch (Exception e)
        {

            _logger.LogError(e, "Error in method GetNewProviders");
            throw;

        }
    }


}

