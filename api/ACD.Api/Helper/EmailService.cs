using SendGrid.Helpers.Mail;
using SendGrid;



namespace ACD.Api.Helper;



public class EmailService
{


    private readonly string apiKey;

    public EmailService(string sendGridApiKey)
    {
        apiKey = sendGridApiKey;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent)
    {
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("livingstone23@gmail.com", "Livingstone");
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

        var response = await client.SendEmailAsync(msg);
        Console.WriteLine(response.StatusCode);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            var errorMessage = await response.Body.ReadAsStringAsync();
            Console.WriteLine($"Error sending email: {errorMessage}");
        }
    }
}