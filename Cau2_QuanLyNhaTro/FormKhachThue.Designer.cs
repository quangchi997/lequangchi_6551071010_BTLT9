namespace Cau2_QuanLyNhaTro
{
    partial class FormKhachThue
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
            lblMaKhach = new Label();
            txtMaKhach = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            grpGioiTinh = new GroupBox();
            radNam = new RadioButton();
            radNu = new RadioButton();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblPhong = new Label();
            cboPhong = new ComboBox();
            lblTinhThanh = new Label();
            cboTinhThanh = new ComboBox();
            lblPhuongXa = new Label();
            cboPhuongXa = new ComboBox();
            txtPhuongXaThuCong = new TextBox();
            chkTamTru = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnGayLoi = new Button();
            grpTimKiem = new GroupBox();
            lblTimTuKhoa = new Label();
            txtTimTuKhoa = new TextBox();
            lblLocPhong = new Label();
            cboLocPhong = new ComboBox();
            lblLocTinh = new Label();
            cboLocTinh = new ComboBox();
            btnTimKiem = new Button();
            btnBoLoc = new Button();
            dgvKhachThue = new DataGridView();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            grpThongTin.SuspendLayout();
            grpGioiTinh.SuspendLayout();
            grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachThue).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblMaKhach);
            grpThongTin.Controls.Add(txtMaKhach);
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(grpGioiTinh);
            grpThongTin.Controls.Add(lblNgaySinh);
            grpThongTin.Controls.Add(dtpNgaySinh);
            grpThongTin.Controls.Add(lblSoDienThoai);
            grpThongTin.Controls.Add(txtSoDienThoai);
            grpThongTin.Controls.Add(lblPhong);
            grpThongTin.Controls.Add(cboPhong);
            grpThongTin.Controls.Add(lblTinhThanh);
            grpThongTin.Controls.Add(cboTinhThanh);
            grpThongTin.Controls.Add(lblPhuongXa);
            grpThongTin.Controls.Add(cboPhuongXa);
            grpThongTin.Controls.Add(txtPhuongXaThuCong);
            grpThongTin.Controls.Add(chkTamTru);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Controls.Add(btnGayLoi);
            grpThongTin.Font = new Font("Segoe UI", 9.5F);
            grpThongTin.Location = new Point(14, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(390, 480);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin khách thuê";
            // 
            // lblMaKhach
            // 
            lblMaKhach.AutoSize = true;
            lblMaKhach.Location = new Point(15, 26);
            lblMaKhach.Name = "lblMaKhach";
            lblMaKhach.Size = new Size(68, 17);
            lblMaKhach.TabIndex = 0;
            lblMaKhach.Text = "Mã khách:";
            // 
            // txtMaKhach
            // 
            txtMaKhach.Location = new Point(110, 23);
            txtMaKhach.Name = "txtMaKhach";
            txtMaKhach.ReadOnly = true;
            txtMaKhach.Size = new Size(260, 24);
            txtMaKhach.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(15, 60);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(50, 17);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(110, 57);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(260, 24);
            txtHoTen.TabIndex = 3;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(radNam);
            grpGioiTinh.Controls.Add(radNu);
            grpGioiTinh.Location = new Point(110, 87);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(260, 42);
            grpGioiTinh.TabIndex = 4;
            grpGioiTinh.TabStop = false;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Checked = true;
            radNam.Location = new Point(25, 15);
            radNam.Name = "radNam";
            radNam.Size = new Size(54, 21);
            radNam.TabIndex = 0;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(130, 15);
            radNu.Name = "radNu";
            radNu.Size = new Size(44, 21);
            radNu.TabIndex = 1;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(15, 142);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(69, 17);
            lblNgaySinh.TabIndex = 5;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(110, 137);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(260, 24);
            dtpNgaySinh.TabIndex = 6;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(15, 177);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(88, 17);
            lblSoDienThoai.TabIndex = 7;
            lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(110, 174);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(260, 24);
            txtSoDienThoai.TabIndex = 8;
            // 
            // lblPhong
            // 
            lblPhong.AutoSize = true;
            lblPhong.Location = new Point(15, 212);
            lblPhong.Name = "lblPhong";
            lblPhong.Size = new Size(48, 17);
            lblPhong.TabIndex = 9;
            lblPhong.Text = "Phòng:";
            // 
            // cboPhong
            // 
            cboPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(110, 209);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(260, 25);
            cboPhong.TabIndex = 10;
            // 
            // lblTinhThanh
            // 
            lblTinhThanh.AutoSize = true;
            lblTinhThanh.Location = new Point(15, 247);
            lblTinhThanh.Name = "lblTinhThanh";
            lblTinhThanh.Size = new Size(74, 17);
            lblTinhThanh.TabIndex = 11;
            lblTinhThanh.Text = "Tỉnh/Thành:";
            // 
            // cboTinhThanh
            // 
            cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinhThanh.FormattingEnabled = true;
            cboTinhThanh.Location = new Point(110, 244);
            cboTinhThanh.Name = "cboTinhThanh";
            cboTinhThanh.Size = new Size(260, 25);
            cboTinhThanh.TabIndex = 12;
            cboTinhThanh.SelectedIndexChanged += cboTinhThanh_SelectedIndexChanged;
            // 
            // lblPhuongXa
            // 
            lblPhuongXa.AutoSize = true;
            lblPhuongXa.Location = new Point(15, 282);
            lblPhuongXa.Name = "lblPhuongXa";
            lblPhuongXa.Size = new Size(77, 17);
            lblPhuongXa.TabIndex = 13;
            lblPhuongXa.Text = "Phường/Xã:";
            // 
            // cboPhuongXa
            // 
            cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongXa.FormattingEnabled = true;
            cboPhuongXa.Location = new Point(110, 279);
            cboPhuongXa.Name = "cboPhuongXa";
            cboPhuongXa.Size = new Size(260, 25);
            cboPhuongXa.TabIndex = 14;
            // 
            // txtPhuongXaThuCong
            // 
            txtPhuongXaThuCong.Location = new Point(110, 310);
            txtPhuongXaThuCong.Name = "txtPhuongXaThuCong";
            txtPhuongXaThuCong.PlaceholderText = "Nhập tay nếu không có mạng...";
            txtPhuongXaThuCong.Size = new Size(260, 24);
            txtPhuongXaThuCong.TabIndex = 15;
            // 
            // chkTamTru
            // 
            chkTamTru.AutoSize = true;
            chkTamTru.Location = new Point(110, 345);
            chkTamTru.Name = "chkTamTru";
            chkTamTru.Size = new Size(137, 21);
            chkTamTru.TabIndex = 16;
            chkTamTru.Text = "Đã đăng ký tạm trú";
            chkTamTru.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(15, 385);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 32);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(105, 385);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 32);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(195, 385);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(80, 32);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(285, 385);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(85, 32);
            btnLamMoi.TabIndex = 20;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnGayLoi
            // 
            btnGayLoi.BackColor = Color.MistyRose;
            btnGayLoi.FlatStyle = FlatStyle.Flat;
            btnGayLoi.ForeColor = Color.DarkRed;
            btnGayLoi.Location = new Point(15, 430);
            btnGayLoi.Name = "btnGayLoi";
            btnGayLoi.Size = new Size(355, 32);
            btnGayLoi.TabIndex = 21;
            btnGayLoi.Text = "⚠ Gây lỗi thử (Kiểm tra xử lý ngoại lệ toàn cục)";
            btnGayLoi.UseVisualStyleBackColor = false;
            btnGayLoi.Click += btnGayLoi_Click;
            // 
            // grpTimKiem
            // 
            grpTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTimKiem.Controls.Add(lblTimTuKhoa);
            grpTimKiem.Controls.Add(txtTimTuKhoa);
            grpTimKiem.Controls.Add(lblLocPhong);
            grpTimKiem.Controls.Add(cboLocPhong);
            grpTimKiem.Controls.Add(lblLocTinh);
            grpTimKiem.Controls.Add(cboLocTinh);
            grpTimKiem.Controls.Add(btnTimKiem);
            grpTimKiem.Controls.Add(btnBoLoc);
            grpTimKiem.Font = new Font("Segoe UI", 9.5F);
            grpTimKiem.Location = new Point(415, 12);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new Size(625, 95);
            grpTimKiem.TabIndex = 1;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "Tìm kiếm & Lọc";
            // 
            // lblTimTuKhoa
            // 
            lblTimTuKhoa.AutoSize = true;
            lblTimTuKhoa.Location = new Point(12, 26);
            lblTimTuKhoa.Name = "lblTimTuKhoa";
            lblTimTuKhoa.Size = new Size(82, 17);
            lblTimTuKhoa.TabIndex = 0;
            lblTimTuKhoa.Text = "Tên hoặc SĐT:";
            // 
            // txtTimTuKhoa
            // 
            txtTimTuKhoa.Location = new Point(98, 23);
            txtTimTuKhoa.Name = "txtTimTuKhoa";
            txtTimTuKhoa.PlaceholderText = "Nhập tên hoặc SĐT...";
            txtTimTuKhoa.Size = new Size(160, 24);
            txtTimTuKhoa.TabIndex = 1;
            // 
            // lblLocPhong
            // 
            lblLocPhong.AutoSize = true;
            lblLocPhong.Location = new Point(270, 26);
            lblLocPhong.Name = "lblLocPhong";
            lblLocPhong.Size = new Size(48, 17);
            lblLocPhong.TabIndex = 2;
            lblLocPhong.Text = "Phòng:";
            // 
            // cboLocPhong
            // 
            cboLocPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocPhong.FormattingEnabled = true;
            cboLocPhong.Location = new Point(325, 23);
            cboLocPhong.Name = "cboLocPhong";
            cboLocPhong.Size = new Size(120, 25);
            cboLocPhong.TabIndex = 3;
            // 
            // lblLocTinh
            // 
            lblLocTinh.AutoSize = true;
            lblLocTinh.Location = new Point(12, 60);
            lblLocTinh.Name = "lblLocTinh";
            lblLocTinh.Size = new Size(74, 17);
            lblLocTinh.TabIndex = 4;
            lblLocTinh.Text = "Tỉnh/Thành:";
            // 
            // cboLocTinh
            // 
            cboLocTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTinh.FormattingEnabled = true;
            cboLocTinh.Location = new Point(98, 57);
            cboLocTinh.Name = "cboLocTinh";
            cboLocTinh.Size = new Size(220, 25);
            cboLocTinh.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(335, 54);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(80, 30);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnBoLoc
            // 
            btnBoLoc.Location = new Point(425, 54);
            btnBoLoc.Name = "btnBoLoc";
            btnBoLoc.Size = new Size(80, 30);
            btnBoLoc.TabIndex = 7;
            btnBoLoc.Text = "Bỏ lọc";
            btnBoLoc.UseVisualStyleBackColor = true;
            btnBoLoc.Click += btnBoLoc_Click;
            // 
            // dgvKhachThue
            // 
            dgvKhachThue.AllowUserToAddRows = false;
            dgvKhachThue.AllowUserToDeleteRows = false;
            dgvKhachThue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhachThue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachThue.BackgroundColor = Color.White;
            dgvKhachThue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachThue.Location = new Point(415, 115);
            dgvKhachThue.MultiSelect = false;
            dgvKhachThue.Name = "dgvKhachThue";
            dgvKhachThue.ReadOnly = true;
            dgvKhachThue.RowHeadersVisible = false;
            dgvKhachThue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachThue.Size = new Size(625, 377);
            dgvKhachThue.TabIndex = 2;
            dgvKhachThue.CellClick += dgvKhachThue_CellClick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 502);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1054, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(59, 17);
            lblStatus.Text = "Sẵn sàng.";
            // 
            // FormKhachThue
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 524);
            Controls.Add(statusStrip1);
            Controls.Add(dgvKhachThue);
            Controls.Add(grpTimKiem);
            Controls.Add(grpThongTin);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(1000, 560);
            Name = "FormKhachThue";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhà trọ - Khách thuê";
            Load += FormKhachThue_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachThue).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaKhach;
        private TextBox txtMaKhach;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private GroupBox grpGioiTinh;
        private RadioButton radNam;
        private RadioButton radNu;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblPhong;
        private ComboBox cboPhong;
        private Label lblTinhThanh;
        private ComboBox cboTinhThanh;
        private Label lblPhuongXa;
        private ComboBox cboPhuongXa;
        private TextBox txtPhuongXaThuCong;
        private CheckBox chkTamTru;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnGayLoi;
        private GroupBox grpTimKiem;
        private Label lblTimTuKhoa;
        private TextBox txtTimTuKhoa;
        private Label lblLocPhong;
        private ComboBox cboLocPhong;
        private Label lblLocTinh;
        private ComboBox cboLocTinh;
        private Button btnTimKiem;
        private Button btnBoLoc;
        private DataGridView dgvKhachThue;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}
