using System.Text.Json.Serialization;

namespace ExciteKit.API.Models;

using System;

public class DataEvent
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("capture_dt")]
    public DateTime CaptureDt { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("event_context")]
    public required string EventContext { get; set; }

    [JsonPropertyName("event_name")]
    public required string EventName { get; set; }

    [JsonPropertyName("item")]
    public required string Item { get; set; }
}