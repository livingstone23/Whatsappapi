using System.Linq.Expressions;

namespace ACD.Domain.Interfaces;

public interface IWhatsAppMessageRepository: IRepository<WhatsAppMessage>
{

    Task<WhatsAppMessage> GetByMessageId(string MessageId);

}