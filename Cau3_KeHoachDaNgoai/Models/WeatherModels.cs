using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cau3_KeHoachDaNgoai.Models
{
    public class GeocodingResponse
    {
        [JsonPropertyName("results")]
        public List<GeocodingLocation>? Results { get; set; }
    }

    public class GeocodingLocation
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }

    public class ForecastResponse
    {
        [JsonPropertyName("daily")]
        public DailyForecastData? Daily { get; set; }
    }

    public class DailyForecastData
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; } = new();

        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; } = new();

        [JsonPropertyName("temperature_2m_max")]
        public List<double> TemperatureMax { get; set; } = new();

        [JsonPropertyName("temperature_2m_min")]
        public List<double> TemperatureMin { get; set; } = new();

        [JsonPropertyName("precipitation_probability_max")]
        public List<int> PrecipitationProbabilityMax { get; set; } = new();
    }

    public class WeatherDisplayInfo
    {
        public int WeatherCode { get; set; }
        public string WeatherDescription { get; set; } = string.Empty;
        public string WeatherIcon { get; set; } = "☀️";
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int RainProbability { get; set; }
        public string Advice { get; set; } = string.Empty;
        public bool ShouldWarn { get; set; }
        public bool HasData { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
