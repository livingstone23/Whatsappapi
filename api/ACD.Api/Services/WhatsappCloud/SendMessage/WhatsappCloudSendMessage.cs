using System.Net.Http.Headers;
using System.Text;
using ACD.Api.Dto;
using Newtonsoft.Json;



namespace ACD.Api.Services.WhatsappCloud.SendMessage;



public class WhatsappCloudSendMessage : IWhatsappCloudSendMessage
{

    public async Task<WhatsAppResponseDTO> Execute(object model)
    {
        var client = new HttpClient();

        WhatsAppResponseDTO responseDto = new WhatsAppResponseDTO();

        var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

        using (var content = new ByteArrayContent(byteData))
        {
            string endpoint = "https://graph.facebook.com";
            string phoneNumberId = "";
            string accessToken = "";
            string uri = $"{endpoint}/v20.0/{phoneNumberId}/messages";

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta como un string
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserializar el string JSON a un objeto dinámico
                dynamic responseObject = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                // Ahora puedes acceder a las propiedades del objeto deserializado
                //string messageId = responseObject.messages[0].id;
                //string messageStatus = responseObject.messages[0].message_status;

                responseDto.MessageId = responseObject.messages[0].id;
                responseDto.MessageStatus = responseObject.messages[0].message_status;
                responseDto.IsSuccess = true;

                // Si necesitas trabajar con un objeto específico en lugar de uno dinámico,
                // primero define una clase que coincida con la estructura del JSON y luego deserializa a ese tipo.


                return responseDto;
            }

            responseDto.IsSuccess = false;
            return responseDto;

        }
    }
}