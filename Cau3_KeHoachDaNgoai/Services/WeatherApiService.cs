using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Cau3_KeHoachDaNgoai.Models;
using Serilog;

namespace Cau3_KeHoachDaNgoai.Services
{
    public static class WeatherApiService
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(8)
        };

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).Replace('đ', 'd').Replace('Đ', 'D');
        }

        public static async Task<WeatherDisplayInfo> GetWeatherForecastAsync(string destination, DateTime travelDate, bool isEnglish)
        {
            var info = new WeatherDisplayInfo();

            try
            {
                // Bước 1: Geocoding tìm tọa độ địa danh
                string encodedName = Uri.EscapeDataString(destination.Trim());
                string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={encodedName}&count=1&language=vi";

                GeocodingResponse? geoRes = null;
                try
                {
                    geoRes = await _httpClient.GetFromJsonAsync<GeocodingResponse>(geoUrl);
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "Lỗi gọi Geocoding với tên có dấu: {Destination}", destination);
                }

                // Nếu không tìm thấy, thử xóa dấu tiếng Việt (ví dụ Đà Lạt -> Da Lat)
                if (geoRes?.Results == null || geoRes.Results.Count == 0)
                {
                    string unaccented = RemoveDiacritics(destination.Trim());
                    if (!string.Equals(unaccented, destination.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        string unaccentedUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(unaccented)}&count=1&language=vi";
                        try
                        {
                            geoRes = await _httpClient.GetFromJsonAsync<GeocodingResponse>(unaccentedUrl);
                        }
                        catch (Exception ex)
                        {
                            Log.Warning(ex, "Lỗi gọi Geocoding với tên không dấu: {Unaccented}", unaccented);
                        }
                    }
                }

                if (geoRes?.Results == null || geoRes.Results.Count == 0)
                {
                    info.HasData = false;
                    info.Message = isEnglish
                        ? $"Location '{destination}' not found. Please try entering without accents (e.g., 'Da Lat')."
                        : $"Không tìm thấy địa danh '{destination}'. Vui lòng thử tên không dấu như '{RemoveDiacritics(destination)}'.";
                    return info;
                }

                var location = geoRes.Results[0];
                double lat = location.Latitude;
                double lon = location.Longitude;

                // Bước 2: Gọi Forecast API 16 ngày
                string forecastUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lat.ToString(CultureInfo.InvariantCulture)}&longitude={lon.ToString(CultureInfo.InvariantCulture)}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16";

                var forecast = await _httpClient.GetFromJsonAsync<ForecastResponse>(forecastUrl);
                if (forecast?.Daily == null || forecast.Daily.Time.Count == 0)
                {
                    info.HasData = false;
                    info.Message = isEnglish ? "Failed to retrieve forecast." : "Không thể lấy dữ liệu dự báo thời tiết.";
                    return info;
                }

                string targetDateStr = travelDate.ToString("yyyy-MM-dd");
                int index = forecast.Daily.Time.IndexOf(targetDateStr);

                if (index < 0)
                {
                    info.HasData = false;
                    info.Message = isEnglish ? "No forecast data available (beyond 16 days)." : "Chưa có dữ liệu dự báo (vượt quá 16 ngày).";
                    return info;
                }

                int code = forecast.Daily.WeatherCode.ElementAtOrDefault(index);
                double tMax = forecast.Daily.TemperatureMax.ElementAtOrDefault(index);
                double tMin = forecast.Daily.TemperatureMin.ElementAtOrDefault(index);
                int rainProb = forecast.Daily.PrecipitationProbabilityMax.ElementAtOrDefault(index);

                info.WeatherCode = code;
                info.TempMax = tMax;
                info.TempMin = tMin;
                info.RainProbability = rainProb;

                // Phân tích weather_code theo đề bài:
                // 0 = Trời quang; 1–3 = Có mây; 45, 48 = Sương mù; 51–67 và 80–82 = Mưa; 95–99 = Dông
                if (code == 0)
                {
                    info.WeatherDescription = isEnglish ? "Clear sky" : "Trời quang đãng";
                    info.WeatherIcon = "☀️";
                }
                else if (code >= 1 && code <= 3)
                {
                    info.WeatherDescription = isEnglish ? "Partly cloudy" : "Có mây rải rác";
                    info.WeatherIcon = "⛅";
                }
                else if (code == 45 || code == 48)
                {
                    info.WeatherDescription = isEnglish ? "Foggy" : "Sương mù";
                    info.WeatherIcon = "🌫️";
                }
                else if ((code >= 51 && code <= 67) || (code >= 80 && code <= 82))
                {
                    info.WeatherDescription = isEnglish ? "Rainy" : "Mưa rào / Mưa rải rác";
                    info.WeatherIcon = "🌧️";
                }
                else if (code >= 95 && code <= 99)
                {
                    info.WeatherDescription = isEnglish ? "Thunderstorm" : "Có dông sét";
                    info.WeatherIcon = "⛈️";
                }
                else
                {
                    info.WeatherDescription = isEnglish ? "Moderate weather" : "Thời tiết bình thường";
                    info.WeatherIcon = "🌤️";
                }

                // Cảnh báo nếu xác suất mưa >= 60%
                if (rainProb >= 60)
                {
                    info.ShouldWarn = true;
                    info.Advice = isEnglish
                        ? "⚠ Bring a raincoat or consider rescheduling."
                        : "⚠ Nên mang áo mưa hoặc cân nhắc dời lịch.";
                }

                info.HasData = true;
                return info;
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Lỗi khi gọi API thời tiết cho địa điểm {Destination}: {Message}", destination, ex.Message);
                info.HasData = false;
                info.Message = isEnglish
                    ? "Network error. Unable to load weather data."
                    : "Lỗi kết nối mạng. Không thể tải dữ liệu thời tiết.";
                return info;
            }
        }
    }
}
