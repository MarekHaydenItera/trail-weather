using System.ComponentModel.DataAnnotations;

namespace trail_weather_data_access.Models
{
    public class SportCenter
    {
        public int SportCenterId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public virtual GeoData GeoData { get; set; }
        public virtual SportCenterType SportCenterType { get; set; }
    }
}
