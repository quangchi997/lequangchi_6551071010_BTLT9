namespace Cau1_SoChiTieu
{
    partial class FormChiTieu
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
            lblMaCT = new Label();
            txtMaCT = new TextBox();
            lblNgayChi = new Label();
            dtpNgayChi = new DateTimePicker();
            lblNoiDung = new Label();
            txtNoiDung = new TextBox();
            lblLoaiChi = new Label();
            cboLoaiChi = new ComboBox();
            lblSoTien = new Label();
            nudSoTien = new NumericUpDown();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            grpTimKiem = new GroupBox();
            lblTimNoiDung = new Label();
            txtTimNoiDung = new TextBox();
            lblLocLoaiChi = new Label();
            cboLocLoaiChi = new ComboBox();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            btnTimKiem = new Button();
            btnBoLoc = new Button();
            dgvChiTieu = new DataGridView();
            lblTongChi = new Label();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTien).BeginInit();
            grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTieu).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblMaCT);
            grpThongTin.Controls.Add(txtMaCT);
            grpThongTin.Controls.Add(lblNgayChi);
            grpThongTin.Controls.Add(dtpNgayChi);
            grpThongTin.Controls.Add(lblNoiDung);
            grpThongTin.Controls.Add(txtNoiDung);
            grpThongTin.Controls.Add(lblLoaiChi);
            grpThongTin.Controls.Add(cboLoaiChi);
            grpThongTin.Controls.Add(lblSoTien);
            grpThongTin.Controls.Add(nudSoTien);
            grpThongTin.Controls.Add(lblGhiChu);
            grpThongTin.Controls.Add(txtGhiChu);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Font = new Font("Segoe UI", 9.5F);
            grpThongTin.Location = new Point(16, 15);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(480, 260);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin khoản chi";
            // 
            // lblMaCT
            // 
            lblMaCT.AutoSize = true;
            lblMaCT.Location = new Point(15, 28);
            lblMaCT.Name = "lblMaCT";
            lblMaCT.Size = new Size(48, 17);
            lblMaCT.TabIndex = 0;
            lblMaCT.Text = "Mã CT:";
            // 
            // txtMaCT
            // 
            txtMaCT.Location = new Point(90, 25);
            txtMaCT.Name = "txtMaCT";
            txtMaCT.ReadOnly = true;
            txtMaCT.Size = new Size(140, 24);
            txtMaCT.TabIndex = 1;
            // 
            // lblNgayChi
            // 
            lblNgayChi.AutoSize = true;
            lblNgayChi.Location = new Point(245, 28);
            lblNgayChi.Name = "lblNgayChi";
            lblNgayChi.Size = new Size(62, 17);
            lblNgayChi.TabIndex = 2;
            lblNgayChi.Text = "Ngày chi:";
            // 
            // dtpNgayChi
            // 
            dtpNgayChi.CustomFormat = "dd/MM/yyyy";
            dtpNgayChi.Format = DateTimePickerFormat.Custom;
            dtpNgayChi.Location = new Point(315, 25);
            dtpNgayChi.Name = "dtpNgayChi";
            dtpNgayChi.Size = new Size(150, 24);
            dtpNgayChi.TabIndex = 3;
            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Location = new Point(15, 62);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(66, 17);
            lblNoiDung.TabIndex = 4;
            lblNoiDung.Text = "Nội dung:";
            // 
            // txtNoiDung
            // 
            txtNoiDung.Location = new Point(90, 59);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(375, 24);
            txtNoiDung.TabIndex = 5;
            // 
            // lblLoaiChi
            // 
            lblLoaiChi.AutoSize = true;
            lblLoaiChi.Location = new Point(15, 96);
            lblLoaiChi.Name = "lblLoaiChi";
            lblLoaiChi.Size = new Size(56, 17);
            lblLoaiChi.TabIndex = 6;
            lblLoaiChi.Text = "Loại chi:";
            // 
            // cboLoaiChi
            // 
            cboLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiChi.FormattingEnabled = true;
            cboLoaiChi.Items.AddRange(new object[] { "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác" });
            cboLoaiChi.Location = new Point(90, 93);
            cboLoaiChi.Name = "cboLoaiChi";
            cboLoaiChi.Size = new Size(140, 25);
            cboLoaiChi.TabIndex = 7;
            // 
            // lblSoTien
            // 
            lblSoTien.AutoSize = true;
            lblSoTien.Location = new Point(245, 96);
            lblSoTien.Name = "lblSoTien";
            lblSoTien.Size = new Size(51, 17);
            lblSoTien.TabIndex = 8;
            lblSoTien.Text = "Số tiền:";
            // 
            // nudSoTien
            // 
            nudSoTien.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nudSoTien.Location = new Point(315, 93);
            nudSoTien.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudSoTien.Name = "nudSoTien";
            nudSoTien.Size = new Size(150, 24);
            nudSoTien.TabIndex = 9;
            nudSoTien.ThousandsSeparator = true;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(15, 130);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(54, 17);
            lblGhiChu.TabIndex = 10;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(90, 127);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.ScrollBars = ScrollBars.Vertical;
            txtGhiChu.Size = new Size(375, 75);
            txtGhiChu.TabIndex = 11;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(90, 215);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(85, 32);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(185, 215);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(85, 32);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(280, 215);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(85, 32);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(375, 215);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // grpTimKiem
            // 
            grpTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTimKiem.Controls.Add(lblTimNoiDung);
            grpTimKiem.Controls.Add(txtTimNoiDung);
            grpTimKiem.Controls.Add(lblLocLoaiChi);
            grpTimKiem.Controls.Add(cboLocLoaiChi);
            grpTimKiem.Controls.Add(lblTuNgay);
            grpTimKiem.Controls.Add(dtpTuNgay);
            grpTimKiem.Controls.Add(lblDenNgay);
            grpTimKiem.Controls.Add(dtpDenNgay);
            grpTimKiem.Controls.Add(btnTimKiem);
            grpTimKiem.Controls.Add(btnBoLoc);
            grpTimKiem.Font = new Font("Segoe UI", 9.5F);
            grpTimKiem.Location = new Point(510, 15);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new Size(410, 260);
            grpTimKiem.TabIndex = 1;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "Tìm kiếm / Lọc";
            // 
            // lblTimNoiDung
            // 
            lblTimNoiDung.AutoSize = true;
            lblTimNoiDung.Location = new Point(15, 28);
            lblTimNoiDung.Name = "lblTimNoiDung";
            lblTimNoiDung.Size = new Size(66, 17);
            lblTimNoiDung.TabIndex = 0;
            lblTimNoiDung.Text = "Nội dung:";
            // 
            // txtTimNoiDung
            // 
            txtTimNoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimNoiDung.Location = new Point(90, 25);
            txtTimNoiDung.Name = "txtTimNoiDung";
            txtTimNoiDung.PlaceholderText = "Nhập nội dung tìm kiếm...";
            txtTimNoiDung.Size = new Size(305, 24);
            txtTimNoiDung.TabIndex = 1;
            // 
            // lblLocLoaiChi
            // 
            lblLocLoaiChi.AutoSize = true;
            lblLocLoaiChi.Location = new Point(15, 62);
            lblLocLoaiChi.Name = "lblLocLoaiChi";
            lblLocLoaiChi.Size = new Size(56, 17);
            lblLocLoaiChi.TabIndex = 2;
            lblLocLoaiChi.Text = "Loại chi:";
            // 
            // cboLocLoaiChi
            // 
            cboLocLoaiChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboLocLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoaiChi.FormattingEnabled = true;
            cboLocLoaiChi.Items.AddRange(new object[] { "Tất cả", "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác" });
            cboLocLoaiChi.Location = new Point(90, 59);
            cboLocLoaiChi.Name = "cboLocLoaiChi";
            cboLocLoaiChi.Size = new Size(305, 25);
            cboLocLoaiChi.TabIndex = 3;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(15, 96);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(58, 17);
            lblTuNgay.TabIndex = 4;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(90, 93);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(305, 24);
            dtpTuNgay.TabIndex = 5;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(15, 130);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(66, 17);
            lblDenNgay.TabIndex = 6;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(90, 127);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(305, 24);
            dtpDenNgay.TabIndex = 7;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(90, 170);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 32);
            btnTimKiem.TabIndex = 8;
            btnTimKiem.Text = "Tìm kiếm / Lọc";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnBoLoc
            // 
            btnBoLoc.Location = new Point(210, 170);
            btnBoLoc.Name = "btnBoLoc";
            btnBoLoc.Size = new Size(95, 32);
            btnBoLoc.TabIndex = 9;
            btnBoLoc.Text = "Bỏ lọc";
            btnBoLoc.UseVisualStyleBackColor = true;
            btnBoLoc.Click += btnBoLoc_Click;
            // 
            // dgvChiTieu
            // 
            dgvChiTieu.AllowUserToAddRows = false;
            dgvChiTieu.AllowUserToDeleteRows = false;
            dgvChiTieu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTieu.BackgroundColor = Color.White;
            dgvChiTieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTieu.Location = new Point(16, 290);
            dgvChiTieu.MultiSelect = false;
            dgvChiTieu.Name = "dgvChiTieu";
            dgvChiTieu.ReadOnly = true;
            dgvChiTieu.RowHeadersVisible = false;
            dgvChiTieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTieu.Size = new Size(904, 280);
            dgvChiTieu.TabIndex = 2;
            dgvChiTieu.CellClick += dgvChiTieu_CellClick;
            // 
            // lblTongChi
            // 
            lblTongChi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTongChi.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTongChi.ForeColor = Color.Red;
            lblTongChi.Location = new Point(450, 580);
            lblTongChi.Name = "lblTongChi";
            lblTongChi.Size = new Size(470, 30);
            lblTongChi.TabIndex = 3;
            lblTongChi.Text = "Tổng chi: 0 đ";
            lblTongChi.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormChiTieu
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 620);
            Controls.Add(lblTongChi);
            Controls.Add(dgvChiTieu);
            Controls.Add(grpTimKiem);
            Controls.Add(grpThongTin);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(950, 650);
            Name = "FormChiTieu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sổ chi tiêu cá nhân";
            Load += FormChiTieu_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTien).EndInit();
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTieu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaCT;
        private TextBox txtMaCT;
        private Label lblNgayChi;
        private DateTimePicker dtpNgayChi;
        private Label lblNoiDung;
        private TextBox txtNoiDung;
        private Label lblLoaiChi;
        private ComboBox cboLoaiChi;
        private Label lblSoTien;
        private NumericUpDown nudSoTien;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private GroupBox grpTimKiem;
        private Label lblTimNoiDung;
        private TextBox txtTimNoiDung;
        private Label lblLocLoaiChi;
        private ComboBox cboLocLoaiChi;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnTimKiem;
        private Button btnBoLoc;
        private DataGridView dgvChiTieu;
        private Label lblTongChi;
    }
}
