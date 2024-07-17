using ACD.Domain.Interfaces;
using ACD.Domain.Models;
using ACD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace ACD.Infrastructure.Repository;



public class WhatsAppMessageRepository : Repository<WhatsAppMessage>, IWhatsAppMessageRepository
{
    

    public WhatsAppMessageRepository(ACDDbContext context, ILogger<Repository<WhatsAppMessage>> logger) : base(context, logger)
    {

    }


    public async Task<WhatsAppMessage> GetByMessageId(string MessageId)
    {

        try
        {
            WhatsAppMessage foundWhatsAppMessage = await _dbSet.FirstOrDefaultAsync(x => x.MessageId == MessageId);
            return foundWhatsAppMessage;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting balance service providers by country");
            throw;
        }

    }

}