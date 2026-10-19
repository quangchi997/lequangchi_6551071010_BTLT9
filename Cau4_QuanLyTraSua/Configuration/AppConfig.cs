namespace Cau4_QuanLyTraSua.Configuration
{
    public class AppSettings
    {
        public ConnectionStringsConfig ConnectionStrings { get; set; } = new();
        public PaymentConfig Payment { get; set; } = new();
    }

    public class ConnectionStringsConfig
    {
        public string DefaultConnection { get; set; } = string.Empty;
    }

    public class PaymentConfig
    {
        public string BankId { get; set; } = "970436";
        public string AccountNo { get; set; } = "1234567890";
        public string AccountName { get; set; } = "QUAN TRA SUA";
        public string Template { get; set; } = "compact2";
        public string ShopName { get; set; } = "QUÁN TRÀ SỮA";
    }
}
