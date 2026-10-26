using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.DTO;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.DanhMuc
{
    public partial class frmNhaCungCap : Form
    {
        private readonly DoiTacBLL doiTacBLL;
        private FormMode currentMode;
        private Button btnKhoiPhuc;
        private ComboBox cboLocTrangThai;
        private Label lblLocTrangThai;

        public frmNhaCungCap()
        {
            InitializeComponent();
            doiTacBLL = new DoiTacBLL();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            UIHelper.GanXoaChonTuDong(dgvNhaCungCap);
            txtMaNCC.CharacterCasing = CharacterCasing.Upper;
            txtMaNCC.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapMa(ev);
            txtDienThoai.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);
            txtDienThoai.MaxLength = 10;

            KhoiTaoBoLocTrangThai();
            LoadDanhSachNhaCungCap();
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvNhaCungCap);
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

        private void LoadDanhSachNhaCungCap()
        {
            try
            {
                bool chiLayDangHoatDong = cboLocTrangThai == null || cboLocTrangThai.SelectedIndex != 1;
                DataTable dt = doiTacBLL.LayDanhSachNhaCungCap(chiLayDangHoatDong);
                dgvNhaCungCap.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvNhaCungCap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            LoadDanhSachNhaCungCap();
            UIHelper.XoaChonLuoi(dgvNhaCungCap);
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
                case FormMode.Selected:
                    txtMaNCC.ReadOnly = true;
                    txtTenNCC.ReadOnly = true;
                    txtDienThoai.ReadOnly = true;
                    txtDiaChi.ReadOnly = true;
                    break;

                case FormMode.Insert:
                    txtMaNCC.ReadOnly = true;
                    txtTenNCC.ReadOnly = false;
                    txtDienThoai.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;
                    XoaTrang();
                    txtTenNCC.Focus();
                    break;

                case FormMode.Update:
                    txtMaNCC.ReadOnly = true;
                    txtTenNCC.ReadOnly = false;
                    txtDienThoai.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;
                    txtTenNCC.Focus();
                    break;
            }
        }

        private void XoaTrang()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || currentMode == FormMode.Insert || currentMode == FormMode.Update)
            {
                return;
            }

            DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];
            txtMaNCC.Text = row.Cells["colMaNCC"].Value?.ToString() ?? string.Empty;
            txtTenNCC.Text = row.Cells["colTenNCC"].Value?.ToString() ?? string.Empty;
            txtDienThoai.Text = row.Cells["colDienThoai"].Value?.ToString() ?? string.Empty;
            txtDiaChi.Text = row.Cells["colDiaChi"].Value?.ToString() ?? string.Empty;

            ThietLapTrangThai(FormMode.Selected);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThietLapTrangThai(FormMode.Insert);
            UIHelper.XoaChonLuoi(dgvNhaCungCap);
            txtMaNCC.Text = doiTacBLL.SinhMaNhaCungCapMoi();
            txtTenNCC.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ThietLapTrangThai(FormMode.Update);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa nhà cung cấp '{0}' không?", txtTenNCC.Text),
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                doiTacBLL.XoaMemNhaCungCap(txtMaNCC.Text.Trim());
                MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachNhaCungCap();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvNhaCungCap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần khôi phục từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn khôi phục nhà cung cấp '{0}' hoạt động trở lại không?", txtTenNCC.Text),
                "Xác nhận khôi phục",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                doiTacBLL.KhoiPhucNhaCungCap(txtMaNCC.Text.Trim());
                MessageBox.Show("Khôi phục nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachNhaCungCap();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvNhaCungCap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO ncc = new NhaCungCapDTO
            {
                MaNhaCungCap = txtMaNCC.Text.Trim(),
                TenNhaCungCap = txtTenNCC.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                TrangThaiXoa = false
            };

            try
            {
                if (currentMode == FormMode.Insert)
                {
                    doiTacBLL.ThemNhaCungCap(ncc);
                    MessageBox.Show("Thêm mới nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentMode == FormMode.Update)
                {
                    doiTacBLL.CapNhatNhaCungCap(ncc);
                    MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachNhaCungCap();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvNhaCungCap);
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
            UIHelper.XoaChonLuoi(dgvNhaCungCap);
        }
    }
}
