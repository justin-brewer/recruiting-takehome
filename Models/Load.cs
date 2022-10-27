using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace recruiting_takehome.Models
{
    public class Load
    {
        public Load(string LoadId, int X, int Y) {
            this.LoadId = LoadId;
            this.X = X;
            this.Y = Y;
        }
        [JsonPropertyName("loadId")]
        public string LoadId { get; set; }
        [JsonPropertyName("x")]
        public int X { get; set; }
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}
