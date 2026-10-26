namespace QuanLyBanBanGhe.GUI.Forms.HeThong
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.flpSidebarMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNavBanHang = new System.Windows.Forms.Button();
            this.btnNavBaoHanh = new System.Windows.Forms.Button();
            this.btnNavNhapHang = new System.Windows.Forms.Button();
            this.btnNavHangHoa = new System.Windows.Forms.Button();
            this.btnNavDanhMucChung = new System.Windows.Forms.Button();
            this.btnNavKhachHang = new System.Windows.Forms.Button();
            this.btnNavNhaCungCap = new System.Windows.Forms.Button();
            this.btnNavNhanVien = new System.Windows.Forms.Button();
            this.btnNavTimKiemHangHoa = new System.Windows.Forms.Button();
            this.btnNavTimKiemHDBan = new System.Windows.Forms.Button();
            this.btnNavTimKiemHDNhap = new System.Windows.Forms.Button();
            this.btnNavBaoCao = new System.Windows.Forms.Button();
            this.btnNavDoiMatKhau = new System.Windows.Forms.Button();
            this.btnNavDangXuat = new System.Windows.Forms.Button();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlBrandDivider = new System.Windows.Forms.Panel();
            this.pnlVerticalDivider = new System.Windows.Forms.Panel();
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHeaderDivider = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSessionInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.flpSidebarMenu.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.pnlTopHeader.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            this.pnlSidebar.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSidebar.Controls.Add(this.flpSidebarMenu);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 726);
            this.pnlSidebar.TabIndex = 1;

            this.flpSidebarMenu.AutoScroll = true;
            this.flpSidebarMenu.Controls.Add(this.btnNavBanHang);
            this.flpSidebarMenu.Controls.Add(this.btnNavBaoHanh);
            this.flpSidebarMenu.Controls.Add(this.btnNavNhapHang);
            this.flpSidebarMenu.Controls.Add(this.btnNavHangHoa);
            this.flpSidebarMenu.Controls.Add(this.btnNavDanhMucChung);
            this.flpSidebarMenu.Controls.Add(this.btnNavKhachHang);
            this.flpSidebarMenu.Controls.Add(this.btnNavNhaCungCap);
            this.flpSidebarMenu.Controls.Add(this.btnNavNhanVien);
            this.flpSidebarMenu.Controls.Add(this.btnNavTimKiemHangHoa);
            this.flpSidebarMenu.Controls.Add(this.btnNavTimKiemHDBan);
            this.flpSidebarMenu.Controls.Add(this.btnNavTimKiemHDNhap);
            this.flpSidebarMenu.Controls.Add(this.btnNavBaoCao);
            this.flpSidebarMenu.Controls.Add(this.btnNavDoiMatKhau);
            this.flpSidebarMenu.Controls.Add(this.btnNavDangXuat);
            this.flpSidebarMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSidebarMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSidebarMenu.Location = new System.Drawing.Point(0, 55);
            this.flpSidebarMenu.Name = "flpSidebarMenu";
            this.flpSidebarMenu.Padding = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.flpSidebarMenu.Size = new System.Drawing.Size(220, 671);
            this.flpSidebarMenu.TabIndex = 1;
            this.flpSidebarMenu.WrapContents = false;

            this.btnNavBanHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavBanHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavBanHang.Location = new System.Drawing.Point(8, 10);
            this.btnNavBanHang.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavBanHang.Name = "btnNavBanHang";
            this.btnNavBanHang.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavBanHang.Size = new System.Drawing.Size(200, 38);
            this.btnNavBanHang.TabIndex = 0;
            this.btnNavBanHang.Text = "Bán hàng";
            this.btnNavBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBanHang.UseVisualStyleBackColor = true;
            this.btnNavBanHang.Click += new System.EventHandler(this.btnNavBanHang_Click);
            this.btnNavBaoHanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavBaoHanh.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavBaoHanh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavBaoHanh.Location = new System.Drawing.Point(8, 54);
            this.btnNavBaoHanh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavBaoHanh.Name = "btnNavBaoHanh";
            this.btnNavBaoHanh.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavBaoHanh.Size = new System.Drawing.Size(200, 38);
            this.btnNavBaoHanh.TabIndex = 1;
            this.btnNavBaoHanh.Text = "Phiếu bảo hành";
            this.btnNavBaoHanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBaoHanh.UseVisualStyleBackColor = true;
            this.btnNavBaoHanh.Click += new System.EventHandler(this.btnNavBaoHanh_Click);

            this.btnNavNhapHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavNhapHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavNhapHang.Location = new System.Drawing.Point(8, 54);
            this.btnNavNhapHang.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavNhapHang.Name = "btnNavNhapHang";
            this.btnNavNhapHang.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavNhapHang.Size = new System.Drawing.Size(200, 38);
            this.btnNavNhapHang.TabIndex = 1;
            this.btnNavNhapHang.Text = "Nhập hàng";
            this.btnNavNhapHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavNhapHang.UseVisualStyleBackColor = true;
            this.btnNavNhapHang.Click += new System.EventHandler(this.btnNavNhapHang_Click);

            this.btnNavHangHoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavHangHoa.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavHangHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavHangHoa.Location = new System.Drawing.Point(8, 98);
            this.btnNavHangHoa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavHangHoa.Name = "btnNavHangHoa";
            this.btnNavHangHoa.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavHangHoa.Size = new System.Drawing.Size(200, 38);
            this.btnNavHangHoa.TabIndex = 2;
            this.btnNavHangHoa.Text = "Hàng hóa";
            this.btnNavHangHoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavHangHoa.UseVisualStyleBackColor = true;
            this.btnNavHangHoa.Click += new System.EventHandler(this.btnNavHangHoa_Click);

            this.btnNavDanhMucChung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDanhMucChung.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavDanhMucChung.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDanhMucChung.Location = new System.Drawing.Point(8, 142);
            this.btnNavDanhMucChung.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavDanhMucChung.Name = "btnNavDanhMucChung";
            this.btnNavDanhMucChung.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavDanhMucChung.Size = new System.Drawing.Size(200, 38);
            this.btnNavDanhMucChung.TabIndex = 3;
            this.btnNavDanhMucChung.Text = "Danh mục chung";
            this.btnNavDanhMucChung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDanhMucChung.UseVisualStyleBackColor = true;
            this.btnNavDanhMucChung.Click += new System.EventHandler(this.btnNavDanhMucChung_Click);

            this.btnNavKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavKhachHang.Location = new System.Drawing.Point(8, 186);
            this.btnNavKhachHang.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavKhachHang.Name = "btnNavKhachHang";
            this.btnNavKhachHang.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavKhachHang.Size = new System.Drawing.Size(200, 38);
            this.btnNavKhachHang.TabIndex = 4;
            this.btnNavKhachHang.Text = "Khách hàng";
            this.btnNavKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavKhachHang.UseVisualStyleBackColor = true;
            this.btnNavKhachHang.Click += new System.EventHandler(this.btnNavKhachHang_Click);

            this.btnNavNhaCungCap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavNhaCungCap.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavNhaCungCap.Location = new System.Drawing.Point(8, 230);
            this.btnNavNhaCungCap.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavNhaCungCap.Name = "btnNavNhaCungCap";
            this.btnNavNhaCungCap.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavNhaCungCap.Size = new System.Drawing.Size(200, 38);
            this.btnNavNhaCungCap.TabIndex = 5;
            this.btnNavNhaCungCap.Text = "Nhà cung cấp";
            this.btnNavNhaCungCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavNhaCungCap.UseVisualStyleBackColor = true;
            this.btnNavNhaCungCap.Click += new System.EventHandler(this.btnNavNhaCungCap_Click);

            this.btnNavNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavNhanVien.Location = new System.Drawing.Point(8, 274);
            this.btnNavNhanVien.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavNhanVien.Name = "btnNavNhanVien";
            this.btnNavNhanVien.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavNhanVien.Size = new System.Drawing.Size(200, 38);
            this.btnNavNhanVien.TabIndex = 6;
            this.btnNavNhanVien.Text = "Nhân sự";
            this.btnNavNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavNhanVien.UseVisualStyleBackColor = true;
            this.btnNavNhanVien.Click += new System.EventHandler(this.btnNavNhanVien_Click);

            this.btnNavTimKiemHangHoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTimKiemHangHoa.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavTimKiemHangHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavTimKiemHangHoa.Location = new System.Drawing.Point(8, 318);
            this.btnNavTimKiemHangHoa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavTimKiemHangHoa.Name = "btnNavTimKiemHangHoa";
            this.btnNavTimKiemHangHoa.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavTimKiemHangHoa.Size = new System.Drawing.Size(200, 38);
            this.btnNavTimKiemHangHoa.TabIndex = 7;
            this.btnNavTimKiemHangHoa.Text = "Tìm kiếm hàng hóa";
            this.btnNavTimKiemHangHoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavTimKiemHangHoa.UseVisualStyleBackColor = true;
            this.btnNavTimKiemHangHoa.Click += new System.EventHandler(this.btnNavTimKiemHangHoa_Click);

            this.btnNavTimKiemHDBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTimKiemHDBan.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavTimKiemHDBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavTimKiemHDBan.Location = new System.Drawing.Point(8, 362);
            this.btnNavTimKiemHDBan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavTimKiemHDBan.Name = "btnNavTimKiemHDBan";
            this.btnNavTimKiemHDBan.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavTimKiemHDBan.Size = new System.Drawing.Size(200, 38);
            this.btnNavTimKiemHDBan.TabIndex = 8;
            this.btnNavTimKiemHDBan.Text = "Tìm kiếm HĐ bán";
            this.btnNavTimKiemHDBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavTimKiemHDBan.UseVisualStyleBackColor = true;
            this.btnNavTimKiemHDBan.Click += new System.EventHandler(this.btnNavTimKiemHDBan_Click);

            this.btnNavTimKiemHDNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTimKiemHDNhap.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavTimKiemHDNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavTimKiemHDNhap.Location = new System.Drawing.Point(8, 362);
            this.btnNavTimKiemHDNhap.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavTimKiemHDNhap.Name = "btnNavTimKiemHDNhap";
            this.btnNavTimKiemHDNhap.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavTimKiemHDNhap.Size = new System.Drawing.Size(200, 38);
            this.btnNavTimKiemHDNhap.TabIndex = 8;
            this.btnNavTimKiemHDNhap.Text = "Tìm kiếm HĐ nhập";
            this.btnNavTimKiemHDNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavTimKiemHDNhap.UseVisualStyleBackColor = true;
            this.btnNavTimKiemHDNhap.Click += new System.EventHandler(this.btnNavTimKiemHDNhap_Click);

            this.btnNavBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavBaoCao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavBaoCao.Location = new System.Drawing.Point(8, 406);
            this.btnNavBaoCao.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavBaoCao.Name = "btnNavBaoCao";
            this.btnNavBaoCao.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavBaoCao.Size = new System.Drawing.Size(200, 38);
            this.btnNavBaoCao.TabIndex = 9;
            this.btnNavBaoCao.Text = "Báo cáo thống kê";
            this.btnNavBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBaoCao.UseVisualStyleBackColor = true;
            this.btnNavBaoCao.Click += new System.EventHandler(this.btnNavBaoCao_Click);

            this.btnNavDoiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDoiMatKhau.Location = new System.Drawing.Point(8, 450);
            this.btnNavDoiMatKhau.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavDoiMatKhau.Name = "btnNavDoiMatKhau";
            this.btnNavDoiMatKhau.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavDoiMatKhau.Size = new System.Drawing.Size(200, 38);
            this.btnNavDoiMatKhau.TabIndex = 10;
            this.btnNavDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnNavDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnNavDoiMatKhau.Click += new System.EventHandler(this.btnNavDoiMatKhau_Click);

            this.btnNavDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNavDangXuat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDangXuat.Location = new System.Drawing.Point(8, 494);
            this.btnNavDangXuat.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNavDangXuat.Name = "btnNavDangXuat";
            this.btnNavDangXuat.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavDangXuat.Size = new System.Drawing.Size(200, 38);
            this.btnNavDangXuat.TabIndex = 11;
            this.btnNavDangXuat.Text = "Đăng xuất";
            this.btnNavDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDangXuat.UseVisualStyleBackColor = true;
            this.btnNavDangXuat.Click += new System.EventHandler(this.btnNavDangXuat_Click);

            this.pnlBrand.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBrand.Controls.Add(this.lblBrand);
            this.pnlBrand.Controls.Add(this.pnlBrandDivider);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(220, 55);
            this.pnlBrand.TabIndex = 0;

            this.lblBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(0, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(220, 54);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "QUẢN LÝ BÁN BÀN GHẾ";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlBrandDivider.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlBrandDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBrandDivider.Location = new System.Drawing.Point(0, 54);
            this.pnlBrandDivider.Name = "pnlBrandDivider";
            this.pnlBrandDivider.Size = new System.Drawing.Size(220, 1);
            this.pnlBrandDivider.TabIndex = 1;

            this.pnlVerticalDivider.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlVerticalDivider.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlVerticalDivider.Location = new System.Drawing.Point(220, 0);
            this.pnlVerticalDivider.Name = "pnlVerticalDivider";
            this.pnlVerticalDivider.Size = new System.Drawing.Size(1, 726);
            this.pnlVerticalDivider.TabIndex = 4;

            this.pnlTopHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTopHeader.Controls.Add(this.lblUserInfo);
            this.pnlTopHeader.Controls.Add(this.lblTitle);
            this.pnlTopHeader.Controls.Add(this.pnlHeaderDivider);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(221, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(979, 55);
            this.pnlTopHeader.TabIndex = 2;

            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.Location = new System.Drawing.Point(460, 16);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(500, 23);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Người dùng: Chưa đăng nhập";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ";

            this.pnlHeaderDivider.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlHeaderDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderDivider.Location = new System.Drawing.Point(0, 54);
            this.pnlHeaderDivider.Name = "pnlHeaderDivider";
            this.pnlHeaderDivider.Size = new System.Drawing.Size(979, 1);
            this.pnlHeaderDivider.TabIndex = 2;

            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.SystemColors.Control;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(221, 55);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(979, 671);
            this.pnlContent.TabIndex = 3;

            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblSessionInfo,
            this.lblClock});
            this.statusStrip.Location = new System.Drawing.Point(0, 726);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 24);
            this.statusStrip.TabIndex = 0;

            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(895, 19);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Trạng thái: Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSessionInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblSessionInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblSessionInfo.Name = "lblSessionInfo";
            this.lblSessionInfo.Size = new System.Drawing.Size(175, 19);
            this.lblSessionInfo.Text = "Phiên làm việc: Chưa đăng nhập";

            this.lblClock.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblClock.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(115, 19);
            this.lblClock.Text = "20:58:00";

            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTopHeader);
            this.Controls.Add(this.pnlVerticalDivider);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ BÁN BÀN GHẾ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.pnlSidebar.ResumeLayout(false);
            this.flpSidebarMenu.ResumeLayout(false);
            this.pnlBrand.ResumeLayout(false);
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Panel pnlBrandDivider;
        private System.Windows.Forms.FlowLayoutPanel flpSidebarMenu;
        private System.Windows.Forms.Button btnNavBanHang;
        private System.Windows.Forms.Button btnNavBaoHanh;
        private System.Windows.Forms.Button btnNavNhapHang;
        private System.Windows.Forms.Button btnNavHangHoa;
        private System.Windows.Forms.Button btnNavDanhMucChung;
        private System.Windows.Forms.Button btnNavKhachHang;
        private System.Windows.Forms.Button btnNavNhaCungCap;
        private System.Windows.Forms.Button btnNavNhanVien;
        private System.Windows.Forms.Button btnNavTimKiemHangHoa;
        private System.Windows.Forms.Button btnNavTimKiemHDBan;
        private System.Windows.Forms.Button btnNavTimKiemHDNhap;
        private System.Windows.Forms.Button btnNavBaoCao;
        private System.Windows.Forms.Button btnNavDoiMatKhau;
        private System.Windows.Forms.Button btnNavDangXuat;
        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel pnlHeaderDivider;
        private System.Windows.Forms.Panel pnlVerticalDivider;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSessionInfo;
        private System.Windows.Forms.ToolStripStatusLabel lblClock;
        private System.Windows.Forms.Timer tmrClock;
    }
}
