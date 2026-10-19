using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cau2_QuanLyNhaTro.Models
{
    public class ProvinceDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        public override string ToString() => Name;
    }

    public class WardDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        public override string ToString() => Name;
    }

    public class ProvinceDetailDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("wards")]
        public List<WardDto> Wards { get; set; } = new();
    }
}
