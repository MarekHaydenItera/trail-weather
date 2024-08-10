using trail_weather_api.DTOs;

namespace trail_weather_api.Services.Interfaces
{
    public interface IDistanceCalculator
    {
        int CalculateDistance(GeoDTO start, GeoDTO end);
    }
}
