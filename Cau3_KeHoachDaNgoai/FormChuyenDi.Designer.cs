namespace Cau3_KeHoachDaNgoai
{
    partial class FormChuyenDi
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
            grpThongTin = new GroupBox();
            lblMaChuyen = new Label();
            txtMaChuyen = new TextBox();
            lblTenChuyen = new Label();
            txtTenChuyen = new TextBox();
            lblDiaDiem = new Label();
            txtDiaDiem = new TextBox();
            lblNgayDi = new Label();
            dtpNgayDi = new DateTimePicker();
            lblSoNguoi = new Label();
            nudSoNguoi = new NumericUpDown();
            lblNganSach = new Label();
            nudNganSach = new NumericUpDown();
            lblPhuongTien = new Label();
            cboPhuongTien = new ComboBox();
            chkDaHoanThanh = new CheckBox();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            pnlHeaderLang = new Panel();
            lblNgonNgu = new Label();
            cboNgonNgu = new ComboBox();
            grpThoiTiet = new GroupBox();
            btnXemThoiTiet = new Button();
            prgLoading = new ProgressBar();
            pnlWeatherContent = new Panel();
            lblWeatherHeader = new Label();
            lblWeatherIcon = new Label();
            lblWeatherDesc = new Label();
            lblTemperature = new Label();
            lblRainProb = new Label();
            pnlWarning = new Panel();
            lblWarningText = new Label();
            pnlFilter = new Panel();
            txtTimKiem = new TextBox();
            chkChuaHoanThanh = new CheckBox();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            btnTimKiem = new Button();
            btnBoLoc = new Button();
            dgvChuyenDi = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNganSach).BeginInit();
            pnlHeaderLang.SuspendLayout();
            grpThoiTiet.SuspendLayout();
            pnlWeatherContent.SuspendLayout();
            pnlWarning.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblMaChuyen);
            grpThongTin.Controls.Add(txtMaChuyen);
            grpThongTin.Controls.Add(lblTenChuyen);
            grpThongTin.Controls.Add(txtTenChuyen);
            grpThongTin.Controls.Add(lblDiaDiem);
            grpThongTin.Controls.Add(txtDiaDiem);
            grpThongTin.Controls.Add(lblNgayDi);
            grpThongTin.Controls.Add(dtpNgayDi);
            grpThongTin.Controls.Add(lblSoNguoi);
            grpThongTin.Controls.Add(nudSoNguoi);
            grpThongTin.Controls.Add(lblNganSach);
            grpThongTin.Controls.Add(nudNganSach);
            grpThongTin.Controls.Add(lblPhuongTien);
            grpThongTin.Controls.Add(cboPhuongTien);
            grpThongTin.Controls.Add(chkDaHoanThanh);
            grpThongTin.Controls.Add(lblGhiChu);
            grpThongTin.Controls.Add(txtGhiChu);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Font = new Font("Segoe UI", 9.5F);
            grpThongTin.Location = new Point(16, 45);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(500, 315);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin chuyến đi";
            // 
            // lblMaChuyen
            // 
            lblMaChuyen.AutoSize = true;
            lblMaChuyen.Location = new Point(15, 25);
            lblMaChuyen.Name = "lblMaChuyen";
            lblMaChuyen.Size = new Size(74, 17);
            lblMaChuyen.TabIndex = 0;
            lblMaChuyen.Text = "Mã chuyến:";
            // 
            // txtMaChuyen
            // 
            txtMaChuyen.Location = new Point(110, 22);
            txtMaChuyen.Name = "txtMaChuyen";
            txtMaChuyen.ReadOnly = true;
            txtMaChuyen.Size = new Size(120, 24);
            txtMaChuyen.TabIndex = 1;
            // 
            // lblTenChuyen
            // 
            lblTenChuyen.AutoSize = true;
            lblTenChuyen.Location = new Point(15, 58);
            lblTenChuyen.Name = "lblTenChuyen";
            lblTenChuyen.Size = new Size(76, 17);
            lblTenChuyen.TabIndex = 2;
            lblTenChuyen.Text = "Tên chuyến:";
            // 
            // txtTenChuyen
            // 
            txtTenChuyen.Location = new Point(110, 55);
            txtTenChuyen.Name = "txtTenChuyen";
            txtTenChuyen.Size = new Size(375, 24);
            txtTenChuyen.TabIndex = 3;
            // 
            // lblDiaDiem
            // 
            lblDiaDiem.AutoSize = true;
            lblDiaDiem.Location = new Point(15, 91);
            lblDiaDiem.Name = "lblDiaDiem";
            lblDiaDiem.Size = new Size(63, 17);
            lblDiaDiem.TabIndex = 4;
            lblDiaDiem.Text = "Địa điểm:";
            // 
            // txtDiaDiem
            // 
            txtDiaDiem.Location = new Point(110, 88);
            txtDiaDiem.Name = "txtDiaDiem";
            txtDiaDiem.Size = new Size(375, 24);
            txtDiaDiem.TabIndex = 5;
            // 
            // lblNgayDi
            // 
            lblNgayDi.AutoSize = true;
            lblNgayDi.Location = new Point(15, 124);
            lblNgayDi.Name = "lblNgayDi";
            lblNgayDi.Size = new Size(56, 17);
            lblNgayDi.TabIndex = 6;
            lblNgayDi.Text = "Ngày đi:";
            // 
            // dtpNgayDi
            // 
            dtpNgayDi.CustomFormat = "dd/MM/yyyy";
            dtpNgayDi.Format = DateTimePickerFormat.Custom;
            dtpNgayDi.Location = new Point(110, 121);
            dtpNgayDi.Name = "dtpNgayDi";
            dtpNgayDi.Size = new Size(130, 24);
            dtpNgayDi.TabIndex = 7;
            // 
            // lblSoNguoi
            // 
            lblSoNguoi.AutoSize = true;
            lblSoNguoi.Location = new Point(265, 124);
            lblSoNguoi.Name = "lblSoNguoi";
            lblSoNguoi.Size = new Size(64, 17);
            lblSoNguoi.TabIndex = 8;
            lblSoNguoi.Text = "Số người:";
            // 
            // nudSoNguoi
            // 
            nudSoNguoi.Location = new Point(345, 121);
            nudSoNguoi.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoNguoi.Name = "nudSoNguoi";
            nudSoNguoi.Size = new Size(140, 24);
            nudSoNguoi.TabIndex = 9;
            nudSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblNganSach
            // 
            lblNganSach.AutoSize = true;
            lblNganSach.Location = new Point(15, 157);
            lblNganSach.Name = "lblNganSach";
            lblNganSach.Size = new Size(71, 17);
            lblNganSach.TabIndex = 10;
            lblNganSach.Text = "Ngân sách:";
            // 
            // nudNganSach
            // 
            nudNganSach.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            nudNganSach.Location = new Point(110, 154);
            nudNganSach.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudNganSach.Name = "nudNganSach";
            nudNganSach.Size = new Size(130, 24);
            nudNganSach.TabIndex = 11;
            nudNganSach.ThousandsSeparator = true;
            // 
            // lblPhuongTien
            // 
            lblPhuongTien.AutoSize = true;
            lblPhuongTien.Location = new Point(265, 157);
            lblPhuongTien.Name = "lblPhuongTien";
            lblPhuongTien.Size = new Size(82, 17);
            lblPhuongTien.TabIndex = 12;
            lblPhuongTien.Text = "Phương tiện:";
            // 
            // cboPhuongTien
            // 
            cboPhuongTien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongTien.FormattingEnabled = true;
            cboPhuongTien.Items.AddRange(new object[] { "Xe máy", "Ô tô", "Xe khách", "Tàu hỏa" });
            cboPhuongTien.Location = new Point(345, 153);
            cboPhuongTien.Name = "cboPhuongTien";
            cboPhuongTien.Size = new Size(140, 25);
            cboPhuongTien.TabIndex = 13;
            // 
            // chkDaHoanThanh
            // 
            chkDaHoanThanh.AutoSize = true;
            chkDaHoanThanh.Location = new Point(110, 187);
            chkDaHoanThanh.Name = "chkDaHoanThanh";
            chkDaHoanThanh.Size = new Size(111, 21);
            chkDaHoanThanh.TabIndex = 14;
            chkDaHoanThanh.Text = "Đã hoàn thành";
            chkDaHoanThanh.UseVisualStyleBackColor = true;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(15, 217);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(54, 17);
            lblGhiChu.TabIndex = 15;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(110, 214);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(375, 45);
            txtGhiChu.TabIndex = 16;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(110, 270);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(85, 32);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(205, 270);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(85, 32);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(300, 270);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(85, 32);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(395, 270);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 20;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // pnlHeaderLang
            // 
            pnlHeaderLang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlHeaderLang.Controls.Add(lblNgonNgu);
            pnlHeaderLang.Controls.Add(cboNgonNgu);
            pnlHeaderLang.Location = new Point(780, 8);
            pnlHeaderLang.Name = "pnlHeaderLang";
            pnlHeaderLang.Size = new Size(240, 32);
            pnlHeaderLang.TabIndex = 1;
            // 
            // lblNgonNgu
            // 
            lblNgonNgu.AutoSize = true;
            lblNgonNgu.Font = new Font("Segoe UI", 9.5F);
            lblNgonNgu.Location = new Point(10, 8);
            lblNgonNgu.Name = "lblNgonNgu";
            lblNgonNgu.Size = new Size(71, 17);
            lblNgonNgu.TabIndex = 0;
            lblNgonNgu.Text = "Ngôn ngữ:";
            // 
            // cboNgonNgu
            // 
            cboNgonNgu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNgonNgu.FormattingEnabled = true;
            cboNgonNgu.Items.AddRange(new object[] { "Tiếng Việt", "English" });
            cboNgonNgu.Location = new Point(95, 4);
            cboNgonNgu.Name = "cboNgonNgu";
            cboNgonNgu.Size = new Size(140, 25);
            cboNgonNgu.TabIndex = 1;
            cboNgonNgu.SelectedIndexChanged += cboNgonNgu_SelectedIndexChanged;
            // 
            // grpThoiTiet
            // 
            grpThoiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThoiTiet.Controls.Add(btnXemThoiTiet);
            grpThoiTiet.Controls.Add(prgLoading);
            grpThoiTiet.Controls.Add(pnlWeatherContent);
            grpThoiTiet.Font = new Font("Segoe UI", 9.5F);
            grpThoiTiet.Location = new Point(530, 45);
            grpThoiTiet.Name = "grpThoiTiet";
            grpThoiTiet.Size = new Size(490, 315);
            grpThoiTiet.TabIndex = 2;
            grpThoiTiet.TabStop = false;
            grpThoiTiet.Text = "Dự báo thời tiết";
            // 
            // btnXemThoiTiet
            // 
            btnXemThoiTiet.Location = new Point(15, 23);
            btnXemThoiTiet.Name = "btnXemThoiTiet";
            btnXemThoiTiet.Size = new Size(130, 32);
            btnXemThoiTiet.TabIndex = 0;
            btnXemThoiTiet.Text = "Xem thời tiết";
            btnXemThoiTiet.UseVisualStyleBackColor = true;
            btnXemThoiTiet.Click += btnXemThoiTiet_Click;
            // 
            // prgLoading
            // 
            prgLoading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            prgLoading.Location = new Point(155, 27);
            prgLoading.MarqueeAnimationSpeed = 30;
            prgLoading.Name = "prgLoading";
            prgLoading.Size = new Size(320, 24);
            prgLoading.Style = ProgressBarStyle.Marquee;
            prgLoading.TabIndex = 1;
            prgLoading.Visible = false;
            // 
            // pnlWeatherContent
            // 
            pnlWeatherContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlWeatherContent.BackColor = Color.White;
            pnlWeatherContent.BorderStyle = BorderStyle.FixedSingle;
            pnlWeatherContent.Controls.Add(lblWeatherHeader);
            pnlWeatherContent.Controls.Add(lblWeatherIcon);
            pnlWeatherContent.Controls.Add(lblWeatherDesc);
            pnlWeatherContent.Controls.Add(lblTemperature);
            pnlWeatherContent.Controls.Add(lblRainProb);
            pnlWeatherContent.Controls.Add(pnlWarning);
            pnlWeatherContent.Location = new Point(15, 62);
            pnlWeatherContent.Name = "pnlWeatherContent";
            pnlWeatherContent.Size = new Size(460, 240);
            pnlWeatherContent.TabIndex = 2;
            // 
            // lblWeatherHeader
            // 
            lblWeatherHeader.AutoSize = true;
            lblWeatherHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblWeatherHeader.ForeColor = Color.DimGray;
            lblWeatherHeader.Location = new Point(12, 10);
            lblWeatherHeader.Name = "lblWeatherHeader";
            lblWeatherHeader.Size = new Size(198, 17);
            lblWeatherHeader.TabIndex = 0;
            lblWeatherHeader.Text = "Chọn một chuyến đi để xem dự báo";
            // 
            // lblWeatherIcon
            // 
            lblWeatherIcon.Font = new Font("Segoe UI Emoji", 42F);
            lblWeatherIcon.Location = new Point(15, 35);
            lblWeatherIcon.Name = "lblWeatherIcon";
            lblWeatherIcon.Size = new Size(100, 90);
            lblWeatherIcon.TabIndex = 1;
            lblWeatherIcon.Text = "⛅";
            lblWeatherIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWeatherDesc
            // 
            lblWeatherDesc.AutoSize = true;
            lblWeatherDesc.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWeatherDesc.Location = new Point(130, 45);
            lblWeatherDesc.Name = "lblWeatherDesc";
            lblWeatherDesc.Size = new Size(116, 25);
            lblWeatherDesc.TabIndex = 2;
            lblWeatherDesc.Text = "Mô tả thời tiết";
            // 
            // lblTemperature
            // 
            lblTemperature.AutoSize = true;
            lblTemperature.Font = new Font("Segoe UI", 10.5F);
            lblTemperature.Location = new Point(132, 78);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(130, 19);
            lblTemperature.TabIndex = 3;
            lblTemperature.Text = "Nhiệt độ: --°C - --°C";
            // 
            // lblRainProb
            // 
            lblRainProb.AutoSize = true;
            lblRainProb.Font = new Font("Segoe UI", 10.5F);
            lblRainProb.Location = new Point(132, 103);
            lblRainProb.Name = "lblRainProb";
            lblRainProb.Size = new Size(129, 19);
            lblRainProb.TabIndex = 4;
            lblRainProb.Text = "Khả năng mưa: --%";
            // 
            // pnlWarning
            // 
            pnlWarning.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlWarning.BackColor = Color.FromArgb(255, 179, 102);
            pnlWarning.Controls.Add(lblWarningText);
            pnlWarning.Location = new Point(12, 160);
            pnlWarning.Name = "pnlWarning";
            pnlWarning.Size = new Size(434, 65);
            pnlWarning.TabIndex = 5;
            pnlWarning.Visible = false;
            // 
            // lblWarningText
            // 
            lblWarningText.Dock = DockStyle.Fill;
            lblWarningText.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblWarningText.ForeColor = Color.DarkRed;
            lblWarningText.Location = new Point(0, 0);
            lblWarningText.Name = "lblWarningText";
            lblWarningText.Padding = new Padding(10);
            lblWarningText.Size = new Size(434, 65);
            lblWarningText.TabIndex = 0;
            lblWarningText.Text = "⚠ Nên mang áo mưa hoặc cân nhắc dời lịch";
            lblWarningText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFilter
            // 
            pnlFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilter.Controls.Add(txtTimKiem);
            pnlFilter.Controls.Add(chkChuaHoanThanh);
            pnlFilter.Controls.Add(lblTuNgay);
            pnlFilter.Controls.Add(dtpTuNgay);
            pnlFilter.Controls.Add(lblDenNgay);
            pnlFilter.Controls.Add(dtpDenNgay);
            pnlFilter.Controls.Add(btnTimKiem);
            pnlFilter.Controls.Add(btnBoLoc);
            pnlFilter.Location = new Point(16, 370);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1004, 45);
            pnlFilter.TabIndex = 3;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(5, 10);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm theo tên hoặc địa điểm...";
            txtTimKiem.Size = new Size(185, 24);
            txtTimKiem.TabIndex = 0;
            // 
            // chkChuaHoanThanh
            // 
            chkChuaHoanThanh.AutoSize = true;
            chkChuaHoanThanh.Location = new Point(200, 12);
            chkChuaHoanThanh.Name = "chkChuaHoanThanh";
            chkChuaHoanThanh.Size = new Size(198, 21);
            chkChuaHoanThanh.TabIndex = 1;
            chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";
            chkChuaHoanThanh.UseVisualStyleBackColor = true;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(405, 13);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(26, 17);
            lblTuNgay.TabIndex = 2;
            lblTuNgay.Text = "Từ:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(435, 10);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(115, 24);
            dtpTuNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(555, 13);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(34, 17);
            lblDenNgay.TabIndex = 4;
            lblDenNgay.Text = "Đến:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(595, 10);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(115, 24);
            dtpDenNgay.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(720, 7);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(75, 30);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnBoLoc
            // 
            btnBoLoc.Location = new Point(805, 7);
            btnBoLoc.Name = "btnBoLoc";
            btnBoLoc.Size = new Size(75, 30);
            btnBoLoc.TabIndex = 7;
            btnBoLoc.Text = "Bỏ lọc";
            btnBoLoc.UseVisualStyleBackColor = true;
            btnBoLoc.Click += btnBoLoc_Click;
            // 
            // dgvChuyenDi
            // 
            dgvChuyenDi.AllowUserToAddRows = false;
            dgvChuyenDi.AllowUserToDeleteRows = false;
            dgvChuyenDi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChuyenDi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuyenDi.BackgroundColor = Color.White;
            dgvChuyenDi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenDi.Location = new Point(16, 425);
            dgvChuyenDi.MultiSelect = false;
            dgvChuyenDi.Name = "dgvChuyenDi";
            dgvChuyenDi.ReadOnly = true;
            dgvChuyenDi.RowHeadersVisible = false;
            dgvChuyenDi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenDi.Size = new Size(1004, 250);
            dgvChuyenDi.TabIndex = 4;
            dgvChuyenDi.CellClick += dgvChuyenDi_CellClick;
            // 
            // FormChuyenDi
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 687);
            Controls.Add(dgvChuyenDi);
            Controls.Add(pnlFilter);
            Controls.Add(grpThoiTiet);
            Controls.Add(pnlHeaderLang);
            Controls.Add(grpThongTin);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(1000, 680);
            Name = "FormChuyenDi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kế hoạch dã ngoại cuối tuần";
            Load += FormChuyenDi_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNganSach).EndInit();
            pnlHeaderLang.ResumeLayout(false);
            pnlHeaderLang.PerformLayout();
            grpThoiTiet.ResumeLayout(false);
            pnlWeatherContent.ResumeLayout(false);
            pnlWeatherContent.PerformLayout();
            pnlWarning.ResumeLayout(false);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaChuyen;
        private TextBox txtMaChuyen;
        private Label lblTenChuyen;
        private TextBox txtTenChuyen;
        private Label lblDiaDiem;
        private TextBox txtDiaDiem;
        private Label lblNgayDi;
        private DateTimePicker dtpNgayDi;
        private Label lblSoNguoi;
        private NumericUpDown nudSoNguoi;
        private Label lblNganSach;
        private NumericUpDown nudNganSach;
        private Label lblPhuongTien;
        private ComboBox cboPhuongTien;
        private CheckBox chkDaHoanThanh;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Panel pnlHeaderLang;
        private Label lblNgonNgu;
        private ComboBox cboNgonNgu;
        private GroupBox grpThoiTiet;
        private Button btnXemThoiTiet;
        private ProgressBar prgLoading;
        private Panel pnlWeatherContent;
        private Label lblWeatherHeader;
        private Label lblWeatherIcon;
        private Label lblWeatherDesc;
        private Label lblTemperature;
        private Label lblRainProb;
        private Panel pnlWarning;
        private Label lblWarningText;
        private Panel pnlFilter;
        private TextBox txtTimKiem;
        private CheckBox chkChuaHoanThanh;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnTimKiem;
        private Button btnBoLoc;
        private DataGridView dgvChuyenDi;
    }
}
