using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.DTO;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.NghiepVu
{
    public partial class frmHoaDonNhap : Form
    {
        private readonly HoaDonNhapBLL hoaDonNhapBLL;
        private readonly DoiTacBLL doiTacBLL;
        private readonly HangHoaBLL hangHoaBLL;
        private readonly NhanSuBLL nhanSuBLL;

        private DataTable dtChiTiet;
        private DataTable dtDanhSachNhaCungCap;
        private bool dangTaoDon;
        private bool dangTaiDuLieu;
        private bool dangXuLyNhaCungCap;
        private decimal tongTienHienTai;

        public frmHoaDonNhap()
        {
            InitializeComponent();
            hoaDonNhapBLL = new HoaDonNhapBLL();
            doiTacBLL = new DoiTacBLL();
            hangHoaBLL = new HangHoaBLL();
            nhanSuBLL = new NhanSuBLL();
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            KhoiTaoBangChiTiet();
            UIHelper.FormatCurrencyColumns(dgvChiTiet, "colDonGia", "colThanhTien");
            UIHelper.FormatIntegerColumns(dgvChiTiet, "colSoLuong");
            UIHelper.GanXoaChonTuDong(dgvChiTiet);

            txtSoLuong.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);
            txtDonGiaNhap.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);
            dtpNgayNhap.ValueChanged += dtpNgayNhap_ValueChanged;

            cboNhaCungCap.KeyPress += cboNhaCungCap_KeyPress;
            cboNhaCungCap.TextChanged += cboNhaCungCap_TextChanged;

            cboDienThoai.KeyPress += cboDienThoai_KeyPress;
            cboDienThoai.TextChanged += cboDienThoai_TextChanged;
            cboDienThoai.SelectedIndexChanged += cboDienThoai_SelectedIndexChanged;
            cboDienThoai.MaxLength = 10;

            LoadDanhSachNhanVien();
            LoadDanhSachNhaCungCap();
            LoadDanhSachHangHoa();

            ThietLapTrangThaiBanDau();
        }

        private void KhoiTaoBangChiTiet()
        {
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("ma_hang", typeof(string));
            dtChiTiet.Columns.Add("ten_hang_hoa", typeof(string));
            dtChiTiet.Columns.Add("so_luong", typeof(int));
            dtChiTiet.Columns.Add("don_gia", typeof(decimal));
            dtChiTiet.Columns.Add("thanh_tien", typeof(decimal));
            dgvChiTiet.DataSource = dtChiTiet;
        }

        private void LoadDanhSachNhanVien()
        {
            dangTaiDuLieu = true;
            try
            {
                DataTable dt = nhanSuBLL.LayDanhSachNhanVien();
                cboNhanVien.DataSource = dt;
                cboNhanVien.DisplayMember = "ten_nhan_vien";
                cboNhanVien.ValueMember = "ma_nhan_vien";
                cboNhanVien.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private void NapDanhSachTatCaTenNhaCungCap()
        {
            cboNhaCungCap.Items.Clear();
            if (dtDanhSachNhaCungCap != null)
            {
                List<string> dsTen = new List<string>();
                foreach (DataRow r in dtDanhSachNhaCungCap.Rows)
                {
                    string ten = r["ten_nha_cung_cap"]?.ToString()?.Trim() ?? string.Empty;
                    if (!string.IsNullOrEmpty(ten) && !dsTen.Contains(ten))
                    {
                        dsTen.Add(ten);
                    }
                }
                dsTen.Sort(StringComparer.CurrentCulture);
                foreach (string ten in dsTen)
                {
                    cboNhaCungCap.Items.Add(ten);
                }
            }
        }

        private void NapDanhSachTatCaSoDienThoaiNCC()
        {
            cboDienThoai.Items.Clear();
            if (dtDanhSachNhaCungCap != null)
            {
                List<string> dsSDT = new List<string>();
                foreach (DataRow r in dtDanhSachNhaCungCap.Rows)
                {
                    string sdt = r["dien_thoai"]?.ToString()?.Trim() ?? string.Empty;
                    if (!string.IsNullOrEmpty(sdt) && !dsSDT.Contains(sdt))
                    {
                        dsSDT.Add(sdt);
                    }
                }
                dsSDT.Sort();
                foreach (string sdt in dsSDT)
                {
                    cboDienThoai.Items.Add(sdt);
                }
            }
        }

        private void LoadDanhSachNhaCungCap()
        {
            dangTaiDuLieu = true;
            try
            {
                dtDanhSachNhaCungCap = doiTacBLL.LayDanhSachNhaCungCap();
                NapDanhSachTatCaTenNhaCungCap();
                NapDanhSachTatCaSoDienThoaiNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private void LoadDanhSachHangHoa()
        {
            dangTaiDuLieu = true;
            try
            {
                DataTable dt = hangHoaBLL.LayTatCaHangHoa();
                cboHangHoa.DataSource = dt;
                cboHangHoa.DisplayMember = "ten_hang_hoa";
                cboHangHoa.ValueMember = "ma_hang";
                cboHangHoa.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hàng hóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).Replace('đ', 'd').Replace('Đ', 'D');
        }

        private void cboNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsLetterOrDigit(e.KeyChar)) return;
            if (" -().,/&'\"_#".IndexOf(e.KeyChar) >= 0) return;
            e.Handled = true;
        }

        private void cboDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                string currentText = cboDienThoai.Text;
                int selLen = cboDienThoai.SelectionLength;
                if (currentText.Length - selLen >= 10)
                {
                    e.Handled = true;
                }
            }
        }

        private void cboNhaCungCap_TextChanged(object sender, EventArgs e)
        {
            XuLyKhiChonHoacNhapNhaCungCap();
        }

        private void cboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            XuLyKhiChonHoacNhapNhaCungCap();
        }

        private void XuLyKhiChonHoacNhapNhaCungCap()
        {
            if (dangTaiDuLieu || dangXuLyNhaCungCap || !dangTaoDon)
            {
                return;
            }

            dangXuLyNhaCungCap = true;
            try
            {
                string text = cboNhaCungCap.Text.Trim();
                if (string.IsNullOrEmpty(text))
                {
                    NapDanhSachTatCaSoDienThoaiNCC();
                    txtDiaChi.Clear();
                    txtDiaChi.ReadOnly = false;
                    return;
                }

                if (dtDanhSachNhaCungCap == null) return;

                string textNoDiacritics = RemoveDiacritics(text);
                List<DataRow> khop = new List<DataRow>();
                foreach (DataRow r in dtDanhSachNhaCungCap.Rows)
                {
                    string ten = r["ten_nha_cung_cap"]?.ToString()?.Trim() ?? string.Empty;
                    if (string.Equals(ten, text, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(RemoveDiacritics(ten), textNoDiacritics, StringComparison.OrdinalIgnoreCase))
                    {
                        khop.Add(r);
                    }
                }

                if (khop.Count > 0)
                {
                    cboDienThoai.Items.Clear();
                    foreach (DataRow r in khop)
                    {
                        string sdtRow = r["dien_thoai"]?.ToString()?.Trim() ?? string.Empty;
                        if (!string.IsNullOrEmpty(sdtRow) && !cboDienThoai.Items.Contains(sdtRow))
                        {
                            cboDienThoai.Items.Add(sdtRow);
                        }
                    }

                    if (khop.Count == 1)
                    {
                        cboDienThoai.Text = khop[0]["dien_thoai"]?.ToString() ?? string.Empty;
                        txtDiaChi.Text = khop[0]["dia_chi"]?.ToString() ?? string.Empty;
                        txtDiaChi.ReadOnly = true;
                    }
                    else
                    {
                        string sdtHienTai = cboDienThoai.Text.Trim();
                        DataRow nccKhopSDT = null;
                        if (!string.IsNullOrEmpty(sdtHienTai))
                        {
                            nccKhopSDT = khop.Find(r => string.Equals(r["dien_thoai"]?.ToString()?.Trim(), sdtHienTai, StringComparison.OrdinalIgnoreCase));
                        }

                        if (nccKhopSDT != null)
                        {
                            txtDiaChi.Text = nccKhopSDT["dia_chi"]?.ToString() ?? string.Empty;
                            txtDiaChi.ReadOnly = true;
                        }
                        else
                        {
                            cboDienThoai.SelectedIndex = -1;
                            cboDienThoai.Text = string.Empty;
                            txtDiaChi.Clear();
                            txtDiaChi.ReadOnly = true;
                        }
                    }
                }
                else
                {
                    cboDienThoai.Items.Clear();
                    string sdtHienTai = cboDienThoai.Text.Trim();
                    if (sdtHienTai.Length != 10)
                    {
                        cboDienThoai.SelectedIndex = -1;
                        cboDienThoai.Text = string.Empty;
                    }
                    if (txtDiaChi.ReadOnly)
                    {
                        txtDiaChi.Clear();
                    }
                    txtDiaChi.ReadOnly = false;
                }
            }
            finally
            {
                dangXuLyNhaCungCap = false;
            }
        }

        private void cboDienThoai_TextChanged(object sender, EventArgs e)
        {
            XuLyKhiChonHoacNhapDienThoai();
        }

        private void cboDienThoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            XuLyKhiChonHoacNhapDienThoai();
        }

        private void XuLyKhiChonHoacNhapDienThoai()
        {
            if (dangTaiDuLieu || dangXuLyNhaCungCap || !dangTaoDon)
            {
                return;
            }

            string sdt = cboDienThoai.Text.Trim();
            if (string.IsNullOrEmpty(sdt))
            {
                dangXuLyNhaCungCap = true;
                try
                {
                    NapDanhSachTatCaTenNhaCungCap();
                    txtDiaChi.Clear();
                    txtDiaChi.ReadOnly = false;
                }
                finally
                {
                    dangXuLyNhaCungCap = false;
                }
                return;
            }

            if (dtDanhSachNhaCungCap == null) return;

            DataRow timThay = null;
            foreach (DataRow r in dtDanhSachNhaCungCap.Rows)
            {
                string phone = r["dien_thoai"]?.ToString()?.Trim() ?? string.Empty;
                if (string.Equals(phone, sdt, StringComparison.OrdinalIgnoreCase))
                {
                    timThay = r;
                    break;
                }
            }

            dangXuLyNhaCungCap = true;
            try
            {
                if (timThay != null)
                {
                    string tenChuSDT = timThay["ten_nha_cung_cap"]?.ToString()?.Trim() ?? string.Empty;
                    string tenHienTai = cboNhaCungCap.Text.Trim();

                    bool laChonTuDanhSach = cboDienThoai.SelectedIndex >= 0;
                    bool dangKhoaDiaChi = txtDiaChi.ReadOnly;

                    if (laChonTuDanhSach || dangKhoaDiaChi || string.IsNullOrEmpty(tenHienTai) ||
                        string.Equals(tenHienTai, tenChuSDT, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(RemoveDiacritics(tenHienTai), RemoveDiacritics(tenChuSDT), StringComparison.OrdinalIgnoreCase))
                    {
                        cboNhaCungCap.Text = tenChuSDT;
                        txtDiaChi.Text = timThay["dia_chi"]?.ToString()?.Trim() ?? string.Empty;
                        txtDiaChi.ReadOnly = true;
                    }
                    else
                    {
                        if (txtDiaChi.ReadOnly)
                        {
                            txtDiaChi.Clear();
                        }
                        txtDiaChi.ReadOnly = false;
                    }
                }
                else
                {
                    if (txtDiaChi.ReadOnly)
                    {
                        txtDiaChi.Clear();
                    }
                    txtDiaChi.ReadOnly = false;
                }
            }
            finally
            {
                dangXuLyNhaCungCap = false;
            }
        }

        private void cboHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu)
            {
                return;
            }
            CapNhatThongTinHangHoa();
        }

        private void CapNhatThongTinHangHoa()
        {
            if (cboHangHoa.SelectedItem is DataRowView drv)
            {
                if (drv["don_gia_nhap"] != DBNull.Value)
                {
                    decimal giaNhap = Convert.ToDecimal(drv["don_gia_nhap"]);
                    txtDonGiaNhap.Text = giaNhap.ToString("N0");
                }
                else
                {
                    txtDonGiaNhap.Text = "0";
                }

                if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || txtSoLuong.Text == "0")
                {
                    txtSoLuong.Text = "1";
                }

                txtTinhToanThanhTien_TextChanged(null, null);
            }
            else
            {
                txtDonGiaNhap.Clear();
                txtSoLuong.Clear();
                txtThanhTien.Clear();
            }
        }

        private void ThietLapTrangThaiBanDau()
        {
            dangTaoDon = false;

            btnTaoMoi.Enabled = true;
            btnThemVaoDon.Enabled = false;
            btnXoaDong.Enabled = false;
            btnLuuHoaDon.Enabled = false;
            btnInHoaDon.Enabled = false;
            btnHuyHoaDon.Enabled = false;
            btnHuyHoaDon.Visible = true;

            DatTrangThaiNhapLieu(false);

            dangTaiDuLieu = true;
            try
            {
                txtMaHDN.Clear();
                dtpNgayNhap.CustomFormat = " ";
                cboNhanVien.SelectedIndex = -1;
                cboNhaCungCap.SelectedIndex = -1;
                cboNhaCungCap.Text = string.Empty;
                NapDanhSachTatCaTenNhaCungCap();
                cboDienThoai.SelectedIndex = -1;
                cboDienThoai.Text = string.Empty;
                NapDanhSachTatCaSoDienThoaiNCC();
                txtDiaChi.Clear();
                txtDiaChi.ReadOnly = true;
                cboHangHoa.SelectedIndex = -1;
                txtDonGiaNhap.Clear();
                txtSoLuong.Clear();
                txtThanhTien.Clear();
            }
            finally
            {
                dangTaiDuLieu = false;
            }

            dtChiTiet.Rows.Clear();
            UIHelper.XoaChonLuoi(dgvChiTiet);
            CapNhatTongTien();
        }

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            if (dangTaoDon && dtpNgayNhap.CustomFormat == " ")
            {
                dtpNgayNhap.CustomFormat = "dd/MM/yyyy HH:mm";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (dangTaoDon && dtChiTiet != null && dtChiTiet.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show(
                    "Hóa đơn nhập đang tạo có sản phẩm trong giỏ hàng. Bạn có chắc chắn muốn rời đi và hủy dữ liệu đang nhập không?",
                    "Xác nhận rời khỏi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void DatTrangThaiNhapLieu(bool moKhoa)
        {
            dtpNgayNhap.Enabled = moKhoa;
            cboNhanVien.Enabled = moKhoa && (cboNhanVien.SelectedValue == null || string.Equals(UserSession.Quyen, "QuanLy", StringComparison.OrdinalIgnoreCase));
            cboNhaCungCap.Enabled = moKhoa;
            cboDienThoai.Enabled = moKhoa;
            txtDiaChi.ReadOnly = !moKhoa;
            cboHangHoa.Enabled = moKhoa;
            txtDonGiaNhap.ReadOnly = !moKhoa;
            txtSoLuong.ReadOnly = !moKhoa;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            dangTaoDon = true;
            dtChiTiet.Rows.Clear();

            txtMaHDN.Text = "HDN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayNhap.Value = DateTime.Now;

            if (!string.IsNullOrEmpty(UserSession.MaNV))
            {
                cboNhanVien.SelectedValue = UserSession.MaNV;
            }

            DatTrangThaiNhapLieu(true);
            if (cboNhanVien.SelectedValue == null || string.Equals(UserSession.Quyen, "QuanLy", StringComparison.OrdinalIgnoreCase))
            {
                cboNhanVien.Enabled = true;
            }

            dangTaiDuLieu = true;
            try
            {
                cboNhaCungCap.SelectedIndex = -1;
                cboNhaCungCap.Text = string.Empty;
                NapDanhSachTatCaTenNhaCungCap();
                cboDienThoai.SelectedIndex = -1;
                cboDienThoai.Text = string.Empty;
                NapDanhSachTatCaSoDienThoaiNCC();
                txtDiaChi.Clear();
                txtDiaChi.ReadOnly = false;

                cboHangHoa.SelectedIndex = -1;
                txtDonGiaNhap.Clear();
                txtSoLuong.Text = "1";
                txtThanhTien.Clear();
            }
            finally
            {
                dangTaiDuLieu = false;
            }

            btnTaoMoi.Enabled = false;
            btnThemVaoDon.Enabled = true;
            btnXoaDong.Enabled = false;
            btnLuuHoaDon.Enabled = false;
            btnInHoaDon.Enabled = false;
            btnHuyHoaDon.Enabled = true;

            CapNhatTongTien();
        }

        private void txtTinhToanThanhTien_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(txtDonGiaNhap.Text.Replace(".", "").Replace(",", "").Trim(), out decimal donGia);
            int.TryParse(txtSoLuong.Text.Trim(), out int soLuong);

            decimal thanhTien = Math.Ceiling((soLuong * donGia) / 1000m) * 1000m;
            txtThanhTien.Text = thanhTien.ToString("N0");
        }

        private void btnThemVaoDon_Click(object sender, EventArgs e)
        {
            if (cboHangHoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHangHoa.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng nhập phải là số nguyên lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            if (!decimal.TryParse(txtDonGiaNhap.Text.Replace(".", "").Replace(",", "").Trim(), out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá nhập phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }

            string maHang = cboHangHoa.SelectedValue.ToString();
            string tenHang = cboHangHoa.Text;

            DataRow timDong = null;
            foreach (DataRow r in dtChiTiet.Rows)
            {
                if (string.Equals(r["ma_hang"]?.ToString(), maHang, StringComparison.OrdinalIgnoreCase))
                {
                    timDong = r;
                    break;
                }
            }

            if (timDong != null)
            {
                int soLuongCu = Convert.ToInt32(timDong["so_luong"]);
                decimal donGiaCu = Convert.ToDecimal(timDong["don_gia"]);

                if (donGiaCu == donGia)
                {
                    int soLuongMoi = soLuongCu + soLuong;
                    timDong["so_luong"] = soLuongMoi;
                    timDong["thanh_tien"] = Math.Ceiling((soLuongMoi * donGia) / 1000m) * 1000m;
                }
                else
                {
                    decimal donGiaBinhQuan = Math.Ceiling(((soLuongCu * donGiaCu + soLuong * donGia) / (soLuongCu + soLuong)) / 1000m) * 1000m;
                    string thongBao = string.Format("Mặt hàng '{0}' đã có trong đơn với đơn giá nhập {1:N0} đ.\nBạn có muốn gộp với đơn giá bình quân mới là {2:N0} đ (tổng số lượng: {3}) không?", tenHang, donGiaCu, donGiaBinhQuan, soLuongCu + soLuong);
                    DialogResult dr = MessageBox.Show(thongBao, "Xác nhận gộp mặt hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr != DialogResult.Yes)
                    {
                        return;
                    }

                    int soLuongMoi = soLuongCu + soLuong;
                    timDong["so_luong"] = soLuongMoi;
                    timDong["don_gia"] = donGiaBinhQuan;
                    timDong["thanh_tien"] = Math.Ceiling((soLuongMoi * donGiaBinhQuan) / 1000m) * 1000m;
                }
            }
            else
            {
                decimal thanhTien = Math.Ceiling((soLuong * donGia) / 1000m) * 1000m;
                dtChiTiet.Rows.Add(maHang, tenHang, soLuong, donGia, thanhTien);
            }

            dangTaiDuLieu = true;
            try
            {
                cboHangHoa.SelectedIndex = -1;
                txtDonGiaNhap.Clear();
                txtSoLuong.Text = "1";
                txtThanhTien.Clear();
            }
            finally
            {
                dangTaiDuLieu = false;
            }

            CapNhatTongTien();
            btnLuuHoaDon.Enabled = dtChiTiet.Rows.Count > 0;
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dangTaoDon)
            {
                btnXoaDong.Enabled = true;
            }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null && dgvChiTiet.CurrentRow.Index >= 0)
            {
                dtChiTiet.Rows.RemoveAt(dgvChiTiet.CurrentRow.Index);
                CapNhatTongTien();

                if (dtChiTiet.Rows.Count == 0)
                {
                    btnLuuHoaDon.Enabled = false;
                    btnXoaDong.Enabled = false;
                }
            }
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text))
            {
                MessageBox.Show("Số hóa đơn nhập không hợp lệ! Vui lòng bấm Tạo mới trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenNCC = cboNhaCungCap.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenNCC))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhaCungCap.Focus();
                return;
            }

            string sdt = cboDienThoai.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDienThoai.Focus();
                return;
            }

            if (sdt.Length != 10 || !sdt.StartsWith("0") || !long.TryParse(sdt, out _))
            {
                MessageBox.Show("Số điện thoại nhà cung cấp không hợp lệ! Bắt buộc phải gồm đúng 10 chữ số và bắt đầu bằng số 0 (ví dụ: 0912345678).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDienThoai.Focus();
                return;
            }

            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return;
            }

            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất 1 mặt hàng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string diaChi = txtDiaChi.Text.Trim();

            string maNCC = string.Empty;
            DataRow nccTheoSDT = null;

            if (dtDanhSachNhaCungCap != null)
            {
                foreach (DataRow r in dtDanhSachNhaCungCap.Rows)
                {
                    string phone = r["dien_thoai"]?.ToString()?.Trim() ?? string.Empty;
                    if (string.Equals(phone, sdt, StringComparison.OrdinalIgnoreCase))
                    {
                        nccTheoSDT = r;
                        break;
                    }
                }
            }

            if (nccTheoSDT != null)
            {
                string tenCu = nccTheoSDT["ten_nha_cung_cap"]?.ToString()?.Trim() ?? string.Empty;
                if (!string.Equals(tenNCC, tenCu, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        string.Format("Số điện thoại {0} đang thuộc về nhà cung cấp '{1}', không khớp với tên '{2}' đang nhập. Vui lòng kiểm tra lại số điện thoại hoặc chỉnh sửa thông tin cho đúng!", sdt, tenCu, tenNCC),
                        "Cảnh báo sai thông tin",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cboNhaCungCap.Focus();
                    return;
                }

                maNCC = nccTheoSDT["ma_nha_cung_cap"].ToString();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(diaChi))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ cho nhà cung cấp mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.ReadOnly = false;
                    txtDiaChi.Focus();
                    return;
                }

                string msg = string.Format("Nhà cung cấp '{0}' với số điện thoại '{1}' chưa có trong hệ thống. Bạn có muốn thêm mới nhà cung cấp này không?", tenNCC, sdt);
                DialogResult dr = MessageBox.Show(msg, "Xác nhận thêm nhà cung cấp mới", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        maNCC = doiTacBLL.SinhMaNhaCungCapMoi();
                        NhaCungCapDTO nccMoi = new NhaCungCapDTO
                        {
                            MaNhaCungCap = maNCC,
                            TenNhaCungCap = tenNCC,
                            DienThoai = sdt,
                            DiaChi = diaChi
                        };
                        doiTacBLL.ThemNhaCungCap(nccMoi);

                        LoadDanhSachNhaCungCap();
                        cboNhaCungCap.Text = tenNCC;
                        cboDienThoai.Text = sdt;
                        txtDiaChi.Text = diaChi;
                        txtDiaChi.ReadOnly = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm mới nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            HoaDonNhapDTO hdn = new HoaDonNhapDTO
            {
                SoHoaDonNhap = txtMaHDN.Text.Trim(),
                ThoiGianNhap = dtpNgayNhap.Value,
                MaNhaCungCap = maNCC,
                MaNhanVien = cboNhanVien.SelectedValue.ToString(),
                TongTien = tongTienHienTai,
                TrangThaiGiaoDich = "HoanThanh"
            };

            List<ChiTietHDNhapDTO> list = new List<ChiTietHDNhapDTO>();
            foreach (DataRow r in dtChiTiet.Rows)
            {
                list.Add(new ChiTietHDNhapDTO
                {
                    SoHoaDonNhap = hdn.SoHoaDonNhap,
                    MaHang = r["ma_hang"].ToString(),
                    TenHangHoa = r["ten_hang_hoa"].ToString(),
                    SoLuong = Convert.ToInt32(r["so_luong"]),
                    DonGia = Convert.ToDecimal(r["don_gia"]),
                    GiamGia = 0,
                    ThanhTien = Convert.ToDecimal(r["thanh_tien"])
                });
            }

            try
            {
                hoaDonNhapBLL.LuuHoaDonNhap(hdn, list);

                dangTaoDon = false;
                DatTrangThaiNhapLieu(false);

                btnTaoMoi.Enabled = true;
                btnInHoaDon.Enabled = true;
                btnLuuHoaDon.Enabled = false;
                btnThemVaoDon.Enabled = false;
                btnXoaDong.Enabled = false;
                btnHuyHoaDon.Enabled = true;

                LoadDanhSachHangHoa();
                LoadDanhSachNhaCungCap();

                MessageBox.Show("Lưu hóa đơn nhập hàng thành công! Tồn kho và đơn giá sản phẩm đã được tự động cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi lưu hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text) || dtChiTiet == null || dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hóa đơn để in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<ReportParameter> parameters = new List<ReportParameter>
                {
                    new ReportParameter("pSoHoaDon", txtMaHDN.Text.Trim()),
                    new ReportParameter("pNgayNhap", dtpNgayNhap.Value.ToString("dd/MM/yyyy HH:mm")),
                    new ReportParameter("pTenNhaCungCap", string.IsNullOrWhiteSpace(cboNhaCungCap.Text) ? "" : cboNhaCungCap.Text),
                    new ReportParameter("pDienThoai", string.IsNullOrWhiteSpace(cboDienThoai.Text) ? "" : cboDienThoai.Text),
                    new ReportParameter("pDiaChi", string.IsNullOrWhiteSpace(txtDiaChi.Text) ? "" : txtDiaChi.Text),
                    new ReportParameter("pTenNhanVien", string.IsNullOrWhiteSpace(cboNhanVien.Text) ? "" : cboNhanVien.Text),
                    new ReportParameter("pTongTien", tongTienHienTai.ToString("N0") + " đ"),
                    new ReportParameter("pTongTienBangChu", UIHelper.DocSoThanhChu(tongTienHienTai))
                };

                RdlcReportHelper.HienThiBaoCao(
                    "rptHoaDonNhap.rdlc",
                    "DataSetChiTiet",
                    dtChiTiet,
                    parameters,
                    "In Hóa Đơn Nhập Hàng - " + txtMaHDN.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (dangTaoDon)
            {
                DialogResult drHuyTao = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy bỏ thao tác lập hóa đơn nhập hiện tại không?",
                    "Xác nhận hủy tạo mới",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (drHuyTao == DialogResult.Yes)
                {
                    ThietLapTrangThaiBanDau();
                }
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaHDN.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần hủy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn hủy phiếu nhập {0} và trừ tồn kho hoàn lại không?", txtMaHDN.Text),
                "Xác nhận hủy phiếu nhập",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                hoaDonNhapBLL.HuyHoaDonNhap(txtMaHDN.Text.Trim());
                ThietLapTrangThaiBanDau();
                LoadDanhSachHangHoa();

                MessageBox.Show("Hủy phiếu nhập kho thành công! Tồn kho đã được hoàn lại chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi hủy hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (DataRow r in dtChiTiet.Rows)
            {
                if (r["thanh_tien"] != DBNull.Value)
                {
                    tongTien += Convert.ToDecimal(r["thanh_tien"]);
                }
            }

            tongTienHienTai = tongTien;
            lblTongTienBangSo.Text = string.Format("Tổng tiền: {0:N0} VNĐ", tongTien);
            lblTongTienBangChu.Text = string.Format("Bằng chữ: {0}", UIHelper.DocSoThanhChu(tongTien));
        }
    }
}
