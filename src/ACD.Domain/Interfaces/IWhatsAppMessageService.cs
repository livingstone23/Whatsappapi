using ACD.Domain.Models;



namespace ACD.Domain.Interfaces;



public interface IWhatsAppMessageService
{

    Task<WhatsAppMessage> Add(WhatsAppMessage whatsAppMessage);

}