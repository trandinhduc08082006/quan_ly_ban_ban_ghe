using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.TimKiem
{
    public partial class frmTimKiemHDNhap : Form
    {
        private readonly TimKiemBLL timKiemBLL;
        private readonly NhanSuBLL nhanSuBLL;
        private readonly DoiTacBLL doiTacBLL;
        private bool dangTaiDuLieu;

        public frmTimKiemHDNhap()
        {
            InitializeComponent();
            timKiemBLL = new TimKiemBLL();
            nhanSuBLL = new NhanSuBLL();
            doiTacBLL = new DoiTacBLL();
            dangTaiDuLieu = false;
        }

        private void frmTimKiemHDNhap_Load(object sender, EventArgs e)
        {
            UIHelper.FormatDateTimeColumns(dgvKetQua, "colThoiGianNhap");
            UIHelper.FormatCurrencyColumns(dgvKetQua, "colTongTien");
            UIHelper.GanXoaChonTuDong(dgvKetQua);

            LoadComboBoxes();
            LamMoiBoLoc();
            ThucHienTimKiem();
        }

        private void LoadComboBoxes()
        {
            dangTaiDuLieu = true;
            try
            {
                DataTable dtNV = nhanSuBLL.LayDanhSachNhanVien();
                cboNhanVien.DataSource = TaoBangNhanVienCoTatCa(dtNV);
                cboNhanVien.DisplayMember = "ten_nhan_vien";
                cboNhanVien.ValueMember = "ma_nhan_vien";

                DataTable dtNCC = doiTacBLL.LayDanhSachNhaCungCap();
                cboNhaCungCap.DataSource = TaoBangNCCCoTatCa(dtNCC);
                cboNhaCungCap.DisplayMember = "ten_nha_cung_cap";
                cboNhaCungCap.ValueMember = "ma_nha_cung_cap";
                cboNhaCungCap.DropDownWidth = 380;
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private DataTable TaoBangNhanVienCoTatCa(DataTable dtNguon)
        {
            DataTable dt = dtNguon.Clone();
            DataRow r = dt.NewRow();
            r["ma_nhan_vien"] = string.Empty;
            r["ten_nhan_vien"] = "[Tất cả]";
            dt.Rows.Add(r);

            foreach (DataRow row in dtNguon.Rows)
            {
                dt.ImportRow(row);
            }

            return dt;
        }

        private DataTable TaoBangNCCCoTatCa(DataTable dtNguon)
        {
            DataTable dt = dtNguon.Clone();
            DataRow r = dt.NewRow();
            r["ma_nha_cung_cap"] = string.Empty;
            r["ten_nha_cung_cap"] = "[Tất cả]";
            dt.Rows.Add(r);

            foreach (DataRow row in dtNguon.Rows)
            {
                dt.ImportRow(row);
            }

            return dt;
        }

        private void ThucHienTimKiem()
        {
            if (dangTaiDuLieu)
            {
                return;
            }

            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;
                string maNhanVien = cboNhanVien.SelectedValue?.ToString() ?? string.Empty;
                string maNCC = cboNhaCungCap.SelectedValue?.ToString() ?? string.Empty;

                DataTable dt = timKiemBLL.TimKiemHoaDonNhap(tuNgay, denNgay, maNhanVien, maNCC);
                dgvKetQua.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvKetQua);
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show(aex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiBoLoc();
            ThucHienTimKiem();
        }

        private void LamMoiBoLoc()
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            if (cboNhanVien.Items.Count > 0) cboNhanVien.SelectedIndex = 0;
            if (cboNhaCungCap.Items.Count > 0) cboNhaCungCap.SelectedIndex = 0;
        }

        private void dgvKetQua_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string soHDN = dgvKetQua.Rows[e.RowIndex].Cells["colSoHDN"].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(soHDN))
            {
                using (frmChiTietHDNhapModal dlg = new frmChiTietHDNhapModal(soHDN.Trim()))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        ThucHienTimKiem();
                    }
                }
            }
        }

        private void dgvKetQua_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvKetQua.Columns[e.ColumnIndex].Name == "colTrangThai")
            {
                string val = e.Value?.ToString();
                if (string.Equals(val, "DaHuy", StringComparison.OrdinalIgnoreCase))
                {
                    e.Value = "Đã hủy";
                    e.FormattingApplied = true;
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvKetQua.Font, FontStyle.Italic);
                }
                else if (string.Equals(val, "HoanThanh", StringComparison.OrdinalIgnoreCase))
                {
                    e.Value = "Hoàn thành";
                    e.FormattingApplied = true;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }
    }
}
