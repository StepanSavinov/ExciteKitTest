using System.Text.Json.Serialization;

namespace ExciteKit.DTO;

public class UrlCountVm
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    [JsonPropertyName("count")] 
    public double Count { get; set; }
}