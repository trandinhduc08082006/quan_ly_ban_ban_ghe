namespace QuanLyBanBanGhe.GUI.Forms.DanhMuc
{
    partial class frmNhanVien
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

        private void InitializeComponent()
        {
            this.pnlTopContainer = new System.Windows.Forms.Panel();
            this.grpThongTinNhanVien = new System.Windows.Forms.GroupBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.pnlGioiTinh = new System.Windows.Forms.Panel();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblCongViec = new System.Windows.Forms.Label();
            this.cboCongViec = new System.Windows.Forms.ComboBox();
            this.lblLuong = new System.Windows.Forms.Label();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.grpTaiKhoan = new System.Windows.Forms.GroupBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblQuyen = new System.Windows.Forms.Label();
            this.cboQuyen = new System.Windows.Forms.ComboBox();
            this.lblMatKhauMoi = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.btnResetMatKhau = new System.Windows.Forms.Button();
            this.chkTrangThaiHoatDong = new System.Windows.Forms.CheckBox();
            this.pnlChucNang = new System.Windows.Forms.Panel();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.colMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCongViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTopContainer.SuspendLayout();
            this.grpThongTinNhanVien.SuspendLayout();
            this.pnlGioiTinh.SuspendLayout();
            this.grpTaiKhoan.SuspendLayout();
            this.pnlChucNang.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();

            this.pnlTopContainer.Controls.Add(this.grpThongTinNhanVien);
            this.pnlTopContainer.Controls.Add(this.grpTaiKhoan);
            this.pnlTopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopContainer.Location = new System.Drawing.Point(10, 10);
            this.pnlTopContainer.Name = "pnlTopContainer";
            this.pnlTopContainer.Size = new System.Drawing.Size(1100, 240);
            this.pnlTopContainer.TabIndex = 0;

            this.grpThongTinNhanVien.Controls.Add(this.lblMaNV);
            this.grpThongTinNhanVien.Controls.Add(this.txtMaNV);
            this.grpThongTinNhanVien.Controls.Add(this.lblTenNV);
            this.grpThongTinNhanVien.Controls.Add(this.txtTenNV);
            this.grpThongTinNhanVien.Controls.Add(this.lblGioiTinh);
            this.grpThongTinNhanVien.Controls.Add(this.pnlGioiTinh);
            this.grpThongTinNhanVien.Controls.Add(this.lblNgaySinh);
            this.grpThongTinNhanVien.Controls.Add(this.dtpNgaySinh);
            this.grpThongTinNhanVien.Controls.Add(this.lblDienThoai);
            this.grpThongTinNhanVien.Controls.Add(this.txtDienThoai);
            this.grpThongTinNhanVien.Controls.Add(this.lblDiaChi);
            this.grpThongTinNhanVien.Controls.Add(this.txtDiaChi);
            this.grpThongTinNhanVien.Controls.Add(this.lblCongViec);
            this.grpThongTinNhanVien.Controls.Add(this.cboCongViec);
            this.grpThongTinNhanVien.Controls.Add(this.lblLuong);
            this.grpThongTinNhanVien.Controls.Add(this.txtLuong);
            this.grpThongTinNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTinNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinNhanVien.Location = new System.Drawing.Point(0, 0);
            this.grpThongTinNhanVien.Name = "grpThongTinNhanVien";
            this.grpThongTinNhanVien.Size = new System.Drawing.Size(730, 240);
            this.grpThongTinNhanVien.TabIndex = 0;
            this.grpThongTinNhanVien.TabStop = false;
            this.grpThongTinNhanVien.Text = "Thông tin nhân viên";

            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(15, 28);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(89, 17);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã nhân viên:";

            this.txtMaNV.Location = new System.Drawing.Point(115, 25);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(180, 24);
            this.txtMaNV.TabIndex = 1;

            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Location = new System.Drawing.Point(325, 28);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(67, 17);
            this.lblTenNV.TabIndex = 2;
            this.lblTenNV.Text = "Họ và tên:";

            this.txtTenNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNV.Location = new System.Drawing.Point(415, 25);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(295, 24);
            this.txtTenNV.TabIndex = 3;

            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(15, 68);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(59, 17);
            this.lblGioiTinh.TabIndex = 4;
            this.lblGioiTinh.Text = "Giới tính:";

            this.pnlGioiTinh.Controls.Add(this.radNam);
            this.pnlGioiTinh.Controls.Add(this.radNu);
            this.pnlGioiTinh.Location = new System.Drawing.Point(115, 63);
            this.pnlGioiTinh.Name = "pnlGioiTinh";
            this.pnlGioiTinh.Size = new System.Drawing.Size(180, 27);
            this.pnlGioiTinh.TabIndex = 5;

            this.radNam.AutoSize = true;
            this.radNam.Checked = true;
            this.radNam.Location = new System.Drawing.Point(3, 3);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(54, 21);
            this.radNam.TabIndex = 0;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;

            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(75, 3);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(44, 21);
            this.radNu.TabIndex = 1;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;

            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(325, 68);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(69, 17);
            this.lblNgaySinh.TabIndex = 6;
            this.lblNgaySinh.Text = "Ngày sinh:";

            this.dtpNgaySinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(415, 65);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(295, 24);
            this.dtpNgaySinh.TabIndex = 7;

            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(15, 108);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(70, 17);
            this.lblDienThoai.TabIndex = 8;
            this.lblDienThoai.Text = "Điện thoại:";

            this.txtDienThoai.Location = new System.Drawing.Point(115, 105);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(180, 24);
            this.txtDienThoai.TabIndex = 9;

            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(325, 108);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(50, 17);
            this.lblDiaChi.TabIndex = 10;
            this.lblDiaChi.Text = "Địa chỉ:";

            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Location = new System.Drawing.Point(415, 105);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(295, 24);
            this.txtDiaChi.TabIndex = 11;

            this.lblCongViec.AutoSize = true;
            this.lblCongViec.Location = new System.Drawing.Point(15, 148);
            this.lblCongViec.Name = "lblCongViec";
            this.lblCongViec.Size = new System.Drawing.Size(57, 17);
            this.lblCongViec.TabIndex = 12;
            this.lblCongViec.Text = "Chức vụ:";

            this.cboCongViec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCongViec.FormattingEnabled = true;
            this.cboCongViec.Location = new System.Drawing.Point(115, 145);
            this.cboCongViec.Name = "cboCongViec";
            this.cboCongViec.Size = new System.Drawing.Size(180, 25);
            this.cboCongViec.TabIndex = 13;
            this.cboCongViec.SelectedIndexChanged += new System.EventHandler(this.cboCongViec_SelectedIndexChanged);

            this.lblLuong.AutoSize = true;
            this.lblLuong.Location = new System.Drawing.Point(325, 148);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(74, 17);
            this.lblLuong.TabIndex = 14;
            this.lblLuong.Text = "Mức lương:";

            this.txtLuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLuong.Location = new System.Drawing.Point(415, 145);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(295, 24);
            this.txtLuong.TabIndex = 15;

            this.grpTaiKhoan.Controls.Add(this.lblTenDangNhap);
            this.grpTaiKhoan.Controls.Add(this.txtTenDangNhap);
            this.grpTaiKhoan.Controls.Add(this.lblQuyen);
            this.grpTaiKhoan.Controls.Add(this.cboQuyen);
            this.grpTaiKhoan.Controls.Add(this.lblMatKhauMoi);
            this.grpTaiKhoan.Controls.Add(this.txtMatKhauMoi);
            this.grpTaiKhoan.Controls.Add(this.btnResetMatKhau);
            this.grpTaiKhoan.Controls.Add(this.chkTrangThaiHoatDong);
            this.grpTaiKhoan.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTaiKhoan.Location = new System.Drawing.Point(730, 0);
            this.grpTaiKhoan.Name = "grpTaiKhoan";
            this.grpTaiKhoan.Size = new System.Drawing.Size(370, 240);
            this.grpTaiKhoan.TabIndex = 1;
            this.grpTaiKhoan.TabStop = false;
            this.grpTaiKhoan.Text = "Tài khoản hệ thống";

            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(15, 28);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(98, 17);
            this.lblTenDangNhap.TabIndex = 0;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";

            this.txtTenDangNhap.Location = new System.Drawing.Point(125, 25);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(225, 24);
            this.txtTenDangNhap.TabIndex = 1;

            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Location = new System.Drawing.Point(15, 68);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(67, 17);
            this.lblQuyen.TabIndex = 2;
            this.lblQuyen.Text = "Quyền hạn:";

            this.cboQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuyen.FormattingEnabled = true;
            this.cboQuyen.Location = new System.Drawing.Point(125, 65);
            this.cboQuyen.Name = "cboQuyen";
            this.cboQuyen.Size = new System.Drawing.Size(225, 25);
            this.cboQuyen.TabIndex = 3;

            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Location = new System.Drawing.Point(15, 108);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Size = new System.Drawing.Size(91, 17);
            this.lblMatKhauMoi.TabIndex = 4;
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";

            this.txtMatKhauMoi.Location = new System.Drawing.Point(125, 105);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(225, 24);
            this.txtMatKhauMoi.TabIndex = 5;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;

            this.btnResetMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnResetMatKhau.Location = new System.Drawing.Point(125, 145);
            this.btnResetMatKhau.Name = "btnResetMatKhau";
            this.btnResetMatKhau.Size = new System.Drawing.Size(225, 30);
            this.btnResetMatKhau.TabIndex = 6;
            this.btnResetMatKhau.Text = "Reset mật khẩu";
            this.btnResetMatKhau.UseVisualStyleBackColor = true;
            this.btnResetMatKhau.Click += new System.EventHandler(this.btnResetMatKhau_Click);

            this.chkTrangThaiHoatDong.AutoSize = true;
            this.chkTrangThaiHoatDong.Checked = true;
            this.chkTrangThaiHoatDong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThaiHoatDong.Location = new System.Drawing.Point(125, 190);
            this.chkTrangThaiHoatDong.Name = "chkTrangThaiHoatDong";
            this.chkTrangThaiHoatDong.Size = new System.Drawing.Size(180, 21);
            this.chkTrangThaiHoatDong.TabIndex = 7;
            this.chkTrangThaiHoatDong.Text = "Tài khoản đang hoạt động";
            this.chkTrangThaiHoatDong.UseVisualStyleBackColor = true;

            this.pnlChucNang.Controls.Add(this.flpButtons);
            this.pnlChucNang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChucNang.Location = new System.Drawing.Point(10, 250);
            this.pnlChucNang.Name = "pnlChucNang";
            this.pnlChucNang.Size = new System.Drawing.Size(1100, 48);
            this.pnlChucNang.TabIndex = 1;

            this.flpButtons.Controls.Add(this.btnThem);
            this.flpButtons.Controls.Add(this.btnSua);
            this.flpButtons.Controls.Add(this.btnXoa);
            this.flpButtons.Controls.Add(this.btnLuu);
            this.flpButtons.Controls.Add(this.btnBoQua);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.Location = new System.Drawing.Point(0, 0);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.flpButtons.Size = new System.Drawing.Size(1100, 48);
            this.flpButtons.TabIndex = 0;

            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(0, 8);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 32);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(105, 8);
            this.btnSua.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 32);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(210, 8);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 32);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(315, 8);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(95, 32);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            this.btnBoQua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoQua.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnBoQua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoQua.Location = new System.Drawing.Point(420, 8);
            this.btnBoQua.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(95, 32);
            this.btnBoQua.TabIndex = 4;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);

            this.grpDanhSach.Controls.Add(this.dgvNhanVien);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSach.Location = new System.Drawing.Point(10, 298);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(10);
            this.grpDanhSach.Size = new System.Drawing.Size(1100, 392);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách nhân viên";

            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNV,
            this.colTenNV,
            this.colGioiTinh,
            this.colNgaySinh,
            this.colDienThoai,
            this.colDiaChi,
            this.colCongViec,
            this.colLuong,
            this.colTenDangNhap,
            this.colQuyen,
            this.colTrangThai});
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.Location = new System.Drawing.Point(10, 27);
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersWidth = 35;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(1080, 355);
            this.dgvNhanVien.TabIndex = 0;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);

            this.colMaNV.DataPropertyName = "ma_nhan_vien";
            this.colMaNV.HeaderText = "Mã NV";
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.ReadOnly = true;
            this.colMaNV.Width = 90;

            this.colTenNV.DataPropertyName = "ten_nhan_vien";
            this.colTenNV.HeaderText = "Họ và tên";
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.ReadOnly = true;
            this.colTenNV.Width = 160;

            this.colGioiTinh.DataPropertyName = "gioi_tinh";
            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;
            this.colGioiTinh.Width = 80;

            this.colNgaySinh.DataPropertyName = "ngay_sinh";
            this.colNgaySinh.HeaderText = "Ngày sinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.ReadOnly = true;
            this.colNgaySinh.Width = 95;

            this.colDienThoai.DataPropertyName = "dien_thoai";
            this.colDienThoai.HeaderText = "Điện thoại";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.ReadOnly = true;
            this.colDienThoai.Width = 100;

            this.colDiaChi.DataPropertyName = "dia_chi";
            this.colDiaChi.HeaderText = "Địa chỉ";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.ReadOnly = true;
            this.colDiaChi.Width = 150;

            this.colCongViec.DataPropertyName = "ten_cong_viec";
            this.colCongViec.HeaderText = "Chức vụ";
            this.colCongViec.Name = "colCongViec";
            this.colCongViec.ReadOnly = true;
            this.colCongViec.Width = 110;

            this.colLuong.DataPropertyName = "muc_luong";
            this.colLuong.HeaderText = "Mức lương";
            this.colLuong.Name = "colLuong";
            this.colLuong.ReadOnly = true;
            this.colLuong.Width = 105;

            this.colTenDangNhap.DataPropertyName = "ten_dang_nhap";
            this.colTenDangNhap.HeaderText = "Tên đăng nhập";
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.ReadOnly = true;
            this.colTenDangNhap.Width = 110;

            this.colQuyen.DataPropertyName = "quyen";
            this.colQuyen.HeaderText = "Quyền";
            this.colQuyen.Name = "colQuyen";
            this.colQuyen.ReadOnly = true;
            this.colQuyen.Width = 85;

            this.colTrangThai.DataPropertyName = "trang_thai_hoat_dong";
            this.colTrangThai.HeaderText = "Trạng thái TK";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 100;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 700);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.pnlChucNang);
            this.Controls.Add(this.pnlTopContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmNhanVien";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "QUẢN LÝ NHÂN SỰ VÀ TÀI KHOẢN";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            this.pnlTopContainer.ResumeLayout(false);
            this.grpThongTinNhanVien.ResumeLayout(false);
            this.grpThongTinNhanVien.PerformLayout();
            this.pnlGioiTinh.ResumeLayout(false);
            this.pnlGioiTinh.PerformLayout();
            this.grpTaiKhoan.ResumeLayout(false);
            this.grpTaiKhoan.PerformLayout();
            this.pnlChucNang.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTopContainer;
        private System.Windows.Forms.GroupBox grpThongTinNhanVien;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Panel pnlGioiTinh;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblCongViec;
        private System.Windows.Forms.ComboBox cboCongViec;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.GroupBox grpTaiKhoan;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblQuyen;
        private System.Windows.Forms.ComboBox cboQuyen;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Button btnResetMatKhau;
        private System.Windows.Forms.CheckBox chkTrangThaiHoatDong;
        private System.Windows.Forms.Panel pnlChucNang;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCongViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}
