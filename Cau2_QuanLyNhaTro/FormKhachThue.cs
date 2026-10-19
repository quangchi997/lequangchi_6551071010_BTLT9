using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cau2_QuanLyNhaTro.Models;
using Cau2_QuanLyNhaTro.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cau2_QuanLyNhaTro
{
    public partial class FormKhachThue : Form
    {
        private readonly CultureInfo _vnCulture = new CultureInfo("vi-VN");
        private List<ProvinceDto> _cachedProvinces = new();
        private bool _isLoadingAddress = false;

        public FormKhachThue()
        {
            InitializeComponent();
        }

        private async void FormKhachThue_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRooms();
                await LoadProvincesAsync();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi khởi động FormKhachThue");
                MessageBox.Show("Đã xảy ra lỗi khi khởi tạo dữ liệu ứng dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                using var db = new NhaTroDbContext();
                var rooms = db.PhongTros.AsNoTracking().OrderBy(p => p.TenPhong).ToList();

                cboPhong.DataSource = null;
                cboPhong.DisplayMember = "Display";
                cboPhong.ValueMember = "MaPhong";
                cboPhong.DataSource = rooms.Select(r => new
                {
                    r.MaPhong,
                    Display = $"{r.TenPhong} - {r.GiaThue.ToString("N0", _vnCulture)} đ ({r.TinhTrang})"
                }).ToList();

                // Lọc phòng cho tìm kiếm
                var filterRooms = new List<object> { new { MaPhong = 0, Display = "Tất cả" } };
                filterRooms.AddRange(rooms.Select(r => new { r.MaPhong, Display = r.TenPhong }));
                cboLocPhong.DisplayMember = "Display";
                cboLocPhong.ValueMember = "MaPhong";
                cboLocPhong.DataSource = filterRooms;
                cboLocPhong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi tải danh sách phòng trọ");
            }
        }

        private async Task LoadProvincesAsync()
        {
            try
            {
                _isLoadingAddress = true;
                cboTinhThanh.Enabled = false;
                lblStatus.Text = "Đang tải danh sách tỉnh/thành từ API...";

                var provinces = await ProvinceApiService.GetProvincesAsync();
                if (provinces != null && provinces.Count > 0)
                {
                    _cachedProvinces = provinces;
                    cboTinhThanh.DisplayMember = "Name";
                    cboTinhThanh.ValueMember = "Code";
                    cboTinhThanh.DataSource = provinces;

                    // Bộ lọc tỉnh
                    var filterProvinces = new List<ProvinceDto>
                    {
                        new ProvinceDto { Code = 0, Name = "Tất cả" }
                    };
                    filterProvinces.AddRange(provinces);
                    cboLocTinh.DisplayMember = "Name";
                    cboLocTinh.ValueMember = "Code";
                    cboLocTinh.DataSource = filterProvinces;
                    cboLocTinh.SelectedIndex = 0;

                    lblStatus.Text = $"Đã tải {provinces.Count} tỉnh/thành từ provinces.open-api.vn";
                }
                else
                {
                    lblStatus.Text = "Không thể tải API tỉnh/thành. Chuyển sang chế độ nhập tay.";
                    MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng. Bạn có thể tự gõ tên Tỉnh/Phường bên dưới.", "Cảnh báo mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                cboTinhThanh.Enabled = true;
                _isLoadingAddress = false;
            }
        }

        private async void cboTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingAddress || cboTinhThanh.SelectedValue == null) return;

            if (cboTinhThanh.SelectedValue is int provinceCode && provinceCode > 0)
            {
                try
                {
                    cboPhuongXa.Enabled = false;
                    cboPhuongXa.DataSource = null;
                    lblStatus.Text = "Đang tải danh sách phường/xã...";

                    var wards = await ProvinceApiService.GetWardsAsync(provinceCode);
                    if (wards != null && wards.Count > 0)
                    {
                        cboPhuongXa.DisplayMember = "Name";
                        cboPhuongXa.ValueMember = "Code";
                        cboPhuongXa.DataSource = wards;
                        lblStatus.Text = $"Đã tải {wards.Count} phường/xã.";
                    }
                    else
                    {
                        lblStatus.Text = "Không tải được phường/xã. Cho phép gõ tay.";
                    }
                }
                finally
                {
                    cboPhuongXa.Enabled = true;
                }
            }
        }

        private void LoadData()
        {
            try
            {
                using var db = new NhaTroDbContext();
                var query = db.KhachThues.Include(k => k.PhongTro).AsNoTracking().AsQueryable();

                // Tìm theo tên hoặc SĐT
                string keyword = txtTimTuKhoa.Text.Trim();
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(k => k.HoTen.Contains(keyword) || k.SoDienThoai.Contains(keyword));
                }

                // Lọc theo phòng
                if (cboLocPhong.SelectedValue is int maPhong && maPhong > 0)
                {
                    query = query.Where(k => k.MaPhong == maPhong);
                }

                // Lọc theo tỉnh
                if (cboLocTinh.SelectedValue is int maTinh && maTinh > 0)
                {
                    query = query.Where(k => k.MaTinh == maTinh);
                }

                var list = query.OrderByDescending(k => k.MaKhach).ToList();

                dgvKhachThue.DataSource = list.Select(k => new
                {
                    Mã = k.MaKhach,
                    HọTên = k.HoTen,
                    GiớiTính = k.GioiTinh,
                    NgàySinh = k.NgaySinh.ToString("dd/MM/yyyy"),
                    SĐT = k.SoDienThoai,
                    Phòng = k.PhongTro?.TenPhong ?? "",
                    GiáThuê = (k.PhongTro?.GiaThue ?? 0).ToString("N0", _vnCulture) + " đ",
                    QuêQuán = $"{k.TenPhuongXa} - {k.TenTinh}",
                    TạmTrú = k.DaDangKyTamTru,
                    MaPhongRaw = k.MaPhong,
                    MaTinhRaw = k.MaTinh,
                    MaPhuongXaRaw = k.MaPhuongXa,
                    TenTinhRaw = k.TenTinh,
                    TenPhuongXaRaw = k.TenPhuongXa
                }).ToList();

                // Định dạng hiển thị DataGridView
                if (dgvKhachThue.Columns.Contains("MaPhongRaw") && dgvKhachThue.Columns["MaPhongRaw"] is DataGridViewColumn col1) col1.Visible = false;
                if (dgvKhachThue.Columns.Contains("MaTinhRaw") && dgvKhachThue.Columns["MaTinhRaw"] is DataGridViewColumn col2) col2.Visible = false;
                if (dgvKhachThue.Columns.Contains("MaPhuongXaRaw") && dgvKhachThue.Columns["MaPhuongXaRaw"] is DataGridViewColumn col3) col3.Visible = false;
                if (dgvKhachThue.Columns.Contains("TenTinhRaw") && dgvKhachThue.Columns["TenTinhRaw"] is DataGridViewColumn col4) col4.Visible = false;
                if (dgvKhachThue.Columns.Contains("TenPhuongXaRaw") && dgvKhachThue.Columns["TenPhuongXaRaw"] is DataGridViewColumn col5) col5.Visible = false;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi nạp dữ liệu khách thuê");
                MessageBox.Show("Không thể tải dữ liệu từ CSDL. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKhachThue.Rows.Count) return;

            var row = dgvKhachThue.Rows[e.RowIndex];
            txtMaKhach.Text = row.Cells["Mã"].Value?.ToString();
            txtHoTen.Text = row.Cells["HọTên"].Value?.ToString();

            string gt = row.Cells["GiớiTính"].Value?.ToString() ?? "Nam";
            radNam.Checked = (gt == "Nam");
            radNu.Checked = (gt == "Nữ");

            if (DateTime.TryParseExact(row.Cells["NgàySinh"].Value?.ToString(), "dd/MM/yyyy", _vnCulture, DateTimeStyles.None, out var ns))
            {
                dtpNgaySinh.Value = ns;
            }

            txtSoDienThoai.Text = row.Cells["SĐT"].Value?.ToString();

            if (int.TryParse(row.Cells["MaPhongRaw"].Value?.ToString(), out int maPhong))
            {
                cboPhong.SelectedValue = maPhong;
            }

            if (int.TryParse(row.Cells["MaTinhRaw"].Value?.ToString(), out int maTinh))
            {
                cboTinhThanh.SelectedValue = maTinh;
            }

            txtPhuongXaThuCong.Text = row.Cells["TenPhuongXaRaw"].Value?.ToString();
            chkTamTru.Checked = Convert.ToBoolean(row.Cells["TạmTrú"].Value);
        }

        private bool ValidateInput(out int maTinh, out string tenTinh, out int maPhuongXa, out string tenPhuongXa)
        {
            maTinh = 0;
            tenTinh = "";
            maPhuongXa = 0;
            tenPhuongXa = "";

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }

            if (cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trọ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhong.Focus();
                return false;
            }

            // Xử lý Tỉnh / Thành
            if (cboTinhThanh.SelectedItem is ProvinceDto selectedProvince)
            {
                maTinh = selectedProvince.Code;
                tenTinh = selectedProvince.Name;
            }
            else
            {
                tenTinh = cboTinhThanh.Text.Trim();
                if (string.IsNullOrEmpty(tenTinh))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập Tỉnh/Thành!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Xử lý Phường / Xã
            if (cboPhuongXa.SelectedItem is WardDto selectedWard)
            {
                maPhuongXa = selectedWard.Code;
                tenPhuongXa = selectedWard.Name;
            }
            else if (!string.IsNullOrWhiteSpace(txtPhuongXaThuCong.Text))
            {
                tenPhuongXa = txtPhuongXaThuCong.Text.Trim();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Phường/Xã từ danh sách hoặc nhập tay vào ô bên dưới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out int maTinh, out string tenTinh, out int maPhuongXa, out string tenPhuongXa)) return;

            try
            {
                using var db = new NhaTroDbContext();
                int maPhong = Convert.ToInt32(cboPhong.SelectedValue);

                var khach = new KhachThue
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = radNam.Checked ? "Nam" : "Nữ",
                    NgaySinh = dtpNgaySinh.Value.Date,
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    MaPhong = maPhong,
                    MaTinh = maTinh,
                    TenTinh = tenTinh,
                    MaPhuongXa = maPhuongXa,
                    TenPhuongXa = tenPhuongXa,
                    DaDangKyTamTru = chkTamTru.Checked
                };

                db.KhachThues.Add(khach);

                // Cập nhật trạng thái phòng sang "Đang thuê"
                var phong = db.PhongTros.Find(maPhong);
                if (phong != null)
                {
                    phong.TinhTrang = "Đang thuê";
                }

                db.SaveChanges();

                Log.Information("Thêm khách thuê thành công: MaKhach = {MaKhach}, HoTen = {HoTen}, Phong = {Phong}",
                    khach.MaKhach, khach.HoTen, phong?.TenPhong);

                MessageBox.Show("Thêm khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadRooms();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm khách thuê vào CSDL");
                MessageBox.Show("Đã xảy ra lỗi khi thêm khách thuê. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKhach.Text, out int maKhach))
            {
                MessageBox.Show("Vui lòng chọn khách thuê từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(out int maTinh, out string tenTinh, out int maPhuongXa, out string tenPhuongXa)) return;

            try
            {
                using var db = new NhaTroDbContext();
                var khach = db.KhachThues.Find(maKhach);
                if (khach == null)
                {
                    MessageBox.Show("Không tìm thấy khách thuê cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int oldRoomId = khach.MaPhong;
                int newRoomId = Convert.ToInt32(cboPhong.SelectedValue);

                khach.HoTen = txtHoTen.Text.Trim();
                khach.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
                khach.NgaySinh = dtpNgaySinh.Value.Date;
                khach.SoDienThoai = txtSoDienThoai.Text.Trim();
                khach.MaPhong = newRoomId;
                khach.MaTinh = maTinh;
                khach.TenTinh = tenTinh;
                khach.MaPhuongXa = maPhuongXa;
                khach.TenPhuongXa = tenPhuongXa;
                khach.DaDangKyTamTru = chkTamTru.Checked;

                // Nếu chuyển phòng: cập nhật trạng thái phòng cũ và mới
                if (oldRoomId != newRoomId)
                {
                    var newRoom = db.PhongTros.Find(newRoomId);
                    if (newRoom != null) newRoom.TinhTrang = "Đang thuê";

                    int countRemaining = db.KhachThues.Count(k => k.MaPhong == oldRoomId && k.MaKhach != maKhach);
                    if (countRemaining == 0)
                    {
                        var oldRoom = db.PhongTros.Find(oldRoomId);
                        if (oldRoom != null) oldRoom.TinhTrang = "Trống";
                    }
                }

                db.SaveChanges();

                Log.Information("Cập nhật thông tin khách thuê thành công: MaKhach = {MaKhach}, HoTen = {HoTen}",
                    khach.MaKhach, khach.HoTen);

                MessageBox.Show("Cập nhật thông tin khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadRooms();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi cập nhật khách thuê MaKhach = {MaKhach}", maKhach);
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin khách thuê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKhach.Text, out int maKhach))
            {
                MessageBox.Show("Vui lòng chọn khách thuê từ danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialog = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách thuê mã #{maKhach}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog != DialogResult.Yes) return;

            try
            {
                using var db = new NhaTroDbContext();
                var khach = db.KhachThues.Find(maKhach);
                if (khach != null)
                {
                    int roomId = khach.MaPhong;
                    db.KhachThues.Remove(khach);

                    // Kiểm tra xem phòng còn khách nào khác không
                    int remaining = db.KhachThues.Count(k => k.MaPhong == roomId && k.MaKhach != maKhach);
                    if (remaining == 0)
                    {
                        var phong = db.PhongTros.Find(roomId);
                        if (phong != null)
                        {
                            phong.TinhTrang = "Trống";
                        }
                    }

                    db.SaveChanges();

                    Log.Information("Xóa khách thuê thành công: MaKhach = {MaKhach}, PhongId = {PhongId}", maKhach, roomId);
                    MessageBox.Show("Đã xóa khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadRooms();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa khách thuê MaKhach = {MaKhach}", maKhach);
                MessageBox.Show("Đã xảy ra lỗi khi xóa khách thuê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadRooms();
            LoadData();
        }

        private void ClearInputs()
        {
            txtMaKhach.Clear();
            txtHoTen.Clear();
            radNam.Checked = true;
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            txtSoDienThoai.Clear();
            txtPhuongXaThuCong.Clear();
            chkTamTru.Checked = false;
            if (cboPhong.Items.Count > 0) cboPhong.SelectedIndex = 0;
            if (cboTinhThanh.Items.Count > 0) cboTinhThanh.SelectedIndex = 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimTuKhoa.Clear();
            cboLocPhong.SelectedIndex = 0;
            cboLocTinh.SelectedIndex = 0;
            LoadData();
        }

        private void btnGayLoi_Click(object sender, EventArgs e)
        {
            // Thử nghiệm xử lý lỗi toàn cục theo yêu cầu Task 7
            throw new InvalidOperationException("Đây là ngoại lệ thử nghiệm để kiểm tra tính năng xử lý lỗi toàn cục (Global Exception Handling)!");
        }
    }
}
