using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc;
using trail_weather_api.DTOs;
using trail_weather_api.Services.Interfaces;
using trail_weather_data_access.Models;
using trail_weather_data_access.Repositories;
namespace trail_weather_api.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {       
        private readonly IDistanceCalculator _distanceCalculator;
        private readonly ISportCenterRepository _sportCenterRepository;
        private readonly IForecastService _forecastService;
        

        public WeatherForecastController(IDistanceCalculator distanceCalculator, ISportCenterRepository sportCenterRepository, IForecastService forecastService)
        {
            _distanceCalculator = distanceCalculator;
            _sportCenterRepository = sportCenterRepository;
            _forecastService = forecastService;
        }

        [HttpGet("{range}", Name = "GetByRangeFromCurrentLocation")]        
        public async Task<List<ForecastDTO>> Get(int range)
        {
            GeoDTO currentLocation = new GeoDTO
            {
                Latitude = 49.19,
                Longitude = 18.73
            };

            List<SportCenter> sportCenters = _sportCenterRepository.GetSportCenters();

            var filteredByDistance = sportCenters.Where(sc => CalculateDistance(currentLocation, new GeoDTO { Latitude = sc.GeoData.Lat, Longitude = sc.GeoData.Lon }) <= range)
                .Select(sc => new ForecastDTO
                {
                    Name = sc.Name,
                    DistanceTo = CalculateDistance(currentLocation, new GeoDTO { Latitude = sc.GeoData.Lat, Longitude = sc.GeoData.Lon }),
                    Latitude = Math.Round(sc.GeoData.Lat, 2),
                    Longitude = Math.Round(sc.GeoData.Lon, 2),                   
                }).ToList();

            return await _forecastService.GetForecast(filteredByDistance);            
        }

        private static int CalculateDistance(GeoDTO start, GeoDTO end)
        {
            GeoCoordinate startCoordinate = new GeoCoordinate(start.Latitude, start.Longitude);
            GeoCoordinate endCoordinate = new GeoCoordinate(end.Latitude, end.Longitude);
            return (int)startCoordinate.GetDistanceTo(endCoordinate);
        }
    }
}
