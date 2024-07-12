using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;



namespace ACD.Api.Services.WhatsappCloud.SendMessage;



public class WhatsappCloudSendMessage : IWhatsappCloudSendMessage
{

    public async Task<bool> Execute(object model)
    {
        var client = new HttpClient();

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
                return true;
            }

            return false;

        }
    }
}