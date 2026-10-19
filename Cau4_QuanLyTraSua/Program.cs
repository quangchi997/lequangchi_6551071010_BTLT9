using System;
using System.IO;
using System.Windows.Forms;
using Serilog;

namespace Cau4_QuanLyTraSua
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
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

            Log.Information("Ứng dụng Bán hàng quán trà sữa khởi động.");

            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new FormBanHang());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Lỗi ứng dụng Bán hàng trà sữa");
            }
            finally
            {
                Log.Information("Ứng dụng Bán hàng quán trà sữa kết thúc.");
                Log.CloseAndFlush();
            }
        }
    }
}