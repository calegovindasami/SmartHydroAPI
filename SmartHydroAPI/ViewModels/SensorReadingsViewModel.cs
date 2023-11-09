namespace SmartHydroAPI.ViewModels
{
    public class SensorReadingsViewModel
    {
        public int ReadingId { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? Ph { get; set; }
        public decimal? Ec { get; set; }
        public decimal? WaterFlow { get; set; }
        public decimal? LightIntensity { get; set; }
    }
}
