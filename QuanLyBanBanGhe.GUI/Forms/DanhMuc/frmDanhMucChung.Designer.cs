namespace QuanLyBanBanGhe.GUI.Forms.DanhMuc
{
    partial class frmDanhMucChung
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
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblLoaiThuocTinh = new System.Windows.Forms.Label();
            this.cboLoaiThuocTinh = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.pnlChucNang = new System.Windows.Forms.Panel();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpThongTin.SuspendLayout();
            this.pnlChucNang.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.SuspendLayout();

            this.grpThongTin.Controls.Add(this.lblLoaiThuocTinh);
            this.grpThongTin.Controls.Add(this.cboLoaiThuocTinh);
            this.grpThongTin.Controls.Add(this.lblLoai);
            this.grpThongTin.Controls.Add(this.cboLoai);
            this.grpThongTin.Controls.Add(this.lblMa);
            this.grpThongTin.Controls.Add(this.txtMa);
            this.grpThongTin.Controls.Add(this.lblTen);
            this.grpThongTin.Controls.Add(this.txtTen);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTin.Location = new System.Drawing.Point(10, 10);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(940, 130);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin thuộc tính";

            this.lblLoaiThuocTinh.AutoSize = true;
            this.lblLoaiThuocTinh.Location = new System.Drawing.Point(20, 35);
            this.lblLoaiThuocTinh.Name = "lblLoaiThuocTinh";
            this.lblLoaiThuocTinh.Size = new System.Drawing.Size(127, 17);
            this.lblLoaiThuocTinh.TabIndex = 0;
            this.lblLoaiThuocTinh.Text = "Chọn loại danh mục:";

            this.cboLoaiThuocTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThuocTinh.FormattingEnabled = true;
            this.cboLoaiThuocTinh.Location = new System.Drawing.Point(160, 32);
            this.cboLoaiThuocTinh.Name = "cboLoaiThuocTinh";
            this.cboLoaiThuocTinh.Size = new System.Drawing.Size(260, 25);
            this.cboLoaiThuocTinh.TabIndex = 1;
            this.cboLoaiThuocTinh.SelectedIndexChanged += new System.EventHandler(this.cboLoaiThuocTinh_SelectedIndexChanged);

            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(470, 35);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(123, 17);
            this.lblLoai.TabIndex = 2;
            this.lblLoai.Text = "Thuộc loại bàn ghế:";
            this.lblLoai.Visible = false;

            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(610, 32);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(260, 25);
            this.cboLoai.TabIndex = 3;
            this.cboLoai.Visible = false;

            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(20, 80);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(91, 17);
            this.lblMa.TabIndex = 4;
            this.lblMa.Text = "Mã thuộc tính:";

            this.txtMa.Location = new System.Drawing.Point(160, 77);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(260, 24);
            this.txtMa.TabIndex = 5;

            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(470, 80);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(92, 17);
            this.lblTen.TabIndex = 6;
            this.lblTen.Text = "Tên thuộc tính:";

            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(610, 77);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(300, 24);
            this.txtTen.TabIndex = 7;

            this.pnlChucNang.Controls.Add(this.flpButtons);
            this.pnlChucNang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChucNang.Location = new System.Drawing.Point(10, 140);
            this.pnlChucNang.Name = "pnlChucNang";
            this.pnlChucNang.Size = new System.Drawing.Size(940, 50);
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
            this.flpButtons.Size = new System.Drawing.Size(940, 50);
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

            this.grpDanhSach.Controls.Add(this.dgvDanhMuc);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSach.Location = new System.Drawing.Point(10, 190);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(10);
            this.grpDanhSach.Size = new System.Drawing.Size(940, 400);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách thuộc tính";

            this.dgvDanhMuc.AllowUserToAddRows = false;
            this.dgvDanhMuc.AllowUserToDeleteRows = false;
            this.dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhMuc.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMa,
            this.colTen,
            this.colLoai});
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.Location = new System.Drawing.Point(10, 27);
            this.dgvDanhMuc.MultiSelect = false;
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersWidth = 35;
            this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.Size = new System.Drawing.Size(920, 363);
            this.dgvDanhMuc.TabIndex = 0;
            this.dgvDanhMuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhMuc_CellClick);

            this.colMa.DataPropertyName = "Ma";
            this.colMa.FillWeight = 30F;
            this.colMa.HeaderText = "Mã thuộc tính";
            this.colMa.Name = "colMa";
            this.colMa.ReadOnly = true;

            this.colTen.DataPropertyName = "Ten";
            this.colTen.FillWeight = 45F;
            this.colTen.HeaderText = "Tên thuộc tính";
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;

            this.colLoai.DataPropertyName = "MaLoai";
            this.colLoai.FillWeight = 25F;
            this.colLoai.HeaderText = "Thuộc loại bàn ghế";
            this.colLoai.Name = "colLoai";
            this.colLoai.ReadOnly = true;
            this.colLoai.Visible = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.pnlChucNang);
            this.Controls.Add(this.grpThongTin);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDanhMucChung";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "DANH MỤC THUỘC TÍNH";
            this.Load += new System.EventHandler(this.frmDanhMucChung_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.pnlChucNang.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblLoaiThuocTinh;
        private System.Windows.Forms.ComboBox cboLoaiThuocTinh;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Panel pnlChucNang;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoai;
    }
}
