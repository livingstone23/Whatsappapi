using ACD.Domain.Models;



namespace ACD.Api.Dto;



/// <summary>
/// Represents the data transfer object for the BalanceServiceProvider entity.
/// </summary>
public class BalanceServiceProviderDTO : Entity
{


    /// <summary>
    /// Property that represents the unique identifier for the business Id.
    /// </summary>
    /// <value></value>
    public required string BusinessId { get; set; }


    /// <summary>
    /// Property that represents the code assigned to the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required string BspCode { get; set; }


    /// <summary>
    /// Property that represents the name of the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required string BspName { get; set; }


    /// <summary>
    /// Property that represents the coding scheme used by the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required string CodingScheme { get; set; }


    /// <summary>
    /// Property that represents the country associated with the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required string Country { get; set; }


    /// <summary>
    /// Property that represents the value ValidityStart associated with the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required DateTime ValidityStart { get; set; }


    /// <summary>
    /// Property that represents the value ValidityEnd associated with the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required DateTime ValidityEnd { get; set; }

}

