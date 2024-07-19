using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ACD.Api.Webhooks;

//public class Aviso
//{
//    public string Field { get; set; }
//    public Value Value { get; set; }
//}

//public class Value
//{
//    public string Messaging_Product { get; set; }
//    public Metadata Metadata { get; set; }
//    public List<Contact> Contacts { get; set; }
//    public List<Message> Messages { get; set; }
//}


//public class WhatsAppWebhookPayload
//{

//    [Required]
//    public string Field { get; set; }

//    [Required]
//    public ValueData Value { get; set; }

//    public class ValueData
//    {
//        [Required]
//        public string Messaging_Product { get; set; }

//        [Required]
//        public MetadataData Metadata { get; set; }

//        [Required]
//        public List<StatusData> Statuses { get; set; }
//    }

//    public class MetadataData
//    {
//        [Required]
//        public string Display_Phone_Number { get; set; }

//        [Required]
//        public string Phone_Number_Id { get; set; }
//    }

//    public class StatusData
//    {
//        [Required]
//        public string Id { get; set; }

//        [Required]
//        public string Status { get; set; }

//        [Required]
//        public long Timestamp { get; set; }

//        [Required]
//        public string Recipient_Id { get; set; }
//    }

//}


//Recibir webhooks 
public class WhatsAppWebhookPayload
{
    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("entry")]
    public List<Entry> Entry { get; set; }
}

public class Entry
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("changes")]
    public List<Change> Changes { get; set; }
}

public class Change
{
    [JsonPropertyName("value")]
    public ChangeValue Value { get; set; }

    [JsonPropertyName("field")]
    public string Field { get; set; }
}

public class ChangeValue
{
    [JsonPropertyName("messaging_product")]
    public string MessagingProduct { get; set; }

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; }

    [JsonPropertyName("statuses")]
    public List<Status> Statuses { get; set; }
}

public class Metadata
{
    [JsonPropertyName("display_phone_number")]
    public string DisplayPhoneNumber { get; set; }

    [JsonPropertyName("phone_number_id")]
    public string PhoneNumberId { get; set; }
}

public class Status
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("status")]
    public string StatusValue { get; set; }

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; }

    [JsonPropertyName("recipient_id")]
    public string RecipientId { get; set; }

    [JsonPropertyName("conversation")]
    public Conversation Conversation { get; set; }

    [JsonPropertyName("pricing")]
    public Pricing Pricing { get; set; }
}

public class Conversation
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("origin")]
    public Origin Origin { get; set; }
}

public class Origin
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class Pricing
{
    [JsonPropertyName("billable")]
    public bool Billable { get; set; }

    [JsonPropertyName("pricing_model")]
    public string PricingModel { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }
}







