using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.TimKiem
{
    public partial class frmTimKiemHDBan : Form
    {
        private readonly TimKiemBLL timKiemBLL;
        private readonly NhanSuBLL nhanSuBLL;
        private readonly DoiTacBLL doiTacBLL;
        private bool dangTaiDuLieu;

        public frmTimKiemHDBan()
        {
            InitializeComponent();
            timKiemBLL = new TimKiemBLL();
            nhanSuBLL = new NhanSuBLL();
            doiTacBLL = new DoiTacBLL();
            dangTaiDuLieu = false;
        }

        private void frmTimKiemHDBan_Load(object sender, EventArgs e)
        {
            UIHelper.FormatDateTimeColumns(dgvKetQua, "colThoiGianBan");
            UIHelper.FormatCurrencyColumns(dgvKetQua, "colTongTien");
            UIHelper.GanXoaChonTuDong(dgvKetQua);

            dtpTuNgay.ValueChanged += (s, ev) =>
            {
                if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
                {
                    dtpDenNgay.Value = dtpTuNgay.Value;
                }
            };
            dtpDenNgay.ValueChanged += (s, ev) =>
            {
                if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
                {
                    dtpTuNgay.Value = dtpDenNgay.Value;
                }
            };

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

                DataTable dtKH = doiTacBLL.LayDanhSachKhachHang();
                cboKhachHang.DataSource = TaoBangKHCoTatCa(dtKH);
                cboKhachHang.DisplayMember = "hien_thi";
                cboKhachHang.ValueMember = "ma_khach";
                cboKhachHang.DropDownWidth = 380;
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

        private DataTable TaoBangKHCoTatCa(DataTable dtNguon)
        {
            DataTable dt = dtNguon.Clone();
            if (!dt.Columns.Contains("hien_thi"))
            {
                dt.Columns.Add("hien_thi", typeof(string));
            }

            DataRow r = dt.NewRow();
            r["ma_khach"] = string.Empty;
            r["ten_khach"] = "[Tất cả]";
            r["hien_thi"] = "[Tất cả]";
            dt.Rows.Add(r);

            foreach (DataRow row in dtNguon.Rows)
            {
                DataRow newRow = dt.NewRow();
                foreach (DataColumn col in dtNguon.Columns)
                {
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
                string ten = row["ten_khach"] != null ? row["ten_khach"].ToString().Trim() : string.Empty;
                string sdt = row["dien_thoai"] != null ? row["dien_thoai"].ToString().Trim() : string.Empty;
                newRow["hien_thi"] = string.IsNullOrEmpty(sdt) ? ten : string.Format("{0} - {1}", ten, sdt);
                dt.Rows.Add(newRow);
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
                string maKhach = cboKhachHang.SelectedValue?.ToString() ?? string.Empty;

                DataTable dt = timKiemBLL.TimKiemHoaDonBan(tuNgay, denNgay, maNhanVien, maKhach);
                dgvKetQua.DataSource = dt;
                UIHelper.XoaChonLuoi(dgvKetQua);
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show(aex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm hóa đơn bán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (cboKhachHang.Items.Count > 0) cboKhachHang.SelectedIndex = 0;
        }

        private void dgvKetQua_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string soHDB = dgvKetQua.Rows[e.RowIndex].Cells["colSoHDB"].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(soHDB))
            {
                using (frmChiTietHDBanModal dlg = new frmChiTietHDBanModal(soHDB.Trim()))
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
