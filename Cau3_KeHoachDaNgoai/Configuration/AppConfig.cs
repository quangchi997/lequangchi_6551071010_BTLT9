namespace Cau3_KeHoachDaNgoai.Configuration
{
    public class AppSettings
    {
        public ConnectionStringsConfig ConnectionStrings { get; set; } = new();
    }

    public class ConnectionStringsConfig
    {
        public string DefaultConnection { get; set; } = string.Empty;
    }
}
