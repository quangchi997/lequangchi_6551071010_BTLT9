using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Cau4_QuanLyTraSua.Configuration;
using Serilog;

namespace Cau4_QuanLyTraSua.Services
{
    public static class VietQRService
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        public static string MaskAccountNumber(string acc)
        {
            if (string.IsNullOrEmpty(acc) || acc.Length <= 4) return "****";
            return string.Concat(new string('*', acc.Length - 4), acc.AsSpan(acc.Length - 4));
        }

        public static async Task<Image?> GenerateVietQRImageAsync(int maHD, decimal amount)
        {
            var config = ConfigHelper.GetPaymentConfig();
            string addInfo = $"TRASUA HD{maHD}";

            // Thông tin log bảo mật (không ghi đầy đủ số tài khoản)
            Log.Information("Tạo mã VietQR cho Hóa đơn MaHD = {MaHD}, Số tiền = {SoTien}, Ngân hàng = {BankId}, STK = {MaskedAcc}",
                maHD, amount, config.BankId, MaskAccountNumber(config.AccountNo));

            try
            {
                string bank = Uri.EscapeDataString(config.BankId);
                string acc = Uri.EscapeDataString(config.AccountNo);
                string template = Uri.EscapeDataString(config.Template);
                string amt = ((long)amount).ToString();
                string desc = Uri.EscapeDataString(addInfo);
                string accName = Uri.EscapeDataString(config.AccountName);

                string url = $"https://img.vietqr.io/image/{bank}-{acc}-{template}.png?amount={amt}&addInfo={desc}&accountName={accName}";

                byte[] imageBytes = await _httpClient.GetByteArrayAsync(url);
                using var ms = new MemoryStream(imageBytes);
                return Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi tải ảnh mã VietQR từ img.vietqr.io cho MaHD = {MaHD}", maHD);
                return null;
            }
        }
    }
}
