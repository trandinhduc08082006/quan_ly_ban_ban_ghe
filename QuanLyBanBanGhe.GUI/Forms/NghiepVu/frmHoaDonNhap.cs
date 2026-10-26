using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
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
        private bool dangTaoDon;
        private bool dangTaiDuLieu;
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

        private void LoadDanhSachNhaCungCap()
        {
            dangTaiDuLieu = true;
            try
            {
                DataTable dt = doiTacBLL.LayDanhSachNhaCungCap();
                cboNhaCungCap.DataSource = dt;
                cboNhaCungCap.DisplayMember = "ten_nha_cung_cap";
                cboNhaCungCap.ValueMember = "ma_nha_cung_cap";
                cboNhaCungCap.SelectedIndex = -1;
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

        private void cboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu)
            {
                return;
            }
            CapNhatThongTinNhaCungCap();
        }

        private void CapNhatThongTinNhaCungCap()
        {
            if (cboNhaCungCap.SelectedItem is DataRowView drv)
            {
                txtDienThoai.Text = drv["dien_thoai"]?.ToString() ?? string.Empty;
                txtDiaChi.Text = drv["dia_chi"]?.ToString() ?? string.Empty;
            }
            else
            {
                txtDienThoai.Clear();
                txtDiaChi.Clear();
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
                txtDienThoai.Clear();
                txtDiaChi.Clear();
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

        private void DatTrangThaiNhapLieu(bool moKhoa)
        {
            dtpNgayNhap.Enabled = moKhoa;
            cboNhanVien.Enabled = false;
            cboNhaCungCap.Enabled = moKhoa;
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

            dangTaiDuLieu = true;
            try
            {
                cboNhaCungCap.SelectedIndex = -1;
                txtDienThoai.Clear();
                txtDiaChi.Clear();

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
            decimal.TryParse(txtDonGiaNhap.Text.Replace(",", "").Trim(), out decimal donGia);
            int.TryParse(txtSoLuong.Text.Trim(), out int soLuong);

            decimal thanhTien = soLuong * donGia;
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

            if (!decimal.TryParse(txtDonGiaNhap.Text.Replace(",", "").Trim(), out decimal donGia) || donGia <= 0)
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
                int soLuongMoi = soLuongCu + soLuong;
                timDong["so_luong"] = soLuongMoi;
                timDong["don_gia"] = donGia;
                timDong["thanh_tien"] = soLuongMoi * donGia;
            }
            else
            {
                decimal thanhTien = soLuong * donGia;
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

            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhaCungCap.Focus();
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

            HoaDonNhapDTO hdn = new HoaDonNhapDTO
            {
                SoHoaDonNhap = txtMaHDN.Text.Trim(),
                ThoiGianNhap = dtpNgayNhap.Value,
                MaNhaCungCap = cboNhaCungCap.SelectedValue.ToString(),
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

                MessageBox.Show("Lưu hóa đơn nhập hàng thành công! Tồn kho và đơn giá sản phẩm đã được tự động cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi lưu hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text) || dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hóa đơn để in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ExcelExportHelper.InHoaDonNhap(
                    txtMaHDN.Text.Trim(),
                    dtpNgayNhap.Value.ToString("dd/MM/yyyy HH:mm"),
                    cboNhaCungCap.Text,
                    txtDienThoai.Text,
                    txtDiaChi.Text,
                    cboNhanVien.Text,
                    dgvChiTiet,
                    tongTienHienTai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn nhập qua Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
