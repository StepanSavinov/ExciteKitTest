using System.Text.Json.Serialization;

namespace ExciteKit.DTO;

public class DataEventVm
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("capture_dt")]
    public DateTime CaptureDt { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("event_context")]
    public string EventContext { get; set; }

    [JsonPropertyName("event_name")]
    public string EventName { get; set; }

    [JsonPropertyName("item")]
    public string Item { get; set; }
}