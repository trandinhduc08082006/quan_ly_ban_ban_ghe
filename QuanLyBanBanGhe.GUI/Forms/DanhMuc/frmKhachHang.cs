using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.DTO;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.DanhMuc
{
    public partial class frmKhachHang : Form
    {
        private readonly DoiTacBLL doiTacBLL;
        private FormMode currentMode;
        private bool dangTaiDuLieu;
        private bool daTimKiem;
        private Button btnKhoiPhuc;
        private ComboBox cboLocTrangThai;
        private Label lblLocTrangThai;

        public frmKhachHang()
        {
            InitializeComponent();
            doiTacBLL = new DoiTacBLL();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            UIHelper.GanXoaChonTuDong(dgvKhachHang);
            dgvKhachHang.KeyUp += dgvKhachHang_KeyUp;
            txtMaKhach.CharacterCasing = CharacterCasing.Upper;
            txtMaKhach.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapMa(ev);
            txtDienThoai.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);
            txtDienThoai.MaxLength = 10;

            DangKySuKienTimKiem();
            KhoiTaoBoLocTrangThai();
            LoadDanhSachKhachHang();
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvKhachHang);
        }

        private void DangKySuKienTimKiem()
        {
            txtMaKhach.TextChanged += TieuChiTimKiem_TextChanged;
            txtTenKhach.TextChanged += TieuChiTimKiem_TextChanged;
            txtDienThoai.TextChanged += TieuChiTimKiem_TextChanged;
            txtDiaChi.TextChanged += TieuChiTimKiem_TextChanged;
        }

        private void TieuChiTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu || currentMode != FormMode.View)
            {
                return;
            }

            CapNhatTrangThaiNutBoQua();
        }

        private void CapNhatTrangThaiNutBoQua()
        {
            if (currentMode != FormMode.View)
            {
                return;
            }

            bool coTieuChi = !string.IsNullOrWhiteSpace(txtMaKhach.Text)
                || !string.IsNullOrWhiteSpace(txtTenKhach.Text)
                || !string.IsNullOrWhiteSpace(txtDienThoai.Text)
                || !string.IsNullOrWhiteSpace(txtDiaChi.Text);

            btnBoQua.Enabled = coTieuChi || daTimKiem;
        }

        private void KhoiTaoBoLocTrangThai()
        {
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
                Visible = true
            };

            cboLocTrangThai = new ComboBox
            {
                Name = "cboLocTrangThai",
                DropDownStyle = ComboBoxStyle.DropDownList,
                Size = new System.Drawing.Size(140, 32),
                Margin = new Padding(0, 4, 10, 0),
                Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0),
                Visible = true
            };
            cboLocTrangThai.Items.Add("Đang hoạt động");
            cboLocTrangThai.Items.Add("Đã xóa");
            cboLocTrangThai.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndexChanged += cboLocTrangThai_SelectedIndexChanged;

            flpButtons.Controls.Add(btnKhoiPhuc);
            flpButtons.Controls.Add(lblLocTrangThai);
            flpButtons.Controls.Add(cboLocTrangThai);
        }

        private void LoadDanhSachKhachHang()
        {
            try
            {
                bool chiLayDangHoatDong = cboLocTrangThai == null || cboLocTrangThai.SelectedIndex != 1;
                DataTable dt = doiTacBLL.LayDanhSachKhachHang(chiLayDangHoatDong);
                dgvKhachHang.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvKhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            daTimKiem = false;
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            LoadDanhSachKhachHang();
            UIHelper.XoaChonLuoi(dgvKhachHang);
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
                btnBoQua.Visible = true;
                btnBoQua.Enabled = (mode == FormMode.Selected);
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

            if (btnTimKiem != null)
            {
                btnTimKiem.Visible = true;
                btnTimKiem.Enabled = (mode != FormMode.Insert && mode != FormMode.Update);
            }

            switch (mode)
            {
                case FormMode.View:
                    txtMaKhach.ReadOnly = false;
                    txtTenKhach.ReadOnly = false;
                    txtDienThoai.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;
                    CapNhatTrangThaiNutBoQua();
                    break;

                case FormMode.Selected:
                    txtMaKhach.ReadOnly = true;
                    txtTenKhach.ReadOnly = true;
                    txtDienThoai.ReadOnly = true;
                    txtDiaChi.ReadOnly = true;
                    break;

                case FormMode.Insert:
                    txtMaKhach.ReadOnly = true;
                    txtTenKhach.ReadOnly = false;
                    txtDienThoai.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;
                    XoaTrang();
                    txtTenKhach.Focus();
                    break;

                case FormMode.Update:
                    txtMaKhach.ReadOnly = true;
                    txtTenKhach.ReadOnly = false;
                    txtDienThoai.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;
                    txtTenKhach.Focus();
                    break;
            }
        }

        private void XoaTrang()
        {
            dangTaiDuLieu = true;
            try
            {
                txtMaKhach.Clear();
                txtTenKhach.Clear();
                txtDienThoai.Clear();
                txtDiaChi.Clear();
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private void NapDuLieuTuDong(DataGridViewRow row)
        {
            if (row == null || row.Index < 0 || currentMode == FormMode.Insert || currentMode == FormMode.Update)
            {
                return;
            }

            dangTaiDuLieu = true;
            try
            {
                txtMaKhach.Text = row.Cells["colMaKhach"].Value?.ToString() ?? string.Empty;
                txtTenKhach.Text = row.Cells["colTenKhach"].Value?.ToString() ?? string.Empty;
                txtDienThoai.Text = row.Cells["colDienThoai"].Value?.ToString() ?? string.Empty;
                txtDiaChi.Text = row.Cells["colDiaChi"].Value?.ToString() ?? string.Empty;

                ThietLapTrangThai(FormMode.Selected);
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || currentMode == FormMode.Insert || currentMode == FormMode.Update)
            {
                return;
            }

            NapDuLieuTuDong(dgvKhachHang.Rows[e.RowIndex]);
        }

        private void dgvKhachHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                NapDuLieuTuDong(dgvKhachHang.CurrentRow);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            daTimKiem = false;
            ThietLapTrangThai(FormMode.Insert);
            UIHelper.XoaChonLuoi(dgvKhachHang);
            txtMaKhach.Text = doiTacBLL.SinhMaKhachHangMoi();
            txtTenKhach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhach.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            daTimKiem = false;
            ThietLapTrangThai(FormMode.Update);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhach.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa khách hàng '{0}' không?", txtTenKhach.Text),
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                doiTacBLL.XoaMemKhachHang(txtMaKhach.Text.Trim());
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                daTimKiem = false;
                LoadDanhSachKhachHang();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvKhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhach.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần khôi phục từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn khôi phục khách hàng '{0}' hoạt động trở lại không?", txtTenKhach.Text),
                "Xác nhận khôi phục",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                doiTacBLL.KhoiPhucKhachHang(txtMaKhach.Text.Trim());
                MessageBox.Show("Khôi phục khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                daTimKiem = false;
                LoadDanhSachKhachHang();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvKhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO
            {
                MaKhach = txtMaKhach.Text.Trim(),
                TenKhach = txtTenKhach.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                TrangThaiXoa = false
            };

            try
            {
                if (currentMode == FormMode.Insert)
                {
                    doiTacBLL.ThemKhachHang(kh);
                    MessageBox.Show("Thêm mới khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentMode == FormMode.Update)
                {
                    doiTacBLL.CapNhatKhachHang(kh);
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                daTimKiem = false;
                LoadDanhSachKhachHang();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvKhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            daTimKiem = false;
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            LoadDanhSachKhachHang();
            UIHelper.XoaChonLuoi(dgvKhachHang);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maKhach = txtMaKhach.Text.Trim();
                string tenKhach = txtTenKhach.Text.Trim();
                string dienThoai = txtDienThoai.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                bool chiLayDangHoatDong = cboLocTrangThai == null || cboLocTrangThai.SelectedIndex != 1;

                DataTable dt = doiTacBLL.TimKiemKhachHang(maKhach, tenKhach, dienThoai, diaChi, chiLayDangHoatDong);
                dgvKhachHang.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvKhachHang);

                daTimKiem = true;
                ThietLapTrangThai(FormMode.View);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
