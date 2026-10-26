using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.DTO;
using QuanLyBanBanGhe.GUI.Forms.DungChung;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.DanhMuc
{
    public partial class frmHangHoa : Form
    {
        private readonly HangHoaBLL hangHoaBLL;
        private readonly ThuocTinhBLL thuocTinhBLL;
        private FormMode currentMode;
        private string duongDanAnhNguon;
        private bool dangTaiDuLieu;
        private Button btnKhoiPhuc;
        private ComboBox cboLocTrangThai;
        private Label lblLocTrangThai;

        public frmHangHoa()
        {
            InitializeComponent();
            hangHoaBLL = new HangHoaBLL();
            thuocTinhBLL = new ThuocTinhBLL();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            UIHelper.FormatCurrencyColumns(dgvHangHoa, "colDonGiaNhap", "colDonGiaBan");
            UIHelper.FormatIntegerColumns(dgvHangHoa, "colSoLuong", "colBaoHanh");
            UIHelper.GanXoaChonTuDong(dgvHangHoa);

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(picAnh, "Nhấp để xem ảnh phóng to");

            txtMaHang.CharacterCasing = CharacterCasing.Upper;
            txtMaHang.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapMa(ev);
            txtDonGiaNhap.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);
            txtDonGiaNhap.MaxLength = 15;
            txtThoiGianBaoHanh.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);

            LoadDanhSachThuocTinh();
            KhoiTaoBoLocTrangThai();
            LoadDanhSachHangHoa();
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvHangHoa);
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

        private void LoadDanhSachThuocTinh()
        {
            dangTaiDuLieu = true;
            try
            {
                cboLoai.DataSource = thuocTinhBLL.LayDanhSach("loai");
                cboLoai.DisplayMember = "Ten";
                cboLoai.ValueMember = "Ma";
                cboLoai.SelectedIndex = -1;

                cboChatLieu.DataSource = thuocTinhBLL.LayDanhSach("chat_lieu");
                cboChatLieu.DisplayMember = "Ten";
                cboChatLieu.ValueMember = "Ma";
                cboChatLieu.SelectedIndex = -1;

                cboMauSac.DataSource = thuocTinhBLL.LayDanhSach("mau_sac");
                cboMauSac.DisplayMember = "Ten";
                cboMauSac.ValueMember = "Ma";
                cboMauSac.SelectedIndex = -1;

                cboNuocSX.DataSource = thuocTinhBLL.LayDanhSach("nuoc_san_xuat");
                cboNuocSX.DisplayMember = "Ten";
                cboNuocSX.ValueMember = "Ma";
                cboNuocSX.SelectedIndex = -1;

                cboHinhDang.DataSource = thuocTinhBLL.LayDanhSach("hinh_dang");
                cboHinhDang.DisplayMember = "Ten";
                cboHinhDang.ValueMember = "Ma";
                cboHinhDang.SelectedIndex = -1;

                cboNhaSX.DataSource = thuocTinhBLL.LayDanhSach("nha_san_xuat");
                cboNhaSX.DisplayMember = "Ten";
                cboNhaSX.ValueMember = "Ma";
                cboNhaSX.SelectedIndex = -1;

                cboCongDung.DataSource = thuocTinhBLL.LayDanhSach("cong_dung");
                cboCongDung.DisplayMember = "Ten";
                cboCongDung.ValueMember = "Ma";
                cboCongDung.SelectedIndex = -1;

                cboDacDiem.DataSource = thuocTinhBLL.LayDanhSach("dac_diem");
                cboDacDiem.DisplayMember = "Ten";
                cboDacDiem.ValueMember = "Ma";
                cboDacDiem.SelectedIndex = -1;

                cboKichThuoc.DataSource = null;
                cboKichThuoc.Items.Clear();
                cboKichThuoc.SelectedIndex = -1;
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private void LoadDanhSachHangHoa()
        {
            try
            {
                bool chiLayDangHoatDong = cboLocTrangThai == null || cboLocTrangThai.SelectedIndex != 1;
                DataTable dt = hangHoaBLL.LayTatCaHangHoa(chiLayDangHoatDong);
                dgvHangHoa.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvHangHoa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hàng hóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LoadDanhSachHangHoa();
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu)
            {
                return;
            }

            string maLoai = cboLoai.SelectedValue?.ToString();
            cboKichThuoc.DataSource = hangHoaBLL.LayKichThuocTheoLoai(maLoai);
            cboKichThuoc.DisplayMember = "Ten";
            cboKichThuoc.ValueMember = "Ma";
            cboKichThuoc.SelectedIndex = -1;
        }

        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {
            string raw = txtDonGiaNhap.Text.Trim().Replace(",", "");
            if (decimal.TryParse(raw, out decimal giaNhap))
            {
                decimal giaBan = Math.Round((giaNhap * 1.10m) / 10000m, MidpointRounding.AwayFromZero) * 10000m;
                txtDonGiaBan.Text = giaBan.ToString("N0");
            }
            else
            {
                txtDonGiaBan.Text = "0";
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    duongDanAnhNguon = ofd.FileName;
                    txtTenAnh.Text = Path.GetFileName(ofd.FileName);
                    HienThiAnhTuDuongDan(duongDanAnhNguon);
                }
            }
        }

        private void picAnh_Click(object sender, EventArgs e)
        {
            if (picAnh.Image == null)
            {
                return;
            }

            string tieuDe = "Xem ảnh sản phẩm";
            string ma = txtMaHang.Text.Trim();
            string ten = txtTenHang.Text.Trim();
            if (!string.IsNullOrWhiteSpace(ma))
            {
                tieuDe = string.Format("Ảnh sản phẩm: {0} - {1}", ma, ten);
            }

            using (frmXemAnh frm = new frmXemAnh(picAnh.Image, tieuDe))
            {
                frm.ShowDialog(this);
            }
        }

        private void HienThiAnhTuDuongDan(string duongDan)
        {
            if (picAnh.Image != null)
            {
                picAnh.Image.Dispose();
                picAnh.Image = null;
            }

            if (string.IsNullOrWhiteSpace(duongDan) || !File.Exists(duongDan))
            {
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (Image img = Image.FromStream(fs))
                    {
                        picAnh.Image = new Bitmap(img);
                    }
                }
            }
            catch
            {
                picAnh.Image = null;
            }
        }

        private void HienThiAnhSanPham(string tenFileAnh)
        {
            if (picAnh.Image != null)
            {
                picAnh.Image.Dispose();
                picAnh.Image = null;
            }

            if (string.IsNullOrWhiteSpace(tenFileAnh))
            {
                return;
            }

            string duongDanThuMucAnh = Path.Combine(Application.StartupPath, "Images");
            string duongDanFile = Path.Combine(duongDanThuMucAnh, tenFileAnh);

            if (!File.Exists(duongDanFile))
            {
                DirectoryInfo runDir = new DirectoryInfo(Application.StartupPath);
                if (runDir.Parent != null && runDir.Parent.Parent != null)
                {
                    string duongDanSource = Path.Combine(runDir.Parent.Parent.FullName, "Images", tenFileAnh);
                    if (File.Exists(duongDanSource))
                    {
                        duongDanFile = duongDanSource;
                    }
                }
            }

            if (File.Exists(duongDanFile))
            {
                try
                {
                    using (FileStream fs = new FileStream(duongDanFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (Image img = Image.FromStream(fs))
                        {
                            picAnh.Image = new Bitmap(img);
                        }
                    }
                }
                catch
                {
                    picAnh.Image = null;
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
                btnChonAnh.Enabled = false;
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
                    txtMaHang.ReadOnly = true;
                    txtSoLuong.ReadOnly = true;
                    txtDonGiaBan.ReadOnly = true;
                    break;

                case FormMode.Selected:
                    DatTrangThaiNhapLieu(false);
                    txtMaHang.ReadOnly = true;
                    txtSoLuong.ReadOnly = true;
                    txtDonGiaBan.ReadOnly = true;
                    break;

                case FormMode.Insert:
                    DatTrangThaiNhapLieu(true);
                    txtMaHang.ReadOnly = true;
                    txtSoLuong.ReadOnly = true;
                    txtDonGiaBan.ReadOnly = true;
                    XoaTrang();
                    txtTenHang.Focus();
                    break;

                case FormMode.Update:
                    DatTrangThaiNhapLieu(true);
                    txtMaHang.ReadOnly = true;
                    txtSoLuong.ReadOnly = true;
                    txtDonGiaBan.ReadOnly = true;
                    txtTenHang.Focus();
                    break;
            }
        }

        private void DatTrangThaiNhapLieu(bool moKhoa)
        {
            txtTenHang.ReadOnly = !moKhoa;
            txtDonGiaNhap.ReadOnly = !moKhoa;
            txtThoiGianBaoHanh.ReadOnly = !moKhoa;
            txtGhiChu.ReadOnly = !moKhoa;

            cboLoai.Enabled = moKhoa;
            cboChatLieu.Enabled = moKhoa;
            cboKichThuoc.Enabled = moKhoa;
            cboMauSac.Enabled = moKhoa;
            cboNuocSX.Enabled = moKhoa;
            cboHinhDang.Enabled = moKhoa;
            cboNhaSX.Enabled = moKhoa;
            cboCongDung.Enabled = moKhoa;
            cboDacDiem.Enabled = moKhoa;

            btnChonAnh.Enabled = moKhoa;
        }

        private void XoaTrang()
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtDonGiaNhap.Clear();
            txtDonGiaBan.Clear();
            txtSoLuong.Text = "0";
            txtThoiGianBaoHanh.Clear();
            txtGhiChu.Clear();
            txtTenAnh.Clear();
            duongDanAnhNguon = null;

            if (picAnh.Image != null)
            {
                picAnh.Image.Dispose();
                picAnh.Image = null;
            }

            dangTaiDuLieu = true;
            try
            {
                cboLoai.SelectedIndex = -1;
                cboChatLieu.SelectedIndex = -1;
                cboKichThuoc.DataSource = null;
                cboKichThuoc.Items.Clear();
                cboKichThuoc.SelectedIndex = -1;
                cboMauSac.SelectedIndex = -1;
                cboNuocSX.SelectedIndex = -1;
                cboHinhDang.SelectedIndex = -1;
                cboNhaSX.SelectedIndex = -1;
                cboCongDung.SelectedIndex = -1;
                cboDacDiem.SelectedIndex = -1;
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || currentMode == FormMode.Insert || currentMode == FormMode.Update)
            {
                return;
            }

            DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;
            if (drv == null)
            {
                return;
            }

            txtMaHang.Text = drv["ma_hang"]?.ToString() ?? string.Empty;
            txtTenHang.Text = drv["ten_hang_hoa"]?.ToString() ?? string.Empty;
            txtDonGiaNhap.Text = drv["don_gia_nhap"] != DBNull.Value ? Convert.ToDecimal(drv["don_gia_nhap"]).ToString("N0") : "0";
            txtDonGiaBan.Text = drv["don_gia_ban"] != DBNull.Value ? Convert.ToDecimal(drv["don_gia_ban"]).ToString("N0") : "0";
            txtSoLuong.Text = drv["so_luong"] != DBNull.Value ? drv["so_luong"].ToString() : "0";
            txtThoiGianBaoHanh.Text = drv["thoi_gian_bao_hanh"] != DBNull.Value ? drv["thoi_gian_bao_hanh"].ToString() : string.Empty;
            txtGhiChu.Text = drv["ghi_chu"]?.ToString() ?? string.Empty;

            dangTaiDuLieu = true;
            try
            {
                if (drv["ma_loai"] != DBNull.Value)
                {
                    string maLoai = drv["ma_loai"].ToString();
                    cboLoai.SelectedValue = maLoai;
                    cboKichThuoc.DataSource = hangHoaBLL.LayKichThuocTheoLoai(maLoai);
                    cboKichThuoc.DisplayMember = "Ten";
                    cboKichThuoc.ValueMember = "Ma";
                }
                if (drv["ma_kich_thuoc"] != DBNull.Value)
                {
                    cboKichThuoc.SelectedValue = drv["ma_kich_thuoc"].ToString();
                }
                if (drv["ma_chat_lieu"] != DBNull.Value)
                {
                    cboChatLieu.SelectedValue = drv["ma_chat_lieu"].ToString();
                }
                if (drv["ma_mau"] != DBNull.Value)
                {
                    cboMauSac.SelectedValue = drv["ma_mau"].ToString();
                }
                if (drv["ma_nuoc_san_xuat"] != DBNull.Value)
                {
                    cboNuocSX.SelectedValue = drv["ma_nuoc_san_xuat"].ToString();
                }
                if (drv["ma_hinh_dang"] != DBNull.Value)
                {
                    cboHinhDang.SelectedValue = drv["ma_hinh_dang"].ToString();
                }
                if (drv["ma_nha_san_xuat"] != DBNull.Value)
                {
                    cboNhaSX.SelectedValue = drv["ma_nha_san_xuat"].ToString();
                }
                if (drv["ma_cong_dung"] != DBNull.Value)
                {
                    cboCongDung.SelectedValue = drv["ma_cong_dung"].ToString();
                }
                if (drv["ma_dac_diem"] != DBNull.Value)
                {
                    cboDacDiem.SelectedValue = drv["ma_dac_diem"].ToString();
                }
            }
            finally
            {
                dangTaiDuLieu = false;
            }

            string tenAnh = drv["anh"]?.ToString() ?? string.Empty;
            txtTenAnh.Text = tenAnh;
            duongDanAnhNguon = null;
            HienThiAnhSanPham(tenAnh);

            ThietLapTrangThai(FormMode.Selected);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThietLapTrangThai(FormMode.Insert);
            UIHelper.XoaChonLuoi(dgvHangHoa);
            txtMaHang.Text = hangHoaBLL.SinhMaHangHoaMoi();
            txtSoLuong.Text = "0";
            txtTenHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHang.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ThietLapTrangThai(FormMode.Update);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHang.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa sản phẩm '{0}' không?", txtTenHang.Text),
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                hangHoaBLL.XoaMemHangHoa(txtMaHang.Text.Trim());
                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHangHoa();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvHangHoa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHang.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần khôi phục từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn khôi phục sản phẩm '{0}' hoạt động trở lại không?", txtTenHang.Text),
                "Xác nhận khôi phục",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                hangHoaBLL.KhoiPhucHangHoa(txtMaHang.Text.Trim());
                MessageBox.Show("Khôi phục sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHangHoa();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvHangHoa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text.Trim();
            string tenHang = txtTenHang.Text.Trim();

            if (string.IsNullOrWhiteSpace(maHang))
            {
                MessageBox.Show("Mã sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tenHang))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHang.Focus();
                return;
            }

            string rawGiaNhap = txtDonGiaNhap.Text.Trim().Replace(",", "");
            if (!decimal.TryParse(rawGiaNhap, out decimal giaNhap) || giaNhap < 0)
            {
                MessageBox.Show("Đơn giá nhập phải là số hợp lệ và không được nhỏ hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }

            if (giaNhap > 1000000000000m)
            {
                MessageBox.Show("Đơn giá nhập không được vượt quá 1,000 tỷ VNĐ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }

            if (cboLoai.SelectedValue == null || cboLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại bàn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoai.Focus();
                return;
            }

            if (cboKichThuoc.SelectedValue == null || cboKichThuoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn kích thước bàn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKichThuoc.Focus();
                return;
            }

            if (cboChatLieu.SelectedValue == null || cboChatLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chất liệu bàn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChatLieu.Focus();
                return;
            }

            if (cboMauSac.SelectedValue == null || cboMauSac.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn màu sắc bàn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMauSac.Focus();
                return;
            }

            if (cboNuocSX.SelectedValue == null || cboNuocSX.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nước sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNuocSX.Focus();
                return;
            }

            if (cboHinhDang.SelectedValue == null || cboHinhDang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hình dáng bàn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHinhDang.Focus();
                return;
            }

            if (cboNhaSX.SelectedValue == null || cboNhaSX.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhaSX.Focus();
                return;
            }

            if (cboCongDung.SelectedValue == null || cboCongDung.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn công dụng bàn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCongDung.Focus();
                return;
            }

            if (cboDacDiem.SelectedValue == null || cboDacDiem.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đặc điểm bàn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDacDiem.Focus();
                return;
            }

            int? baoHanh = null;
            if (!string.IsNullOrWhiteSpace(txtThoiGianBaoHanh.Text))
            {
                if (int.TryParse(txtThoiGianBaoHanh.Text.Trim(), out int bh) && bh >= 0)
                {
                    baoHanh = bh;
                }
                else
                {
                    MessageBox.Show("Thời gian bảo hành phải là số nguyên không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtThoiGianBaoHanh.Focus();
                    return;
                }
            }

            int soLuong = 0;
            if (int.TryParse(txtSoLuong.Text.Trim(), out int sl))
            {
                soLuong = sl;
            }

            string tenFileAnhLuu = txtTenAnh.Text.Trim();
            if (!string.IsNullOrEmpty(duongDanAnhNguon) && File.Exists(duongDanAnhNguon))
            {
                try
                {
                    string extension = Path.GetExtension(duongDanAnhNguon);
                    string tenFileGoc = Path.GetFileNameWithoutExtension(duongDanAnhNguon);
                    tenFileAnhLuu = string.Format("{0}_{1}{2}", maHang, tenFileGoc, extension);

                    string duongDanThuMucAnh = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(duongDanThuMucAnh))
                    {
                        Directory.CreateDirectory(duongDanThuMucAnh);
                    }
                    string duongDanDich = Path.Combine(duongDanThuMucAnh, tenFileAnhLuu);
                    if (!duongDanAnhNguon.Equals(duongDanDich, StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(duongDanAnhNguon, duongDanDich, true);
                    }

                    DirectoryInfo runDir = new DirectoryInfo(Application.StartupPath);
                    if (runDir.Parent != null && runDir.Parent.Parent != null)
                    {
                        string duongDanThuMucSource = Path.Combine(runDir.Parent.Parent.FullName, "Images");
                        if (Directory.Exists(duongDanThuMucSource) || File.Exists(Path.Combine(runDir.Parent.Parent.FullName, "QuanLyBanBanGhe.GUI.csproj")))
                        {
                            if (!Directory.Exists(duongDanThuMucSource))
                            {
                                Directory.CreateDirectory(duongDanThuMucSource);
                            }
                            string duongDanDichSource = Path.Combine(duongDanThuMucSource, tenFileAnhLuu);
                            if (!duongDanAnhNguon.Equals(duongDanDichSource, StringComparison.OrdinalIgnoreCase))
                            {
                                File.Copy(duongDanAnhNguon, duongDanDichSource, true);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sao chép ảnh sản phẩm: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            HangHoaDTO hh = new HangHoaDTO
            {
                MaHang = maHang,
                TenHangHoa = tenHang,
                MaLoai = cboLoai.SelectedValue?.ToString(),
                MaKichThuoc = cboKichThuoc.SelectedValue?.ToString(),
                MaChatLieu = cboChatLieu.SelectedValue?.ToString(),
                MaMau = cboMauSac.SelectedValue?.ToString(),
                MaNuocSanXuat = cboNuocSX.SelectedValue?.ToString(),
                MaHinhDang = cboHinhDang.SelectedValue?.ToString(),
                MaNhaSanXuat = cboNhaSX.SelectedValue?.ToString(),
                MaCongDung = cboCongDung.SelectedValue?.ToString(),
                MaDacDiem = cboDacDiem.SelectedValue?.ToString(),
                SoLuong = soLuong,
                DonGiaNhap = giaNhap,
                DonGiaBan = Math.Round((giaNhap * 1.10m) / 10000m, MidpointRounding.AwayFromZero) * 10000m,
                ThoiGianBaoHanh = baoHanh,
                Anh = string.IsNullOrWhiteSpace(tenFileAnhLuu) ? null : tenFileAnhLuu,
                GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim(),
                TrangThaiXoa = false
            };

            try
            {
                if (currentMode == FormMode.Insert)
                {
                    hangHoaBLL.ThemHangHoa(hh);
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentMode == FormMode.Update)
                {
                    hangHoaBLL.CapNhatHangHoa(hh);
                    MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachHangHoa();
                XoaTrang();
                ThietLapTrangThai(FormMode.View);
                UIHelper.XoaChonLuoi(dgvHangHoa);
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
            UIHelper.XoaChonLuoi(dgvHangHoa);
        }
    }
}
