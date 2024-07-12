namespace ACD.Domain.Models.WhatsApp;



public class WhatsAppResponse
{
    public int Id { get; set; }
    public string MessagingProduct { get; set; }
    public List<Contact> Contacts { get; set; }
    public List<Message> Messages { get; set; }
}



public class Contact
{
    public string Input { get; set; }
    public string WaId { get; set; }
}



public class Message
{
    public string Id { get; set; }
    public string MessageStatus { get; set; }
}