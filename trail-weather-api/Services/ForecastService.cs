using Azure;
using Newtonsoft.Json;
using trail_weather_api.DTOs;
using trail_weather_api.Services.Interfaces;

namespace trail_weather_api.Services
{
    public class ForecastService : IForecastService
    {
        private readonly HttpClient _httpClient;

        public ForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }   

        public async Task<List<ForecastDTO>> GetForecast(List<ForecastDTO> forecastDTOs)
        {
            List<GeoDTO> geoDTOs;
            
            
            var response = await _httpClient.GetAsync("forecast?latitude=49.22,49.23,49.01&longitude=18.7,19.04,19.01&daily=weather_code&past_days=3&forecast_days=3");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error while fetching data from the API");
            }
            var parsedResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var weatherData = JsonConvert.DeserializeObject<List<WeatherResponseDTO>>(parsedResponse);
            return forecastDTOs;
        }
    }
}
