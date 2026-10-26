namespace QuanLyBanBanGhe.GUI.Forms.NghiepVu
{
    partial class frmHoaDonBan
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
            this.grpMaster = new System.Windows.Forms.GroupBox();
            this.lblMaHDB = new System.Windows.Forms.Label();
            this.txtMaHDB = new System.Windows.Forms.TextBox();
            this.lblNgayBan = new System.Windows.Forms.Label();
            this.dtpNgayBan = new System.Windows.Forms.DateTimePicker();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.cboDienThoai = new System.Windows.Forms.ComboBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblHangHoa = new System.Windows.Forms.Label();
            this.cboHangHoa = new System.Windows.Forms.ComboBox();
            this.lblDonGiaBan = new System.Windows.Forms.Label();
            this.txtDonGiaBan = new System.Windows.Forms.TextBox();
            this.lblTonKho = new System.Windows.Forms.Label();
            this.txtTonKho = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.btnThemVaoDon = new System.Windows.Forms.Button();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colMaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlTongTien = new System.Windows.Forms.Panel();
            this.lblTongTienBangSo = new System.Windows.Forms.Label();
            this.lblTongTienBangChu = new System.Windows.Forms.Label();
            this.flpActionButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.btnLuuHoaDon = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnHuyHoaDon = new System.Windows.Forms.Button();
            this.grpMaster.SuspendLayout();
            this.grpDetail.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlTongTien.SuspendLayout();
            this.flpActionButtons.SuspendLayout();
            this.SuspendLayout();

            this.grpMaster.Controls.Add(this.lblMaHDB);
            this.grpMaster.Controls.Add(this.txtMaHDB);
            this.grpMaster.Controls.Add(this.lblNgayBan);
            this.grpMaster.Controls.Add(this.dtpNgayBan);
            this.grpMaster.Controls.Add(this.lblNhanVien);
            this.grpMaster.Controls.Add(this.cboNhanVien);
            this.grpMaster.Controls.Add(this.lblKhachHang);
            this.grpMaster.Controls.Add(this.cboKhachHang);
            this.grpMaster.Controls.Add(this.lblDienThoai);
            this.grpMaster.Controls.Add(this.cboDienThoai);
            this.grpMaster.Controls.Add(this.lblDiaChi);
            this.grpMaster.Controls.Add(this.txtDiaChi);
            this.grpMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaster.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMaster.Location = new System.Drawing.Point(10, 10);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(1100, 115);
            this.grpMaster.TabIndex = 0;
            this.grpMaster.TabStop = false;
            this.grpMaster.Text = "Thông tin chung hóa đơn bán";

            this.lblMaHDB.AutoSize = true;
            this.lblMaHDB.Location = new System.Drawing.Point(15, 28);
            this.lblMaHDB.Name = "lblMaHDB";
            this.lblMaHDB.Size = new System.Drawing.Size(81, 17);
            this.lblMaHDB.TabIndex = 0;
            this.lblMaHDB.Text = "Số hóa đơn:";

            this.txtMaHDB.Location = new System.Drawing.Point(105, 25);
            this.txtMaHDB.Name = "txtMaHDB";
            this.txtMaHDB.ReadOnly = true;
            this.txtMaHDB.Size = new System.Drawing.Size(200, 24);
            this.txtMaHDB.TabIndex = 1;

            this.lblNgayBan.AutoSize = true;
            this.lblNgayBan.Location = new System.Drawing.Point(340, 28);
            this.lblNgayBan.Name = "lblNgayBan";
            this.lblNgayBan.Size = new System.Drawing.Size(68, 17);
            this.lblNgayBan.TabIndex = 2;
            this.lblNgayBan.Text = "Ngày bán:";

            this.dtpNgayBan.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayBan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBan.Location = new System.Drawing.Point(430, 25);
            this.dtpNgayBan.Name = "dtpNgayBan";
            this.dtpNgayBan.Size = new System.Drawing.Size(200, 24);
            this.dtpNgayBan.TabIndex = 3;

            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(670, 28);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(91, 17);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên lập:";

            this.cboNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(770, 25);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(315, 25);
            this.cboNhanVien.TabIndex = 5;

            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(15, 70);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(79, 17);
            this.lblKhachHang.TabIndex = 6;
            this.lblKhachHang.Text = "Khách hàng:";

            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(105, 67);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(200, 25);
            this.cboKhachHang.TabIndex = 7;
            this.cboKhachHang.SelectedIndexChanged += new System.EventHandler(this.cboKhachHang_SelectedIndexChanged);

            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(340, 70);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(70, 17);
            this.lblDienThoai.TabIndex = 8;
            this.lblDienThoai.Text = "Điện thoại:";

            this.cboDienThoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboDienThoai.FormattingEnabled = true;
            this.cboDienThoai.Location = new System.Drawing.Point(430, 67);
            this.cboDienThoai.Name = "cboDienThoai";
            this.cboDienThoai.Size = new System.Drawing.Size(200, 25);
            this.cboDienThoai.TabIndex = 9;

            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(670, 70);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(50, 17);
            this.lblDiaChi.TabIndex = 10;
            this.lblDiaChi.Text = "Địa chỉ:";

            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Location = new System.Drawing.Point(770, 67);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(315, 24);
            this.txtDiaChi.TabIndex = 11;

            this.grpDetail.Controls.Add(this.lblHangHoa);
            this.grpDetail.Controls.Add(this.cboHangHoa);
            this.grpDetail.Controls.Add(this.lblDonGiaBan);
            this.grpDetail.Controls.Add(this.txtDonGiaBan);
            this.grpDetail.Controls.Add(this.lblTonKho);
            this.grpDetail.Controls.Add(this.txtTonKho);
            this.grpDetail.Controls.Add(this.lblSoLuong);
            this.grpDetail.Controls.Add(this.txtSoLuong);
            this.grpDetail.Controls.Add(this.lblGiamGia);
            this.grpDetail.Controls.Add(this.txtGiamGia);
            this.grpDetail.Controls.Add(this.lblThanhTien);
            this.grpDetail.Controls.Add(this.txtThanhTien);
            this.grpDetail.Controls.Add(this.btnThemVaoDon);
            this.grpDetail.Controls.Add(this.btnXoaDong);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetail.Location = new System.Drawing.Point(10, 125);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(1100, 115);
            this.grpDetail.TabIndex = 1;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Chi tiết mặt hàng bán";

this.lblHangHoa.AutoSize = true;
            this.lblHangHoa.Location = new System.Drawing.Point(15, 28);
            this.lblHangHoa.Name = "lblHangHoa";
            this.lblHangHoa.Size = new System.Drawing.Size(68, 17);
            this.lblHangHoa.TabIndex = 0;
            this.lblHangHoa.Text = "Mặt hàng:";

            this.cboHangHoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHangHoa.DropDownWidth = 350;
            this.cboHangHoa.FormattingEnabled = true;
            this.cboHangHoa.Location = new System.Drawing.Point(105, 25);
            this.cboHangHoa.Name = "cboHangHoa";
            this.cboHangHoa.Size = new System.Drawing.Size(210, 25);
            this.cboHangHoa.TabIndex = 1;
            this.cboHangHoa.SelectedIndexChanged += new System.EventHandler(this.cboHangHoa_SelectedIndexChanged);

            this.lblDonGiaBan.AutoSize = true;
            this.lblDonGiaBan.Location = new System.Drawing.Point(340, 28);
            this.lblDonGiaBan.Name = "lblDonGiaBan";
            this.lblDonGiaBan.Size = new System.Drawing.Size(82, 17);
            this.lblDonGiaBan.TabIndex = 2;
            this.lblDonGiaBan.Text = "Đơn giá bán:";

            this.txtDonGiaBan.Location = new System.Drawing.Point(430, 25);
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.ReadOnly = true;
            this.txtDonGiaBan.Size = new System.Drawing.Size(150, 24);
            this.txtDonGiaBan.TabIndex = 3;

            this.lblTonKho.AutoSize = true;
            this.lblTonKho.Location = new System.Drawing.Point(605, 28);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(81, 17);
            this.lblTonKho.TabIndex = 4;
            this.lblTonKho.Text = "Tồn kho còn:";

            this.txtTonKho.Location = new System.Drawing.Point(695, 25);
            this.txtTonKho.Name = "txtTonKho";
            this.txtTonKho.ReadOnly = true;
            this.txtTonKho.Size = new System.Drawing.Size(150, 24);
            this.txtTonKho.TabIndex = 5;

            this.btnThemVaoDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemVaoDon.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnThemVaoDon.Location = new System.Drawing.Point(875, 22);
            this.btnThemVaoDon.Name = "btnThemVaoDon";
            this.btnThemVaoDon.Size = new System.Drawing.Size(150, 30);
            this.btnThemVaoDon.TabIndex = 12;
            this.btnThemVaoDon.Text = "Thêm vào đơn";
            this.btnThemVaoDon.UseVisualStyleBackColor = true;
            this.btnThemVaoDon.Click += new System.EventHandler(this.btnThemVaoDon_Click);

            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(15, 70);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(64, 17);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Số lượng:";

            this.txtSoLuong.Location = new System.Drawing.Point(105, 67);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(210, 24);
            this.txtSoLuong.TabIndex = 7;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtTinhToanThanhTien_TextChanged);

            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Location = new System.Drawing.Point(340, 70);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(84, 17);
            this.lblGiamGia.TabIndex = 8;
            this.lblGiamGia.Text = "Giảm giá (%):";

            this.txtGiamGia.Location = new System.Drawing.Point(430, 67);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(150, 24);
            this.txtGiamGia.TabIndex = 9;
            this.txtGiamGia.Text = "0";
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtTinhToanThanhTien_TextChanged);

            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(605, 70);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(72, 17);
            this.lblThanhTien.TabIndex = 10;
            this.lblThanhTien.Text = "Thành tiền:";

            this.txtThanhTien.Location = new System.Drawing.Point(695, 67);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(150, 24);
            this.txtThanhTien.TabIndex = 11;

            this.btnXoaDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnXoaDong.Location = new System.Drawing.Point(875, 64);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(150, 30);
            this.btnXoaDong.TabIndex = 13;
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = true;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);

            this.pnlBottom.Controls.Add(this.pnlTongTien);
            this.pnlBottom.Controls.Add(this.flpActionButtons);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.Location = new System.Drawing.Point(10, 595);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1100, 95);
            this.pnlBottom.TabIndex = 3;

            this.pnlTongTien.Controls.Add(this.lblTongTienBangSo);
            this.pnlTongTien.Controls.Add(this.lblTongTienBangChu);
            this.pnlTongTien.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTongTien.Location = new System.Drawing.Point(0, 0);
            this.pnlTongTien.Name = "pnlTongTien";
            this.pnlTongTien.Size = new System.Drawing.Size(1100, 45);
            this.pnlTongTien.TabIndex = 0;

            this.lblTongTienBangSo.AutoSize = true;
            this.lblTongTienBangSo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienBangSo.Location = new System.Drawing.Point(10, 12);
            this.lblTongTienBangSo.Name = "lblTongTienBangSo";
            this.lblTongTienBangSo.Size = new System.Drawing.Size(155, 20);
            this.lblTongTienBangSo.TabIndex = 0;
            this.lblTongTienBangSo.Text = "Tổng tiền: 0 VNĐ";

            this.lblTongTienBangChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienBangChu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienBangChu.Location = new System.Drawing.Point(320, 14);
            this.lblTongTienBangChu.Name = "lblTongTienBangChu";
            this.lblTongTienBangChu.Size = new System.Drawing.Size(760, 22);
            this.lblTongTienBangChu.TabIndex = 1;
            this.lblTongTienBangChu.Text = "Bằng chữ: Không đồng";
            this.lblTongTienBangChu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.flpActionButtons.Controls.Add(this.btnTaoMoi);
            this.flpActionButtons.Controls.Add(this.btnLuuHoaDon);
            this.flpActionButtons.Controls.Add(this.btnInHoaDon);
            this.flpActionButtons.Controls.Add(this.btnHuyHoaDon);
            this.flpActionButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpActionButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpActionButtons.Location = new System.Drawing.Point(0, 47);
            this.flpActionButtons.Name = "flpActionButtons";
            this.flpActionButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flpActionButtons.Size = new System.Drawing.Size(1100, 48);
            this.flpActionButtons.TabIndex = 1;

            this.btnHuyHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnHuyHoaDon.Location = new System.Drawing.Point(970, 8);
            this.btnHuyHoaDon.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(130, 32);
            this.btnHuyHoaDon.TabIndex = 3;
            this.btnHuyHoaDon.Text = "Hủy hóa đơn";
            this.btnHuyHoaDon.UseVisualStyleBackColor = true;
            this.btnHuyHoaDon.Click += new System.EventHandler(this.btnHuyHoaDon_Click);

            this.btnInHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnInHoaDon.Location = new System.Drawing.Point(830, 8);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(130, 32);
            this.btnInHoaDon.TabIndex = 2;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);

            this.btnLuuHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnLuuHoaDon.Location = new System.Drawing.Point(690, 8);
            this.btnLuuHoaDon.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLuuHoaDon.Name = "btnLuuHoaDon";
            this.btnLuuHoaDon.Size = new System.Drawing.Size(130, 32);
            this.btnLuuHoaDon.TabIndex = 1;
            this.btnLuuHoaDon.Text = "Lưu hóa đơn";
            this.btnLuuHoaDon.UseVisualStyleBackColor = true;
            this.btnLuuHoaDon.Click += new System.EventHandler(this.btnLuuHoaDon_Click);

            this.btnTaoMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoMoi.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnTaoMoi.Location = new System.Drawing.Point(550, 8);
            this.btnTaoMoi.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(130, 32);
            this.btnTaoMoi.TabIndex = 0;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);

            this.grpDanhSach.Controls.Add(this.dgvChiTiet);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSach.Location = new System.Drawing.Point(10, 240);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(10);
            this.grpDanhSach.Size = new System.Drawing.Size(1100, 355);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách mặt hàng xuất bán";

            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHang,
            this.colTenHang,
            this.colSoLuong,
            this.colDonGia,
            this.colGiamGia,
            this.colThanhTien});
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 27);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 35;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1080, 318);
            this.dgvChiTiet.TabIndex = 0;
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);

            this.colMaHang.DataPropertyName = "ma_hang";
            this.colMaHang.HeaderText = "Mã hàng";
            this.colMaHang.Name = "colMaHang";
            this.colMaHang.ReadOnly = true;
            this.colMaHang.Width = 100;

            this.colTenHang.DataPropertyName = "ten_hang_hoa";
            this.colTenHang.HeaderText = "Tên hàng hóa";
            this.colTenHang.Name = "colTenHang";
            this.colTenHang.ReadOnly = true;
            this.colTenHang.Width = 260;

            this.colSoLuong.DataPropertyName = "so_luong";
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.Width = 100;

            this.colDonGia.DataPropertyName = "don_gia";
            this.colDonGia.HeaderText = "Đơn giá bán";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            this.colDonGia.Width = 140;

            this.colGiamGia.DataPropertyName = "giam_gia";
            this.colGiamGia.HeaderText = "Giảm giá (%)";
            this.colGiamGia.Name = "colGiamGia";
            this.colGiamGia.ReadOnly = true;
            this.colGiamGia.Width = 110;

            this.colThanhTien.DataPropertyName = "thanh_tien";
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.Width = 160;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 700);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpMaster);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmHoaDonBan";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "LẬP HÓA ĐƠN BÁN HÀNG";
            this.Load += new System.EventHandler(this.frmHoaDonBan_Load);
            this.grpMaster.ResumeLayout(false);
            this.grpMaster.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTongTien.ResumeLayout(false);
            this.pnlTongTien.PerformLayout();
            this.flpActionButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpMaster;
        private System.Windows.Forms.Label lblMaHDB;
        private System.Windows.Forms.TextBox txtMaHDB;
        private System.Windows.Forms.Label lblNgayBan;
        private System.Windows.Forms.DateTimePicker dtpNgayBan;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.ComboBox cboDienThoai;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblHangHoa;
        private System.Windows.Forms.ComboBox cboHangHoa;
        private System.Windows.Forms.Label lblDonGiaBan;
        private System.Windows.Forms.TextBox txtDonGiaBan;
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.TextBox txtTonKho;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Button btnThemVaoDon;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTongTien;
        private System.Windows.Forms.Label lblTongTienBangSo;
        private System.Windows.Forms.Label lblTongTienBangChu;
        private System.Windows.Forms.FlowLayoutPanel flpActionButtons;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Button btnLuuHoaDon;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Button btnHuyHoaDon;
    }
}
