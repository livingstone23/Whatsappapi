using ACD.Domain.Interfaces;
using Microsoft.Extensions.Logging;



namespace ACD.Domain.Services;



public class WhatsAppMessageService: IWhatsAppMessageService
{


    private readonly IWhatsAppMessageRepository _whatsAppMessageRepository;
    private readonly ILogger<WhatsAppMessageService> _logger;


    public WhatsAppMessageService(IWhatsAppMessageRepository whatsAppMessageRepository, 
                                    ILogger<WhatsAppMessageService> logger)
    {
        _whatsAppMessageRepository = whatsAppMessageRepository;
        _logger = logger;
    }


    public async Task<WhatsAppMessage> Add(WhatsAppMessage whatsAppMessage)
    {
        try
        {
            await _whatsAppMessageRepository.Add(whatsAppMessage);
            return whatsAppMessage;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while adding WhatsAppMessage");
            throw;
        }
    }

    public async Task<WhatsAppMessage> GetByMessageId(string MessageId)
    {
        try
        {
            WhatsAppMessage foundWhatsAppMessage = await _whatsAppMessageRepository.GetByMessageId(MessageId);
            return foundWhatsAppMessage;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}