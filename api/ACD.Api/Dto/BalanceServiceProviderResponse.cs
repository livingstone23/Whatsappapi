namespace ACD.Api.Dto;



/// <summary>
/// Represents the response object for the BalanceServiceProvider entity geting from the web.
/// </summary>
public class BalanceServiceProviderResponse
{


    /// <summary>
    /// Property that represents the unique identifier for the business Id.
    /// </summary>
    /// <value></value>
    public string businessId { get; set; }


    /// <summary>
    /// Property that represents the code assigned to the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public string brpCode { get; set; }


    /// <summary>
    /// Property that represents the name of the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public string brpName { get; set; }


    /// <summary>
    /// Property that represents the country associated with the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public string country { get; set; }


    /// <summary>
    /// Property that represents the coding scheme used by the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public string codingScheme { get; set; }


    /// <summary>
    /// Property that represents the value ValidityStart associated with the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public DateTime validityStart { get; set; }


    /// <summary>
    /// Property that represents the value ValidityEnd associated with the BalanceServiceProvider.
    /// </summary>
    public DateTime validityEnd { get; set; }


}