using ACD.Domain.Models;

namespace ACD.Api.Dto;

public class WhatsAppMessageDTO : Entity
{

    public Guid Oui { get; set; }
    public string? PhoneTo { get; set; }
    public string? TemplateNameUsed { get; set; }
    public string? MessageBody { get; set; }
    public string? PhoneFrom { get; set; }
    public string? PhoneId { get; set; }
    public Guid? NotificationId { get; set; }

    public bool? SendingAt { get; set; }
    public DateTime? SendingDate { get; set; }
    public bool? DeliveredAt { get; set; }
    public DateTime? DeliveredDate { get; set; }
    public bool? ReadedAt { get; set; }
    public DateTime? ReadedDate { get; set; }
    public bool? FailedAt { get; set; }
    public DateTime? FailedDate { get; set; }



    // Control fields
    public DateTime? Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Updated { get; set; }
    public string? UpdatedBy { get; set; }
    public int? GcRecord { get; set; }




}