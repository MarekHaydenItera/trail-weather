using Microsoft.Extensions.Configuration;
using trail_weather_data_access;
using trail_weather_data_access.Models;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var secretProvider = config.Providers.First();
secretProvider.TryGet("ConnectionString", out var secretPass);

if (secretPass is null)
    throw new ArgumentNullException("Connection string is empty", secretPass);

using (var db = new TrailWeatherDbContext(secretPass))
{
    var sportCenterType = new SportCenterType { Name = "Ski Resort" };
    db.SportCenterType.Add(sportCenterType);
    db.SaveChanges();

    var geoData = new GeoData { Lat = 45.123, Lon = -120.123 };
    db.GeoData.Add(geoData);
    db.SaveChanges();

    var sportCenter = new SportCenter { Name = "Mt. Hood Meadows", GeoData = geoData, SportCenterType = sportCenterType };
    db.SportCenter.Add(sportCenter);
    db.SaveChanges();
}