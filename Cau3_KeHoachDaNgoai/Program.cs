using System;
using System.IO;
using System.Windows.Forms;
using Serilog;

namespace Cau3_KeHoachDaNgoai
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

            Log.Information("Ứng dụng Kế hoạch dã ngoại khởi động.");

            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new FormChuyenDi());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Lỗi ứng dụng Kế hoạch dã ngoại");
            }
            finally
            {
                Log.Information("Ứng dụng Kế hoạch dã ngoại kết thúc.");
                Log.CloseAndFlush();
            }
        }
    }
}