using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Cau1_SoChiTieu.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cau1_SoChiTieu
{
    public partial class FormChiTieu : Form
    {
        private readonly CultureInfo _vnCulture = new CultureInfo("vi-VN");

        public FormChiTieu()
        {
            InitializeComponent();
        }

        private void FormChiTieu_Load(object sender, EventArgs e)
        {
            try
            {
                cboLoaiChi.SelectedIndex = 0;
                cboLocLoaiChi.SelectedIndex = 0;

                // Cấu hình phông chữ Segoe UI chuẩn tiếng Việt cho DataGridView
                dgvChiTieu.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                dgvChiTieu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                // Mặc định khoảng ngày tìm kiếm: từ đầu tháng hiện tại đến hôm nay
                DateTime now = DateTime.Today;
                dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
                dtpDenNgay.Value = now;
                dtpNgayChi.Value = now;

                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi khởi tạo FormChiTieu");
                MessageBox.Show("Đã xảy ra lỗi khi khởi tạo dữ liệu. Vui lòng kiểm tra kết nối CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                using var db = new ChiTieuDbContext();
                var query = db.ChiTieus.AsNoTracking().AsQueryable();

                // Lọc theo nội dung
                string searchKeyword = txtTimNoiDung.Text.Trim();
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(x => x.NoiDung.Contains(searchKeyword));
                }

                // Lọc theo loại chi
                if (cboLocLoaiChi.SelectedIndex > 0)
                {
                    string selectedLoai = cboLocLoaiChi.SelectedItem?.ToString() ?? "";
                    query = query.Where(x => x.LoaiChi == selectedLoai);
                }

                // Lọc theo khoảng ngày
                DateTime fromDate = dtpTuNgay.Value.Date;
                DateTime toDate = dtpDenNgay.Value.Date;
                query = query.Where(x => x.NgayChi >= fromDate && x.NgayChi <= toDate);

                var list = query.OrderByDescending(x => x.NgayChi)
                                .ThenByDescending(x => x.MaCT)
                                .ToList();

                dgvChiTieu.DataSource = list.Select(x => new
                {
                    Mã = x.MaCT,
                    NgàyChi = x.NgayChi.ToString("dd/MM/yyyy"),
                    NộiDung = x.NoiDung,
                    LoạiChi = x.LoaiChi,
                    SốTiền = x.SoTien.ToString("N0", _vnCulture),
                    GhiChú = x.GhiChu
                }).ToList();

                if (dgvChiTieu.Columns.Contains("Mã") && dgvChiTieu.Columns["Mã"] is DataGridViewColumn colM) colM.HeaderText = "Mã";
                if (dgvChiTieu.Columns.Contains("NgàyChi") && dgvChiTieu.Columns["NgàyChi"] is DataGridViewColumn colN) colN.HeaderText = "Ngày chi";
                if (dgvChiTieu.Columns.Contains("NộiDung") && dgvChiTieu.Columns["NộiDung"] is DataGridViewColumn colND) colND.HeaderText = "Nội dung";
                if (dgvChiTieu.Columns.Contains("LoạiChi") && dgvChiTieu.Columns["LoạiChi"] is DataGridViewColumn colL) colL.HeaderText = "Loại chi";
                if (dgvChiTieu.Columns.Contains("SốTiền") && dgvChiTieu.Columns["SốTiền"] is DataGridViewColumn colT) colT.HeaderText = "Số tiền";
                if (dgvChiTieu.Columns.Contains("GhiChú") && dgvChiTieu.Columns["GhiChú"] is DataGridViewColumn colG) colG.HeaderText = "Ghi chú";

                // Cập nhật nhãn tổng chi theo kết quả hiển thị
                decimal total = list.Sum(x => x.SoTien);
                lblTongChi.Text = $"Tổng chi: {total.ToString("N0", _vnCulture)} đ";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi tải danh sách chi tiêu từ CSDL");
                MessageBox.Show("Không thể tải danh sách chi tiêu từ CSDL. Vui lòng kiểm tra kết nối!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvChiTieu.Rows.Count) return;

            var row = dgvChiTieu.Rows[e.RowIndex];
            txtMaCT.Text = row.Cells["Mã"].Value?.ToString();

            if (DateTime.TryParseExact(row.Cells["NgàyChi"].Value?.ToString(), "dd/MM/yyyy", _vnCulture, DateTimeStyles.None, out var ngayChi))
            {
                dtpNgayChi.Value = ngayChi;
            }

            txtNoiDung.Text = row.Cells["NộiDung"].Value?.ToString();
            cboLoaiChi.SelectedItem = row.Cells["LoạiChi"].Value?.ToString();

            string rawSoTien = row.Cells["SốTiền"].Value?.ToString()?.Replace(".", "").Replace(",", "") ?? "0";
            if (decimal.TryParse(rawSoTien, out var soTien))
            {
                nudSoTien.Value = Math.Min(nudSoTien.Maximum, Math.Max(nudSoTien.Minimum, soTien));
            }

            txtGhiChu.Text = row.Cells["GhiChú"].Value?.ToString();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Nội dung chi tiêu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return false;
            }

            if (nudSoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền chi tiêu phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudSoTien.Focus();
                return false;
            }

            if (dtpNgayChi.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày chi không được lớn hơn ngày hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayChi.Focus();
                return false;
            }

            if (cboLoaiChi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại chi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiChi.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using var db = new ChiTieuDbContext();
                var item = new ChiTieu
                {
                    NgayChi = dtpNgayChi.Value.Date,
                    NoiDung = txtNoiDung.Text.Trim(),
                    LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác",
                    SoTien = nudSoTien.Value,
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
                };

                db.ChiTieus.Add(item);
                db.SaveChanges();

                Log.Information("Thêm khoản chi thành công: MaCT = {MaCT}, Nội dung = {NoiDung}, Số tiền = {SoTien}",
                    item.MaCT, item.NoiDung, item.SoTien);

                MessageBox.Show("Thêm khoản chi tiêu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm khoản chi vào CSDL");
                MessageBox.Show("Đã xảy ra lỗi khi thêm khoản chi. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaCT.Text, out int maCT))
            {
                MessageBox.Show("Vui lòng chọn một khoản chi từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using var db = new ChiTieuDbContext();
                var item = db.ChiTieus.Find(maCT);
                if (item == null)
                {
                    MessageBox.Show("Không tìm thấy khoản chi cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                item.NgayChi = dtpNgayChi.Value.Date;
                item.NoiDung = txtNoiDung.Text.Trim();
                item.LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác";
                item.SoTien = nudSoTien.Value;
                item.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                db.SaveChanges();

                Log.Information("Sửa khoản chi thành công: MaCT = {MaCT}, Nội dung = {NoiDung}, Số tiền = {SoTien}",
                    item.MaCT, item.NoiDung, item.SoTien);

                MessageBox.Show("Cập nhật khoản chi tiêu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi sửa khoản chi MaCT = {MaCT}", maCT);
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật khoản chi. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaCT.Text, out int maCT))
            {
                MessageBox.Show("Vui lòng chọn một khoản chi từ danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialog = MessageBox.Show($"Bạn có chắc chắn muốn xóa khoản chi mã #{maCT}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog != DialogResult.Yes) return;

            try
            {
                using var db = new ChiTieuDbContext();
                var item = db.ChiTieus.Find(maCT);
                if (item != null)
                {
                    db.ChiTieus.Remove(item);
                    db.SaveChanges();

                    Log.Information("Xóa khoản chi thành công: MaCT = {MaCT}", maCT);
                    MessageBox.Show("Đã xóa khoản chi tiêu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Khoản chi không còn tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa khoản chi MaCT = {MaCT}", maCT);
                MessageBox.Show("Đã xảy ra lỗi khi xóa khoản chi. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }

        private void ClearInputs()
        {
            txtMaCT.Clear();
            txtNoiDung.Clear();
            dtpNgayChi.Value = DateTime.Today;
            cboLoaiChi.SelectedIndex = 0;
            nudSoTien.Value = 0;
            txtGhiChu.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimNoiDung.Clear();
            cboLocLoaiChi.SelectedIndex = 0;
            DateTime now = DateTime.Today;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;
            LoadData();
        }
    }
}
