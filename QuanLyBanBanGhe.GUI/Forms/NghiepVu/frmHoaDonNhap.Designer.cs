namespace QuanLyBanBanGhe.GUI.Forms.NghiepVu
{
    partial class frmHoaDonNhap
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
            this.lblMaHDN = new System.Windows.Forms.Label();
            this.txtMaHDN = new System.Windows.Forms.TextBox();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblHangHoa = new System.Windows.Forms.Label();
            this.cboHangHoa = new System.Windows.Forms.ComboBox();
            this.lblDonGiaNhap = new System.Windows.Forms.Label();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
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
            // 
            // grpMaster
            // 
            this.grpMaster.Controls.Add(this.lblMaHDN);
            this.grpMaster.Controls.Add(this.txtMaHDN);
            this.grpMaster.Controls.Add(this.lblNgayNhap);
            this.grpMaster.Controls.Add(this.dtpNgayNhap);
            this.grpMaster.Controls.Add(this.lblNhanVien);
            this.grpMaster.Controls.Add(this.cboNhanVien);
            this.grpMaster.Controls.Add(this.lblNhaCungCap);
            this.grpMaster.Controls.Add(this.cboNhaCungCap);
            this.grpMaster.Controls.Add(this.lblDienThoai);
            this.grpMaster.Controls.Add(this.txtDienThoai);
            this.grpMaster.Controls.Add(this.lblDiaChi);
            this.grpMaster.Controls.Add(this.txtDiaChi);
            this.grpMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaster.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMaster.Location = new System.Drawing.Point(10, 10);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(1100, 115);
            this.grpMaster.TabIndex = 0;
            this.grpMaster.TabStop = false;
            this.grpMaster.Text = "Thông tin chung hóa đơn nhập";
            // 
            // lblMaHDN
            // 
            this.lblMaHDN.AutoSize = true;
            this.lblMaHDN.Location = new System.Drawing.Point(15, 28);
            this.lblMaHDN.Name = "lblMaHDN";
            this.lblMaHDN.Size = new System.Drawing.Size(93, 21);
            this.lblMaHDN.TabIndex = 0;
            this.lblMaHDN.Text = "Số hóa đơn:";
            // 
            // txtMaHDN
            // 
            this.txtMaHDN.Location = new System.Drawing.Point(115, 25);
            this.txtMaHDN.Name = "txtMaHDN";
            this.txtMaHDN.ReadOnly = true;
            this.txtMaHDN.Size = new System.Drawing.Size(200, 29);
            this.txtMaHDN.TabIndex = 1;
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(340, 28);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(89, 21);
            this.lblNgayNhap.TabIndex = 2;
            this.lblNgayNhap.Text = "Ngày nhập:";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(430, 25);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(200, 29);
            this.dtpNgayNhap.TabIndex = 3;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(670, 28);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(109, 21);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên lập:";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(770, 25);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(315, 29);
            this.cboNhanVien.TabIndex = 5;
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Location = new System.Drawing.Point(15, 70);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(108, 21);
            this.lblNhaCungCap.TabIndex = 6;
            this.lblNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(115, 67);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(200, 29);
            this.cboNhaCungCap.TabIndex = 7;
            this.cboNhaCungCap.SelectedIndexChanged += new System.EventHandler(this.cboNhaCungCap_SelectedIndexChanged);
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(340, 70);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(84, 21);
            this.lblDienThoai.TabIndex = 8;
            this.lblDienThoai.Text = "Điện thoại:";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(430, 67);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.ReadOnly = true;
            this.txtDienThoai.Size = new System.Drawing.Size(200, 29);
            this.txtDienThoai.TabIndex = 9;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(670, 70);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(60, 21);
            this.lblDiaChi.TabIndex = 10;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Location = new System.Drawing.Point(770, 67);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(315, 29);
            this.txtDiaChi.TabIndex = 11;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.lblHangHoa);
            this.grpDetail.Controls.Add(this.cboHangHoa);
            this.grpDetail.Controls.Add(this.lblDonGiaNhap);
            this.grpDetail.Controls.Add(this.txtDonGiaNhap);
            this.grpDetail.Controls.Add(this.lblSoLuong);
            this.grpDetail.Controls.Add(this.txtSoLuong);
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
            this.grpDetail.Text = "Chi tiết mặt hàng nhập";
            // 
            // lblHangHoa
            // 
            this.lblHangHoa.AutoSize = true;
            this.lblHangHoa.Location = new System.Drawing.Point(15, 28);
            this.lblHangHoa.Name = "lblHangHoa";
            this.lblHangHoa.Size = new System.Drawing.Size(79, 21);
            this.lblHangHoa.TabIndex = 0;
            this.lblHangHoa.Text = "Mặt hàng:";
            // 
            // cboHangHoa
            // 
            this.cboHangHoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHangHoa.FormattingEnabled = true;
            this.cboHangHoa.Location = new System.Drawing.Point(115, 25);
            this.cboHangHoa.Name = "cboHangHoa";
            this.cboHangHoa.Size = new System.Drawing.Size(200, 29);
            this.cboHangHoa.TabIndex = 1;
            this.cboHangHoa.SelectedIndexChanged += new System.EventHandler(this.cboHangHoa_SelectedIndexChanged);
            // 
            // lblDonGiaNhap
            // 
            this.lblDonGiaNhap.AutoSize = true;
            this.lblDonGiaNhap.Location = new System.Drawing.Point(340, 28);
            this.lblDonGiaNhap.Name = "lblDonGiaNhap";
            this.lblDonGiaNhap.Size = new System.Drawing.Size(107, 21);
            this.lblDonGiaNhap.TabIndex = 2;
            this.lblDonGiaNhap.Text = "Đơn giá nhập:";
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Location = new System.Drawing.Point(435, 25);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(195, 29);
            this.txtDonGiaNhap.TabIndex = 3;
            this.txtDonGiaNhap.TextChanged += new System.EventHandler(this.txtTinhToanThanhTien_TextChanged);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(15, 70);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(76, 21);
            this.lblSoLuong.TabIndex = 4;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(115, 67);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(200, 29);
            this.txtSoLuong.TabIndex = 5;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtTinhToanThanhTien_TextChanged);
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(340, 70);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(86, 21);
            this.lblThanhTien.TabIndex = 6;
            this.lblThanhTien.Text = "Thành tiền:";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(435, 67);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(195, 29);
            this.txtThanhTien.TabIndex = 7;
            // 
            // btnThemVaoDon
            // 
            this.btnThemVaoDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemVaoDon.Location = new System.Drawing.Point(670, 64);
            this.btnThemVaoDon.Name = "btnThemVaoDon";
            this.btnThemVaoDon.Size = new System.Drawing.Size(130, 30);
            this.btnThemVaoDon.TabIndex = 8;
            this.btnThemVaoDon.Text = "Thêm vào đơn";
            this.btnThemVaoDon.UseVisualStyleBackColor = true;
            this.btnThemVaoDon.Click += new System.EventHandler(this.btnThemVaoDon_Click);
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDong.Location = new System.Drawing.Point(815, 64);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(110, 30);
            this.btnXoaDong.TabIndex = 9;
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = true;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvChiTiet);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSach.Location = new System.Drawing.Point(10, 240);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(10);
            this.grpDanhSach.Size = new System.Drawing.Size(1100, 355);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách mặt hàng nhập kho";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHang,
            this.colTenHang,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 32);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 35;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1080, 313);
            this.dgvChiTiet.TabIndex = 0;
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            // 
            // colMaHang
            // 
            this.colMaHang.DataPropertyName = "ma_hang";
            this.colMaHang.HeaderText = "Mã hàng";
            this.colMaHang.MinimumWidth = 6;
            this.colMaHang.Name = "colMaHang";
            this.colMaHang.ReadOnly = true;
            // 
            // colTenHang
            // 
            this.colTenHang.DataPropertyName = "ten_hang_hoa";
            this.colTenHang.HeaderText = "Tên hàng hóa";
            this.colTenHang.MinimumWidth = 6;
            this.colTenHang.Name = "colTenHang";
            this.colTenHang.ReadOnly = true;
            this.colTenHang.Width = 320;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "so_luong";
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "don_gia";
            this.colDonGia.HeaderText = "Đơn giá nhập";
            this.colDonGia.MinimumWidth = 6;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            this.colDonGia.Width = 160;
            // 
            // colThanhTien
            // 
            this.colThanhTien.DataPropertyName = "thanh_tien";
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 6;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.Width = 180;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlTongTien);
            this.pnlBottom.Controls.Add(this.flpActionButtons);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.Location = new System.Drawing.Point(10, 595);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1100, 95);
            this.pnlBottom.TabIndex = 3;
            // 
            // pnlTongTien
            // 
            this.pnlTongTien.Controls.Add(this.lblTongTienBangSo);
            this.pnlTongTien.Controls.Add(this.lblTongTienBangChu);
            this.pnlTongTien.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTongTien.Location = new System.Drawing.Point(0, 0);
            this.pnlTongTien.Name = "pnlTongTien";
            this.pnlTongTien.Size = new System.Drawing.Size(1100, 45);
            this.pnlTongTien.TabIndex = 0;
            // 
            // lblTongTienBangSo
            // 
            this.lblTongTienBangSo.AutoSize = true;
            this.lblTongTienBangSo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienBangSo.Location = new System.Drawing.Point(10, 12);
            this.lblTongTienBangSo.Name = "lblTongTienBangSo";
            this.lblTongTienBangSo.Size = new System.Drawing.Size(166, 25);
            this.lblTongTienBangSo.TabIndex = 0;
            this.lblTongTienBangSo.Text = "Tổng tiền: 0 VNĐ";
            // 
            // lblTongTienBangChu
            // 
            this.lblTongTienBangChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienBangChu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienBangChu.Location = new System.Drawing.Point(320, 14);
            this.lblTongTienBangChu.Name = "lblTongTienBangChu";
            this.lblTongTienBangChu.Size = new System.Drawing.Size(760, 22);
            this.lblTongTienBangChu.TabIndex = 1;
            this.lblTongTienBangChu.Text = "Bằng chữ: Không đồng";
            this.lblTongTienBangChu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flpActionButtons
            // 
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
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoMoi.Location = new System.Drawing.Point(970, 5);
            this.btnTaoMoi.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(130, 32);
            this.btnTaoMoi.TabIndex = 0;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // btnLuuHoaDon
            // 
            this.btnLuuHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuHoaDon.Location = new System.Drawing.Point(830, 5);
            this.btnLuuHoaDon.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLuuHoaDon.Name = "btnLuuHoaDon";
            this.btnLuuHoaDon.Size = new System.Drawing.Size(130, 32);
            this.btnLuuHoaDon.TabIndex = 1;
            this.btnLuuHoaDon.Text = "Lưu hóa đơn";
            this.btnLuuHoaDon.UseVisualStyleBackColor = true;
            this.btnLuuHoaDon.Click += new System.EventHandler(this.btnLuuHoaDon_Click);
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInHoaDon.Location = new System.Drawing.Point(690, 5);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(130, 32);
            this.btnInHoaDon.TabIndex = 2;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // btnHuyHoaDon
            // 
            this.btnHuyHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyHoaDon.Location = new System.Drawing.Point(550, 5);
            this.btnHuyHoaDon.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(130, 32);
            this.btnHuyHoaDon.TabIndex = 3;
            this.btnHuyHoaDon.Text = "Hủy hóa đơn";
            this.btnHuyHoaDon.UseVisualStyleBackColor = true;
            this.btnHuyHoaDon.Click += new System.EventHandler(this.btnHuyHoaDon_Click);
            // 
            // frmHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 700);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpMaster);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmHoaDonNhap";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "LẬP HÓA ĐƠN NHẬP HÀNG";
            this.Load += new System.EventHandler(this.frmHoaDonNhap_Load);
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
        private System.Windows.Forms.Label lblMaHDN;
        private System.Windows.Forms.TextBox txtMaHDN;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblHangHoa;
        private System.Windows.Forms.ComboBox cboHangHoa;
        private System.Windows.Forms.Label lblDonGiaNhap;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
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
