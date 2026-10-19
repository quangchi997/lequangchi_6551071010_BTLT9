using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using Serilog;

namespace Cau3_KeHoachDaNgoai.Services
{
    public class UserSettings
    {
        public string Language { get; set; } = "vi"; // "vi" hoặc "en"
    }

    public static class LocalizationService
    {
        private static readonly string SettingsDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Cau3_KeHoachDaNgoai"
        );
        private static readonly string SettingsFile = Path.Combine(SettingsDir, "usersettings.json");

        public static string CurrentLanguage { get; private set; } = "vi";

        public static CultureInfo CurrentCulture => CurrentLanguage == "en"
            ? new CultureInfo("en-US")
            : new CultureInfo("vi-VN");

        public static void LoadLanguagePreference()
        {
            try
            {
                if (File.Exists(SettingsFile))
                {
                    string json = File.ReadAllText(SettingsFile);
                    var settings = JsonSerializer.Deserialize<UserSettings>(json);
                    if (settings != null && (settings.Language == "en" || settings.Language == "vi"))
                    {
                        CurrentLanguage = settings.Language;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Không thể đọc file cấu hình usersettings.json");
            }
            CurrentLanguage = "vi";
        }

        public static void SaveLanguagePreference(string lang)
        {
            CurrentLanguage = lang;
            try
            {
                if (!Directory.Exists(SettingsDir))
                {
                    Directory.CreateDirectory(SettingsDir);
                }

                var settings = new UserSettings { Language = lang };
                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SettingsFile, json);
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Không thể ghi file cấu hình usersettings.json");
            }
        }
    }
}
