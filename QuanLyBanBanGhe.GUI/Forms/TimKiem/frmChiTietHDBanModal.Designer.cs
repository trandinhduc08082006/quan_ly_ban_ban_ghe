namespace QuanLyBanBanGhe.GUI.Forms.TimKiem
{
    partial class frmChiTietHDBanModal
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
            this.grpThongTinChung = new System.Windows.Forms.GroupBox();
            this.lblSoHDB = new System.Windows.Forms.Label();
            this.txtSoHDB = new System.Windows.Forms.TextBox();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.txtThoiGian = new System.Windows.Forms.TextBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colMaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnHuyHoaDon = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpThongTinChung.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            this.grpThongTinChung.Controls.Add(this.lblSoHDB);
            this.grpThongTinChung.Controls.Add(this.txtSoHDB);
            this.grpThongTinChung.Controls.Add(this.lblThoiGian);
            this.grpThongTinChung.Controls.Add(this.txtThoiGian);
            this.grpThongTinChung.Controls.Add(this.lblKhachHang);
            this.grpThongTinChung.Controls.Add(this.txtKhachHang);
            this.grpThongTinChung.Controls.Add(this.lblNhanVien);
            this.grpThongTinChung.Controls.Add(this.txtNhanVien);
            this.grpThongTinChung.Controls.Add(this.lblTongTien);
            this.grpThongTinChung.Controls.Add(this.txtTongTien);
            this.grpThongTinChung.Controls.Add(this.lblTrangThai);
            this.grpThongTinChung.Controls.Add(this.txtTrangThai);
            this.grpThongTinChung.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTinChung.Location = new System.Drawing.Point(10, 10);
            this.grpThongTinChung.Name = "grpThongTinChung";
            this.grpThongTinChung.Size = new System.Drawing.Size(864, 105);
            this.grpThongTinChung.TabIndex = 0;
            this.grpThongTinChung.TabStop = false;
            this.grpThongTinChung.Text = "Thông tin hóa đơn";

            this.lblSoHDB.AutoSize = true;
            this.lblSoHDB.Location = new System.Drawing.Point(15, 30);
            this.lblSoHDB.Name = "lblSoHDB";
            this.lblSoHDB.Size = new System.Drawing.Size(76, 17);
            this.lblSoHDB.TabIndex = 0;
            this.lblSoHDB.Text = "Số HĐ bán:";

            this.txtSoHDB.Location = new System.Drawing.Point(105, 27);
            this.txtSoHDB.Name = "txtSoHDB";
            this.txtSoHDB.ReadOnly = true;
            this.txtSoHDB.Size = new System.Drawing.Size(160, 24);
            this.txtSoHDB.TabIndex = 1;

            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Location = new System.Drawing.Point(290, 30);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(90, 17);
            this.lblThoiGian.TabIndex = 2;
            this.lblThoiGian.Text = "Thời gian bán:";

            this.txtThoiGian.Location = new System.Drawing.Point(395, 27);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.ReadOnly = true;
            this.txtThoiGian.Size = new System.Drawing.Size(170, 24);
            this.txtThoiGian.TabIndex = 3;

            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(585, 30);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(79, 17);
            this.lblKhachHang.TabIndex = 4;
            this.lblKhachHang.Text = "Khách hàng:";

            this.txtKhachHang.Location = new System.Drawing.Point(685, 27);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.ReadOnly = true;
            this.txtKhachHang.Size = new System.Drawing.Size(165, 24);
            this.txtKhachHang.TabIndex = 5;

            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(15, 68);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(91, 17);
            this.lblNhanVien.TabIndex = 6;
            this.lblNhanVien.Text = "Nhân viên lập:";

            this.txtNhanVien.Location = new System.Drawing.Point(105, 65);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.ReadOnly = true;
            this.txtNhanVien.Size = new System.Drawing.Size(160, 24);
            this.txtNhanVien.TabIndex = 7;

            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(290, 68);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(66, 17);
            this.lblTongTien.TabIndex = 8;
            this.lblTongTien.Text = "Tổng tiền:";

            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(395, 65);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(170, 24);
            this.txtTongTien.TabIndex = 9;

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(585, 68);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(70, 17);
            this.lblTrangThai.TabIndex = 10;
            this.lblTrangThai.Text = "Trạng thái:";

            this.txtTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangThai.Location = new System.Drawing.Point(685, 65);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(165, 24);
            this.txtTrangThai.TabIndex = 11;

            this.grpChiTiet.Controls.Add(this.dgvChiTiet);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTiet.Location = new System.Drawing.Point(10, 115);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Padding = new System.Windows.Forms.Padding(10);
            this.grpChiTiet.Size = new System.Drawing.Size(864, 345);
            this.grpChiTiet.TabIndex = 1;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Danh sách mặt hàng bán";

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
            this.dgvChiTiet.Size = new System.Drawing.Size(844, 308);
            this.dgvChiTiet.TabIndex = 0;

            this.colMaHang.DataPropertyName = "ma_hang";
            this.colMaHang.HeaderText = "Mã hàng";
            this.colMaHang.Name = "colMaHang";
            this.colMaHang.ReadOnly = true;
            this.colMaHang.Width = 110;

            this.colTenHang.DataPropertyName = "ten_hang_hoa";
            this.colTenHang.HeaderText = "Tên hàng hóa";
            this.colTenHang.Name = "colTenHang";
            this.colTenHang.ReadOnly = true;
            this.colTenHang.Width = 220;

            this.colSoLuong.DataPropertyName = "so_luong";
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.Width = 95;

            this.colDonGia.DataPropertyName = "don_gia";
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            this.colDonGia.Width = 130;

            this.colGiamGia.DataPropertyName = "giam_gia";
            this.colGiamGia.HeaderText = "Giảm giá (%)";
            this.colGiamGia.Name = "colGiamGia";
            this.colGiamGia.ReadOnly = true;
            this.colGiamGia.Width = 105;

            this.colThanhTien.DataPropertyName = "thanh_tien";
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.Width = 140;

            this.pnlBottom.Controls.Add(this.btnHuyHoaDon);
            this.pnlBottom.Controls.Add(this.btnInHoaDon);
            this.pnlBottom.Controls.Add(this.btnDong);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(10, 460);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(864, 45);
            this.pnlBottom.TabIndex = 2;

            this.btnHuyHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyHoaDon.Location = new System.Drawing.Point(464, 8);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(140, 32);
            this.btnHuyHoaDon.TabIndex = 2;
            this.btnHuyHoaDon.Text = "Hủy hóa đơn";
            this.btnHuyHoaDon.UseVisualStyleBackColor = true;
            this.btnHuyHoaDon.Click += new System.EventHandler(this.btnHuyHoaDon_Click);

            this.btnInHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInHoaDon.Location = new System.Drawing.Point(614, 8);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(120, 32);
            this.btnInHoaDon.TabIndex = 0;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);

            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.Location = new System.Drawing.Point(744, 8);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 32);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(884, 515);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpThongTinChung);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiTietHDBanModal";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CHI TIẾT HÓA ĐƠN BÁN";
            this.Load += new System.EventHandler(this.frmChiTietHDBanModal_Load);
            this.grpThongTinChung.ResumeLayout(false);
            this.grpThongTinChung.PerformLayout();
            this.grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpThongTinChung;
        private System.Windows.Forms.Label lblSoHDB;
        private System.Windows.Forms.TextBox txtSoHDB;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.TextBox txtThoiGian;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.TextBox txtKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnHuyHoaDon;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Button btnDong;
    }
}
