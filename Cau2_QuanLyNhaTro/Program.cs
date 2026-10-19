using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Serilog;

namespace Cau2_QuanLyNhaTro
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Thiết lập Serilog
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

            Log.Information("Khởi động ứng dụng Quản lý nhà trọ.");

            // Đăng ký xử lý lỗi toàn cục
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += (sender, e) =>
            {
                Log.Error(e.Exception, "Lỗi chưa xử lý trong UI Thread: {Message}", e.Exception.Message);
                MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Fatal(ex, "Lỗi chưa xử lý trong AppDomain: {Message}", ex.Message);
                }
                MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new FormKhachThue());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Lỗi xảy ra trong vòng đời ứng dụng");
            }
            finally
            {
                Log.Information("Ứng dụng Quản lý nhà trọ kết thúc.");
                Log.CloseAndFlush();
            }
        }
    }
}