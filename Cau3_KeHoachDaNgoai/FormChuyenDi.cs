using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cau3_KeHoachDaNgoai.Models;
using Cau3_KeHoachDaNgoai.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cau3_KeHoachDaNgoai
{
    public partial class FormChuyenDi : Form
    {
        private bool _isEnglish = false;
        private bool _isInitializing = true;

        public FormChuyenDi()
        {
            InitializeComponent();
        }

        private void FormChuyenDi_Load(object sender, EventArgs e)
        {
            try
            {
                // Tải tùy chọn ngôn ngữ từ LocalAppData
                LocalizationService.LoadLanguagePreference();
                _isEnglish = LocalizationService.CurrentLanguage == "en";

                _isInitializing = true;
                cboNgonNgu.SelectedIndex = _isEnglish ? 1 : 0;
                cboPhuongTien.SelectedIndex = 1; // Ô tô

                DateTime now = DateTime.Today;
                dtpNgayDi.Value = now.AddDays(3);
                dtpTuNgay.Value = now;
                dtpDenNgay.Value = now.AddMonths(1);

                ApplyLanguage();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi khởi chạy FormChuyenDi");
                MessageBox.Show("Đã xảy ra lỗi khởi động ứng dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isInitializing = false;
            }
        }

        private void cboNgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;

            _isEnglish = cboNgonNgu.SelectedIndex == 1;
            LocalizationService.SaveLanguagePreference(_isEnglish ? "en" : "vi");
            ApplyLanguage();
            LoadData();

            // Nếu đang có thông tin chuyến đi hiển thị, cập nhật lại dự báo theo ngôn ngữ mới
            if (!string.IsNullOrWhiteSpace(txtDiaDiem.Text))
            {
                _ = FetchWeatherAsync(txtDiaDiem.Text.Trim(), dtpNgayDi.Value.Date);
            }
        }

        private void ApplyLanguage()
        {
            if (_isEnglish)
            {
                Text = "Weekend Trip Planner";
                grpThongTin.Text = "Trip Information";
                lblMaChuyen.Text = "Trip ID:";
                lblTenChuyen.Text = "Trip Name:";
                lblDiaDiem.Text = "Destination:";
                lblNgayDi.Text = "Travel Date:";
                lblSoNguoi.Text = "People:";
                lblNganSach.Text = "Budget:";
                lblPhuongTien.Text = "Transport:";
                chkDaHoanThanh.Text = "Completed";
                lblGhiChu.Text = "Notes:";
                btnThem.Text = "Add";
                btnSua.Text = "Update";
                btnXoa.Text = "Delete";
                btnLamMoi.Text = "Reset";

                lblNgonNgu.Text = "Language:";
                grpThoiTiet.Text = "Weather Forecast";
                btnXemThoiTiet.Text = "View Weather";
                lblWeatherHeader.Text = "Select a trip to view forecast";

                txtTimKiem.PlaceholderText = "Search by name or destination...";
                chkChuaHoanThanh.Text = "Incomplete only";
                lblTuNgay.Text = "From:";
                lblDenNgay.Text = "To:";
                btnTimKiem.Text = "Search";
                btnBoLoc.Text = "Clear";

                lblWarningText.Text = "⚠ Bring a raincoat or consider rescheduling.";
            }
            else
            {
                Text = "Kế hoạch dã ngoại cuối tuần";
                grpThongTin.Text = "Thông tin chuyến đi";
                lblMaChuyen.Text = "Mã chuyến:";
                lblTenChuyen.Text = "Tên chuyến:";
                lblDiaDiem.Text = "Địa điểm:";
                lblNgayDi.Text = "Ngày đi:";
                lblSoNguoi.Text = "Số người:";
                lblNganSach.Text = "Ngân sách:";
                lblPhuongTien.Text = "Phương tiện:";
                chkDaHoanThanh.Text = "Đã hoàn thành";
                lblGhiChu.Text = "Ghi chú:";
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Text = "Xóa";
                btnLamMoi.Text = "Làm mới";

                lblNgonNgu.Text = "Ngôn ngữ:";
                grpThoiTiet.Text = "Dự báo thời tiết";
                btnXemThoiTiet.Text = "Xem thời tiết";
                lblWeatherHeader.Text = "Chọn một chuyến đi để xem dự báo";

                txtTimKiem.PlaceholderText = "Tìm theo tên hoặc địa điểm...";
                chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";
                lblTuNgay.Text = "Từ:";
                lblDenNgay.Text = "Đến:";
                btnTimKiem.Text = "Tìm";
                btnBoLoc.Text = "Bỏ lọc";

                lblWarningText.Text = "⚠ Nên mang áo mưa hoặc cân nhắc dời lịch";
            }
        }

        private void LoadData()
        {
            try
            {
                using var db = new DaNgoaiDbContext();
                var query = db.ChuyenDis.AsNoTracking().AsQueryable();

                string keyword = txtTimKiem.Text.Trim();
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(c => c.TenChuyen.Contains(keyword) || c.DiaDiem.Contains(keyword));
                }

                if (chkChuaHoanThanh.Checked)
                {
                    query = query.Where(c => !c.DaHoanThanh);
                }

                DateTime fromDate = dtpTuNgay.Value.Date;
                DateTime toDate = dtpDenNgay.Value.Date;
                query = query.Where(c => c.NgayDi >= fromDate && c.NgayDi <= toDate);

                var list = query.OrderBy(c => c.NgayDi).ToList();
                var culture = LocalizationService.CurrentCulture;

                if (_isEnglish)
                {
                    dgvChuyenDi.DataSource = list.Select(c => new
                    {
                        ID = c.MaChuyen,
                        TripName = c.TenChuyen,
                        Destination = c.DiaDiem,
                        TravelDate = c.NgayDi.ToString("dd/MM/yyyy", culture),
                        People = c.SoNguoi,
                        Budget = c.NganSach.ToString("C0", culture),
                        Transport = c.PhuongTien,
                        Completed = c.DaHoanThanh,
                        Notes = c.GhiChu
                    }).ToList();
                }
                else
                {
                    dgvChuyenDi.DataSource = list.Select(c => new
                    {
                        Mã = c.MaChuyen,
                        TênChuyến = c.TenChuyen,
                        ĐịaĐiểm = c.DiaDiem,
                        NgàyĐi = c.NgayDi.ToString("dd/MM/yyyy", culture),
                        SốNgười = c.SoNguoi,
                        NgânSách = c.NganSach.ToString("N0", culture) + " đ",
                        PhươngTiện = c.PhuongTien,
                        HoànThành = c.DaHoanThanh,
                        GhiChú = c.GhiChu
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi nạp dữ liệu chuyến đi");
                MessageBox.Show(_isEnglish ? "Database error." : "Lỗi truy cập CSDL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChuyenDi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvChuyenDi.Rows.Count) return;

            var row = dgvChuyenDi.Rows[e.RowIndex];
            string idCol = _isEnglish ? "ID" : "Mã";
            string nameCol = _isEnglish ? "TripName" : "TênChuyến";
            string destCol = _isEnglish ? "Destination" : "ĐịaĐiểm";
            string dateCol = _isEnglish ? "TravelDate" : "NgàyĐi";
            string peopleCol = _isEnglish ? "People" : "SốNgười";
            string budgetCol = _isEnglish ? "Budget" : "NgânSách";
            string transportCol = _isEnglish ? "Transport" : "PhươngTiện";
            string doneCol = _isEnglish ? "Completed" : "HoànThành";
            string noteCol = _isEnglish ? "Notes" : "GhiChú";

            txtMaChuyen.Text = row.Cells[idCol].Value?.ToString();
            txtTenChuyen.Text = row.Cells[nameCol].Value?.ToString();
            txtDiaDiem.Text = row.Cells[destCol].Value?.ToString();

            if (DateTime.TryParseExact(row.Cells[dateCol].Value?.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
            {
                dtpNgayDi.Value = dt;
            }

            if (int.TryParse(row.Cells[peopleCol].Value?.ToString(), out int p)) nudSoNguoi.Value = Math.Max(1, p);

            string rawBudget = row.Cells[budgetCol].Value?.ToString()?.Replace(".", "").Replace(",", "").Replace("đ", "").Replace("$", "").Trim() ?? "0";
            if (decimal.TryParse(rawBudget, out decimal b)) nudNganSach.Value = Math.Min(nudNganSach.Maximum, b);

            cboPhuongTien.SelectedItem = row.Cells[transportCol].Value?.ToString();
            chkDaHoanThanh.Checked = Convert.ToBoolean(row.Cells[doneCol].Value);
            txtGhiChu.Text = row.Cells[noteCol].Value?.ToString();

            // Tự động xem thời tiết cho chuyến được chọn
            if (!string.IsNullOrWhiteSpace(txtDiaDiem.Text))
            {
                _ = FetchWeatherAsync(txtDiaDiem.Text.Trim(), dtpNgayDi.Value.Date);
            }
        }

        private async void btnXemThoiTiet_Click(object sender, EventArgs e)
        {
            string dest = txtDiaDiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(dest))
            {
                MessageBox.Show(_isEnglish ? "Please enter destination first!" : "Vui lòng nhập địa điểm cần xem!",
                    _isEnglish ? "Notice" : "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await FetchWeatherAsync(dest, dtpNgayDi.Value.Date);
        }

        private async Task FetchWeatherAsync(string destination, DateTime travelDate)
        {
            try
            {
                btnXemThoiTiet.Enabled = false;
                prgLoading.Visible = true;
                lblWeatherHeader.Text = _isEnglish
                    ? $"Forecast for {travelDate:dd/MM/yyyy} - {destination}"
                    : $"Dự báo thời tiết ngày {travelDate:dd/MM/yyyy} - {destination}";

                var result = await WeatherApiService.GetWeatherForecastAsync(destination, travelDate, _isEnglish);

                if (!result.HasData)
                {
                    lblWeatherIcon.Text = "❓";
                    lblWeatherDesc.Text = _isEnglish ? "No data" : "Không có dữ liệu";
                    lblTemperature.Text = result.Message;
                    lblRainProb.Text = "";
                    pnlWarning.Visible = false;
                    return;
                }

                lblWeatherIcon.Text = result.WeatherIcon;
                lblWeatherDesc.Text = result.WeatherDescription;
                lblTemperature.Text = _isEnglish
                    ? $"Temperature: {result.TempMin:F1}°C - {result.TempMax:F1}°C"
                    : $"Nhiệt độ: {result.TempMin:F1}°C - {result.TempMax:F1}°C";
                lblRainProb.Text = _isEnglish
                    ? $"Rain probability: {result.RainProbability}%"
                    : $"Khả năng mưa: {result.RainProbability}%";

                if (result.ShouldWarn)
                {
                    pnlWarning.Visible = true;
                    lblWarningText.Text = result.Advice;
                }
                else
                {
                    pnlWarning.Visible = false;
                }
            }
            finally
            {
                prgLoading.Visible = false;
                btnXemThoiTiet.Enabled = true;
            }
        }

        private bool ValidateInput(bool isCreating)
        {
            if (string.IsNullOrWhiteSpace(txtTenChuyen.Text))
            {
                MessageBox.Show(_isEnglish ? "Trip name cannot be empty!" : "Tên chuyến đi không được để trống!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChuyen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaDiem.Text))
            {
                MessageBox.Show(_isEnglish ? "Destination cannot be empty!" : "Địa điểm không được để trống!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return false;
            }

            if (isCreating && dtpNgayDi.Value.Date < DateTime.Today)
            {
                MessageBox.Show(_isEnglish ? "Travel date cannot be earlier than today!" : "Ngày đi không được nhỏ hơn ngày hôm nay khi thêm mới!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayDi.Focus();
                return false;
            }

            if (nudSoNguoi.Value < 1)
            {
                MessageBox.Show(_isEnglish ? "Number of people must be at least 1!" : "Số người phải từ 1 trở lên!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudSoNguoi.Focus();
                return false;
            }

            if (nudNganSach.Value < 0)
            {
                MessageBox.Show(_isEnglish ? "Budget cannot be negative!" : "Ngân sách không được âm!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudNganSach.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(true)) return;

            try
            {
                using var db = new DaNgoaiDbContext();
                var item = new ChuyenDi
                {
                    TenChuyen = txtTenChuyen.Text.Trim(),
                    DiaDiem = txtDiaDiem.Text.Trim(),
                    NgayDi = dtpNgayDi.Value.Date,
                    SoNguoi = (int)nudSoNguoi.Value,
                    NganSach = nudNganSach.Value,
                    PhuongTien = cboPhuongTien.SelectedItem?.ToString() ?? "Ô tô",
                    DaHoanThanh = chkDaHoanThanh.Checked,
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
                };

                db.ChuyenDis.Add(item);
                db.SaveChanges();

                Log.Information("Thêm chuyến đi thành công: MaChuyen = {MaChuyen}, Ten = {Ten}", item.MaChuyen, item.TenChuyen);
                MessageBox.Show(_isEnglish ? "Trip added successfully!" : "Thêm chuyến đi thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm chuyến đi");
                MessageBox.Show(_isEnglish ? "Failed to add trip!" : "Không thể thêm chuyến đi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaChuyen.Text, out int id))
            {
                MessageBox.Show(_isEnglish ? "Please select a trip to update!" : "Vui lòng chọn chuyến đi cần sửa!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(false)) return;

            try
            {
                using var db = new DaNgoaiDbContext();
                var item = db.ChuyenDis.Find(id);
                if (item == null) return;

                item.TenChuyen = txtTenChuyen.Text.Trim();
                item.DiaDiem = txtDiaDiem.Text.Trim();
                item.NgayDi = dtpNgayDi.Value.Date;
                item.SoNguoi = (int)nudSoNguoi.Value;
                item.NganSach = nudNganSach.Value;
                item.PhuongTien = cboPhuongTien.SelectedItem?.ToString() ?? "Ô tô";
                item.DaHoanThanh = chkDaHoanThanh.Checked;
                item.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                db.SaveChanges();

                Log.Information("Cập nhật chuyến đi thành công: MaChuyen = {MaChuyen}", id);
                MessageBox.Show(_isEnglish ? "Trip updated successfully!" : "Cập nhật chuyến đi thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi cập nhật chuyến đi MaChuyen = {Id}", id);
                MessageBox.Show(_isEnglish ? "Failed to update trip!" : "Không thể cập nhật chuyến đi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaChuyen.Text, out int id))
            {
                MessageBox.Show(_isEnglish ? "Please select a trip to delete!" : "Vui lòng chọn chuyến đi cần xóa!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(_isEnglish ? $"Are you sure to delete trip #{id}?" : $"Bạn có chắc muốn xóa chuyến đi #{id}?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new DaNgoaiDbContext();
                var item = db.ChuyenDis.Find(id);
                if (item != null)
                {
                    db.ChuyenDis.Remove(item);
                    db.SaveChanges();

                    Log.Information("Xóa chuyến đi thành công: MaChuyen = {MaChuyen}", id);
                    MessageBox.Show(_isEnglish ? "Trip deleted successfully!" : "Đã xóa chuyến đi thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa chuyến đi MaChuyen = {Id}", id);
                MessageBox.Show(_isEnglish ? "Failed to delete trip!" : "Không thể xóa chuyến đi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }

        private void ClearInputs()
        {
            txtMaChuyen.Clear();
            txtTenChuyen.Clear();
            txtDiaDiem.Clear();
            dtpNgayDi.Value = DateTime.Today.AddDays(3);
            nudSoNguoi.Value = 1;
            nudNganSach.Value = 0;
            cboPhuongTien.SelectedIndex = 1;
            chkDaHoanThanh.Checked = false;
            txtGhiChu.Clear();
            pnlWarning.Visible = false;
            lblWeatherIcon.Text = "⛅";
            lblWeatherDesc.Text = _isEnglish ? "Weather description" : "Mô tả thời tiết";
            lblTemperature.Text = "Nhiệt độ: --°C - --°C";
            lblRainProb.Text = "Khả năng mưa: --%";
            lblWeatherHeader.Text = _isEnglish ? "Select a trip to view forecast" : "Chọn một chuyến đi để xem dự báo";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            chkChuaHoanThanh.Checked = false;
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today.AddMonths(1);
            LoadData();
        }
    }
}
