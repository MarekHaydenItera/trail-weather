using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trail_weather_data_access.Models;

namespace trail_weather_data_access.Repositories
{
    public class SportCenterRepository : ISportCenterRepository
    {
        private readonly TrailWeatherDbContext _db;        

        public SportCenterRepository(string connectionString)
        {
            _db = new TrailWeatherDbContext(connectionString);
        }

        public List<SportCenter> GetSportCenters()
        {
            return _db.SportCenter
                .Include(Repositories => Repositories.GeoData)
                .Include(Repositories => Repositories.SportCenterType)
                .ToList();
        }
    }
}
