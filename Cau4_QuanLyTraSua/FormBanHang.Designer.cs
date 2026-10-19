namespace Cau4_QuanLyTraSua
{
    partial class FormBanHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControlMain = new TabControl();
            tabBanHang = new TabPage();
            grpChonMon = new GroupBox();
            lblDanhMuc = new Label();
            cboDanhMucBanHang = new ComboBox();
            lstMonUong = new ListBox();
            lblSoLy = new Label();
            nudSoLy = new NumericUpDown();
            btnThemVaoDon = new Button();
            grpDonHienTai = new GroupBox();
            dgvGioHang = new DataGridView();
            btnXoaDong = new Button();
            btnHuyDon = new Button();
            lblTongTien = new Label();
            grpThanhToan = new GroupBox();
            btnThanhToanCK = new Button();
            btnTienMat = new Button();
            picVietQR = new PictureBox();
            lblSoTienQR = new Label();
            lblNoiDungQR = new Label();
            lblNganHangInfo = new Label();
            btnDaNhanTien = new Button();
            tabThucDon = new TabPage();
            grpMonInfo = new GroupBox();
            lblMaMon = new Label();
            txtMaMon = new TextBox();
            lblTenMon = new Label();
            txtTenMon = new TextBox();
            lblDM = new Label();
            cboDMMon = new ComboBox();
            lblGiaBan = new Label();
            nudGiaBan = new NumericUpDown();
            chkDangBan = new CheckBox();
            btnThemMon = new Button();
            btnSuaMon = new Button();
            btnXoaMon = new Button();
            btnLamMoiMon = new Button();
            pnlFilterMon = new Panel();
            txtTimTenMon = new TextBox();
            lblLocDM = new Label();
            cboLocDMMon = new ComboBox();
            btnTimMon = new Button();
            btnBoLocMon = new Button();
            dgvThucDon = new DataGridView();
            tabHoaDon = new TabPage();
            pnlFilterHD = new Panel();
            lblNgayHD = new Label();
            dtpNgayHD = new DateTimePicker();
            btnLocHD = new Button();
            lblDoanhThuNgay = new Label();
            splitContainerHD = new SplitContainer();
            dgvHoaDon = new DataGridView();
            dgvChiTietHD = new DataGridView();
            tabControlMain.SuspendLayout();
            tabBanHang.SuspendLayout();
            grpChonMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLy).BeginInit();
            grpDonHienTai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            grpThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVietQR).BeginInit();
            tabThucDon.SuspendLayout();
            grpMonInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).BeginInit();
            pnlFilterMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThucDon).BeginInit();
            tabHoaDon.SuspendLayout();
            pnlFilterHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerHD).BeginInit();
            splitContainerHD.Panel1.SuspendLayout();
            splitContainerHD.Panel2.SuspendLayout();
            splitContainerHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabBanHang);
            tabControlMain.Controls.Add(tabThucDon);
            tabControlMain.Controls.Add(tabHoaDon);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 9.5F);
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1064, 641);
            tabControlMain.TabIndex = 0;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // tabBanHang
            // 
            tabBanHang.Controls.Add(grpChonMon);
            tabBanHang.Controls.Add(grpDonHienTai);
            tabBanHang.Controls.Add(grpThanhToan);
            tabBanHang.Location = new Point(4, 25);
            tabBanHang.Name = "tabBanHang";
            tabBanHang.Padding = new Padding(10);
            tabBanHang.Size = new Size(1056, 612);
            tabBanHang.TabIndex = 0;
            tabBanHang.Text = "Bán hàng - Quán trà sữa";
            tabBanHang.UseVisualStyleBackColor = true;
            // 
            // grpChonMon
            // 
            grpChonMon.Controls.Add(lblDanhMuc);
            grpChonMon.Controls.Add(cboDanhMucBanHang);
            grpChonMon.Controls.Add(lstMonUong);
            grpChonMon.Controls.Add(lblSoLy);
            grpChonMon.Controls.Add(nudSoLy);
            grpChonMon.Controls.Add(btnThemVaoDon);
            grpChonMon.Location = new Point(10, 10);
            grpChonMon.Name = "grpChonMon";
            grpChonMon.Size = new Size(270, 590);
            grpChonMon.TabIndex = 0;
            grpChonMon.TabStop = false;
            grpChonMon.Text = "Chọn món";
            // 
            // lblDanhMuc
            // 
            lblDanhMuc.AutoSize = true;
            lblDanhMuc.Location = new Point(12, 25);
            lblDanhMuc.Name = "lblDanhMuc";
            lblDanhMuc.Size = new Size(69, 17);
            lblDanhMuc.TabIndex = 0;
            lblDanhMuc.Text = "Danh mục:";
            // 
            // cboDanhMucBanHang
            // 
            cboDanhMucBanHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanhMucBanHang.FormattingEnabled = true;
            cboDanhMucBanHang.Location = new Point(12, 48);
            cboDanhMucBanHang.Name = "cboDanhMucBanHang";
            cboDanhMucBanHang.Size = new Size(245, 25);
            cboDanhMucBanHang.TabIndex = 1;
            cboDanhMucBanHang.SelectedIndexChanged += cboDanhMucBanHang_SelectedIndexChanged;
            // 
            // lstMonUong
            // 
            lstMonUong.FormattingEnabled = true;
            lstMonUong.ItemHeight = 17;
            lstMonUong.Location = new Point(12, 85);
            lstMonUong.Name = "lstMonUong";
            lstMonUong.Size = new Size(245, 412);
            lstMonUong.TabIndex = 2;
            // 
            // lblSoLy
            // 
            lblSoLy.AutoSize = true;
            lblSoLy.Location = new Point(12, 513);
            lblSoLy.Name = "lblSoLy";
            lblSoLy.Size = new Size(40, 17);
            lblSoLy.TabIndex = 3;
            lblSoLy.Text = "Số ly:";
            // 
            // nudSoLy
            // 
            nudSoLy.Location = new Point(65, 510);
            nudSoLy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLy.Name = "nudSoLy";
            nudSoLy.Size = new Size(60, 24);
            nudSoLy.TabIndex = 4;
            nudSoLy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemVaoDon
            // 
            btnThemVaoDon.Location = new Point(12, 545);
            btnThemVaoDon.Name = "btnThemVaoDon";
            btnThemVaoDon.Size = new Size(245, 34);
            btnThemVaoDon.TabIndex = 5;
            btnThemVaoDon.Text = "+ Thêm vào đơn";
            btnThemVaoDon.UseVisualStyleBackColor = true;
            btnThemVaoDon.Click += btnThemVaoDon_Click;
            // 
            // grpDonHienTai
            // 
            grpDonHienTai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDonHienTai.Controls.Add(dgvGioHang);
            grpDonHienTai.Controls.Add(btnXoaDong);
            grpDonHienTai.Controls.Add(btnHuyDon);
            grpDonHienTai.Controls.Add(lblTongTien);
            grpDonHienTai.Location = new Point(290, 10);
            grpDonHienTai.Name = "grpDonHienTai";
            grpDonHienTai.Size = new Size(460, 590);
            grpDonHienTai.TabIndex = 1;
            grpDonHienTai.TabStop = false;
            grpDonHienTai.Text = "Đơn hiện tại";
            // 
            // dgvGioHang
            // 
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.AllowUserToDeleteRows = false;
            dgvGioHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.BackgroundColor = Color.White;
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Location = new Point(10, 25);
            dgvGioHang.MultiSelect = false;
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.ReadOnly = true;
            dgvGioHang.RowHeadersVisible = false;
            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.Size = new Size(440, 470);
            dgvGioHang.TabIndex = 0;
            // 
            // btnXoaDong
            // 
            btnXoaDong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnXoaDong.Location = new Point(10, 508);
            btnXoaDong.Name = "btnXoaDong";
            btnXoaDong.Size = new Size(110, 32);
            btnXoaDong.TabIndex = 1;
            btnXoaDong.Text = "Xóa dòng";
            btnXoaDong.UseVisualStyleBackColor = true;
            btnXoaDong.Click += btnXoaDong_Click;
            // 
            // btnHuyDon
            // 
            btnHuyDon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHuyDon.Location = new Point(130, 508);
            btnHuyDon.Name = "btnHuyDon";
            btnHuyDon.Size = new Size(110, 32);
            btnHuyDon.TabIndex = 2;
            btnHuyDon.Text = "Hủy đơn";
            btnHuyDon.UseVisualStyleBackColor = true;
            btnHuyDon.Click += btnHuyDon_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTongTien.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.DarkRed;
            lblTongTien.Location = new Point(10, 545);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(440, 35);
            lblTongTien.TabIndex = 3;
            lblTongTien.Text = "Tổng tiền: 0 đ";
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpThanhToan
            // 
            grpThanhToan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpThanhToan.Controls.Add(btnThanhToanCK);
            grpThanhToan.Controls.Add(btnTienMat);
            grpThanhToan.Controls.Add(picVietQR);
            grpThanhToan.Controls.Add(lblSoTienQR);
            grpThanhToan.Controls.Add(lblNoiDungQR);
            grpThanhToan.Controls.Add(lblNganHangInfo);
            grpThanhToan.Controls.Add(btnDaNhanTien);
            grpThanhToan.Location = new Point(760, 10);
            grpThanhToan.Name = "grpThanhToan";
            grpThanhToan.Size = new Size(285, 590);
            grpThanhToan.TabIndex = 2;
            grpThanhToan.TabStop = false;
            grpThanhToan.Text = "Thanh toán";
            // 
            // btnThanhToanCK
            // 
            btnThanhToanCK.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThanhToanCK.Location = new Point(15, 25);
            btnThanhToanCK.Name = "btnThanhToanCK";
            btnThanhToanCK.Size = new Size(255, 34);
            btnThanhToanCK.TabIndex = 0;
            btnThanhToanCK.Text = "Thanh toán chuyển khoản";
            btnThanhToanCK.UseVisualStyleBackColor = true;
            btnThanhToanCK.Click += btnThanhToanCK_Click;
            // 
            // btnTienMat
            // 
            btnTienMat.Location = new Point(15, 65);
            btnTienMat.Name = "btnTienMat";
            btnTienMat.Size = new Size(255, 32);
            btnTienMat.TabIndex = 1;
            btnTienMat.Text = "💵 Thanh toán tiền mặt";
            btnTienMat.UseVisualStyleBackColor = true;
            btnTienMat.Click += btnTienMat_Click;
            // 
            // picVietQR
            // 
            picVietQR.BackColor = Color.White;
            picVietQR.BorderStyle = BorderStyle.FixedSingle;
            picVietQR.Location = new Point(15, 105);
            picVietQR.Name = "picVietQR";
            picVietQR.Size = new Size(255, 310);
            picVietQR.SizeMode = PictureBoxSizeMode.Zoom;
            picVietQR.TabIndex = 2;
            picVietQR.TabStop = false;
            // 
            // lblSoTienQR
            // 
            lblSoTienQR.AutoSize = true;
            lblSoTienQR.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSoTienQR.Location = new Point(15, 425);
            lblSoTienQR.Name = "lblSoTienQR";
            lblSoTienQR.Size = new Size(95, 17);
            lblSoTienQR.TabIndex = 3;
            lblSoTienQR.Text = "Số tiền: 0 đ";
            // 
            // lblNoiDungQR
            // 
            lblNoiDungQR.AutoSize = true;
            lblNoiDungQR.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNoiDungQR.ForeColor = Color.DarkSlateBlue;
            lblNoiDungQR.Location = new Point(15, 448);
            lblNoiDungQR.Name = "lblNoiDungQR";
            lblNoiDungQR.Size = new Size(130, 17);
            lblNoiDungQR.TabIndex = 4;
            lblNoiDungQR.Text = "Nội dung: TRASUA";
            // 
            // lblNganHangInfo
            // 
            lblNganHangInfo.Font = new Font("Segoe UI", 8.5F);
            lblNganHangInfo.ForeColor = Color.DimGray;
            lblNganHangInfo.Location = new Point(15, 472);
            lblNganHangInfo.Name = "lblNganHangInfo";
            lblNganHangInfo.Size = new Size(255, 50);
            lblNganHangInfo.TabIndex = 5;
            lblNganHangInfo.Text = "Ngân hàng & Số tài khoản...";
            // 
            // btnDaNhanTien
            // 
            btnDaNhanTien.BackColor = Color.FromArgb(46, 139, 87);
            btnDaNhanTien.FlatStyle = FlatStyle.Flat;
            btnDaNhanTien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDaNhanTien.ForeColor = Color.White;
            btnDaNhanTien.Location = new Point(15, 532);
            btnDaNhanTien.Name = "btnDaNhanTien";
            btnDaNhanTien.Size = new Size(255, 45);
            btnDaNhanTien.TabIndex = 6;
            btnDaNhanTien.Text = "✔ ĐÃ NHẬN TIỀN";
            btnDaNhanTien.UseVisualStyleBackColor = false;
            btnDaNhanTien.Click += btnDaNhanTien_Click;
            // 
            // tabThucDon
            // 
            tabThucDon.Controls.Add(dgvThucDon);
            tabThucDon.Controls.Add(pnlFilterMon);
            tabThucDon.Controls.Add(grpMonInfo);
            tabThucDon.Location = new Point(4, 25);
            tabThucDon.Name = "tabThucDon";
            tabThucDon.Padding = new Padding(10);
            tabThucDon.Size = new Size(1056, 612);
            tabThucDon.TabIndex = 1;
            tabThucDon.Text = "Quản lý thực đơn";
            tabThucDon.UseVisualStyleBackColor = true;
            // 
            // grpMonInfo
            // 
            grpMonInfo.Controls.Add(lblMaMon);
            grpMonInfo.Controls.Add(txtMaMon);
            grpMonInfo.Controls.Add(lblTenMon);
            grpMonInfo.Controls.Add(txtTenMon);
            grpMonInfo.Controls.Add(lblDM);
            grpMonInfo.Controls.Add(cboDMMon);
            grpMonInfo.Controls.Add(lblGiaBan);
            grpMonInfo.Controls.Add(nudGiaBan);
            grpMonInfo.Controls.Add(chkDangBan);
            grpMonInfo.Controls.Add(btnThemMon);
            grpMonInfo.Controls.Add(btnSuaMon);
            grpMonInfo.Controls.Add(btnXoaMon);
            grpMonInfo.Controls.Add(btnLamMoiMon);
            grpMonInfo.Location = new Point(10, 10);
            grpMonInfo.Name = "grpMonInfo";
            grpMonInfo.Size = new Size(360, 590);
            grpMonInfo.TabIndex = 0;
            grpMonInfo.TabStop = false;
            grpMonInfo.Text = "Thông tin món";
            // 
            // lblMaMon
            // 
            lblMaMon.AutoSize = true;
            lblMaMon.Location = new Point(15, 30);
            lblMaMon.Name = "lblMaMon";
            lblMaMon.Size = new Size(60, 17);
            lblMaMon.TabIndex = 0;
            lblMaMon.Text = "Mã món:";
            // 
            // txtMaMon
            // 
            txtMaMon.Location = new Point(100, 27);
            txtMaMon.Name = "txtMaMon";
            txtMaMon.ReadOnly = true;
            txtMaMon.Size = new Size(240, 24);
            txtMaMon.TabIndex = 1;
            // 
            // lblTenMon
            // 
            lblTenMon.AutoSize = true;
            lblTenMon.Location = new Point(15, 68);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(62, 17);
            lblTenMon.TabIndex = 2;
            lblTenMon.Text = "Tên món:";
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(100, 65);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(240, 24);
            txtTenMon.TabIndex = 3;
            // 
            // lblDM
            // 
            lblDM.AutoSize = true;
            lblDM.Location = new Point(15, 106);
            lblDM.Name = "lblDM";
            lblDM.Size = new Size(69, 17);
            lblDM.TabIndex = 4;
            lblDM.Text = "Danh mục:";
            // 
            // cboDMMon
            // 
            cboDMMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDMMon.FormattingEnabled = true;
            cboDMMon.Location = new Point(100, 103);
            cboDMMon.Name = "cboDMMon";
            cboDMMon.Size = new Size(240, 25);
            cboDMMon.TabIndex = 5;
            // 
            // lblGiaBan
            // 
            lblGiaBan.AutoSize = true;
            lblGiaBan.Location = new Point(15, 144);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(55, 17);
            lblGiaBan.TabIndex = 6;
            lblGiaBan.Text = "Giá bán:";
            // 
            // nudGiaBan
            // 
            nudGiaBan.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nudGiaBan.Location = new Point(100, 141);
            nudGiaBan.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudGiaBan.Name = "nudGiaBan";
            nudGiaBan.Size = new Size(240, 24);
            nudGiaBan.TabIndex = 7;
            nudGiaBan.ThousandsSeparator = true;
            // 
            // chkDangBan
            // 
            chkDangBan.AutoSize = true;
            chkDangBan.Checked = true;
            chkDangBan.CheckState = CheckState.Checked;
            chkDangBan.Location = new Point(100, 180);
            chkDangBan.Name = "chkDangBan";
            chkDangBan.Size = new Size(83, 21);
            chkDangBan.TabIndex = 8;
            chkDangBan.Text = "Đang bán";
            chkDangBan.UseVisualStyleBackColor = true;
            // 
            // btnThemMon
            // 
            btnThemMon.Location = new Point(15, 225);
            btnThemMon.Name = "btnThemMon";
            btnThemMon.Size = new Size(75, 32);
            btnThemMon.TabIndex = 9;
            btnThemMon.Text = "Thêm";
            btnThemMon.UseVisualStyleBackColor = true;
            btnThemMon.Click += btnThemMon_Click;
            // 
            // btnSuaMon
            // 
            btnSuaMon.Location = new Point(98, 225);
            btnSuaMon.Name = "btnSuaMon";
            btnSuaMon.Size = new Size(75, 32);
            btnSuaMon.TabIndex = 10;
            btnSuaMon.Text = "Sửa";
            btnSuaMon.UseVisualStyleBackColor = true;
            btnSuaMon.Click += btnSuaMon_Click;
            // 
            // btnXoaMon
            // 
            btnXoaMon.Location = new Point(181, 225);
            btnXoaMon.Name = "btnXoaMon";
            btnXoaMon.Size = new Size(75, 32);
            btnXoaMon.TabIndex = 11;
            btnXoaMon.Text = "Xóa";
            btnXoaMon.UseVisualStyleBackColor = true;
            btnXoaMon.Click += btnXoaMon_Click;
            // 
            // btnLamMoiMon
            // 
            btnLamMoiMon.Location = new Point(264, 225);
            btnLamMoiMon.Name = "btnLamMoiMon";
            btnLamMoiMon.Size = new Size(75, 32);
            btnLamMoiMon.TabIndex = 12;
            btnLamMoiMon.Text = "Làm mới";
            btnLamMoiMon.UseVisualStyleBackColor = true;
            btnLamMoiMon.Click += btnLamMoiMon_Click;
            // 
            // pnlFilterMon
            // 
            pnlFilterMon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilterMon.Controls.Add(txtTimTenMon);
            pnlFilterMon.Controls.Add(lblLocDM);
            pnlFilterMon.Controls.Add(cboLocDMMon);
            pnlFilterMon.Controls.Add(btnTimMon);
            pnlFilterMon.Controls.Add(btnBoLocMon);
            pnlFilterMon.Location = new Point(380, 10);
            pnlFilterMon.Name = "pnlFilterMon";
            pnlFilterMon.Size = new Size(665, 45);
            pnlFilterMon.TabIndex = 1;
            // 
            // txtTimTenMon
            // 
            txtTimTenMon.Location = new Point(5, 10);
            txtTimTenMon.Name = "txtTimTenMon";
            txtTimTenMon.PlaceholderText = "Tìm theo tên món...";
            txtTimTenMon.Size = new Size(200, 24);
            txtTimTenMon.TabIndex = 0;
            // 
            // lblLocDM
            // 
            lblLocDM.AutoSize = true;
            lblLocDM.Location = new Point(215, 13);
            lblLocDM.Name = "lblLocDM";
            lblLocDM.Size = new Size(69, 17);
            lblLocDM.TabIndex = 1;
            lblLocDM.Text = "Danh mục:";
            // 
            // cboLocDMMon
            // 
            cboLocDMMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocDMMon.FormattingEnabled = true;
            cboLocDMMon.Location = new Point(290, 10);
            cboLocDMMon.Name = "cboLocDMMon";
            cboLocDMMon.Size = new Size(180, 25);
            cboLocDMMon.TabIndex = 2;
            // 
            // btnTimMon
            // 
            btnTimMon.Location = new Point(480, 8);
            btnTimMon.Name = "btnTimMon";
            btnTimMon.Size = new Size(75, 30);
            btnTimMon.TabIndex = 3;
            btnTimMon.Text = "Tìm";
            btnTimMon.UseVisualStyleBackColor = true;
            btnTimMon.Click += btnTimMon_Click;
            // 
            // btnBoLocMon
            // 
            btnBoLocMon.Location = new Point(565, 8);
            btnBoLocMon.Name = "btnBoLocMon";
            btnBoLocMon.Size = new Size(75, 30);
            btnBoLocMon.TabIndex = 4;
            btnBoLocMon.Text = "Bỏ lọc";
            btnBoLocMon.UseVisualStyleBackColor = true;
            btnBoLocMon.Click += btnBoLocMon_Click;
            // 
            // dgvThucDon
            // 
            dgvThucDon.AllowUserToAddRows = false;
            dgvThucDon.AllowUserToDeleteRows = false;
            dgvThucDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThucDon.BackgroundColor = Color.White;
            dgvThucDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThucDon.Location = new Point(380, 60);
            dgvThucDon.MultiSelect = false;
            dgvThucDon.Name = "dgvThucDon";
            dgvThucDon.ReadOnly = true;
            dgvThucDon.RowHeadersVisible = false;
            dgvThucDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThucDon.Size = new Size(665, 540);
            dgvThucDon.TabIndex = 2;
            dgvThucDon.CellClick += dgvThucDon_CellClick;
            // 
            // tabHoaDon
            // 
            tabHoaDon.Controls.Add(splitContainerHD);
            tabHoaDon.Controls.Add(pnlFilterHD);
            tabHoaDon.Location = new Point(4, 25);
            tabHoaDon.Name = "tabHoaDon";
            tabHoaDon.Padding = new Padding(10);
            tabHoaDon.Size = new Size(1056, 612);
            tabHoaDon.TabIndex = 2;
            tabHoaDon.Text = "Danh sách hóa đơn & Doanh thu";
            tabHoaDon.UseVisualStyleBackColor = true;
            // 
            // pnlFilterHD
            // 
            pnlFilterHD.Controls.Add(lblNgayHD);
            pnlFilterHD.Controls.Add(dtpNgayHD);
            pnlFilterHD.Controls.Add(btnLocHD);
            pnlFilterHD.Controls.Add(lblDoanhThuNgay);
            pnlFilterHD.Dock = DockStyle.Top;
            pnlFilterHD.Location = new Point(10, 10);
            pnlFilterHD.Name = "pnlFilterHD";
            pnlFilterHD.Size = new Size(1036, 45);
            pnlFilterHD.TabIndex = 0;
            // 
            // lblNgayHD
            // 
            lblNgayHD.AutoSize = true;
            lblNgayHD.Location = new Point(5, 13);
            lblNgayHD.Name = "lblNgayHD";
            lblNgayHD.Size = new Size(64, 17);
            lblNgayHD.TabIndex = 0;
            lblNgayHD.Text = "Lọc ngày:";
            // 
            // dtpNgayHD
            // 
            dtpNgayHD.CustomFormat = "dd/MM/yyyy";
            dtpNgayHD.Format = DateTimePickerFormat.Custom;
            dtpNgayHD.Location = new Point(75, 10);
            dtpNgayHD.Name = "dtpNgayHD";
            dtpNgayHD.Size = new Size(130, 24);
            dtpNgayHD.TabIndex = 1;
            // 
            // btnLocHD
            // 
            btnLocHD.Location = new Point(215, 8);
            btnLocHD.Name = "btnLocHD";
            btnLocHD.Size = new Size(80, 28);
            btnLocHD.TabIndex = 2;
            btnLocHD.Text = "Lọc đơn";
            btnLocHD.UseVisualStyleBackColor = true;
            btnLocHD.Click += btnLocHD_Click;
            // 
            // lblDoanhThuNgay
            // 
            lblDoanhThuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDoanhThuNgay.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDoanhThuNgay.ForeColor = Color.DarkGreen;
            lblDoanhThuNgay.Location = new Point(600, 8);
            lblDoanhThuNgay.Name = "lblDoanhThuNgay";
            lblDoanhThuNgay.Size = new Size(430, 28);
            lblDoanhThuNgay.TabIndex = 3;
            lblDoanhThuNgay.Text = "Doanh thu ngày: 0 đ";
            lblDoanhThuNgay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // splitContainerHD
            // 
            splitContainerHD.Dock = DockStyle.Fill;
            splitContainerHD.Location = new Point(10, 55);
            splitContainerHD.Name = "splitContainerHD";
            // 
            // splitContainerHD.Panel1
            // 
            splitContainerHD.Panel1.Controls.Add(dgvHoaDon);
            // 
            // splitContainerHD.Panel2
            // 
            splitContainerHD.Panel2.Controls.Add(dgvChiTietHD);
            splitContainerHD.Size = new Size(1036, 547);
            splitContainerHD.SplitterDistance = 530;
            splitContainerHD.TabIndex = 1;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.BackgroundColor = Color.White;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(0, 0);
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(530, 547);
            dgvHoaDon.TabIndex = 0;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            // 
            // dgvChiTietHD
            // 
            dgvChiTietHD.AllowUserToAddRows = false;
            dgvChiTietHD.AllowUserToDeleteRows = false;
            dgvChiTietHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHD.BackgroundColor = Color.White;
            dgvChiTietHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietHD.Dock = DockStyle.Fill;
            dgvChiTietHD.Location = new Point(0, 0);
            dgvChiTietHD.MultiSelect = false;
            dgvChiTietHD.Name = "dgvChiTietHD";
            dgvChiTietHD.ReadOnly = true;
            dgvChiTietHD.RowHeadersVisible = false;
            dgvChiTietHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietHD.Size = new Size(502, 547);
            dgvChiTietHD.TabIndex = 0;
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 641);
            Controls.Add(tabControlMain);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(1050, 650);
            Name = "FormBanHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bán hàng - Quán trà sữa";
            Load += FormBanHang_Load;
            tabControlMain.ResumeLayout(false);
            tabBanHang.ResumeLayout(false);
            grpChonMon.ResumeLayout(false);
            grpChonMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLy).EndInit();
            grpDonHienTai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            grpThanhToan.ResumeLayout(false);
            grpThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picVietQR).EndInit();
            tabThucDon.ResumeLayout(false);
            grpMonInfo.ResumeLayout(false);
            grpMonInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).EndInit();
            pnlFilterMon.ResumeLayout(false);
            pnlFilterMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThucDon).EndInit();
            tabHoaDon.ResumeLayout(false);
            pnlFilterHD.ResumeLayout(false);
            pnlFilterHD.PerformLayout();
            splitContainerHD.Panel1.ResumeLayout(false);
            splitContainerHD.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerHD).EndInit();
            splitContainerHD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabBanHang;
        private GroupBox grpChonMon;
        private Label lblDanhMuc;
        private ComboBox cboDanhMucBanHang;
        private ListBox lstMonUong;
        private Label lblSoLy;
        private NumericUpDown nudSoLy;
        private Button btnThemVaoDon;
        private GroupBox grpDonHienTai;
        private DataGridView dgvGioHang;
        private Button btnXoaDong;
        private Button btnHuyDon;
        private Label lblTongTien;
        private GroupBox grpThanhToan;
        private Button btnThanhToanCK;
        private Button btnTienMat;
        private PictureBox picVietQR;
        private Label lblSoTienQR;
        private Label lblNoiDungQR;
        private Label lblNganHangInfo;
        private Button btnDaNhanTien;
        private TabPage tabThucDon;
        private GroupBox grpMonInfo;
        private Label lblMaMon;
        private TextBox txtMaMon;
        private Label lblTenMon;
        private TextBox txtTenMon;
        private Label lblDM;
        private ComboBox cboDMMon;
        private Label lblGiaBan;
        private NumericUpDown nudGiaBan;
        private CheckBox chkDangBan;
        private Button btnThemMon;
        private Button btnSuaMon;
        private Button btnXoaMon;
        private Button btnLamMoiMon;
        private Panel pnlFilterMon;
        private TextBox txtTimTenMon;
        private Label lblLocDM;
        private ComboBox cboLocDMMon;
        private Button btnTimMon;
        private Button btnBoLocMon;
        private DataGridView dgvThucDon;
        private TabPage tabHoaDon;
        private Panel pnlFilterHD;
        private Label lblNgayHD;
        private DateTimePicker dtpNgayHD;
        private Button btnLocHD;
        private Label lblDoanhThuNgay;
        private SplitContainer splitContainerHD;
        private DataGridView dgvHoaDon;
        private DataGridView dgvChiTietHD;
    }
}
