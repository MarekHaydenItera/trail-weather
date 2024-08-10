namespace trail_weather_api.DTOs
{
    public class ForecastDTO
    {
        public string Name { get; set; }
        public int DistanceTo { get; set; }    
        public double Latitude { get; set; }
        public double Longitude { get; set; }  
        public int WeatherCode { get; set; }
    }
}
