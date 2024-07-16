using ACD.Api.Dto;

namespace ACD.Api.Services.WhatsappCloud.SendMessage;




public interface IWhatsappCloudSendMessage
{

    Task<WhatsAppResponseDTO> Execute(object model);

}