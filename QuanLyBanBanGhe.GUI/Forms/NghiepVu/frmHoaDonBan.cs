using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.DTO;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.NghiepVu
{
    public partial class frmHoaDonBan : Form
    {
        private readonly HoaDonBanBLL hoaDonBanBLL;
        private readonly DoiTacBLL doiTacBLL;
        private readonly HangHoaBLL hangHoaBLL;
        private readonly NhanSuBLL nhanSuBLL;

        private DataTable dtChiTiet;
        private DataTable dtDanhSachKhachHang;
        private bool dangTaoDon;
        private bool dangTaiDuLieu;
        private bool dangXuLyKhachHang;
        private decimal tongTienHienTai;

        public frmHoaDonBan()
        {
            InitializeComponent();
            hoaDonBanBLL = new HoaDonBanBLL();
            doiTacBLL = new DoiTacBLL();
            hangHoaBLL = new HangHoaBLL();
            nhanSuBLL = new NhanSuBLL();
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            KhoiTaoBangChiTiet();
            UIHelper.FormatCurrencyColumns(dgvChiTiet, "colDonGia", "colThanhTien");
            UIHelper.FormatIntegerColumns(dgvChiTiet, "colSoLuong", "colGiamGia");
            UIHelper.GanXoaChonTuDong(dgvChiTiet);

            txtSoLuong.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);
            txtGiamGia.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);
            dtpNgayBan.ValueChanged += dtpNgayBan_ValueChanged;

            cboKhachHang.KeyPress += cboKhachHang_KeyPress;
            cboKhachHang.TextChanged += cboKhachHang_TextChanged;
            cboKhachHang.SelectedIndexChanged += cboKhachHang_SelectedIndexChanged;
            cboKhachHang.Leave += cboKhachHang_Leave;

            cboDienThoai.KeyPress += cboDienThoai_KeyPress;
            cboDienThoai.TextChanged += cboDienThoai_TextChanged;
            cboDienThoai.SelectedIndexChanged += cboDienThoai_SelectedIndexChanged;
            cboDienThoai.MaxLength = 10;

            LoadDanhSachNhanVien();
            LoadDanhSachKhachHang();
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
            dtChiTiet.Columns.Add("giam_gia", typeof(decimal));
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

        private void LoadDanhSachKhachHang()
        {
            dangTaiDuLieu = true;
            try
            {
                dtDanhSachKhachHang = doiTacBLL.LayDanhSachKhachHang();

                cboKhachHang.Items.Clear();
                foreach (DataRow r in dtDanhSachKhachHang.Rows)
                {
                    string ten = r["ten_khach"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(ten) && !cboKhachHang.Items.Contains(ten))
                    {
                        cboKhachHang.Items.Add(ten);
                    }
                }

                cboDienThoai.Items.Clear();
                foreach (DataRow r in dtDanhSachKhachHang.Rows)
                {
                    string sdt = r["dien_thoai"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(sdt) && !cboDienThoai.Items.Contains(sdt))
                    {
                        cboDienThoai.Items.Add(sdt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private static string GetAcronym(string fullName, bool removeDiacritics)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return string.Empty;
            string name = removeDiacritics ? RemoveDiacritics(fullName) : fullName;
            string[] parts = name.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (var part in parts)
            {
                if (part.Length > 0 && char.IsLetter(part[0]))
                {
                    sb.Append(part[0]);
                }
            }
            return sb.ToString().ToLower();
        }

        private bool KhopTenKhachHang(string tenKhach, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return true;
            if (string.IsNullOrWhiteSpace(tenKhach)) return false;
            keyword = keyword.Trim();

            if (tenKhach.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) return true;

            string tenKhongDau = RemoveDiacritics(tenKhach);
            string kwKhongDau = RemoveDiacritics(keyword);
            if (tenKhongDau.IndexOf(kwKhongDau, StringComparison.OrdinalIgnoreCase) >= 0) return true;

            string acroCoDau = GetAcronym(tenKhach, false);
            if (acroCoDau.Equals(keyword.ToLower())) return true;

            string acroKhongDau = GetAcronym(tenKhach, true);
            if (acroKhongDau.Equals(kwKhongDau.ToLower())) return true;

            return false;
        }

        private void cboKhachHang_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cboKhachHang_TextChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu || dangXuLyKhachHang || !dangTaoDon)
            {
                return;
            }

            dangXuLyKhachHang = true;
            try
            {
                string text = cboKhachHang.Text.Trim();
                if (string.IsNullOrEmpty(text))
                {
                    cboDienThoai.Items.Clear();
                    cboDienThoai.Text = string.Empty;
                    txtDiaChi.Clear();
                    txtDiaChi.ReadOnly = false;
                    return;
                }

                if (dtDanhSachKhachHang == null) return;

                List<DataRow> khop = new List<DataRow>();
                foreach (DataRow r in dtDanhSachKhachHang.Rows)
                {
                    string ten = r["ten_khach"]?.ToString() ?? string.Empty;
                    if (KhopTenKhachHang(ten, text))
                    {
                        khop.Add(r);
                    }
                }

                if (khop.Count > 0)
                {
                    cboDienThoai.Items.Clear();
                    foreach (DataRow r in khop)
                    {
                        string sdt = r["dien_thoai"]?.ToString() ?? string.Empty;
                        if (!string.IsNullOrEmpty(sdt) && !cboDienThoai.Items.Contains(sdt))
                        {
                            cboDienThoai.Items.Add(sdt);
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
                        DataRow chinhXac = khop.Find(r => string.Equals(r["ten_khach"]?.ToString(), text, StringComparison.OrdinalIgnoreCase));
                        if (chinhXac != null)
                        {
                            txtDiaChi.Text = chinhXac["dia_chi"]?.ToString() ?? string.Empty;
                            txtDiaChi.ReadOnly = true;
                        }
                        else
                        {
                            txtDiaChi.Clear();
                            txtDiaChi.ReadOnly = true;
                        }
                    }
                }
                else
                {
                    cboDienThoai.Items.Clear();
                    txtDiaChi.ReadOnly = false;
                }
            }
            finally
            {
                dangXuLyKhachHang = false;
            }
        }

        private void cboKhachHang_Leave(object sender, EventArgs e)
        {
            if (dangTaiDuLieu || !dangTaoDon || dtDanhSachKhachHang == null) return;
            string text = cboKhachHang.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;

            List<DataRow> khop = new List<DataRow>();
            foreach (DataRow r in dtDanhSachKhachHang.Rows)
            {
                string ten = r["ten_khach"]?.ToString() ?? string.Empty;
                if (KhopTenKhachHang(ten, text))
                {
                    khop.Add(r);
                }
            }

            if (khop.Count == 1)
            {
                dangXuLyKhachHang = true;
                try
                {
                    cboKhachHang.Text = khop[0]["ten_khach"]?.ToString() ?? string.Empty;
                    cboDienThoai.Text = khop[0]["dien_thoai"]?.ToString() ?? string.Empty;
                    txtDiaChi.Text = khop[0]["dia_chi"]?.ToString() ?? string.Empty;
                    txtDiaChi.ReadOnly = true;
                }
                finally
                {
                    dangXuLyKhachHang = false;
                }
            }
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu || dangXuLyKhachHang || !dangTaoDon)
            {
                return;
            }

            string selectedName = cboKhachHang.Text.Trim();
            if (string.IsNullOrEmpty(selectedName)) return;

            if (dtDanhSachKhachHang == null) return;

            List<DataRow> dsCungTen = new List<DataRow>();
            foreach (DataRow r in dtDanhSachKhachHang.Rows)
            {
                string ten = r["ten_khach"]?.ToString() ?? string.Empty;
                if (string.Equals(ten, selectedName, StringComparison.OrdinalIgnoreCase))
                {
                    dsCungTen.Add(r);
                }
            }

            dangXuLyKhachHang = true;
            try
            {
                cboDienThoai.Items.Clear();
                foreach (DataRow r in dsCungTen)
                {
                    string sdt = r["dien_thoai"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(sdt) && !cboDienThoai.Items.Contains(sdt))
                    {
                        cboDienThoai.Items.Add(sdt);
                    }
                }

                if (dsCungTen.Count == 1)
                {
                    cboDienThoai.Text = dsCungTen[0]["dien_thoai"]?.ToString() ?? string.Empty;
                    txtDiaChi.Text = dsCungTen[0]["dia_chi"]?.ToString() ?? string.Empty;
                    txtDiaChi.ReadOnly = true;
                }
                else if (dsCungTen.Count > 1)
                {
                    cboDienThoai.SelectedIndex = 0;
                    txtDiaChi.Text = dsCungTen[0]["dia_chi"]?.ToString() ?? string.Empty;
                    txtDiaChi.ReadOnly = true;
                }
            }
            finally
            {
                dangXuLyKhachHang = false;
            }
        }

        private void cboDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu || dangXuLyKhachHang || !dangTaoDon)
            {
                return;
            }

            XuLyKhiChonHoacNhapDienThoai();
        }

        private void cboDienThoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu || dangXuLyKhachHang || !dangTaoDon)
            {
                return;
            }

            XuLyKhiChonHoacNhapDienThoai();
        }

        private void XuLyKhiChonHoacNhapDienThoai()
        {
            string sdt = cboDienThoai.Text.Trim();
            if (string.IsNullOrEmpty(sdt))
            {
                return;
            }

            if (dtDanhSachKhachHang == null) return;

            DataRow timThay = null;
            foreach (DataRow r in dtDanhSachKhachHang.Rows)
            {
                string phone = r["dien_thoai"]?.ToString() ?? string.Empty;
                if (string.Equals(phone, sdt, StringComparison.OrdinalIgnoreCase))
                {
                    timThay = r;
                    break;
                }
            }

            dangXuLyKhachHang = true;
            try
            {
                if (timThay != null)
                {
                    cboKhachHang.Text = timThay["ten_khach"]?.ToString() ?? string.Empty;
                    txtDiaChi.Text = timThay["dia_chi"]?.ToString() ?? string.Empty;
                    txtDiaChi.ReadOnly = true;
                }
                else
                {
                    txtDiaChi.ReadOnly = false;
                }
            }
            finally
            {
                dangXuLyKhachHang = false;
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
                if (drv["don_gia_ban"] != DBNull.Value)
                {
                    decimal giaBan = Convert.ToDecimal(drv["don_gia_ban"]);
                    txtDonGiaBan.Text = giaBan.ToString("N0");
                }
                else
                {
                    txtDonGiaBan.Text = "0";
                }

                if (drv["so_luong"] != DBNull.Value)
                {
                    txtTonKho.Text = drv["so_luong"].ToString();
                }
                else
                {
                    txtTonKho.Text = "0";
                }

                if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || txtSoLuong.Text == "0")
                {
                    txtSoLuong.Text = "1";
                }

                if (string.IsNullOrWhiteSpace(txtGiamGia.Text))
                {
                    txtGiamGia.Text = "0";
                }

                txtTinhToanThanhTien_TextChanged(null, null);
            }
            else
            {
                txtDonGiaBan.Clear();
                txtTonKho.Clear();
                txtSoLuong.Clear();
                txtGiamGia.Clear();
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
                txtMaHDB.Clear();
                dtpNgayBan.CustomFormat = " ";
                cboNhanVien.SelectedIndex = -1;
                cboKhachHang.SelectedIndex = -1;
                cboKhachHang.Text = string.Empty;
                cboDienThoai.Items.Clear();
                cboDienThoai.Text = string.Empty;
                txtDiaChi.Clear();
                txtDiaChi.ReadOnly = true;
                cboHangHoa.SelectedIndex = -1;
                txtDonGiaBan.Clear();
                txtTonKho.Clear();
                txtSoLuong.Clear();
                txtGiamGia.Clear();
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

        private void dtpNgayBan_ValueChanged(object sender, EventArgs e)
        {
            if (dangTaoDon && dtpNgayBan.CustomFormat == " ")
            {
                dtpNgayBan.CustomFormat = "dd/MM/yyyy HH:mm";
            }
        }

        private void DatTrangThaiNhapLieu(bool moKhoa)
        {
            dtpNgayBan.Enabled = moKhoa;
            cboNhanVien.Enabled = false;
            cboKhachHang.Enabled = moKhoa;
            cboDienThoai.Enabled = moKhoa;
            txtDiaChi.ReadOnly = !moKhoa;
            cboHangHoa.Enabled = moKhoa;
            txtSoLuong.ReadOnly = !moKhoa;
            txtGiamGia.ReadOnly = !moKhoa;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            dangTaoDon = true;
            dtChiTiet.Rows.Clear();

            txtMaHDB.Text = "HDB" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtpNgayBan.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayBan.Value = DateTime.Now;

            if (!string.IsNullOrEmpty(UserSession.MaNV))
            {
                cboNhanVien.SelectedValue = UserSession.MaNV;
            }

            DatTrangThaiNhapLieu(true);

            dangTaiDuLieu = true;
            try
            {
                cboKhachHang.SelectedIndex = -1;
                cboKhachHang.Text = string.Empty;
                cboDienThoai.Items.Clear();
                cboDienThoai.Text = string.Empty;
                txtDiaChi.Clear();
                txtDiaChi.ReadOnly = false;

                cboHangHoa.SelectedIndex = -1;
                txtDonGiaBan.Clear();
                txtTonKho.Clear();
                txtSoLuong.Text = "1";
                txtGiamGia.Text = "0";
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
            decimal.TryParse(txtDonGiaBan.Text.Replace(",", "").Trim(), out decimal donGia);
            int.TryParse(txtSoLuong.Text.Trim(), out int soLuong);
            decimal.TryParse(txtGiamGia.Text.Trim(), out decimal giamGia);

            if (giamGia < 0) giamGia = 0;
            if (giamGia > 100) giamGia = 100;

            decimal thanhTien = Math.Round(soLuong * donGia * (1 - giamGia / 100m), 0);
            txtThanhTien.Text = thanhTien.ToString("N0");
        }

        private void btnThemVaoDon_Click(object sender, EventArgs e)
        {
            if (cboHangHoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần bán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHangHoa.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng mua phải là số nguyên lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            decimal.TryParse(txtDonGiaBan.Text.Replace(",", "").Trim(), out decimal donGia);
            decimal.TryParse(txtGiamGia.Text.Trim(), out decimal giamGia);

            if (giamGia < 0 || giamGia > 100)
            {
                MessageBox.Show("Giảm giá phải nằm trong khoảng từ 0% đến 100%!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamGia.Focus();
                return;
            }

            string maHang = cboHangHoa.SelectedValue.ToString();
            string tenHang = cboHangHoa.Text;

            int tonKhoHienTai = int.TryParse(txtTonKho.Text.Trim(), out int tk) ? tk : 0;

            DataRow timDong = null;
            int soLuongDaThem = 0;
            foreach (DataRow r in dtChiTiet.Rows)
            {
                if (string.Equals(r["ma_hang"]?.ToString(), maHang, StringComparison.OrdinalIgnoreCase))
                {
                    timDong = r;
                    soLuongDaThem = Convert.ToInt32(r["so_luong"]);
                    break;
                }
            }

            int tongSoLuongYeuCau = soLuongDaThem + soLuong;
            if (tongSoLuongYeuCau > tonKhoHienTai)
            {
                MessageBox.Show(
                    string.Format("Không đủ tồn kho để xuất bán! Mặt hàng '{0}' hiện chỉ còn tồn {1} cái, tổng số lượng yêu cầu là {2} cái.", tenHang, tonKhoHienTai, tongSoLuongYeuCau),
                    "Cảnh báo thiếu hàng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            if (timDong != null)
            {
                timDong["so_luong"] = tongSoLuongYeuCau;
                timDong["giam_gia"] = giamGia;
                timDong["thanh_tien"] = Math.Round(tongSoLuongYeuCau * donGia * (1 - giamGia / 100m), 0);
            }
            else
            {
                decimal thanhTien = Math.Round(soLuong * donGia * (1 - giamGia / 100m), 0);
                dtChiTiet.Rows.Add(maHang, tenHang, soLuong, donGia, giamGia, thanhTien);
            }

            dangTaiDuLieu = true;
            try
            {
                cboHangHoa.SelectedIndex = -1;
                txtDonGiaBan.Clear();
                txtTonKho.Clear();
                txtSoLuong.Text = "1";
                txtGiamGia.Text = "0";
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
            if (string.IsNullOrWhiteSpace(txtMaHDB.Text))
            {
                MessageBox.Show("Số hóa đơn bán không hợp lệ! Vui lòng bấm Tạo mới trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenKhach = cboKhachHang.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenKhach))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhachHang.Focus();
                return;
            }

            string sdt = cboDienThoai.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDienThoai.Focus();
                return;
            }

            if (sdt.Length != 10 || !sdt.StartsWith("0") || !long.TryParse(sdt, out _))
            {
                MessageBox.Show("Số điện thoại khách hàng không hợp lệ! Bắt buộc phải gồm đúng 10 chữ số và bắt đầu bằng số 0 (ví dụ: 0912345678).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDienThoai.Focus();
                return;
            }

            string diaChi = txtDiaChi.Text.Trim();

            string maKhach = string.Empty;
            DataRow khachTonTai = null;

            if (dtDanhSachKhachHang != null)
            {
                foreach (DataRow r in dtDanhSachKhachHang.Rows)
                {
                    string phone = r["dien_thoai"]?.ToString() ?? string.Empty;
                    if (string.Equals(phone, sdt, StringComparison.OrdinalIgnoreCase))
                    {
                        khachTonTai = r;
                        break;
                    }
                }
            }

            if (khachTonTai != null)
            {
                maKhach = khachTonTai["ma_khach"].ToString();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(diaChi))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ cho khách hàng mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.ReadOnly = false;
                    txtDiaChi.Focus();
                    return;
                }

                string msg = string.Format("Khách hàng chưa có trong dữ liệu.\nXác nhận thêm mới khách hàng {0} - {1}?", tenKhach, sdt);
                DialogResult dr = MessageBox.Show(msg, "Xác nhận thêm khách hàng mới", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        maKhach = doiTacBLL.SinhMaKhachHangMoi();
                        KhachHangDTO khMoi = new KhachHangDTO
                        {
                            MaKhach = maKhach,
                            TenKhach = tenKhach,
                            DienThoai = sdt,
                            DiaChi = diaChi
                        };
                        doiTacBLL.ThemKhachHang(khMoi);

                        LoadDanhSachKhachHang();
                        cboKhachHang.Text = tenKhach;
                        cboDienThoai.Text = sdt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm mới khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return;
            }

            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất 1 mặt hàng bán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HoaDonBanDTO hdb = new HoaDonBanDTO
            {
                SoHoaDonBan = txtMaHDB.Text.Trim(),
                ThoiGianBan = dtpNgayBan.Value,
                MaKhach = maKhach,
                MaNhanVien = cboNhanVien.SelectedValue.ToString(),
                TongTien = tongTienHienTai,
                TrangThaiGiaoDich = "HoanThanh"
            };

            List<ChiTietHDBanDTO> list = new List<ChiTietHDBanDTO>();
            foreach (DataRow r in dtChiTiet.Rows)
            {
                list.Add(new ChiTietHDBanDTO
                {
                    SoHoaDonBan = hdb.SoHoaDonBan,
                    MaHang = r["ma_hang"].ToString(),
                    TenHangHoa = r["ten_hang_hoa"].ToString(),
                    SoLuong = Convert.ToInt32(r["so_luong"]),
                    DonGia = Convert.ToDecimal(r["don_gia"]),
                    GiamGia = Convert.ToDecimal(r["giam_gia"]),
                    ThanhTien = Convert.ToDecimal(r["thanh_tien"])
                });
            }

            try
            {
                hoaDonBanBLL.LuuHoaDonBan(hdb, list);

                dangTaoDon = false;
                DatTrangThaiNhapLieu(false);

                btnTaoMoi.Enabled = true;
                btnThemVaoDon.Enabled = false;
                btnXoaDong.Enabled = false;
                btnLuuHoaDon.Enabled = false;
                btnInHoaDon.Enabled = true;
                btnHuyHoaDon.Enabled = true;

                LoadDanhSachHangHoa();

                MessageBox.Show("Lưu hóa đơn bán hàng thành công! Đã cập nhật tồn kho tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn bán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDB.Text) || dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hóa đơn để in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ExcelExportHelper.InHoaDonBan(
                    txtMaHDB.Text.Trim(),
                    dtpNgayBan.Value.ToString("dd/MM/yyyy HH:mm"),
                    cboKhachHang.Text,
                    cboDienThoai.Text,
                    txtDiaChi.Text,
                    cboNhanVien.Text,
                    dgvChiTiet,
                    tongTienHienTai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn bán qua Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (dangTaoDon)
            {
                DialogResult drHuyTao = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy bỏ thao tác lập hóa đơn bán hiện tại không?",
                    "Xác nhận hủy tạo mới",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (drHuyTao == DialogResult.Yes)
                {
                    ThietLapTrangThaiBanDau();
                }
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaHDB.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần hủy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn hủy hóa đơn bán {0} và hoàn trả lại tồn kho không?", txtMaHDB.Text),
                "Xác nhận hủy hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                hoaDonBanBLL.HuyHoaDonBan(txtMaHDB.Text.Trim());
                ThietLapTrangThaiBanDau();
                LoadDanhSachHangHoa();

                MessageBox.Show("Hủy hóa đơn bán thành công! Hàng hóa đã được hoàn trả lại kho đầy đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            lblTongTienBangChu.Text = string.Format("Bằng chữ: {0}", DocSoThanhChu(tongTien));
        }

        private string DocSoThanhChu(decimal tongTien)
        {
            if (tongTien <= 0)
            {
                return "Không đồng";
            }

            long so = (long)Math.Round(tongTien);
            string[] chuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] donVi = { "", "nghìn", "triệu", "tỷ" };

            string ketQua = "";
            int cap = 0;

            while (so > 0)
            {
                long baSo = so % 1000;
                if (baSo > 0)
                {
                    string chuBaSo = DocNhomBaSo((int)baSo, chuSo);
                    ketQua = chuBaSo + " " + donVi[cap] + " " + ketQua;
                }
                so /= 1000;
                cap++;
            }

            ketQua = ketQua.Trim();
            if (ketQua.Length > 0)
            {
                ketQua = char.ToUpper(ketQua[0]) + ketQua.Substring(1) + " đồng";
            }

            return ketQua;
        }

        private string DocNhomBaSo(int n, string[] chuSo)
        {
            int tram = n / 100;
            int chuc = (n % 100) / 10;
            int donVi = n % 10;
            string res = "";

            if (tram > 0)
            {
                res += chuSo[tram] + " trăm";
                if (chuc == 0 && donVi > 0)
                {
                    res += " lẻ";
                }
            }

            if (chuc > 1)
            {
                res += " " + chuSo[chuc] + " mươi";
                if (donVi == 1)
                {
                    res += " mốt";
                }
                else if (donVi == 5)
                {
                    res += " lăm";
                }
                else if (donVi > 0)
                {
                    res += " " + chuSo[donVi];
                }
            }
            else if (chuc == 1)
            {
                res += " mười";
                if (donVi == 5)
                {
                    res += " lăm";
                }
                else if (donVi > 0)
                {
                    res += " " + chuSo[donVi];
                }
            }
            else if (tram == 0 && donVi > 0)
            {
                res += chuSo[donVi];
            }
            else if (donVi > 0)
            {
                res += " " + chuSo[donVi];
            }

            return res.Trim();
        }
    }
}
