using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.DTO;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.DanhMuc
{
    public partial class frmNhanVien : Form
    {
        private readonly NhanSuBLL nhanSuBLL;
        private FormMode currentMode;
        private bool dangTaiDuLieu;
        private Button btnKhoiPhuc;
        private ComboBox cboLocTrangThai;
        private Label lblLocTrangThai;

        public frmNhanVien()
        {
            InitializeComponent();
            nhanSuBLL = new NhanSuBLL();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            KhoiTaoQuyen();
            LoadDanhSachCongViec();

            UIHelper.FormatCurrencyColumns(dgvNhanVien, "colLuong");
            UIHelper.FormatDateColumns(dgvNhanVien, "colNgaySinh");
            UIHelper.GanXoaChonTuDong(dgvNhanVien);
            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting;

            txtMaNV.CharacterCasing = CharacterCasing.Upper;
            txtMaNV.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapMa(ev);
            txtDienThoai.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);
            txtDienThoai.MaxLength = 10;
            txtTenDangNhap.KeyPress += (s, ev) => UIHelper.KhongChoPhepKhoangTrang(ev);
            txtMatKhauMoi.KeyPress += (s, ev) => UIHelper.KhongChoPhepKhoangTrang(ev);

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = " ";
            dtpNgaySinh.ValueChanged += (s, ev) =>
            {
                if (dtpNgaySinh.CustomFormat == " ")
                {
                    dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
                }
            };
            dtpNgaySinh.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Back || ev.KeyCode == Keys.Delete)
                {
                    dtpNgaySinh.CustomFormat = " ";
                }
            };

            KhoiTaoBoLocTrangThai();
            LoadDanhSachNhanVien();
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvNhanVien);
        }

        private void KhoiTaoBoLocTrangThai()
        {
            bool laQuanLy = string.Equals(UserSession.Quyen, "QuanLy", StringComparison.OrdinalIgnoreCase);

            btnKhoiPhuc = new Button
            {
                Name = "btnKhoiPhuc",
                Text = "Khôi phục",
                Size = new System.Drawing.Size(95, 32),
                Margin = new Padding(0, 0, 10, 0),
                Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = true,
                Visible = false,
                Enabled = false
            };
            btnKhoiPhuc.Click += btnKhoiPhuc_Click;

            lblLocTrangThai = new Label
            {
                Name = "lblLocTrangThai",
                Text = "Trạng thái:",
                Size = new System.Drawing.Size(75, 32),
                Margin = new Padding(15, 0, 5, 0),
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0),
                Visible = laQuanLy
            };

            cboLocTrangThai = new ComboBox
            {
                Name = "cboLocTrangThai",
                DropDownStyle = ComboBoxStyle.DropDownList,
                Size = new System.Drawing.Size(140, 32),
                Margin = new Padding(0, 4, 10, 0),
                Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0),
                Visible = laQuanLy
            };
            cboLocTrangThai.Items.Add("Đang hoạt động");
            cboLocTrangThai.Items.Add("Đã xóa");
            cboLocTrangThai.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndexChanged += cboLocTrangThai_SelectedIndexChanged;

            flpButtons.Controls.Add(btnKhoiPhuc);
            flpButtons.Controls.Add(lblLocTrangThai);
            flpButtons.Controls.Add(cboLocTrangThai);
        }

        private void KhoiTaoQuyen()
        {
            cboQuyen.Items.Clear();
            cboQuyen.Items.Add("QuanLy");
            cboQuyen.Items.Add("BanHang");
            cboQuyen.Items.Add("ThuKho");
            cboQuyen.SelectedIndex = -1;
        }

        private void LoadDanhSachCongViec()
        {
            dangTaiDuLieu = true;
            try
            {
                DataTable dt = nhanSuBLL.LayDanhSachCongViec();
                cboCongViec.DataSource = dt;
                cboCongViec.DisplayMember = "ten_cong_viec";
                cboCongViec.ValueMember = "ma_cong_viec";
                cboCongViec.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                bool chiLayDangHoatDong = cboLocTrangThai == null || cboLocTrangThai.SelectedIndex != 1;
                DataTable dt = nhanSuBLL.LayDanhSachNhanVien(chiLayDangHoatDong);
                dgvNhanVien.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu)
            {
                return;
            }

            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            LoadDanhSachNhanVien();
            UIHelper.XoaChonLuoi(dgvNhanVien);
        }

        private void cboCongViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu)
            {
                return;
            }

            if (cboCongViec.SelectedItem is DataRowView drv)
            {
                if (drv["muc_luong"] != DBNull.Value)
                {
                    txtLuong.Text = Convert.ToDecimal(drv["muc_luong"]).ToString("N0");
                }
                else
                {
                    txtLuong.Text = "0";
                }
            }
            else
            {
                txtLuong.Clear();
            }
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNhanVien.Columns[e.ColumnIndex].Name == "colTrangThai")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.Value = "Chưa cấp TK";
                }
                else if (e.Value is bool b)
                {
                    e.Value = b ? "Hoạt động" : "Khóa";
                }
            }
        }

        private void ThietLapTrangThai(FormMode mode)
        {
            currentMode = mode;
            UIHelper.SetButtonState(mode, btnThem, btnSua, btnXoa, btnLuu, btnBoQua);

            bool dangXemDaXoa = cboLocTrangThai != null && cboLocTrangThai.SelectedIndex == 1;
            if (dangXemDaXoa)
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnLuu.Visible = false;
                btnBoQua.Visible = false;
                if (btnKhoiPhuc != null)
                {
                    btnKhoiPhuc.Visible = true;
                    btnKhoiPhuc.Enabled = (mode == FormMode.Selected);
                }
            }
            else
            {
                btnThem.Visible = true;
                btnSua.Visible = true;
                btnXoa.Visible = true;
                btnLuu.Visible = true;
                btnBoQua.Visible = true;
                if (btnKhoiPhuc != null)
                {
                    btnKhoiPhuc.Visible = false;
                    btnKhoiPhuc.Enabled = false;
                }
            }

            switch (mode)
            {
                case FormMode.View:
                    DatTrangThaiNhapLieu(false);
                    txtMaNV.ReadOnly = true;
                    txtTenDangNhap.ReadOnly = true;
                    txtLuong.ReadOnly = true;
                    btnResetMatKhau.Enabled = false;
                    break;

                case FormMode.Selected:
                    DatTrangThaiNhapLieu(false);
                    txtMaNV.ReadOnly = true;
                    txtTenDangNhap.ReadOnly = true;
                    txtLuong.ReadOnly = true;
                    btnResetMatKhau.Enabled = !dangXemDaXoa && !string.IsNullOrEmpty(txtTenDangNhap.Text);
                    break;

                case FormMode.Insert:
                    DatTrangThaiNhapLieu(true);
                    txtMaNV.ReadOnly = true;
                    txtTenDangNhap.ReadOnly = false;
                    txtLuong.ReadOnly = true;
                    btnResetMatKhau.Enabled = false;
                    XoaTrang();
                    txtTenNV.Focus();
                    break;

                case FormMode.Update:
                    DatTrangThaiNhapLieu(true);
                    txtMaNV.ReadOnly = true;
                    txtTenDangNhap.ReadOnly = !string.IsNullOrEmpty(txtTenDangNhap.Text);
                    txtLuong.ReadOnly = true;
                    btnResetMatKhau.Enabled = !string.IsNullOrEmpty(txtTenDangNhap.Text);
                    txtTenNV.Focus();
                    break;
            }
        }

        private void DatTrangThaiNhapLieu(bool moKhoa)
        {
            txtTenNV.ReadOnly = !moKhoa;
            radNam.Enabled = moKhoa;
            radNu.Enabled = moKhoa;
            dtpNgaySinh.Enabled = moKhoa;
            txtDienThoai.ReadOnly = !moKhoa;
            txtDiaChi.ReadOnly = !moKhoa;
            cboCongViec.Enabled = moKhoa;
            cboQuyen.Enabled = moKhoa;
            txtMatKhauMoi.ReadOnly = !moKhoa;
            chkTrangThaiHoatDong.Enabled = moKhoa;
        }

        private void XoaTrang()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaySinh.CustomFormat = " ";
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtLuong.Clear();
            txtTenDangNhap.Clear();
            txtMatKhauMoi.Clear();
            chkTrangThaiHoatDong.Checked = true;

            dangTaiDuLieu = true;
            try
            {
                cboCongViec.SelectedIndex = -1;
                cboQuyen.SelectedIndex = -1;
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || currentMode == FormMode.Insert || currentMode == FormMode.Update)
            {
                return;
            }

            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;
            if (drv == null)
            {
                return;
            }

            txtMaNV.Text = drv["ma_nhan_vien"]?.ToString() ?? string.Empty;
            txtTenNV.Text = drv["ten_nhan_vien"]?.ToString() ?? string.Empty;

            string gioiTinh = drv["gioi_tinh"]?.ToString() ?? string.Empty;
            if (string.Equals(gioiTinh, "Nữ", StringComparison.OrdinalIgnoreCase))
            {
                radNu.Checked = true;
            }
            else if (string.Equals(gioiTinh, "Nam", StringComparison.OrdinalIgnoreCase))
            {
                radNam.Checked = true;
            }
            else
            {
                radNam.Checked = false;
                radNu.Checked = false;
            }

            if (DateTime.TryParse(drv["ngay_sinh"]?.ToString(), out DateTime ngaySinh))
            {
                dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
                dtpNgaySinh.Value = ngaySinh;
            }
            else
            {
                dtpNgaySinh.CustomFormat = " ";
            }

            txtDienThoai.Text = drv["dien_thoai"]?.ToString() ?? string.Empty;
            txtDiaChi.Text = drv["dia_chi"]?.ToString() ?? string.Empty;

            dangTaiDuLieu = true;
            try
            {
                if (drv["ma_cong_viec"] != DBNull.Value)
                {
                    cboCongViec.SelectedValue = drv["ma_cong_viec"].ToString();
                }
            }
            finally
            {
                dangTaiDuLieu = false;
            }

            txtLuong.Text = drv["muc_luong"] != DBNull.Value ? Convert.ToDecimal(drv["muc_luong"]).ToString("N0") : "0";
            txtTenDangNhap.Text = drv["ten_dang_nhap"]?.ToString() ?? string.Empty;

            string quyen = drv["quyen"]?.ToString() ?? "BanHang";
            cboQuyen.SelectedItem = quyen;

            if (drv["trang_thai_hoat_dong"] != DBNull.Value)
            {
                chkTrangThaiHoatDong.Checked = Convert.ToBoolean(drv["trang_thai_hoat_dong"]);
            }
            else
            {
                chkTrangThaiHoatDong.Checked = true;
            }

            txtMatKhauMoi.Clear();
            ThietLapTrangThai(FormMode.Selected);
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên có tài khoản để reset mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string matKhauNhap = txtMatKhauMoi.Text.Trim();

            try
            {
                string matKhauKetQua = nhanSuBLL.ResetMatKhau(txtTenDangNhap.Text.Trim(), txtTenNV.Text.Trim(), matKhauNhap);

                if (string.IsNullOrEmpty(matKhauNhap))
                {
                    MessageBox.Show(
                        string.Format("Đã reset mật khẩu tài khoản '{0}' về mặc định: {1}", txtTenDangNhap.Text, matKhauKetQua),
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        string.Format("Đã cập nhật mật khẩu mới cho tài khoản '{0}' thành công!", txtTenDangNhap.Text),
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                txtMatKhauMoi.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThietLapTrangThai(FormMode.Insert);
            UIHelper.XoaChonLuoi(dgvNhanVien);
            txtMaNV.Text = nhanSuBLL.SinhMaNhanVienMoi();
            txtTenNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ThietLapTrangThai(FormMode.Update);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa nhân viên '{0}' không? Hệ thống sẽ khóa tài khoản liên kết (nếu có).", txtTenNV.Text),
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                nhanSuBLL.XoaMemNhanVien(txtMaNV.Text.Trim(), UserSession.MaNV);
                MessageBox.Show("Xóa nhân viên và khóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachNhanVien();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần khôi phục từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn khôi phục nhân viên '{0}' hoạt động trở lại không? Tài khoản liên kết (nếu có) cũng sẽ được mở hoạt động.", txtTenNV.Text),
                "Xác nhận khôi phục",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                nhanSuBLL.KhoiPhucNhanVien(txtMaNV.Text.Trim());
                MessageBox.Show("Khôi phục nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachNhanVien();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string gioiTinh = null;
            if (radNu.Checked)
            {
                gioiTinh = "Nữ";
            }
            else if (radNam.Checked)
            {
                gioiTinh = "Nam";
            }

            DateTime? ngaySinh = null;
            if (dtpNgaySinh.CustomFormat != " ")
            {
                ngaySinh = dtpNgaySinh.Value;
            }

            NhanVienDTO nv = new NhanVienDTO
            {
                MaNhanVien = txtMaNV.Text.Trim(),
                TenNhanVien = txtTenNV.Text.Trim(),
                GioiTinh = gioiTinh,
                NgaySinh = ngaySinh,
                DienThoai = txtDienThoai.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                MaCongViec = cboCongViec.SelectedValue?.ToString(),
                TrangThaiXoa = false
            };

            TaiKhoanDTO tk = null;
            if (!string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                tk = new TaiKhoanDTO
                {
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    Quyen = cboQuyen.SelectedItem?.ToString() ?? "BanHang",
                    TrangThaiHoatDong = chkTrangThaiHoatDong.Checked,
                    MaNhanVien = nv.MaNhanVien
                };
            }

            try
            {
                if (currentMode == FormMode.Insert)
                {
                    nhanSuBLL.ThemNhanVien(nv, tk, txtMatKhauMoi.Text.Trim());
                    MessageBox.Show("Thêm mới nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentMode == FormMode.Update)
                {
                    nhanSuBLL.CapNhatNhanVien(nv, tk, txtMatKhauMoi.Text.Trim());
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachNhanVien();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvNhanVien);
        }
    }
}
