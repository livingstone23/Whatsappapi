using Newtonsoft.Json;



namespace ACD.Api.Dto;



public class WhatsAppMessageNotification
{


    [JsonProperty("messaging_product")]
    public string MessagingProduct { get; set; } = "whatsapp";

    [JsonProperty("to")]
    public string To { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("template")]
    public Template Template { get; set; }

}

public class Template
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("language")]
    public Language Language { get; set; }

    [JsonProperty("components")]
    public List<Component> Components { get; set; }
}

public class Language
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("policy")]
    public string Policy { get; set; }
}

public class Component
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("parameters")]
    public List<Parameter> Parameters { get; set; }
}

public class Parameter
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

}

public class WhatsAppBusinessAccountNotification
{
    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("entry")]
    public List<Entry> Entry { get; set; }
}

public class Entry
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("changes")]
    public List<Change> Changes { get; set; }
}

public class Change
{
    [JsonProperty("value")]
    public ChangeValue Value { get; set; }

    [JsonProperty("field")]
    public string Field { get; set; }
}

public class ChangeValue
{
    [JsonProperty("messaging_product")]
    public string MessagingProduct { get; set; }

    [JsonProperty("metadata")]
    public Metadata Metadata { get; set; }

    [JsonProperty("contacts")]
    public List<Contact> Contacts { get; set; }

    [JsonProperty("messages")]
    public List<Message> Messages { get; set; }

    [JsonProperty("statuses")]
    public List<Statuses> Statuses { get; set; }
}

public class Metadata
{
    [JsonProperty("display_phone_number")]
    public string DisplayPhoneNumber { get; set; }

    [JsonProperty("phone_number_id")]
    public string PhoneNumberId { get; set; }
}

public class Contact
{
    [JsonProperty("profile")]
    public Profile Profile { get; set; }

    [JsonProperty("wa_id")]
    public string WaId { get; set; }
}

public class Profile
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class Message
{
    [JsonProperty("from")]
    public string From { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("timestamp")]
    public string Timestamp { get; set; }

    [JsonProperty("text")]
    public Text Text { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}

public class Text
{
    [JsonProperty("body")]
    public string Body { get; set; }
}

public class Statuses
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("timestamp")]
    public string Timestamp { get; set; }
}