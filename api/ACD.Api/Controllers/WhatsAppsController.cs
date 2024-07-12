using ACD.Api.Dto;
using ACD.Api.Services.WhatsappCloud.SendMessage;
using ACD.Domain.Models.WhatsApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACD.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WhatsAppsController : ControllerBase
    {

        private readonly IWhatsappCloudSendMessage _whatsappCloudSendMessage;


        public WhatsAppsController(IWhatsappCloudSendMessage whatsappCloudSendMessage)
        {
            _whatsappCloudSendMessage = whatsappCloudSendMessage;
        }


        //Method Get to send notificacation
        //In the route name the method SendNotification
        [HttpGet]
        [Route("SendNotification")]
        public async Task<IActionResult> SendMessage([FromBody] WhatsAppMessageNotification model)
        {
            try
            {
                var result = await _whatsappCloudSendMessage.Execute(model);

                if (result)
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







    }
}
