namespace ACD.Domain.Models.WhatsApp;

public class WhatsAppCloudModel
{
    public List<Entry> Entry { get; set; }
}
public class Entry
{
    public List<Change>? Changes { get; set; }
}
public class Change
{
    public Value? Value { get; set; }
    public string? Field { get; set; }
}
public class Value
{
    public string? Messaging_Product { get; set; }
    public List<MessageData>? Messages { get; set; }
}
public class MessageData
{
    public string? From { get; set; }
    public string? Id { get; set; }
    public string? Timestamp { get; set; }
    public string? Type { get; set; }
    public Text? Text { get; set; }
    public Interactive? Interactive { get; set; }

}
public class Interactive
{
    public string? Type { get; set; }
    public ListReply? List_Reply { get; set; }
    public ButtonReply? Button_Reply { get; set; }
}
public class ListReply
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
public class ButtonReply
{
    public string? Id { get; set; }
    public string? Title { get; set; }
}

public class Text
{
    public string? Body { get; set; }
}