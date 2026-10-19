using System;
using Microsoft.Extensions.Configuration;

namespace Cau3_KeHoachDaNgoai.Configuration
{
    public static class ConfigHelper
    {
        private static AppSettings? _settings;

        public static AppSettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    LoadConfiguration();
                }
                return _settings!;
            }
        }

        public static void LoadConfiguration()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            _settings = new AppSettings();
            configuration.Bind(_settings);
        }

        public static string GetConnectionString()
        {
            return Settings.ConnectionStrings.DefaultConnection;
        }
    }
}
