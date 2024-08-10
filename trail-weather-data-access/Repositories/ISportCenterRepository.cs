using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trail_weather_data_access.Models;

namespace trail_weather_data_access.Repositories
{
    public interface ISportCenterRepository
    { 
        List<SportCenter> GetSportCenters();
    }
}
