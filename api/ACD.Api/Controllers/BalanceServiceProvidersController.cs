using ACD.Api.Dto;
using ACD.Api.Helper;
using ACD.Domain.Interfaces;
using ACD.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;



namespace ACD.Api.Controllers;

/*
 

/// <summary>
/// Controller to manage Balance Service Providers.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class BalanceServiceProvidersController : ControllerBase
{



    private readonly IBalanceServiceProviderService _balanceServiceProviderService;
    private readonly IMapper _mapper;
    private readonly ILogger<BalanceServiceProvidersController> _logger;
    private readonly ILogger<AcdHelper> _acdHelperLogger;



    /// <summary>
    /// Constructor of Balance Service Providers Controller
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="balanceServiceProviderService"></param>
    public BalanceServiceProvidersController(IMapper mapper,
        IBalanceServiceProviderService balanceServiceProviderService,
        ILogger<BalanceServiceProvidersController> logger,
        ILogger<AcdHelper> acdHelperLogger)
        {
            _mapper = mapper;
            _balanceServiceProviderService = balanceServiceProviderService;
            _logger = logger;
            _acdHelperLogger = acdHelperLogger;
    }



    /// <summary>
    /// Get all register of Balance Service Provider
    /// </summary>
    /// <remarks>
    /// Get all register of Balance Service Provider
    /// </remarks>
    /// <response code="200">Success - JSON Array of BRPs</response>
    /// <response code="204">If no data exists but the request is otherwise valid</response>
    /// <response code="400">If validation failed for any reason</response>
    /// <response code="500">Server Error</response>
    [HttpGet]
    [Route("GetAllFromDatabase")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BalanceServiceProviderDTO>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {

            var result = await _balanceServiceProviderService.GetAll();

            if (!result.IsSuccess)
            {
                _logger.LogError(result.Error);
                return StatusCode(StatusCodes.Status500InternalServerError, result.Error);
            }

            if (result.Value == null || !result.Value.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<BalanceServiceProviderDTO>>(result.Value));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting balance service providers from database");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }



    /// <summary>
    /// Get all register of Balance Service Provider from the official Web "https://api.opendata.esett.com..."
    /// </summary>
    /// <remarks>
    /// Get all register of Balance Service Provider
    /// </remarks>
    /// <response code="200">Success - JSON Array of BRPs</response>
    /// <response code="204">If no data exists but the request is otherwise valid</response>
    /// <response code="400">If validation failed for any reason</response>
    /// <response code="500">Server Error</response>
    [HttpGet]
    [Route("GetAllFromWebPage")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BalanceServiceProviderDTO>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllFromWeb()
    {

        try
        {


            // You can call the GetAllFromWeb method from the AcdHelper class
            // and then save the data to the database
            AcdHelper _acdHelper = new AcdHelper(new HttpClient(), _mapper, _acdHelperLogger);
            
            var balanceServiceProviders = await _acdHelper.GetAllFromWeb();
            

            if (balanceServiceProviders == null || !balanceServiceProviders.Any())
            {
                return NoContent();
            }

            var currentProviders = (_mapper.Map<IEnumerable<BalanceServiceProvider>>(balanceServiceProviders)).ToList();


            // Get the new providers that are not already in the database
            var newProviders = await _balanceServiceProviderService.GetNewProviders(currentProviders);



            if (!newProviders.Any())
            {
                return NoContent();
            }

            return Ok(newProviders);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting balance service providers from web page");
            throw;
        }
    }



    /// <summary>
    /// Get a register by Id
    /// </summary>
    /// <remarks>
    /// Get a register by Id
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Success - JSON Array of BRPs</response>
    /// <response code="204">If no data exists but the request is otherwise valid</response>
    /// <response code="400">If validation failed for any reason</response>
    /// <response code="500">Server Error</response>
    [HttpGet]
    [Route("GetById/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BalanceServiceProviderDTO))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(int id)
    {

        try
        {
            var result = await _balanceServiceProviderService.GetById(id);

            if (!result.IsSuccess)
            {
                _logger.LogError(result.Error);
                return StatusCode(StatusCodes.Status500InternalServerError, result.Error);
            }

            if (result.Value == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<BalanceServiceProviderDTO>(result.Value));
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error getting balance service provider with ID {id}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }



    /// <summary>
    /// Get a register by businessId
    /// </summary>
    /// <remarks>
    /// Get a register by businessId
    /// </remarks>
    /// <param name="businessId"></param>
    /// <returns></returns>
    /// <response code="200">Success - JSON Array of BRPs</response>
    /// <response code="204">If no data exists but the request is otherwise valid</response>
    /// <response code="400">If validation failed for any reason</response>
    /// <response code="500">Server Error</response>
    [HttpGet]
    [Route("GetByBusinessId/{businessId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BalanceServiceProviderDTO))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByBusinessId(string businessId)
    {

        try
        {

            var balanceServiceProviders = await _balanceServiceProviderService.GetBalanceServiceProviderGetByBusinessId(businessId);

            if (balanceServiceProviders == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<BalanceServiceProviderDTO>(balanceServiceProviders));

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting balance service providers from web page");
            throw;
        }
    }



    /// <summary>
    /// Get all register by CountryId
    /// </summary>
    /// <remarks>
    /// Get all register by CountryId
    /// </remarks>
    /// <response code="200">Success - JSON Array of BRPs</response>
    /// <response code="204">If no data exists but the request is otherwise valid</response>
    /// <response code="400">If validation failed for any reason</response>
    /// <response code="500">Server Error</response>
    [HttpGet]
    [Route("GetByCountryId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BalanceServiceProviderDTO>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByCountryId(string countryId)
    {

        try
        {


            var balanceServiceProviders = await _balanceServiceProviderService.GetBalanceServiceProviderByCountry(countryId);


            if (balanceServiceProviders == null || !balanceServiceProviders.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<BalanceServiceProviderDTO>>(balanceServiceProviders));

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting balance service providers from database");
            throw;
        }
    }


}

 */