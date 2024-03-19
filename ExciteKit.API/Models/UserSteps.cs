using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExciteKit.API.Models;

public class UserSteps
{
    [JsonPropertyName("user_id")]
    [Column("UserId")]
    public int UserId { get; set; }
    
    [JsonPropertyName("step_url")]
    [Column("step_url")]
    public string StepUrl { get; set; }
    
    [JsonPropertyName("step_event")]
    [Column("step_event")]
    public string StepEvent { get; set; }
    
    [JsonPropertyName("step_number")]
    [Column("step_number")]
    public long StepNumber { get; set; }
    
    [JsonPropertyName("total_steps")]
    [Column("total_steps")]
    public int TotalSteps { get; set; }
}