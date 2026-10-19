using System;
using System.IO;
using System.Windows.Forms;
using Serilog;

namespace Cau1_SoChiTieu
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Cấu hình Serilog ghi theo ngày vào thư mục Logs cạnh file .exe
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    path: Path.Combine(logDirectory, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            Log.Information("Ứng dụng Sổ chi tiêu cá nhân khởi động.");

            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new FormChiTieu());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng gặp lỗi nghiêm trọng.");
            }
            finally
            {
                Log.Information("Ứng dụng Sổ chi tiêu cá nhân kết thúc.");
                Log.CloseAndFlush();
            }
        }
    }
}