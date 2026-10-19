using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Cau2_QuanLyNhaTro.Models;
using Serilog;

namespace Cau2_QuanLyNhaTro.Services
{
    public static class ProvinceApiService
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        private const string BaseUrl = "https://provinces.open-api.vn/api/v2/";

        public static async Task<List<ProvinceDto>?> GetProvincesAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ProvinceDto>>(BaseUrl);
                return response;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
            {
                Log.Warning(ex, "Không thể kết nối đến API lấy danh sách tỉnh/thành: {Message}", ex.Message);
                return null;
            }
        }

        public static async Task<List<WardDto>?> GetWardsAsync(int provinceCode)
        {
            try
            {
                string url = $"{BaseUrl}p/{provinceCode}?depth=2";
                var detail = await _httpClient.GetFromJsonAsync<ProvinceDetailDto>(url);
                return detail?.Wards;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
            {
                Log.Warning(ex, "Không thể kết nối đến API lấy danh sách phường/xã cho tỉnh mã {Code}: {Message}", provinceCode, ex.Message);
                return null;
            }
        }
    }
}
