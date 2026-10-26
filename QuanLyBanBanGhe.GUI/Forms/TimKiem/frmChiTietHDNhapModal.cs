using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.TimKiem
{
    public partial class frmChiTietHDNhapModal : Form
    {
        private readonly string soHDN;
        private readonly HoaDonNhapBLL hoaDonNhapBLL;
        private string tenNCC = string.Empty;
        private string dienThoai = string.Empty;
        private string diaChi = string.Empty;
        private string tenNhanVien = string.Empty;
        private string ngayNhap = string.Empty;
        private decimal tongTien = 0;

        public frmChiTietHDNhapModal(string soHDN)
        {
            InitializeComponent();
            this.soHDN = soHDN;
            hoaDonNhapBLL = new HoaDonNhapBLL();
        }

        private void frmChiTietHDNhapModal_Load(object sender, EventArgs e)
        {
            Text = string.Format("CHI TIẾT HÓA ĐƠN NHẬP - {0}", soHDN);
            UIHelper.FormatIntegerColumns(dgvChiTiet, "colSoLuong", "colGiamGia");
            UIHelper.FormatCurrencyColumns(dgvChiTiet, "colDonGia", "colThanhTien");
            UIHelper.GanXoaChonTuDong(dgvChiTiet);

            LoadThongTinHoaDon();
            LoadDanhSachChiTiet();
        }

        private void LoadThongTinHoaDon()
        {
            try
            {
                DataTable dt = hoaDonNhapBLL.LayHoaDonNhapTheoMa(soHDN);
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    txtSoHDN.Text = r["so_hoa_don_nhap"]?.ToString() ?? string.Empty;

                    tenNCC = r["ten_nha_cung_cap"]?.ToString() ?? string.Empty;
                    dienThoai = r["dien_thoai"]?.ToString() ?? string.Empty;
                    diaChi = r["dia_chi"]?.ToString() ?? string.Empty;
                    tenNhanVien = r["ten_nhan_vien"]?.ToString() ?? string.Empty;

                    if (r["thoi_gian_nhap"] != DBNull.Value)
                    {
                        DateTime tg = Convert.ToDateTime(r["thoi_gian_nhap"]);
                        ngayNhap = tg.ToString("dd/MM/yyyy HH:mm");
                        txtThoiGian.Text = ngayNhap;
                    }
                    else
                    {
                        txtThoiGian.Text = string.Empty;
                    }

                    txtNhaCungCap.Text = tenNCC;
                    txtNhanVien.Text = tenNhanVien;

                    if (r["tong_tien"] != DBNull.Value)
                    {
                        tongTien = Convert.ToDecimal(r["tong_tien"]);
                        txtTongTien.Text = tongTien.ToString("N0") + " VNĐ";
                    }
                    else
                    {
                        txtTongTien.Text = "0 VNĐ";
                    }

                    string trangThai = r["trang_thai_giao_dich"]?.ToString() ?? string.Empty;
                    bool daHuy = string.Equals(trangThai, "DaHuy", StringComparison.OrdinalIgnoreCase);
                    if (daHuy)
                    {
                        txtTrangThai.Text = "ĐÃ HỦY";
                        txtTrangThai.ForeColor = Color.Red;
                        btnHuyHoaDon.Enabled = false;
                    }
                    else
                    {
                        txtTrangThai.Text = "HOÀN THÀNH";
                        txtTrangThai.ForeColor = Color.Green;
                        btnHuyHoaDon.Enabled = true;
                    }

                    bool coQuyen = string.Equals(UserSession.Quyen, "QuanLy", StringComparison.OrdinalIgnoreCase)
                                || string.Equals(UserSession.Quyen, "ThuKho", StringComparison.OrdinalIgnoreCase);
                    btnHuyHoaDon.Visible = coQuyen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachChiTiet()
        {
            try
            {
                DataTable dt = hoaDonNhapBLL.LayChiTietHoaDonNhap(soHDN);
                dgvChiTiet.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvChiTiet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết mặt hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelExportHelper.InHoaDonNhap(
                    soHDN,
                    ngayNhap,
                    tenNCC,
                    dienThoai,
                    diaChi,
                    tenNhanVien,
                    dgvChiTiet,
                    tongTien
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn hủy phiếu nhập {0} và trừ tồn kho hoàn lại không?", soHDN),
                "Xác nhận hủy phiếu nhập",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                hoaDonNhapBLL.HuyHoaDonNhap(soHDN);
                txtTrangThai.Text = "ĐÃ HỦY";
                txtTrangThai.ForeColor = Color.Red;
                btnHuyHoaDon.Enabled = false;
                DialogResult = DialogResult.OK;
                MessageBox.Show("Hủy phiếu nhập kho thành công! Tồn kho đã được hoàn lại chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi hủy hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
