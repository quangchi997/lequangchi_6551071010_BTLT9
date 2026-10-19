using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cau4_QuanLyTraSua.Configuration;
using Cau4_QuanLyTraSua.Models;
using Cau4_QuanLyTraSua.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cau4_QuanLyTraSua
{
    public partial class FormBanHang : Form
    {
        private readonly CultureInfo _vnCulture = new CultureInfo("vi-VN");
        private readonly BindingList<CartItemModel> _cart = new();
        private int _currentOrderNumber = 0;

        public class CartItemModel
        {
            public int MaMon { get; set; }
            public string TenMon { get; set; } = string.Empty;
            public int SoLy { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien => SoLy * DonGia;
        }

        public FormBanHang()
        {
            InitializeComponent();
        }

        private void FormBanHang_Load(object sender, EventArgs e)
        {
            try
            {
                SetupCartGrid();
                LoadCategories();
                LoadThucDon();
                LoadInvoices();
                UpdateBankInfoDisplay();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi khởi chạy FormBanHang");
                MessageBox.Show("Đã xảy ra lỗi khởi động ứng dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupCartGrid()
        {
            dgvGioHang.AutoGenerateColumns = false;
            dgvGioHang.Columns.Clear();

            dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenMon",
                HeaderText = "Tên món",
                Width = 180,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLy",
                HeaderText = "SL",
                Width = 50
            });
            dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGia",
                HeaderText = "Đơn giá",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành tiền",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvGioHang.DataSource = _cart;
        }

        private void UpdateBankInfoDisplay()
        {
            var config = ConfigHelper.GetPaymentConfig();
            lblNganHangInfo.Text = $"{config.ShopName}\nNgân hàng: {config.BankId} - STK: {config.AccountNo}\nChủ TK: {config.AccountName}";
        }

        #region TAB 1: BÁN HÀNG & VIETQR

        private void LoadCategories()
        {
            try
            {
                using var db = new TraSuaDbContext();
                var categories = db.DanhMucMons.AsNoTracking().OrderBy(d => d.MaDM).ToList();

                cboDanhMucBanHang.DataSource = null;
                cboDanhMucBanHang.DisplayMember = "TenDM";
                cboDanhMucBanHang.ValueMember = "MaDM";
                cboDanhMucBanHang.DataSource = categories;

                // Load danh mục cho tab thực đơn
                cboDMMon.DataSource = null;
                cboDMMon.DisplayMember = "TenDM";
                cboDMMon.ValueMember = "MaDM";
                cboDMMon.DataSource = categories.ToList();

                // Load bộ lọc danh mục cho tab thực đơn
                var filterCats = new List<DanhMucMon> { new DanhMucMon { MaDM = 0, TenDM = "Tất cả danh mục" } };
                filterCats.AddRange(categories);
                cboLocDMMon.DisplayMember = "TenDM";
                cboLocDMMon.ValueMember = "MaDM";
                cboLocDMMon.DataSource = filterCats;
                cboLocDMMon.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi nạp danh mục");
            }
        }

        private void cboDanhMucBanHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMucBanHang.SelectedValue is int maDM && maDM > 0)
            {
                try
                {
                    using var db = new TraSuaDbContext();
                    var list = db.MonUongs
                        .AsNoTracking()
                        .Where(m => m.MaDM == maDM && m.DangBan)
                        .OrderBy(m => m.TenMon)
                        .ToList();

                    lstMonUong.DataSource = null;
                    lstMonUong.DisplayMember = "Display";
                    lstMonUong.ValueMember = "MaMon";
                    lstMonUong.DataSource = list.Select(m => new
                    {
                        m.MaMon,
                        m.TenMon,
                        m.GiaBan,
                        Display = $"{m.TenMon} - {m.GiaBan.ToString("N0", _vnCulture)}"
                    }).ToList();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Lỗi khi tải món theo danh mục");
                }
            }
        }

        private void btnThemVaoDon_Click(object sender, EventArgs e)
        {
            if (lstMonUong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một món uống từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dynamic selected = lstMonUong.SelectedItem;
            int maMon = selected.MaMon;
            string tenMon = selected.TenMon;
            decimal giaBan = selected.GiaBan;
            int soLy = (int)nudSoLy.Value;

            var existing = _cart.FirstOrDefault(c => c.MaMon == maMon);
            if (existing != null)
            {
                existing.SoLy += soLy;
                _cart.ResetBindings();
            }
            else
            {
                _cart.Add(new CartItemModel
                {
                    MaMon = maMon,
                    TenMon = tenMon,
                    SoLy = soLy,
                    DonGia = giaBan
                });
            }

            UpdateCartTotal();
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null && dgvGioHang.CurrentRow.DataBoundItem is CartItemModel item)
            {
                _cart.Remove(item);
                UpdateCartTotal();
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            _cart.Clear();
            UpdateCartTotal();
            ResetPaymentDisplay();
        }

        private void UpdateCartTotal()
        {
            decimal total = _cart.Sum(x => x.ThanhTien);
            lblTongTien.Text = $"Tổng tiền: {total.ToString("N0", _vnCulture)} đ";
        }

        private void ResetPaymentDisplay()
        {
            picVietQR.Image?.Dispose();
            picVietQR.Image = null;
            lblSoTienQR.Text = "Số tiền: 0 đ";
            lblNoiDungQR.Text = "Nội dung: TRASUA";
            _currentOrderNumber = 0;
        }

        private async void btnThanhToanCK_Click(object sender, EventArgs e)
        {
            decimal total = _cart.Sum(x => x.ThanhTien);
            if (total <= 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng thêm món trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnThanhToanCK.Enabled = false;
            try
            {
                using var db = new TraSuaDbContext();
                int maxId = db.HoaDons.Max(h => (int?)h.MaHD) ?? 1000;
                _currentOrderNumber = maxId + 1;

                string addInfo = $"TRASUA HD{_currentOrderNumber}";
                lblSoTienQR.Text = $"Số tiền: {total.ToString("N0", _vnCulture)} đ";
                lblNoiDungQR.Text = $"Nội dung: {addInfo}";

                picVietQR.Image?.Dispose();
                picVietQR.Image = null;

                var qrImage = await VietQRService.GenerateVietQRImageAsync(_currentOrderNumber, total);
                if (qrImage != null)
                {
                    picVietQR.Image = qrImage;
                }
                else
                {
                    MessageBox.Show("Không thể tải mã VietQR trực tuyến. Quý khách vui lòng chuyển khoản theo thông tin số tài khoản và nội dung hiển thị bên dưới, hoặc chọn thanh toán tiền mặt.",
                        "Thông báo mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                btnThanhToanCK.Enabled = true;
            }
        }

        private void btnTienMat_Click(object sender, EventArgs e)
        {
            decimal total = _cart.Sum(x => x.ThanhTien);
            if (total <= 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Xác nhận thanh toán TIỀN MẶT số tiền {total.ToString("N0", _vnCulture)} đ?",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            SaveOrder("Tiền mặt", total);
        }

        private void btnDaNhanTien_Click(object sender, EventArgs e)
        {
            decimal total = _cart.Sum(x => x.ThanhTien);
            if (total <= 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn đã kiểm tra tin nhắn/biến động số dư và xác nhận ĐÃ NHẬN ĐỦ {total.ToString("N0", _vnCulture)} đ?",
                "Xác nhận chuyển khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            SaveOrder("Chuyển khoản", total);
        }

        private void SaveOrder(string hinhThuc, decimal total)
        {
            try
            {
                using var db = new TraSuaDbContext();
                var hoaDon = new HoaDon
                {
                    NgayLap = DateTime.Now,
                    TongTien = total,
                    HinhThucTT = hinhThuc,
                    DaThanhToan = true
                };

                foreach (var item in _cart)
                {
                    hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon
                    {
                        MaMon = item.MaMon,
                        SoLy = item.SoLy,
                        DonGia = item.DonGia
                    });
                }

                db.HoaDons.Add(hoaDon);
                db.SaveChanges(); // Lưu cả HoaDon và ChiTietHoaDon trong 1 lần SaveChanges

                Log.Information("Lập hóa đơn thành công: MaHD = {MaHD}, Tổng tiền = {TongTien}, Hình thức = {HinhThuc}",
                    hoaDon.MaHD, hoaDon.TongTien, hoaDon.HinhThucTT);

                MessageBox.Show($"Thanh toán thành công hóa đơn #{hoaDon.MaHD}!\nTổng tiền: {total.ToString("N0", _vnCulture)} đ ({hinhThuc})",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _cart.Clear();
                UpdateCartTotal();
                ResetPaymentDisplay();
                LoadInvoices();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi lưu hóa đơn vào CSDL");
                MessageBox.Show("Đã xảy ra lỗi khi lưu hóa đơn vào CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region TAB 2: QUẢN LÝ THỰC ĐƠN

        private void LoadThucDon()
        {
            try
            {
                using var db = new TraSuaDbContext();
                var query = db.MonUongs.Include(m => m.DanhMucMon).AsNoTracking().AsQueryable();

                string keyword = txtTimTenMon.Text.Trim();
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(m => m.TenMon.Contains(keyword));
                }

                if (cboLocDMMon.SelectedValue is int maDM && maDM > 0)
                {
                    query = query.Where(m => m.MaDM == maDM);
                }

                var list = query.OrderBy(m => m.MaDM).ThenBy(m => m.TenMon).ToList();

                dgvThucDon.DataSource = list.Select(m => new
                {
                    Mã = m.MaMon,
                    TênMón = m.TenMon,
                    DanhMục = m.DanhMucMon.TenDM,
                    GiáBán = m.GiaBan.ToString("N0", _vnCulture) + " đ",
                    ĐangBán = m.DangBan,
                    MaDMRaw = m.MaDM,
                    GiaBanRaw = m.GiaBan
                }).ToList();

                if (dgvThucDon.Columns.Contains("MaDMRaw") && dgvThucDon.Columns["MaDMRaw"] is DataGridViewColumn c1) c1.Visible = false;
                if (dgvThucDon.Columns.Contains("GiaBanRaw") && dgvThucDon.Columns["GiaBanRaw"] is DataGridViewColumn c2) c2.Visible = false;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi nạp thực đơn");
            }
        }

        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvThucDon.Rows.Count) return;

            var row = dgvThucDon.Rows[e.RowIndex];
            txtMaMon.Text = row.Cells["Mã"].Value?.ToString();
            txtTenMon.Text = row.Cells["TênMón"].Value?.ToString();

            if (int.TryParse(row.Cells["MaDMRaw"].Value?.ToString(), out int dm))
            {
                cboDMMon.SelectedValue = dm;
            }

            if (decimal.TryParse(row.Cells["GiaBanRaw"].Value?.ToString(), out decimal gia))
            {
                nudGiaBan.Value = Math.Min(nudGiaBan.Maximum, gia);
            }

            chkDangBan.Checked = Convert.ToBoolean(row.Cells["ĐangBán"].Value);
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Tên món không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDMMon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục món!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new TraSuaDbContext();
                var mon = new MonUong
                {
                    TenMon = txtTenMon.Text.Trim(),
                    MaDM = Convert.ToInt32(cboDMMon.SelectedValue),
                    GiaBan = nudGiaBan.Value,
                    DangBan = chkDangBan.Checked
                };

                db.MonUongs.Add(mon);
                db.SaveChanges();

                Log.Information("Thêm món thành công: MaMon = {MaMon}, Ten = {Ten}", mon.MaMon, mon.TenMon);
                MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearThucDonInputs();
                LoadThucDon();
                cboDanhMucBanHang_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm món mới");
            }
        }

        private void btnSuaMon_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaMon.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn món cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using var db = new TraSuaDbContext();
                var mon = db.MonUongs.Find(id);
                if (mon == null) return;

                mon.TenMon = txtTenMon.Text.Trim();
                mon.MaDM = Convert.ToInt32(cboDMMon.SelectedValue);
                mon.GiaBan = nudGiaBan.Value;
                mon.DangBan = chkDangBan.Checked;

                db.SaveChanges();

                Log.Information("Sửa món thành công: MaMon = {MaMon}", id);
                MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearThucDonInputs();
                LoadThucDon();
                cboDanhMucBanHang_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi sửa món");
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaMon.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa món #{id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new TraSuaDbContext();
                var mon = db.MonUongs.Find(id);
                if (mon != null)
                {
                    db.MonUongs.Remove(mon);
                    db.SaveChanges();
                    Log.Information("Xóa món thành công: MaMon = {MaMon}", id);
                    MessageBox.Show("Đã xóa món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearThucDonInputs();
                    LoadThucDon();
                    cboDanhMucBanHang_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa món MaMon = {Id}", id);
                MessageBox.Show("Không thể xóa món này do đã có trong lịch sử hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoiMon_Click(object sender, EventArgs e)
        {
            ClearThucDonInputs();
            LoadThucDon();
        }

        private void ClearThucDonInputs()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            nudGiaBan.Value = 0;
            chkDangBan.Checked = true;
            if (cboDMMon.Items.Count > 0) cboDMMon.SelectedIndex = 0;
        }

        private void btnTimMon_Click(object sender, EventArgs e) => LoadThucDon();

        private void btnBoLocMon_Click(object sender, EventArgs e)
        {
            txtTimTenMon.Clear();
            cboLocDMMon.SelectedIndex = 0;
            LoadThucDon();
        }

        #endregion

        #region TAB 3: HÓA ĐƠN & DOANH THU

        private void LoadInvoices()
        {
            try
            {
                using var db = new TraSuaDbContext();
                DateTime filterDate = dtpNgayHD.Value.Date;

                var list = db.HoaDons
                    .AsNoTracking()
                    .Where(h => h.NgayLap.Date == filterDate)
                    .OrderByDescending(h => h.NgayLap)
                    .ToList();

                dgvHoaDon.DataSource = list.Select(h => new
                {
                    MãHD = h.MaHD,
                    GiờLập = h.NgayLap.ToString("HH:mm:ss"),
                    HìnhThức = h.HinhThucTT,
                    TổngTiền = h.TongTien.ToString("N0", _vnCulture) + " đ",
                    TongTienRaw = h.TongTien
                }).ToList();

                if (dgvHoaDon.Columns.Contains("TongTienRaw") && dgvHoaDon.Columns["TongTienRaw"] is DataGridViewColumn c3) c3.Visible = false;

                decimal revenue = list.Sum(h => h.TongTien);
                lblDoanhThuNgay.Text = $"Doanh thu ngày {filterDate:dd/MM/yyyy}: {revenue.ToString("N0", _vnCulture)} đ";

                dgvChiTietHD.DataSource = null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi nạp danh sách hóa đơn");
            }
        }

        private void btnLocHD_Click(object sender, EventArgs e) => LoadInvoices();

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvHoaDon.Rows.Count) return;

            var row = dgvHoaDon.Rows[e.RowIndex];
            if (int.TryParse(row.Cells["MãHD"].Value?.ToString(), out int maHD))
            {
                try
                {
                    using var db = new TraSuaDbContext();
                    var details = db.ChiTietHoaDons
                        .Include(c => c.MonUong)
                        .AsNoTracking()
                        .Where(c => c.MaHD == maHD)
                        .ToList();

                    dgvChiTietHD.DataSource = details.Select(d => new
                    {
                        TênMón = d.MonUong?.TenMon ?? "",
                        SốLy = d.SoLy,
                        ĐơnGiá = d.DonGia.ToString("N0", _vnCulture) + " đ",
                        ThànhTiền = (d.SoLy * d.DonGia).ToString("N0", _vnCulture) + " đ"
                    }).ToList();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Lỗi khi nạp chi tiết hóa đơn MaHD = {MaHD}", maHD);
                }
            }
        }

        #endregion

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabThucDon) LoadThucDon();
            else if (tabControlMain.SelectedTab == tabHoaDon) LoadInvoices();
        }
    }
}
