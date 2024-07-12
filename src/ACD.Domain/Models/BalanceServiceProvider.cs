namespace ACD.Domain.Models;



/// <summary>
/// Entity for managing BalanceServiceProvider objects.
/// </summary>
public class BalanceServiceProvider: Entity
{
    
    
    /// <summary>
    /// The unique identifier for the business Id.
    /// </summary>
    public required string BusinessId { get; set; }
    

    /// <summary>
    /// The code assigned to the BalanceServiceProvider.
    /// </summary>
    public required string BspCode { get; set; }
    

    /// <summary>
    /// The name of the BalanceServiceProvider.
    /// </summary>
    public required string BspName { get; set; }
    

    /// <summary>
    /// The coding scheme used by the BalanceServiceProvider.
    /// </summary>
    public required string CodingScheme { get; set; }
    

    /// <summary>
    /// The country associated with the BalanceServiceProvider.
    /// </summary>
    public required string Country { get; set; }


    /// <summary>
    /// The country associated with the BalanceServiceProvider.
    /// </summary>
    public required DateTime ValidityStart { get; set; }


    /// <summary>
    /// The country associated with the BalanceServiceProvider.
    /// </summary>
    public required DateTime ValidityEnd { get; set; }



    //Control field

    /// <summary>
    /// Indicates whether the entity is active or flagged for low-level deletion.
    /// </summary>
    /// <value></value>
    public required bool Active { get; set; } = true;


    /// <summary>
    /// The date and time when the object was created.
    /// </summary>
    public DateTime? Created { get; set; }

    /// <summary>
    /// The user who created the object.
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// The date and time when the object was last updated.
    /// </summary>
    public DateTime? Updated { get; set; }

    /// <summary>
    /// The user who last updated the object.
    /// </summary>
    public string? UpdatedBy { get; set; }


}
