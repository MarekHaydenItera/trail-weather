using trail_weather_api.Services.Interfaces;
using trail_weather_api.DTOs;
using GeoCoordinatePortable;

namespace trail_weather_api.Services
{
    public class DistanceCalculator : IDistanceCalculator
    {           
        public int CalculateDistance(GeoDTO start, GeoDTO end)
        {
            GeoCoordinate startCoordinate = new GeoCoordinate(start.Latitude, start.Longitude);
            GeoCoordinate endCoordinate = new GeoCoordinate(end.Latitude, end.Longitude);
            return (int)startCoordinate.GetDistanceTo(endCoordinate);
        }
    }
}
