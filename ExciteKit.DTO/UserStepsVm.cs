using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExciteKit.DTO;

public class UserStepsVm
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    
    [JsonPropertyName("step_url")]
    public string StepUrl { get; set; }
    
    [JsonPropertyName("step_event")]
    public string StepEvent { get; set; }
    
    [JsonPropertyName("step_number")]
    public long StepNumber { get; set; }
    
    [JsonPropertyName("total_steps")]
    public int TotalSteps { get; set; }
}