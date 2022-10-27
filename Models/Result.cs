using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace recruiting_takehome.Models
{
    public class Result
    {
        public Result(String? RobotId, int? BatteryLevel, double? DistanceToGoal, string? ErrorMessage) {
            this.RobotId = RobotId;
            this.BatteryLevel = BatteryLevel;
            this.DistanceToGoal = DistanceToGoal;
            this.ErrorMessage = ErrorMessage;
        }
        [JsonPropertyName("robotId")]
        public string? RobotId { get; set; }
        [JsonPropertyName("batteryLevel")]
        public int? BatteryLevel { get; set; }
        [JsonPropertyName("distanceToGoal")]
        public double? DistanceToGoal { get; set; }
        [JsonPropertyName("errorMessage")]
        public string? ErrorMessage { get; set; }
    }
}
