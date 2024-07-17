using ACD.Api.Dto;
using ACD.Api.Helper;
using ACD.Api.Services.WhatsappCloud.SendMessage;
using ACD.Domain.Interfaces;
using ACD.Domain.Models.WhatsApp;
using ACD.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace ACD.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WhatsAppsController : ControllerBase
    {

        private readonly IWhatsappCloudSendMessage _whatsappCloudSendMessage;

        private readonly IConfiguration _configuration;

        private readonly IWhatsAppMessageRepository _whatsAppMessageRepository;
        
        private readonly ILogger<WhatsAppsController> _logger;


        public WhatsAppsController(IWhatsappCloudSendMessage whatsappCloudSendMessage, 
                                IConfiguration configuration,
                                IWhatsAppMessageRepository whatsAppMessageRepository,
                                ILogger<WhatsAppsController> logger
                                )
        {


            _whatsappCloudSendMessage = whatsappCloudSendMessage;
            _configuration = configuration;
            _whatsAppMessageRepository = whatsAppMessageRepository;
            _logger = logger;
        }


        //Method Get to send notificacation
        //In the route name the method SendNotification
        [HttpPost]
        [Route("SendNotification")]
        public async Task<IActionResult> SendMessage([FromBody] WhatsAppMessageNotification model)
        {
            try
            {

                WhatsAppResponseDTO whatsappResponse = await _whatsappCloudSendMessage.Execute(model);


                WhatsAppMessage newWhatsAppMessage   = new WhatsAppMessage                 
                {

                    PhoneTo = model.To,
                    TemplateNameUsed = model.Template.Name,
                    PhoneFrom = _configuration["WhatsApp:PhoneNumber"],
                    PhoneId = _configuration["WhatsApp:PhoneNumberId"],
                    //Guardamos los parametros del mensaje
                    MessageBody = JsonConvert.SerializeObject(model.Template.Components[0].Parameters),
                    Created = DateTime.Now,
                    Oui = Guid.NewGuid()
                };

                if (whatsappResponse.IsSuccess)
                {
                    newWhatsAppMessage.MessageId = whatsappResponse.MessageId;
                    newWhatsAppMessage.SendingAt = true;
                    newWhatsAppMessage.SendingDate  = DateTime.Now;

                }
                else
                {
                    newWhatsAppMessage.FailedAt = true;
                    newWhatsAppMessage.FailedDate = DateTime.Now;
                }

                await _whatsAppMessageRepository.Add(newWhatsAppMessage);

                string notification = $" El MessageId es: {whatsappResponse.MessageId}";
                
                var resultMail = SendEmail(notification);

                if (whatsappResponse.IsSuccess)
                {
                    return Ok("EVENT_RECEIVED");
                }

                return Ok("EVENT_RECEIVED");
            }
            catch (Exception e)
            {
                return Ok("EVENT_RECEIVED");
            }
        }


        /// <summary>
        /// Metodo para verificar el token de facebook
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult VerifyToken()
        {
            string AcessToken = "SAHKDSDTTAEFE232256456EWRE43";

            //Permite que o Facebook valide token
            var token = Request.Query["hub.verify_token"].ToString();

            //Capturamos codigo de verificacion generado por facebook
            var challenge = Request.Query["hub.challenge"].ToString();

            if (challenge != null && token != null && token == AcessToken)
            {
                return Ok(challenge);
            }
            else
            {
                return BadRequest();
            }

        }



        /// <summary>
        /// Metodo para recibir el mensaje enviado por el cliente.
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReceivedMessage([FromBody] WhatsAppCloudModel body)
        {

            try
            {

                var Message = body.Entry[0]?.Changes[0]?.Value?.Messages[0];
                if(Message == null)
                {
                    var userNumber = Message.From;
                    var userText = GetUserText(Message);
                }



                return Ok("EVENT_RECEIVED");

            }

            catch (Exception ex)
            {

                return Ok("EVENT_RECEIVED");

            }
        }



        ///Metodo para identificar mensaje por Id
        [HttpGet]
        [Route("GetMessageById")]
        public async Task<IActionResult> GetMessageById(string messageId)
        {
            try
            {
                var message = await _whatsAppMessageRepository.GetByMessageId(messageId);

                if (message != null)
                {
                    return Ok(message);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        



        /// <summary>
        /// Method for processing the message sent by the client.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string GetUserText(MessageData message)
        {
            string TypeMessage = message.Type;

            //If message come from a text
            if (TypeMessage.ToUpper() == "TEXT")
            {
                return message.Text.Body;
            } //If message come from a interactive message like buttons or list
            else if (TypeMessage.ToUpper() == "INTERACTIVE")
            {
                string interactiveType = message.Interactive.Type;

                if (interactiveType.ToUpper() == "LIST_REPLY")
                {
                    return message.Interactive.List_Reply.Title;
                }
                else if (interactiveType.ToUpper() == "BUTTON_REPLY")
                {
                    return message.Interactive.Button_Reply.Title;
                }
                else
                {
                    //If the message is not a text or interactive message
                    //Return empty string
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// metodo privado para envio de correo electronico
        /// si se envio correctamente retorna true de lo contrario false
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        private async Task<bool> SendEmail(string notification)
        {
            try
            {

                ///Objtengo sendgrid api key desde el archivo del appsettings.json
                var apiKey = _configuration["SendGrid:ApiKey"];

                
                
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("livingstone23@gmail.com", "Livingstone");
                var subject = "Asunto de correo : " + notification;
                var to = new EmailAddress("livingstone23@gmail.com", "Livingstone");
                var plainTextContent = "This is a test email sent from SendGrid.";
                var htmlContent = $"<strong> {notification} </strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var response = await client.SendEmailAsync(msg);

                if (response.Headers.TryGetValues("X-Message-Id", out var messageIds))
                {
                    var messageId = messageIds.FirstOrDefault();
                    return true; // Retorna el MessageId para su uso posterior
                }

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error al enviar correo electrónico");
                return false;
            }
        }

       



    }
}
