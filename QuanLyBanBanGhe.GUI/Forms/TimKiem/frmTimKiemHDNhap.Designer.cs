namespace QuanLyBanBanGhe.GUI.Forms.TimKiem
{
    partial class frmTimKiemHDNhap
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
            this.grpTieuChi = new System.Windows.Forms.GroupBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpKetQua = new System.Windows.Forms.GroupBox();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.colSoHDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiGianNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpTieuChi.SuspendLayout();
            this.grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();

            this.grpTieuChi.Controls.Add(this.lblTuNgay);
            this.grpTieuChi.Controls.Add(this.dtpTuNgay);
            this.grpTieuChi.Controls.Add(this.lblDenNgay);
            this.grpTieuChi.Controls.Add(this.dtpDenNgay);
            this.grpTieuChi.Controls.Add(this.lblNhanVien);
            this.grpTieuChi.Controls.Add(this.cboNhanVien);
            this.grpTieuChi.Controls.Add(this.lblNhaCungCap);
            this.grpTieuChi.Controls.Add(this.cboNhaCungCap);
            this.grpTieuChi.Controls.Add(this.btnTimKiem);
            this.grpTieuChi.Controls.Add(this.btnLamMoi);
            this.grpTieuChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTieuChi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTieuChi.Location = new System.Drawing.Point(10, 10);
            this.grpTieuChi.Name = "grpTieuChi";
            this.grpTieuChi.Size = new System.Drawing.Size(1080, 115);
            this.grpTieuChi.TabIndex = 0;
            this.grpTieuChi.TabStop = false;
            this.grpTieuChi.Text = "Tiêu chí tìm kiếm hóa đơn nhập hàng";

            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(20, 32);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(58, 17);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";

            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(115, 29);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(220, 24);
            this.dtpTuNgay.TabIndex = 1;

            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(365, 32);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(66, 17);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";

            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(470, 29);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(290, 24);
            this.dtpDenNgay.TabIndex = 3;

            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(20, 72);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(91, 17);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên lập:";

            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(115, 69);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(220, 25);
            this.cboNhanVien.TabIndex = 5;

            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Location = new System.Drawing.Point(365, 72);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(92, 17);
            this.lblNhaCungCap.TabIndex = 6;
            this.lblNhaCungCap.Text = "Nhà cung cấp:";

            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.DropDownWidth = 380;
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(470, 69);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(290, 25);
            this.cboNhaCungCap.TabIndex = 7;

            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnTimKiem.Location = new System.Drawing.Point(790, 26);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(130, 32);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnLamMoi.Location = new System.Drawing.Point(790, 66);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 32);
            this.btnLamMoi.TabIndex = 9;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.grpKetQua.Controls.Add(this.dgvKetQua);
            this.grpKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKetQua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpKetQua.Location = new System.Drawing.Point(10, 125);
            this.grpKetQua.Name = "grpKetQua";
            this.grpKetQua.Padding = new System.Windows.Forms.Padding(10);
            this.grpKetQua.Size = new System.Drawing.Size(1080, 545);
            this.grpKetQua.TabIndex = 1;
            this.grpKetQua.TabStop = false;
            this.grpKetQua.Text = "Danh sách hóa đơn nhập tìm thấy";

            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSoHDN,
            this.colThoiGianNhap,
            this.colNhaCungCap,
            this.colNhanVien,
            this.colTongTien,
            this.colTrangThai});
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(10, 27);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersWidth = 35;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(1060, 508);
            this.dgvKetQua.TabIndex = 0;
            this.dgvKetQua.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellDoubleClick);
            this.dgvKetQua.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKetQua_CellFormatting);

            this.colSoHDN.DataPropertyName = "so_hoa_don_nhap";
            this.colSoHDN.HeaderText = "Số HĐ nhập";
            this.colSoHDN.Name = "colSoHDN";
            this.colSoHDN.ReadOnly = true;
            this.colSoHDN.Width = 140;

            this.colThoiGianNhap.DataPropertyName = "thoi_gian_nhap";
            this.colThoiGianNhap.HeaderText = "Thời gian nhập";
            this.colThoiGianNhap.Name = "colThoiGianNhap";
            this.colThoiGianNhap.ReadOnly = true;
            this.colThoiGianNhap.Width = 160;

            this.colNhaCungCap.DataPropertyName = "ten_nha_cung_cap";
            this.colNhaCungCap.HeaderText = "Nhà cung cấp";
            this.colNhaCungCap.Name = "colNhaCungCap";
            this.colNhaCungCap.ReadOnly = true;
            this.colNhaCungCap.Width = 240;

            this.colNhanVien.DataPropertyName = "ten_nhan_vien";
            this.colNhanVien.HeaderText = "Nhân viên lập";
            this.colNhanVien.Name = "colNhanVien";
            this.colNhanVien.ReadOnly = true;
            this.colNhanVien.Width = 200;

            this.colTongTien.DataPropertyName = "tong_tien";
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            this.colTongTien.Width = 150;

            this.colTrangThai.DataPropertyName = "trang_thai_giao_dich";
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 130;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.grpKetQua);
            this.Controls.Add(this.grpTieuChi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTimKiemHDNhap";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "TÌM KIẾM HÓA ĐƠN NHẬP";
            this.Load += new System.EventHandler(this.frmTimKiemHDNhap_Load);
            this.grpTieuChi.ResumeLayout(false);
            this.grpTieuChi.PerformLayout();
            this.grpKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpTieuChi;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpKetQua;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoHDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGianNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}
