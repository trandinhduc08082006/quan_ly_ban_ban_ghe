using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.GUI.Forms.DungChung;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.TimKiem
{
    public partial class frmTimKiemHangHoa : Form
    {
        private readonly TimKiemBLL timKiemBLL;
        private readonly ThuocTinhBLL thuocTinhBLL;
        private readonly HangHoaBLL hangHoaBLL;
        private bool dangTaiDuLieu;
        private ToolTip toolTip;

        public frmTimKiemHangHoa()
        {
            InitializeComponent();
            timKiemBLL = new TimKiemBLL();
            thuocTinhBLL = new ThuocTinhBLL();
            hangHoaBLL = new HangHoaBLL();
            dangTaiDuLieu = false;
        }

        private void frmTimKiemHangHoa_Load(object sender, EventArgs e)
        {
            UIHelper.FormatIntegerColumns(dgvKetQua, "colSoLuong", "colBaoHanh");
            UIHelper.FormatCurrencyColumns(dgvKetQua, "colDonGiaNhap", "colDonGiaBan");
            UIHelper.GanXoaChonTuDong(dgvKetQua);

            toolTip = new ToolTip();
            toolTip.SetToolTip(picAnh, "Nhấp để xem ảnh phóng to");

            LoadComboBoxes();
            ThucHienTimKiem();
        }

        private void LoadComboBoxes()
        {
            dangTaiDuLieu = true;
            try
            {
                cboLoai.DataSource = TaoBangCoMucTatCa(thuocTinhBLL.LayDanhSach("loai"));
                cboLoai.DisplayMember = "Ten";
                cboLoai.ValueMember = "Ma";

                DataTable dtKichThuoc = hangHoaBLL.LayKichThuocTheoLoai(string.Empty);
                cboKichThuoc.DataSource = TaoBangCoMucTatCa(dtKichThuoc);
                cboKichThuoc.DisplayMember = "Ten";
                cboKichThuoc.ValueMember = "Ma";

                cboHinhDang.DataSource = TaoBangCoMucTatCa(thuocTinhBLL.LayDanhSach("hinh_dang"));
                cboHinhDang.DisplayMember = "Ten";
                cboHinhDang.ValueMember = "Ma";

                cboChatLieu.DataSource = TaoBangCoMucTatCa(thuocTinhBLL.LayDanhSach("chat_lieu"));
                cboChatLieu.DisplayMember = "Ten";
                cboChatLieu.ValueMember = "Ma";

                cboMauSac.DataSource = TaoBangCoMucTatCa(thuocTinhBLL.LayDanhSach("mau_sac"));
                cboMauSac.DisplayMember = "Ten";
                cboMauSac.ValueMember = "Ma";

                cboNuocSX.DataSource = TaoBangCoMucTatCa(thuocTinhBLL.LayDanhSach("nuoc_san_xuat"));
                cboNuocSX.DisplayMember = "Ten";
                cboNuocSX.ValueMember = "Ma";

                cboNhaSX.DataSource = TaoBangCoMucTatCa(thuocTinhBLL.LayDanhSach("nha_san_xuat"));
                cboNhaSX.DisplayMember = "Ten";
                cboNhaSX.ValueMember = "Ma";

                cboCongDung.DataSource = TaoBangCoMucTatCa(thuocTinhBLL.LayDanhSach("cong_dung"));
                cboCongDung.DisplayMember = "Ten";
                cboCongDung.ValueMember = "Ma";

                cboDacDiem.DataSource = TaoBangCoMucTatCa(thuocTinhBLL.LayDanhSach("dac_diem"));
                cboDacDiem.DisplayMember = "Ten";
                cboDacDiem.ValueMember = "Ma";

                cboLoai.SelectedIndex = 0;
                cboKichThuoc.SelectedIndex = 0;
                cboHinhDang.SelectedIndex = 0;
                cboChatLieu.SelectedIndex = 0;
                cboMauSac.SelectedIndex = 0;
                cboNuocSX.SelectedIndex = 0;
                cboNhaSX.SelectedIndex = 0;
                cboCongDung.SelectedIndex = 0;
                cboDacDiem.SelectedIndex = 0;
            }
            finally
            {
                dangTaiDuLieu = false;
            }
        }

        private DataTable TaoBangCoMucTatCa(DataTable dtNguon)
        {
            DataTable dt = dtNguon.Clone();
            DataRow rowTatCa = dt.NewRow();
            rowTatCa["Ma"] = string.Empty;
            rowTatCa["Ten"] = "[Tất cả]";
            dt.Rows.Add(rowTatCa);

            foreach (DataRow row in dtNguon.Rows)
            {
                dt.ImportRow(row);
            }

            return dt;
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu)
            {
                return;
            }

            dangTaiDuLieu = true;
            try
            {
                string maLoai = cboLoai.SelectedValue?.ToString() ?? string.Empty;
                DataTable dtKichThuoc = hangHoaBLL.LayKichThuocTheoLoai(maLoai);
                cboKichThuoc.DataSource = TaoBangCoMucTatCa(dtKichThuoc);
                cboKichThuoc.DisplayMember = "Ten";
                cboKichThuoc.ValueMember = "Ma";
                cboKichThuoc.SelectedIndex = 0;
            }
            finally
            {
                dangTaiDuLieu = false;
            }

            ThucHienTimKiem();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiDuLieu)
            {
                return;
            }

            ThucHienTimKiem();
        }

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ThucHienTimKiem();
            }
        }

        private void ThucHienTimKiem()
        {
            if (dangTaiDuLieu)
            {
                return;
            }

            try
            {
                string tuKhoa = txtTuKhoa.Text.Trim();
                string maLoai = cboLoai.SelectedValue?.ToString() ?? string.Empty;
                string maKichThuoc = cboKichThuoc.SelectedValue?.ToString() ?? string.Empty;
                string maHinhDang = cboHinhDang.SelectedValue?.ToString() ?? string.Empty;
                string maChatLieu = cboChatLieu.SelectedValue?.ToString() ?? string.Empty;
                string maNuocSX = cboNuocSX.SelectedValue?.ToString() ?? string.Empty;
                string maMau = cboMauSac.SelectedValue?.ToString() ?? string.Empty;
                string maNhaSX = cboNhaSX.SelectedValue?.ToString() ?? string.Empty;
                string maCongDung = cboCongDung.SelectedValue?.ToString() ?? string.Empty;
                string maDacDiem = cboDacDiem.SelectedValue?.ToString() ?? string.Empty;

                DataTable dt = timKiemBLL.TimKiemHangHoa(
                    tuKhoa,
                    maLoai,
                    maKichThuoc,
                    maHinhDang,
                    maChatLieu,
                    maNuocSX,
                    maMau,
                    maNhaSX,
                    maCongDung,
                    maDacDiem);

                dgvKetQua.DataSource = dt;

                ApDungPhanQuyen();

                UIHelper.XoaChonLuoi(dgvKetQua);
                HienThiAnhSanPham(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm hàng hóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApDungPhanQuyen()
        {
            if (string.Equals(UserSession.Quyen, "BanHang", StringComparison.OrdinalIgnoreCase))
            {
                if (dgvKetQua.Columns.Contains("colDonGiaNhap"))
                {
                    dgvKetQua.Columns["colDonGiaNhap"].Visible = false;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dangTaiDuLieu = true;
            try
            {
                txtTuKhoa.Clear();
                cboLoai.SelectedIndex = 0;

                DataTable dtKichThuoc = hangHoaBLL.LayKichThuocTheoLoai(string.Empty);
                cboKichThuoc.DataSource = TaoBangCoMucTatCa(dtKichThuoc);
                cboKichThuoc.DisplayMember = "Ten";
                cboKichThuoc.ValueMember = "Ma";
                cboKichThuoc.SelectedIndex = 0;

                cboHinhDang.SelectedIndex = 0;
                cboChatLieu.SelectedIndex = 0;
                cboMauSac.SelectedIndex = 0;
                cboNuocSX.SelectedIndex = 0;
                cboNhaSX.SelectedIndex = 0;
                cboCongDung.SelectedIndex = 0;
                cboDacDiem.SelectedIndex = 0;
                txtTuKhoa.Focus();
            }
            finally
            {
                dangTaiDuLieu = false;
            }

            ThucHienTimKiem();
        }

        private void picAnh_Click(object sender, EventArgs e)
        {
            if (picAnh.Image == null)
            {
                return;
            }

            string tieuDe = "Xem ảnh sản phẩm";
            if (dgvKetQua.CurrentRow != null && dgvKetQua.CurrentRow.Index >= 0)
            {
                string ma = dgvKetQua.CurrentRow.Cells["colMaHang"].Value?.ToString();
                string ten = dgvKetQua.CurrentRow.Cells["colTenHang"].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(ma))
                {
                    tieuDe = string.Format("Ảnh sản phẩm: {0} - {1}", ma, ten);
                }
            }

            using (frmXemAnh frm = new frmXemAnh(picAnh.Image, tieuDe))
            {
                frm.ShowDialog(this);
            }
        }

        private void dgvKetQua_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKetQua.SelectedRows.Count == 0 && dgvKetQua.SelectedCells.Count == 0)
            {
                HienThiAnhSanPham(null);
                return;
            }
            CapNhatAnhTheoDongChon();
        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CapNhatAnhTheoDongChon();
            }
        }

        private void CapNhatAnhTheoDongChon()
        {
            if (dgvKetQua.CurrentRow != null && dgvKetQua.CurrentRow.Index >= 0 && (dgvKetQua.SelectedRows.Count > 0 || dgvKetQua.SelectedCells.Count > 0))
            {
                DataRowView drv = dgvKetQua.CurrentRow.DataBoundItem as DataRowView;
                if (drv != null && drv.Row.Table.Columns.Contains("anh"))
                {
                    string tenAnh = drv["anh"]?.ToString();
                    HienThiAnhSanPham(tenAnh);
                    return;
                }
            }

            HienThiAnhSanPham(null);
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
    }
}
