using System;
using System.Collections.Generic;

namespace SmartHydroAPI.Models
{
    public partial class SensorReading
    {
        public int ReadingId { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? Ph { get; set; }
        public decimal? Ec { get; set; }
        public decimal? WaterFlow { get; set; }
        public decimal? LightIntensity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
