using ACD.Domain.Interfaces;
using ACD.Domain.Models;
using ACD.Infrastructure.Context;
using Microsoft.Extensions.Logging;



namespace ACD.Infrastructure.Repository;



public class WhatsAppMessageRepository : Repository<WhatsAppMessage>, IWhatsAppMessageRepository
{


    public WhatsAppMessageRepository(ACDDbContext context, ILogger<Repository<WhatsAppMessage>> logger) : base(context, logger)
    {

    }


}