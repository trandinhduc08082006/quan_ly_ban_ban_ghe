namespace QuanLyBanBanGhe.GUI.Forms.TimKiem
{
    partial class frmTimKiemHangHoa
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
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblKichThuoc = new System.Windows.Forms.Label();
            this.cboKichThuoc = new System.Windows.Forms.ComboBox();
            this.lblHinhDang = new System.Windows.Forms.Label();
            this.cboHinhDang = new System.Windows.Forms.ComboBox();
            this.lblChatLieu = new System.Windows.Forms.Label();
            this.cboChatLieu = new System.Windows.Forms.ComboBox();
            this.lblMauSac = new System.Windows.Forms.Label();
            this.cboMauSac = new System.Windows.Forms.ComboBox();
            this.lblNuocSX = new System.Windows.Forms.Label();
            this.cboNuocSX = new System.Windows.Forms.ComboBox();
            this.lblNhaSX = new System.Windows.Forms.Label();
            this.cboNhaSX = new System.Windows.Forms.ComboBox();
            this.lblCongDung = new System.Windows.Forms.Label();
            this.cboCongDung = new System.Windows.Forms.ComboBox();
            this.lblDacDiem = new System.Windows.Forms.Label();
            this.cboDacDiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpKetQua = new System.Windows.Forms.GroupBox();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.colMaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNuocSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChatLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCongDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaoHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.lblAnh = new System.Windows.Forms.Label();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.grpTieuChi.SuspendLayout();
            this.grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.SuspendLayout();

            this.grpTieuChi.Controls.Add(this.lblTuKhoa);
            this.grpTieuChi.Controls.Add(this.txtTuKhoa);
            this.grpTieuChi.Controls.Add(this.lblLoai);
            this.grpTieuChi.Controls.Add(this.cboLoai);
            this.grpTieuChi.Controls.Add(this.lblKichThuoc);
            this.grpTieuChi.Controls.Add(this.cboKichThuoc);
            this.grpTieuChi.Controls.Add(this.lblHinhDang);
            this.grpTieuChi.Controls.Add(this.cboHinhDang);
            this.grpTieuChi.Controls.Add(this.lblChatLieu);
            this.grpTieuChi.Controls.Add(this.cboChatLieu);
            this.grpTieuChi.Controls.Add(this.lblMauSac);
            this.grpTieuChi.Controls.Add(this.cboMauSac);
            this.grpTieuChi.Controls.Add(this.lblNuocSX);
            this.grpTieuChi.Controls.Add(this.cboNuocSX);
            this.grpTieuChi.Controls.Add(this.lblNhaSX);
            this.grpTieuChi.Controls.Add(this.cboNhaSX);
            this.grpTieuChi.Controls.Add(this.lblCongDung);
            this.grpTieuChi.Controls.Add(this.cboCongDung);
            this.grpTieuChi.Controls.Add(this.lblDacDiem);
            this.grpTieuChi.Controls.Add(this.cboDacDiem);
            this.grpTieuChi.Controls.Add(this.btnTimKiem);
            this.grpTieuChi.Controls.Add(this.btnLamMoi);
            this.grpTieuChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTieuChi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTieuChi.Location = new System.Drawing.Point(10, 10);
            this.grpTieuChi.Name = "grpTieuChi";
            this.grpTieuChi.Size = new System.Drawing.Size(1080, 145);
            this.grpTieuChi.TabIndex = 0;
            this.grpTieuChi.TabStop = false;
            this.grpTieuChi.Text = "Tiêu chí tìm kiếm sản phẩm bàn ghế";

            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(15, 28);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(95, 17);
            this.lblTuKhoa.TabIndex = 0;
            this.lblTuKhoa.Text = "Mã/Tên hàng:";

            this.txtTuKhoa.Location = new System.Drawing.Point(115, 25);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(150, 24);
            this.txtTuKhoa.TabIndex = 1;
            this.txtTuKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTuKhoa_KeyDown);

            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(285, 28);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(35, 17);
            this.lblLoai.TabIndex = 2;
            this.lblLoai.Text = "Loại:";

            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(365, 25);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(150, 25);
            this.cboLoai.TabIndex = 3;
            this.cboLoai.SelectedIndexChanged += new System.EventHandler(this.cboLoai_SelectedIndexChanged);

            this.lblKichThuoc.AutoSize = true;
            this.lblKichThuoc.Location = new System.Drawing.Point(535, 28);
            this.lblKichThuoc.Name = "lblKichThuoc";
            this.lblKichThuoc.Size = new System.Drawing.Size(71, 17);
            this.lblKichThuoc.TabIndex = 4;
            this.lblKichThuoc.Text = "Kích thước:";

            this.cboKichThuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKichThuoc.FormattingEnabled = true;
            this.cboKichThuoc.Location = new System.Drawing.Point(625, 25);
            this.cboKichThuoc.Name = "cboKichThuoc";
            this.cboKichThuoc.Size = new System.Drawing.Size(150, 25);
            this.cboKichThuoc.TabIndex = 5;
            this.cboKichThuoc.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);

            this.lblHinhDang.AutoSize = true;
            this.lblHinhDang.Location = new System.Drawing.Point(795, 28);
            this.lblHinhDang.Name = "lblHinhDang";
            this.lblHinhDang.Size = new System.Drawing.Size(71, 17);
            this.lblHinhDang.TabIndex = 6;
            this.lblHinhDang.Text = "Hình dáng:";

            this.cboHinhDang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHinhDang.FormattingEnabled = true;
            this.cboHinhDang.Location = new System.Drawing.Point(885, 25);
            this.cboHinhDang.Name = "cboHinhDang";
            this.cboHinhDang.Size = new System.Drawing.Size(150, 25);
            this.cboHinhDang.TabIndex = 7;
            this.cboHinhDang.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);

            this.lblChatLieu.AutoSize = true;
            this.lblChatLieu.Location = new System.Drawing.Point(15, 65);
            this.lblChatLieu.Name = "lblChatLieu";
            this.lblChatLieu.Size = new System.Drawing.Size(61, 17);
            this.lblChatLieu.TabIndex = 8;
            this.lblChatLieu.Text = "Chất liệu:";

            this.cboChatLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChatLieu.FormattingEnabled = true;
            this.cboChatLieu.Location = new System.Drawing.Point(115, 62);
            this.cboChatLieu.Name = "cboChatLieu";
            this.cboChatLieu.Size = new System.Drawing.Size(150, 25);
            this.cboChatLieu.TabIndex = 9;
            this.cboChatLieu.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);

            this.lblMauSac.AutoSize = true;
            this.lblMauSac.Location = new System.Drawing.Point(285, 65);
            this.lblMauSac.Name = "lblMauSac";
            this.lblMauSac.Size = new System.Drawing.Size(59, 17);
            this.lblMauSac.TabIndex = 10;
            this.lblMauSac.Text = "Màu sắc:";

            this.cboMauSac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMauSac.FormattingEnabled = true;
            this.cboMauSac.Location = new System.Drawing.Point(365, 62);
            this.cboMauSac.Name = "cboMauSac";
            this.cboMauSac.Size = new System.Drawing.Size(150, 25);
            this.cboMauSac.TabIndex = 11;
            this.cboMauSac.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);

            this.lblNuocSX.AutoSize = true;
            this.lblNuocSX.Location = new System.Drawing.Point(535, 65);
            this.lblNuocSX.Name = "lblNuocSX";
            this.lblNuocSX.Size = new System.Drawing.Size(60, 17);
            this.lblNuocSX.TabIndex = 12;
            this.lblNuocSX.Text = "Nước SX:";

            this.cboNuocSX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNuocSX.FormattingEnabled = true;
            this.cboNuocSX.Location = new System.Drawing.Point(625, 62);
            this.cboNuocSX.Name = "cboNuocSX";
            this.cboNuocSX.Size = new System.Drawing.Size(150, 25);
            this.cboNuocSX.TabIndex = 13;
            this.cboNuocSX.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);

            this.lblNhaSX.AutoSize = true;
            this.lblNhaSX.Location = new System.Drawing.Point(795, 65);
            this.lblNhaSX.Name = "lblNhaSX";
            this.lblNhaSX.Size = new System.Drawing.Size(55, 17);
            this.lblNhaSX.TabIndex = 14;
            this.lblNhaSX.Text = "Nhà SX:";

            this.cboNhaSX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaSX.FormattingEnabled = true;
            this.cboNhaSX.Location = new System.Drawing.Point(885, 62);
            this.cboNhaSX.Name = "cboNhaSX";
            this.cboNhaSX.Size = new System.Drawing.Size(150, 25);
            this.cboNhaSX.TabIndex = 15;
            this.cboNhaSX.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);

            this.lblCongDung.AutoSize = true;
            this.lblCongDung.Location = new System.Drawing.Point(15, 102);
            this.lblCongDung.Name = "lblCongDung";
            this.lblCongDung.Size = new System.Drawing.Size(75, 17);
            this.lblCongDung.TabIndex = 16;
            this.lblCongDung.Text = "Công dụng:";

            this.cboCongDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCongDung.FormattingEnabled = true;
            this.cboCongDung.Location = new System.Drawing.Point(115, 99);
            this.cboCongDung.Name = "cboCongDung";
            this.cboCongDung.Size = new System.Drawing.Size(150, 25);
            this.cboCongDung.TabIndex = 17;
            this.cboCongDung.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);

            this.lblDacDiem.AutoSize = true;
            this.lblDacDiem.Location = new System.Drawing.Point(285, 102);
            this.lblDacDiem.Name = "lblDacDiem";
            this.lblDacDiem.Size = new System.Drawing.Size(65, 17);
            this.lblDacDiem.TabIndex = 18;
            this.lblDacDiem.Text = "Đặc điểm:";

            this.cboDacDiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDacDiem.FormattingEnabled = true;
            this.cboDacDiem.Location = new System.Drawing.Point(365, 99);
            this.cboDacDiem.Name = "cboDacDiem";
            this.cboDacDiem.Size = new System.Drawing.Size(150, 25);
            this.cboDacDiem.TabIndex = 19;
            this.cboDacDiem.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);

            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnTimKiem.Location = new System.Drawing.Point(625, 97);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(150, 30);
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnLamMoi.Location = new System.Drawing.Point(885, 97);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(150, 30);
            this.btnLamMoi.TabIndex = 21;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.grpKetQua.Controls.Add(this.dgvKetQua);
            this.grpKetQua.Controls.Add(this.pnlPreview);
            this.grpKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKetQua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpKetQua.Location = new System.Drawing.Point(10, 155);
            this.grpKetQua.Name = "grpKetQua";
            this.grpKetQua.Padding = new System.Windows.Forms.Padding(10);
            this.grpKetQua.Size = new System.Drawing.Size(1080, 515);
            this.grpKetQua.TabIndex = 1;
            this.grpKetQua.TabStop = false;
            this.grpKetQua.Text = "Danh sách kết quả tìm kiếm";

            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHang,
            this.colTenHang,
            this.colNuocSX,
            this.colChatLieu,
            this.colCongDung,
            this.colSoLuong,
            this.colDonGiaNhap,
            this.colDonGiaBan,
            this.colBaoHanh,
            this.colGhiChu});
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(10, 27);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersWidth = 35;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(840, 478);
            this.dgvKetQua.TabIndex = 0;
            this.dgvKetQua.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellClick);
            this.dgvKetQua.SelectionChanged += new System.EventHandler(this.dgvKetQua_SelectionChanged);

            this.pnlPreview.Controls.Add(this.picAnh);
            this.pnlPreview.Controls.Add(this.lblAnh);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPreview.Location = new System.Drawing.Point(850, 27);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlPreview.Size = new System.Drawing.Size(220, 478);
            this.pnlPreview.TabIndex = 1;

            this.lblAnh.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAnh.Location = new System.Drawing.Point(10, 0);
            this.lblAnh.Name = "lblAnh";
            this.lblAnh.Size = new System.Drawing.Size(210, 25);
            this.lblAnh.TabIndex = 0;
            this.lblAnh.Text = "Ảnh sản phẩm (Nhấp để phóng to):";
            this.lblAnh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAnh.Dock = System.Windows.Forms.DockStyle.Top;
            this.picAnh.Location = new System.Drawing.Point(10, 25);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(210, 210);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.TabIndex = 1;
            this.picAnh.TabStop = false;
            this.picAnh.Click += new System.EventHandler(this.picAnh_Click);

            this.colMaHang.DataPropertyName = "ma_hang";
            this.colMaHang.HeaderText = "Mã hàng";
            this.colMaHang.Name = "colMaHang";
            this.colMaHang.ReadOnly = true;
            this.colMaHang.Width = 95;

            this.colTenHang.DataPropertyName = "ten_hang_hoa";
            this.colTenHang.HeaderText = "Tên hàng hóa";
            this.colTenHang.Name = "colTenHang";
            this.colTenHang.ReadOnly = true;
            this.colTenHang.Width = 180;

            this.colNuocSX.DataPropertyName = "ten_nuoc_san_xuat";
            this.colNuocSX.HeaderText = "Nước sản xuất";
            this.colNuocSX.Name = "colNuocSX";
            this.colNuocSX.ReadOnly = true;
            this.colNuocSX.Width = 120;

            this.colChatLieu.DataPropertyName = "ten_chat_lieu";
            this.colChatLieu.HeaderText = "Chất liệu";
            this.colChatLieu.Name = "colChatLieu";
            this.colChatLieu.ReadOnly = true;
            this.colChatLieu.Width = 110;

            this.colCongDung.DataPropertyName = "ten_cong_dung";
            this.colCongDung.HeaderText = "Công dụng";
            this.colCongDung.Name = "colCongDung";
            this.colCongDung.ReadOnly = true;
            this.colCongDung.Width = 120;

            this.colSoLuong.DataPropertyName = "so_luong";
            this.colSoLuong.HeaderText = "Tồn kho";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.Width = 85;

            this.colDonGiaNhap.DataPropertyName = "don_gia_nhap";
            this.colDonGiaNhap.HeaderText = "Đơn giá nhập";
            this.colDonGiaNhap.Name = "colDonGiaNhap";
            this.colDonGiaNhap.ReadOnly = true;
            this.colDonGiaNhap.Width = 115;

            this.colDonGiaBan.DataPropertyName = "don_gia_ban";
            this.colDonGiaBan.HeaderText = "Đơn giá bán";
            this.colDonGiaBan.Name = "colDonGiaBan";
            this.colDonGiaBan.ReadOnly = true;
            this.colDonGiaBan.Width = 115;

            this.colBaoHanh.DataPropertyName = "thoi_gian_bao_hanh";
            this.colBaoHanh.HeaderText = "BH (tháng)";
            this.colBaoHanh.Name = "colBaoHanh";
            this.colBaoHanh.ReadOnly = true;
            this.colBaoHanh.Width = 90;

            this.colGhiChu.DataPropertyName = "ghi_chu";
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            this.colGhiChu.Width = 130;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.grpKetQua);
            this.Controls.Add(this.grpTieuChi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTimKiemHangHoa";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "TÌM KIẾM HÀNG HÓA";
            this.Load += new System.EventHandler(this.frmTimKiemHangHoa_Load);
            this.grpTieuChi.ResumeLayout(false);
            this.grpTieuChi.PerformLayout();
            this.grpKetQua.ResumeLayout(false);
            this.pnlPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpTieuChi;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblKichThuoc;
        private System.Windows.Forms.ComboBox cboKichThuoc;
        private System.Windows.Forms.Label lblHinhDang;
        private System.Windows.Forms.ComboBox cboHinhDang;
        private System.Windows.Forms.Label lblChatLieu;
        private System.Windows.Forms.ComboBox cboChatLieu;
        private System.Windows.Forms.Label lblMauSac;
        private System.Windows.Forms.ComboBox cboMauSac;
        private System.Windows.Forms.Label lblNuocSX;
        private System.Windows.Forms.ComboBox cboNuocSX;
        private System.Windows.Forms.Label lblNhaSX;
        private System.Windows.Forms.ComboBox cboNhaSX;
        private System.Windows.Forms.Label lblCongDung;
        private System.Windows.Forms.ComboBox cboCongDung;
        private System.Windows.Forms.Label lblDacDiem;
        private System.Windows.Forms.ComboBox cboDacDiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpKetQua;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Label lblAnh;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNuocSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCongDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaoHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
    }
}
