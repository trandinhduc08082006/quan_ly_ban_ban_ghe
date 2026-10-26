using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.TimKiem
{
    public partial class frmChiTietHDBanModal : Form
    {
        private readonly string soHDB;
        private readonly HoaDonBanBLL hoaDonBanBLL;
        private string tenKhach = string.Empty;
        private string dienThoai = string.Empty;
        private string diaChi = string.Empty;
        private string tenNhanVien = string.Empty;
        private string ngayBan = string.Empty;
        private decimal tongTien = 0;

        public frmChiTietHDBanModal(string soHDB)
        {
            InitializeComponent();
            this.soHDB = soHDB;
            hoaDonBanBLL = new HoaDonBanBLL();
        }

        private void frmChiTietHDBanModal_Load(object sender, EventArgs e)
        {
            Text = string.Format("CHI TIẾT HÓA ĐƠN BÁN - {0}", soHDB);
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
                DataTable dt = hoaDonBanBLL.LayHoaDonBanTheoMa(soHDB);
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    txtSoHDB.Text = r["so_hoa_don_ban"]?.ToString() ?? string.Empty;

                    tenKhach = r["ten_khach"]?.ToString() ?? string.Empty;
                    dienThoai = r["dien_thoai"]?.ToString() ?? string.Empty;
                    diaChi = r["dia_chi"]?.ToString() ?? string.Empty;
                    tenNhanVien = r["ten_nhan_vien"]?.ToString() ?? string.Empty;

                    if (r["thoi_gian_ban"] != DBNull.Value)
                    {
                        DateTime tg = Convert.ToDateTime(r["thoi_gian_ban"]);
                        ngayBan = tg.ToString("dd/MM/yyyy HH:mm");
                        txtThoiGian.Text = ngayBan;
                    }
                    else
                    {
                        txtThoiGian.Text = string.Empty;
                    }

                    txtKhachHang.Text = tenKhach;
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
                                || string.Equals(UserSession.Quyen, "BanHang", StringComparison.OrdinalIgnoreCase);
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
                DataTable dt = hoaDonBanBLL.LayChiTietHoaDonBan(soHDB);
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
                ExcelExportHelper.InHoaDonBan(
                    soHDB,
                    ngayBan,
                    tenKhach,
                    dienThoai,
                    diaChi,
                    tenNhanVien,
                    dgvChiTiet,
                    tongTien
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn bán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn hủy hóa đơn bán {0} và hoàn trả lại tồn kho không?", soHDB),
                "Xác nhận hủy hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                hoaDonBanBLL.HuyHoaDonBan(soHDB);
                txtTrangThai.Text = "ĐÃ HỦY";
                txtTrangThai.ForeColor = Color.Red;
                btnHuyHoaDon.Enabled = false;
                DialogResult = DialogResult.OK;
                MessageBox.Show("Hủy hóa đơn bán thành công! Hàng hóa đã được hoàn trả lại kho đầy đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
