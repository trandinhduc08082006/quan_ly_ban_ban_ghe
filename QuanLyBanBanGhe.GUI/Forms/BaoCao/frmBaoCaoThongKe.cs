using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.BaoCao
{
    public partial class frmBaoCaoThongKe : Form
    {
        private readonly BaoCaoBLL baoCaoBLL;
        private readonly NhanSuBLL nhanSuBLL;
        private bool dangKhoiTao = false;
        private bool dangCapNhatTab2 = false;
        private bool dangCapNhatTab3 = false;

        public frmBaoCaoThongKe()
        {
            InitializeComponent();
            baoCaoBLL = new BaoCaoBLL();
            nhanSuBLL = new NhanSuBLL();
        }

        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            dangKhoiTao = true;
            try
            {
                KhoiTaoCacComboBox();
                CaiDatDinhDangLuoi();
                GanSuKienControl();

                UIHelper.GanXoaChonTuDong(dgvTop10);
                UIHelper.GanXoaChonTuDong(dgvNhapHang);
                UIHelper.GanXoaChonTuDong(dgvBanHang);
                UIHelper.GanXoaChonTuDong(dgvNVDoanhSo0);
                UIHelper.GanXoaChonTuDong(dgvNVDoanhSoThap);
            }
            finally
            {
                dangKhoiTao = false;
            }

            TaiBaoCao1();
            TaiBaoCao2();
            TaiBaoCao3();
            TaiBaoCao4();
        }

        private void GanSuKienControl()
        {
            cboNam1.KeyPress += cboNam_KeyPress;
            cboNam2.KeyPress += cboNam_KeyPress;
            cboNam3.KeyPress += cboNam_KeyPress;
            cboNam4.KeyPress += cboNam_KeyPress;

            cboNam1.Leave += cboNam_Leave;
            cboNam2.Leave += cboNam_Leave;
            cboNam3.Leave += cboNam_Leave;
            cboNam4.Leave += cboNam_Leave;

            cboNam1.KeyDown += cboNam_KeyDown;
            cboNam2.KeyDown += cboNam_KeyDown;
            cboNam3.KeyDown += cboNam_KeyDown;
            cboNam4.KeyDown += cboNam_KeyDown;

            cboThang2.SelectedIndexChanged += cboThang2_SelectedIndexChanged;
            cboQuy2.SelectedIndexChanged += cboQuy2_SelectedIndexChanged;

            cboThang3.SelectedIndexChanged += cboThang3_SelectedIndexChanged;
            cboQuy3.SelectedIndexChanged += cboQuy3_SelectedIndexChanged;
        }

        private void cboNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHelper.ChiChoPhepNhapSo(e);
        }

        private void cboNam_Leave(object sender, EventArgs e)
        {
            if (sender is ComboBox cbo)
            {
                string text = cbo.Text.Trim();
                if (int.TryParse(text, out int nam))
                {
                    if (nam > DateTime.Now.Year)
                    {
                        MessageBox.Show(string.Format("Năm thống kê ({0}) không được lớn hơn năm hiện tại ({1})!", nam, DateTime.Now.Year), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbo.Text = DateTime.Now.Year.ToString();
                        cbo.Focus();
                        cbo.SelectAll();
                    }
                    else if (nam < 2000)
                    {
                        MessageBox.Show("Năm thống kê không hợp lệ (phải từ năm 2000 trở lên)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbo.Text = DateTime.Now.Year.ToString();
                        cbo.Focus();
                        cbo.SelectAll();
                    }
                }
                else if (!string.IsNullOrEmpty(text))
                {
                    MessageBox.Show("Vui lòng nhập năm hợp lệ (phải từ năm 2000 trở lên)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo.Text = DateTime.Now.Year.ToString();
                    cbo.Focus();
                    cbo.SelectAll();
                }
            }
        }

        private void cboNam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (sender == cboNam1) btnBaoCao1.PerformClick();
                else if (sender == cboNam2) btnBaoCao2.PerformClick();
                else if (sender == cboNam3) btnBaoCao3.PerformClick();
                else if (sender == cboNam4) btnBaoCao4.PerformClick();
            }
        }

        private bool KiemTraNamHopLe(ComboBox cbo, out int nam)
        {
            nam = 0;
            string text = cbo.Text.Trim();
            if (string.IsNullOrEmpty(text) || !int.TryParse(text, out nam))
            {
                MessageBox.Show("Vui lòng nhập năm hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo.Focus();
                return false;
            }

            int namHienTai = DateTime.Now.Year;
            if (nam > namHienTai)
            {
                MessageBox.Show(string.Format("Năm thống kê ({0}) không được lớn hơn năm hiện tại ({1})!", nam, namHienTai), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo.Focus();
                return false;
            }

            if (nam < 2000)
            {
                MessageBox.Show("Năm thống kê không hợp lệ (phải từ năm 2000 trở lên)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo.Focus();
                return false;
            }

            return true;
        }

        private DataTable TaoDataTableThang()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaThang", typeof(int));
            dt.Columns.Add("TenThang", typeof(string));
            dt.Rows.Add(0, "[Không chọn]");
            for (int m = 1; m <= 12; m++)
            {
                dt.Rows.Add(m, "Tháng " + m);
            }
            return dt;
        }

        private DataTable TaoDataTableQuy()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaQuy", typeof(int));
            dt.Columns.Add("TenQuy", typeof(string));
            dt.Rows.Add(0, "[Không chọn]");
            for (int q = 1; q <= 4; q++)
            {
                dt.Rows.Add(q, "Quý " + q);
            }
            return dt;
        }

        private void KhoiTaoCacComboBox()
        {
            int namHienTai = DateTime.Now.Year;
            cboNam1.Items.Clear();
            cboNam2.Items.Clear();
            cboNam3.Items.Clear();
            cboNam4.Items.Clear();

            for (int y = namHienTai; y >= 2000; y--)
            {
                cboNam1.Items.Add(y);
                cboNam2.Items.Add(y);
                cboNam3.Items.Add(y);
                cboNam4.Items.Add(y);
            }

            cboNam1.Text = namHienTai.ToString();
            cboNam2.Text = namHienTai.ToString();
            cboNam3.Text = namHienTai.ToString();
            cboNam4.Text = namHienTai.ToString();

            cboThang2.DataSource = TaoDataTableThang();
            cboThang2.DisplayMember = "TenThang";
            cboThang2.ValueMember = "MaThang";

            cboQuy2.DataSource = TaoDataTableQuy();
            cboQuy2.DisplayMember = "TenQuy";
            cboQuy2.ValueMember = "MaQuy";

            cboThang3.DataSource = TaoDataTableThang();
            cboThang3.DisplayMember = "TenThang";
            cboThang3.ValueMember = "MaThang";

            cboQuy3.DataSource = TaoDataTableQuy();
            cboQuy3.DisplayMember = "TenQuy";
            cboQuy3.ValueMember = "MaQuy";

            DataTable dtNV = nhanSuBLL.LayDanhSachNhanVien();

            DataTable dtNV2 = dtNV.Clone();
            DataRow rowTatCa2 = dtNV2.NewRow();
            rowTatCa2["ma_nhan_vien"] = string.Empty;
            rowTatCa2["ten_nhan_vien"] = "[Tất cả nhân viên]";
            dtNV2.Rows.Add(rowTatCa2);
            foreach (DataRow r in dtNV.Rows)
            {
                dtNV2.ImportRow(r);
            }
            cboNhanVien2.DataSource = dtNV2;
            cboNhanVien2.DisplayMember = "ten_nhan_vien";
            cboNhanVien2.ValueMember = "ma_nhan_vien";
            cboNhanVien2.SelectedIndex = 0;

            DataTable dtNV3 = dtNV.Clone();
            DataRow rowTatCa3 = dtNV3.NewRow();
            rowTatCa3["ma_nhan_vien"] = string.Empty;
            rowTatCa3["ten_nhan_vien"] = "[Tất cả nhân viên]";
            dtNV3.Rows.Add(rowTatCa3);
            foreach (DataRow r in dtNV.Rows)
            {
                dtNV3.ImportRow(r);
            }
            cboNhanVien3.DataSource = dtNV3;
            cboNhanVien3.DisplayMember = "ten_nhan_vien";
            cboNhanVien3.ValueMember = "ma_nhan_vien";
            cboNhanVien3.SelectedIndex = 0;

            cboQuy2.SelectedValue = 1;
            cboThang2.SelectedValue = 0;
            cboThang2.Enabled = false;

            cboThang3.SelectedValue = 1;
            cboQuy3.SelectedValue = 0;
            cboQuy3.Enabled = false;
        }

        private void cboThang2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao || dangCapNhatTab2) return;
            dangCapNhatTab2 = true;
            try
            {
                int thang = Convert.ToInt32(cboThang2.SelectedValue ?? 0);
                if (thang > 0)
                {
                    cboQuy2.SelectedValue = 0;
                    cboQuy2.Enabled = false;
                }
                else
                {
                    cboQuy2.Enabled = true;
                }
            }
            finally
            {
                dangCapNhatTab2 = false;
            }
        }

        private void cboQuy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao || dangCapNhatTab2) return;
            dangCapNhatTab2 = true;
            try
            {
                int quy = Convert.ToInt32(cboQuy2.SelectedValue ?? 0);
                if (quy > 0)
                {
                    cboThang2.SelectedValue = 0;
                    cboThang2.Enabled = false;
                }
                else
                {
                    cboThang2.Enabled = true;
                }
            }
            finally
            {
                dangCapNhatTab2 = false;
            }
        }

        private void cboThang3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao || dangCapNhatTab3) return;
            dangCapNhatTab3 = true;
            try
            {
                int thang = Convert.ToInt32(cboThang3.SelectedValue ?? 0);
                if (thang > 0)
                {
                    cboQuy3.SelectedValue = 0;
                    cboQuy3.Enabled = false;
                }
                else
                {
                    cboQuy3.Enabled = true;
                }
            }
            finally
            {
                dangCapNhatTab3 = false;
            }
        }

        private void cboQuy3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao || dangCapNhatTab3) return;
            dangCapNhatTab3 = true;
            try
            {
                int quy = Convert.ToInt32(cboQuy3.SelectedValue ?? 0);
                if (quy > 0)
                {
                    cboThang3.SelectedValue = 0;
                    cboThang3.Enabled = false;
                }
                else
                {
                    cboThang3.Enabled = true;
                }
            }
            finally
            {
                dangCapNhatTab3 = false;
            }
        }

        private void CaiDatDinhDangLuoi()
        {
            UIHelper.FormatIntegerColumns(dgvTop10, "colSoLuong1");
            UIHelper.FormatCurrencyColumns(dgvTop10, "colDoanhThu1");

            UIHelper.FormatDateTimeColumns(dgvNhapHang, "colThoiGianNhap2");
            UIHelper.FormatCurrencyColumns(dgvNhapHang, "colTongTien2");

            UIHelper.FormatDateTimeColumns(dgvBanHang, "colThoiGianBan3");
            UIHelper.FormatCurrencyColumns(dgvBanHang, "colTongTien3");

            UIHelper.FormatIntegerColumns(dgvNVDoanhSo0, "colSoHoaDon0");
            UIHelper.FormatCurrencyColumns(dgvNVDoanhSo0, "colTongTien0");

            UIHelper.FormatIntegerColumns(dgvNVDoanhSoThap, "colSoHoaDonThap");
            UIHelper.FormatCurrencyColumns(dgvNVDoanhSoThap, "colTongTienThap");
        }

        private void TaiBaoCao1()
        {
            if (!KiemTraNamHopLe(cboNam1, out int nam)) return;

            try
            {
                DataTable dt = baoCaoBLL.BaoCaoTop10BanChay(nam);
                dgvTop10.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvTop10);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Báo cáo top 10 bán chạy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaoCao1_Click(object sender, EventArgs e)
        {
            TaiBaoCao1();
        }

        private void btnXuatExcel1_Click(object sender, EventArgs e)
        {
            if (!KiemTraNamHopLe(cboNam1, out int nam)) return;
            ExcelExportHelper.ExportToExcel(dgvTop10, string.Format("Top 10 bàn ghế bán chạy năm {0}", nam));
        }

        private void TaiBaoCao2()
        {
            if (!KiemTraNamHopLe(cboNam2, out int nam)) return;

            try
            {
                int thang = Convert.ToInt32(cboThang2.SelectedValue ?? 0);
                int quy = Convert.ToInt32(cboQuy2.SelectedValue ?? 0);
                string maNV = cboNhanVien2.SelectedValue?.ToString() ?? string.Empty;

                int? paramThang = thang > 0 ? (int?)thang : null;
                int? paramQuy = quy > 0 ? (int?)quy : null;

                DataTable dt = baoCaoBLL.BaoCaoNhapHang(paramThang, paramQuy, nam, maNV);
                dgvNhapHang.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvNhapHang);

                decimal tongTien = 0m;
                foreach (DataRow r in dt.Rows)
                {
                    if (r["tong_tien"] != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(r["tong_tien"]);
                    }
                }

                if (paramThang.HasValue)
                {
                    lblTongTienNhap2.Text = string.Format("Tổng tiền nhập trong tháng {0} năm {1}: {2:N0} VNĐ", paramThang.Value, nam, tongTien);
                }
                else if (paramQuy.HasValue)
                {
                    lblTongTienNhap2.Text = string.Format("Tổng tiền nhập trong quý {0} năm {1}: {2:N0} VNĐ", paramQuy.Value, nam, tongTien);
                }
                else
                {
                    lblTongTienNhap2.Text = string.Format("Tổng tiền nhập trong năm {0}: {1:N0} VNĐ", nam, tongTien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Báo cáo nhập hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaoCao2_Click(object sender, EventArgs e)
        {
            TaiBaoCao2();
        }

        private void btnXuatExcel2_Click(object sender, EventArgs e)
        {
            if (!KiemTraNamHopLe(cboNam2, out int nam)) return;

            int thang = Convert.ToInt32(cboThang2.SelectedValue ?? 0);
            int quy = Convert.ToInt32(cboQuy2.SelectedValue ?? 0);
            string tieuDe;
            if (thang > 0)
            {
                tieuDe = string.Format("Báo cáo nhập hàng tháng {0} năm {1}", thang, nam);
            }
            else if (quy > 0)
            {
                tieuDe = string.Format("Báo cáo nhập hàng quý {0} năm {1}", quy, nam);
            }
            else
            {
                tieuDe = string.Format("Báo cáo nhập hàng năm {0}", nam);
            }

            ExcelExportHelper.ExportToExcel(dgvNhapHang, tieuDe);
        }

        private void TaiBaoCao3()
        {
            if (!KiemTraNamHopLe(cboNam3, out int nam)) return;

            try
            {
                int thang = Convert.ToInt32(cboThang3.SelectedValue ?? 0);
                int quy = Convert.ToInt32(cboQuy3.SelectedValue ?? 0);
                string maNV = cboNhanVien3.SelectedValue?.ToString() ?? string.Empty;

                int? paramThang = thang > 0 ? (int?)thang : null;
                int? paramQuy = quy > 0 ? (int?)quy : null;

                DataTable dt = baoCaoBLL.BaoCaoBanHang(paramThang, paramQuy, nam, maNV);
                dgvBanHang.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvBanHang);

                int soDon = dt.Rows.Count;
                decimal tongDoanhThu = 0m;
                foreach (DataRow r in dt.Rows)
                {
                    if (r["tong_tien"] != DBNull.Value)
                    {
                        tongDoanhThu += Convert.ToDecimal(r["tong_tien"]);
                    }
                }

                lblTongSoDon3.Text = string.Format("Tổng số hóa đơn: {0}", soDon);
                if (paramThang.HasValue)
                {
                    lblTongDoanhThu3.Text = string.Format("Tổng doanh thu bán hàng trong tháng {0} năm {1}: {2:N0} VNĐ", paramThang.Value, nam, tongDoanhThu);
                }
                else if (paramQuy.HasValue)
                {
                    lblTongDoanhThu3.Text = string.Format("Tổng doanh thu bán hàng trong quý {0} năm {1}: {2:N0} VNĐ", paramQuy.Value, nam, tongDoanhThu);
                }
                else
                {
                    lblTongDoanhThu3.Text = string.Format("Tổng doanh thu bán hàng trong năm {0}: {1:N0} VNĐ", nam, tongDoanhThu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Báo cáo bán hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaoCao3_Click(object sender, EventArgs e)
        {
            TaiBaoCao3();
        }

        private void btnXuatExcel3_Click(object sender, EventArgs e)
        {
            if (!KiemTraNamHopLe(cboNam3, out int nam)) return;

            int thang = Convert.ToInt32(cboThang3.SelectedValue ?? 0);
            int quy = Convert.ToInt32(cboQuy3.SelectedValue ?? 0);
            string tieuDe;
            if (thang > 0)
            {
                tieuDe = string.Format("Báo cáo bán hàng tháng {0} năm {1}", thang, nam);
            }
            else if (quy > 0)
            {
                tieuDe = string.Format("Báo cáo bán hàng quý {0} năm {1}", quy, nam);
            }
            else
            {
                tieuDe = string.Format("Báo cáo bán hàng năm {0}", nam);
            }

            ExcelExportHelper.ExportToExcel(dgvBanHang, tieuDe);
        }

        private void TaiBaoCao4()
        {
            if (!KiemTraNamHopLe(cboNam4, out int nam)) return;

            try
            {
                DataTable dt0 = baoCaoBLL.BaoCaoNhanVienDoanhSo0(nam);
                dgvNVDoanhSo0.DataSource = dt0;
                UIHelper.XoaChonLuoi(dgvNVDoanhSo0);
                int count0 = dt0 != null ? dt0.Rows.Count : 0;
                grpNV0.Text = string.Format("Danh sách nhân viên chưa bán được đơn nào trong năm {0} ({1} nhân viên)", nam, count0);

                DataTable dtThap = baoCaoBLL.BaoCaoTop10NhanVienDoanhSoThap(nam);
                dgvNVDoanhSoThap.DataSource = dtThap;
                UIHelper.XoaChonLuoi(dgvNVDoanhSoThap);
                int countThap = dtThap != null ? dtThap.Rows.Count : 0;
                grpNVThap.Text = string.Format("Top 10 nhân viên có doanh số bán hàng thấp nhất năm {0} ({1} nhân viên)", nam, countThap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Báo cáo nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaoCao4_Click(object sender, EventArgs e)
        {
            TaiBaoCao4();
        }

        private void btnXuatExcel4_Click(object sender, EventArgs e)
        {
            if (!KiemTraNamHopLe(cboNam4, out int nam)) return;
            ExcelExportHelper.ExportBaoCao4ToExcel(dgvNVDoanhSo0, dgvNVDoanhSoThap, nam);
        }
    }
}
