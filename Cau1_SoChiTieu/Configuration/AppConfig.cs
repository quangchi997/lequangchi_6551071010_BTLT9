namespace Cau1_SoChiTieu.Configuration
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
