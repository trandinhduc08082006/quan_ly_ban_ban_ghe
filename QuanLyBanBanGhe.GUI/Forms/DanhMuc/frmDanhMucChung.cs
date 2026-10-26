using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.DTO;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.DanhMuc
{
    public partial class frmDanhMucChung : Form
    {
        private readonly ThuocTinhBLL bll;
        private FormMode currentMode;

        private readonly string[] danhSachTenBang = new string[]
        {
            "loai",
            "kich_thuoc",
            "hinh_dang",
            "chat_lieu",
            "nuoc_san_xuat",
            "mau_sac",
            "nha_san_xuat",
            "cong_dung",
            "dac_diem"
        };

        public frmDanhMucChung()
        {
            InitializeComponent();
            bll = new ThuocTinhBLL();
        }

        private void frmDanhMucChung_Load(object sender, EventArgs e)
        {
            UIHelper.GanXoaChonTuDong(dgvDanhMuc);
            txtMa.CharacterCasing = CharacterCasing.Upper;
            txtMa.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapMa(ev);

            KhoiTaoDanhSachLoaiThuocTinh();
            LoadDuLieu();
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvDanhMuc);
        }

        private void KhoiTaoDanhSachLoaiThuocTinh()
        {
            cboLoaiThuocTinh.Items.Clear();
            cboLoaiThuocTinh.Items.Add("Loại bàn ghế");
            cboLoaiThuocTinh.Items.Add("Kích thước");
            cboLoaiThuocTinh.Items.Add("Hình dáng");
            cboLoaiThuocTinh.Items.Add("Chất liệu");
            cboLoaiThuocTinh.Items.Add("Nước sản xuất");
            cboLoaiThuocTinh.Items.Add("Màu sắc");
            cboLoaiThuocTinh.Items.Add("Nhà sản xuất");
            cboLoaiThuocTinh.Items.Add("Công dụng");
            cboLoaiThuocTinh.Items.Add("Đặc điểm");
            cboLoaiThuocTinh.SelectedIndex = 0;
        }

        private string LayTenBangHienTai()
        {
            int index = cboLoaiThuocTinh.SelectedIndex;
            if (index >= 0 && index < danhSachTenBang.Length)
            {
                return danhSachTenBang[index];
            }
            return "loai";
        }

        private void LoadDuLieu()
        {
            string tenBang = LayTenBangHienTai();
            bool laKichThuoc = tenBang == "kich_thuoc";

            lblLoai.Visible = laKichThuoc;
            cboLoai.Visible = laKichThuoc;
            colLoai.Visible = laKichThuoc;

            if (laKichThuoc)
            {
                DataTable dtLoai = bll.LayDanhSach("loai");
                cboLoai.DataSource = dtLoai;
                cboLoai.DisplayMember = "Ten";
                cboLoai.ValueMember = "Ma";
                cboLoai.SelectedIndex = -1;
            }

            try
            {
                DataTable dt = bll.LayDanhSach(tenBang);
                dgvDanhMuc.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvDanhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLoaiThuocTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDuLieu();
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvDanhMuc);
        }

        private void ThietLapTrangThai(FormMode mode)
        {
            currentMode = mode;
            UIHelper.SetButtonState(mode, btnThem, btnSua, btnXoa, btnLuu, btnBoQua);

            btnXoa.Visible = true;

            switch (mode)
            {
                case FormMode.View:
                    txtMa.ReadOnly = true;
                    txtTen.ReadOnly = true;
                    cboLoai.Enabled = false;
                    cboLoaiThuocTinh.Enabled = true;
                    break;

                case FormMode.Selected:
                    txtMa.ReadOnly = true;
                    txtTen.ReadOnly = true;
                    cboLoai.Enabled = false;
                    cboLoaiThuocTinh.Enabled = true;
                    break;

                case FormMode.Insert:
                    txtMa.ReadOnly = true;
                    txtTen.ReadOnly = false;
                    cboLoai.Enabled = true;
                    cboLoaiThuocTinh.Enabled = false;
                    XoaTrang();
                    txtTen.Focus();
                    break;

                case FormMode.Update:
                    txtMa.ReadOnly = true;
                    txtTen.ReadOnly = false;
                    cboLoai.Enabled = true;
                    cboLoaiThuocTinh.Enabled = false;
                    txtTen.Focus();
                    break;
            }
        }

        private void XoaTrang()
        {
            txtMa.Clear();
            txtTen.Clear();
            cboLoai.SelectedIndex = -1;
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || currentMode == FormMode.Insert || currentMode == FormMode.Update)
            {
                return;
            }

            DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
            txtMa.Text = row.Cells["colMa"].Value != null ? row.Cells["colMa"].Value.ToString() : string.Empty;
            txtTen.Text = row.Cells["colTen"].Value != null ? row.Cells["colTen"].Value.ToString() : string.Empty;

            if (colLoai.Visible && cboLoai.Items.Count > 0)
            {
                string maLoai = row.Cells["colLoai"].Value != null ? row.Cells["colLoai"].Value.ToString() : string.Empty;
                cboLoai.SelectedValue = maLoai;
            }

            ThietLapTrangThai(FormMode.Selected);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThietLapTrangThai(FormMode.Insert);
            UIHelper.XoaChonLuoi(dgvDanhMuc);
            string tenBang = LayTenBangHienTai();
            txtMa.Text = bll.SinhMaThuocTinhMoi(tenBang);
            txtTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn thuộc tính cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ThietLapTrangThai(FormMode.Update);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa trên danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenBang = LayTenBangHienTai();
            DialogResult dr = MessageBox.Show(string.Format("Bạn có chắc chắn muốn xóa thuộc tính '{0}' ({1}) không?", txtTen.Text, txtMa.Text), "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    bll.Xoa(tenBang, txtMa.Text.Trim());
                    MessageBox.Show("Xóa thuộc tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDuLieu();
                    XoaTrang();
                    ThietLapTrangThai(FormMode.View);
                    UIHelper.XoaChonLuoi(dgvDanhMuc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();
            string maLoai = cboLoai.Visible && cboLoai.SelectedValue != null ? cboLoai.SelectedValue.ToString() : null;
            string tenBang = LayTenBangHienTai();

            ThuocTinhDTO item = new ThuocTinhDTO(ma, ten, maLoai);

            try
            {
                if (currentMode == FormMode.Insert)
                {
                    bll.Them(tenBang, item);
                    MessageBox.Show("Thêm mới thuộc tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentMode == FormMode.Update)
                {
                    bll.Sua(tenBang, item);
                    MessageBox.Show("Cập nhật thuộc tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDuLieu();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvDanhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvDanhMuc);
        }
    }
}
