using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace recruiting_takehome.Models
{
    public class Robot
    {
        [JsonPropertyName("robotId")]
        public string RobotId { get; set; }
        [JsonPropertyName("batteryLevel")]
        public int BatteryLevel { get; set; }
        [JsonPropertyName("x")]
        public int X { get; set; }
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}