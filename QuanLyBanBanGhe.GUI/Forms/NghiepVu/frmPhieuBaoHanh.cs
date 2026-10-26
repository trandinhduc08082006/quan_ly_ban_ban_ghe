using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.DTO;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.NghiepVu
{
    public partial class frmPhieuBaoHanh : Form
    {
        private readonly PhieuBaoHanhBLL bll;
        private FormMode currentMode;
        private Button btnKhoiPhuc;
        private ComboBox cboLocTrangThai;
        private Label lblLocTrangThai;
        private string maKhachHienTai = string.Empty;
        private string maNVHienTai = string.Empty;
        private DataTable dtTatCaHoaDon;
        private bool dangXuLyChon;

        public frmPhieuBaoHanh()
        {
            InitializeComponent();
            bll = new PhieuBaoHanhBLL();
        }

        private void frmPhieuBaoHanh_Load(object sender, EventArgs e)
        {
            dgvPhieuBaoHanh.AutoGenerateColumns = false;
            dgvPhieuBaoHanh.CellFormatting += dgvPhieuBaoHanh_CellFormatting;
            UIHelper.GanXoaChonTuDong(dgvPhieuBaoHanh);
            UIHelper.FormatDateTimeColumns(dgvPhieuBaoHanh, "colNgayTiepNhan");
            UIHelper.FormatDateColumns(dgvPhieuBaoHanh, "colNgayHenTra", "colNgayTraThucTe", "colHanBaoHanh");
            UIHelper.FormatCurrencyColumns(dgvPhieuBaoHanh, "colChiPhi");

            cboHangHoa.DropDownWidth = 400;
            cboKhachHang.DropDownWidth = 350;

            txtChiPhi.KeyPress += (s, ev) => UIHelper.ChiChoPhepNhapSo(ev);

            dtpNgayTiepNhan.ValueChanged += (s, ev) =>
            {
                if (dtpNgayTiepNhan.CustomFormat == " ")
                {
                    dtpNgayTiepNhan.CustomFormat = "dd/MM/yyyy HH:mm";
                }
            };

            dtpNgayHenTra.ValueChanged += (s, ev) =>
            {
                if (chkCoNgayHen.Checked && dtpNgayHenTra.CustomFormat == " ")
                {
                    dtpNgayHenTra.CustomFormat = "dd/MM/yyyy";
                }
            };

            dtpNgayTraThucTe.ValueChanged += (s, ev) =>
            {
                if (chkCoNgayTra.Checked && dtpNgayTraThucTe.CustomFormat == " ")
                {
                    dtpNgayTraThucTe.CustomFormat = "dd/MM/yyyy";
                }
            };

            KhoiTaoComboBoxTrangThai();
            KhoiTaoBoLocTrangThai();
            LoadDanhSachHoaDon();
            LoadDanhSach();
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvPhieuBaoHanh);
        }

        private void KhoiTaoComboBoxTrangThai()
        {
            DataTable dtTrangThai = new DataTable();
            dtTrangThai.Columns.Add("GiaTri", typeof(string));
            dtTrangThai.Columns.Add("HienThi", typeof(string));

            dtTrangThai.Rows.Add("TiepNhan", "Tiếp nhận");
            dtTrangThai.Rows.Add("DangXuLy", "Đang xử lý");
            dtTrangThai.Rows.Add("DaXong", "Đã sửa xong");
            dtTrangThai.Rows.Add("DaTra", "Đã trả khách");
            dtTrangThai.Rows.Add("TuChoi", "Từ chối bảo hành");

            cboTrangThai.DataSource = dtTrangThai;
            cboTrangThai.DisplayMember = "HienThi";
            cboTrangThai.ValueMember = "GiaTri";
        }

        private void KhoiTaoBoLocTrangThai()
        {
            btnKhoiPhuc = new Button
            {
                Name = "btnKhoiPhuc",
                Text = "Khôi phục",
                Size = new Size(80, 32),
                Margin = new Padding(0, 0, 6, 0),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = true,
                Visible = false,
                Enabled = false
            };
            btnKhoiPhuc.Click += btnKhoiPhuc_Click;

            lblLocTrangThai = new Label
            {
                Name = "lblLocTrangThai",
                Text = "Xem:",
                Size = new Size(40, 32),
                Margin = new Padding(6, 0, 4, 0),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Visible = true
            };

            cboLocTrangThai = new ComboBox
            {
                Name = "cboLocTrangThai",
                DropDownStyle = ComboBoxStyle.DropDownList,
                Size = new Size(120, 25),
                Margin = new Padding(0, 4, 6, 0),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Visible = true
            };

            cboLocTrangThai.Items.Add("Đang hoạt động");
            cboLocTrangThai.Items.Add("Đã xóa");
            cboLocTrangThai.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndexChanged += cboLocTrangThai_SelectedIndexChanged;

            flpNut.Controls.Add(btnKhoiPhuc);
            flpNut.Controls.Add(lblLocTrangThai);
            flpNut.Controls.Add(cboLocTrangThai);
        }

        private void LoadDanhSachHoaDon()
        {
            dtTatCaHoaDon = bll.LayDanhSachHoaDonHopLe();
            NapDanhSachKhachHang(dtTatCaHoaDon);
            NapDanhSachHoaDon(dtTatCaHoaDon);
        }

        private void NapDanhSachKhachHang(DataTable dtNguon)
        {
            if (dtNguon == null || dtNguon.Rows.Count == 0)
            {
                cboKhachHang.DataSource = null;
                return;
            }

            DataView dv = new DataView(dtNguon);
            DataTable dtKhach = dv.ToTable(true, "ma_khach", "ten_khach", "dien_thoai");
            if (!dtKhach.Columns.Contains("hien_thi"))
            {
                dtKhach.Columns.Add("hien_thi", typeof(string));
                foreach (DataRow r in dtKhach.Rows)
                {
                    r["hien_thi"] = string.Format("{0} - {1}", r["ten_khach"], r["dien_thoai"]);
                }
            }

            cboKhachHang.DataSource = dtKhach;
            cboKhachHang.DisplayMember = "hien_thi";
            cboKhachHang.ValueMember = "ma_khach";
            cboKhachHang.SelectedIndex = -1;
        }

        private void NapDanhSachHoaDon(DataTable dtNguon)
        {
            if (dtNguon == null || dtNguon.Rows.Count == 0)
            {
                cboSoHDB.DataSource = null;
                return;
            }

            DataView dv = new DataView(dtNguon);
            DataTable dtHDB = dv.ToTable(true, "so_hoa_don_ban", "ma_khach");
            cboSoHDB.DataSource = dtHDB;
            cboSoHDB.DisplayMember = "so_hoa_don_ban";
            cboSoHDB.ValueMember = "so_hoa_don_ban";
            cboSoHDB.SelectedIndex = -1;
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangXuLyChon)
            {
                return;
            }

            if (cboKhachHang.SelectedIndex == -1 || cboKhachHang.SelectedValue == null)
            {
                maKhachHienTai = string.Empty;
                return;
            }

            maKhachHienTai = cboKhachHang.SelectedValue.ToString();
            if (dtTatCaHoaDon == null)
            {
                return;
            }

            dangXuLyChon = true;
            try
            {
                DataView dv = new DataView(dtTatCaHoaDon);
                dv.RowFilter = string.Format("ma_khach = '{0}'", maKhachHienTai.Replace("'", "''"));
                DataTable dtHDB = dv.ToTable(true, "so_hoa_don_ban", "ma_khach");
                cboSoHDB.DataSource = dtHDB;
                cboSoHDB.DisplayMember = "so_hoa_don_ban";
                cboSoHDB.ValueMember = "so_hoa_don_ban";

                if (dtHDB.Rows.Count > 0)
                {
                    cboSoHDB.SelectedIndex = 0;
                    string soHDB = dtHDB.Rows[0]["so_hoa_don_ban"].ToString();
                    TaiDanhSachSanPham(soHDB);
                }
                else
                {
                    cboSoHDB.SelectedIndex = -1;
                    cboHangHoa.DataSource = null;
                    lblTrangThaiHanBH.Text = string.Empty;
                }
            }
            finally
            {
                dangXuLyChon = false;
            }
        }

        private void cboSoHDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangXuLyChon)
            {
                return;
            }

            if (cboSoHDB.SelectedIndex == -1 || cboSoHDB.SelectedValue == null)
            {
                cboHangHoa.DataSource = null;
                lblTrangThaiHanBH.Text = string.Empty;
                return;
            }

            string soHDB = cboSoHDB.SelectedValue.ToString();

            dangXuLyChon = true;
            try
            {
                if (dtTatCaHoaDon != null)
                {
                    DataRow[] rows = dtTatCaHoaDon.Select(string.Format("so_hoa_don_ban = '{0}'", soHDB.Replace("'", "''")));
                    if (rows.Length > 0)
                    {
                        string maKhach = rows[0]["ma_khach"].ToString();
                        maKhachHienTai = maKhach;
                        cboKhachHang.SelectedValue = maKhach;
                    }
                }
                TaiDanhSachSanPham(soHDB);
            }
            finally
            {
                dangXuLyChon = false;
            }
        }

        private void TaiDanhSachSanPham(string soHDB)
        {
            if (string.IsNullOrWhiteSpace(soHDB))
            {
                cboHangHoa.DataSource = null;
                lblTrangThaiHanBH.Text = string.Empty;
                return;
            }

            DataTable dtHang = bll.LayDanhSachHangHoaTheoHoaDon(soHDB);
            if (dtHang != null && dtHang.Rows.Count > 0)
            {
                cboHangHoa.DataSource = dtHang;
                cboHangHoa.DisplayMember = "ten_hang_hoa";
                cboHangHoa.ValueMember = "ma_hang";
                cboHangHoa.SelectedIndex = 0;
            }
            else
            {
                cboHangHoa.DataSource = null;
                lblTrangThaiHanBH.Text = string.Empty;
            }
        }

        private void txtTimNhanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucHienTimNhanh();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnTimNhanh_Click(object sender, EventArgs e)
        {
            ThucHienTimNhanh();
        }

        private void ThucHienTimNhanh()
        {
            string tuKhoa = txtTimNhanh.Text.Trim();
            if (dtTatCaHoaDon == null || dtTatCaHoaDon.Rows.Count == 0)
            {
                LoadDanhSachHoaDon();
                if (dtTatCaHoaDon == null || dtTatCaHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn bán trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                NapDanhSachKhachHang(dtTatCaHoaDon);
                NapDanhSachHoaDon(dtTatCaHoaDon);
                cboKhachHang.SelectedIndex = -1;
                cboSoHDB.SelectedIndex = -1;
                cboHangHoa.DataSource = null;
                lblTrangThaiHanBH.Text = string.Empty;
                return;
            }

            string safe = tuKhoa.Replace("'", "''");

            DataView dvHDB = new DataView(dtTatCaHoaDon);
            dvHDB.RowFilter = string.Format("so_hoa_don_ban LIKE '%{0}%'", safe);
            DataTable dtHDBFiltered = dvHDB.ToTable();

            DataView dvKhach = new DataView(dtTatCaHoaDon);
            dvKhach.RowFilter = string.Format("ten_khach LIKE '%{0}%' OR dien_thoai LIKE '%{0}%'", safe);
            DataTable dtKhachFiltered = dvKhach.ToTable();

            if (dtHDBFiltered.Rows.Count == 0 && dtKhachFiltered.Rows.Count == 0)
            {
                MessageBox.Show(string.Format("Không tìm thấy kết quả nào phù hợp với từ khóa '{0}'!\n(Vui lòng thử tìm theo số HĐ, tên khách hoặc số điện thoại)", tuKhoa), "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dangXuLyChon = true;
            try
            {
                if (dtKhachFiltered.Rows.Count > 0 && dtHDBFiltered.Rows.Count == 0)
                {
                    NapDanhSachKhachHang(dtKhachFiltered);
                    cboKhachHang.SelectedIndex = 0;
                    string maKhach = cboKhachHang.SelectedValue.ToString();
                    maKhachHienTai = maKhach;

                    DataView dvHDBTheoKhach = new DataView(dtTatCaHoaDon);
                    dvHDBTheoKhach.RowFilter = string.Format("ma_khach = '{0}'", maKhach.Replace("'", "''"));
                    DataTable dtHDB = dvHDBTheoKhach.ToTable(true, "so_hoa_don_ban", "ma_khach");
                    cboSoHDB.DataSource = dtHDB;
                    cboSoHDB.DisplayMember = "so_hoa_don_ban";
                    cboSoHDB.ValueMember = "so_hoa_don_ban";
                    if (dtHDB.Rows.Count > 0)
                    {
                        cboSoHDB.SelectedIndex = 0;
                        string soHDB = dtHDB.Rows[0]["so_hoa_don_ban"].ToString();
                        TaiDanhSachSanPham(soHDB);
                    }
                }
                else if (dtHDBFiltered.Rows.Count > 0)
                {
                    DataTable dtHDB = dtHDBFiltered.DefaultView.ToTable(true, "so_hoa_don_ban", "ma_khach");
                    cboSoHDB.DataSource = dtHDB;
                    cboSoHDB.DisplayMember = "so_hoa_don_ban";
                    cboSoHDB.ValueMember = "so_hoa_don_ban";
                    cboSoHDB.SelectedIndex = 0;

                    string soHDB = dtHDB.Rows[0]["so_hoa_don_ban"].ToString();
                    string maKhach = dtHDB.Rows[0]["ma_khach"].ToString();
                    maKhachHienTai = maKhach;

                    NapDanhSachKhachHang(dtTatCaHoaDon);
                    cboKhachHang.SelectedValue = maKhach;

                    TaiDanhSachSanPham(soHDB);
                }
            }
            finally
            {
                dangXuLyChon = false;
            }
        }

        private void LoadDanhSach()
        {
            bool xemDaXoa = cboLocTrangThai != null && cboLocTrangThai.SelectedIndex == 1;
            DataTable dt = bll.LayTatCa(xemDaXoa);
            dgvPhieuBaoHanh.DataSource = dt;
        }

        private void ThietLapTrangThai(FormMode mode)
        {
            currentMode = mode;
            bool xemDaXoa = cboLocTrangThai != null && cboLocTrangThai.SelectedIndex == 1;

            if (xemDaXoa)
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnLuu.Visible = false;
                btnBoQua.Visible = false;
                btnKhoiPhuc.Visible = true;
                btnKhoiPhuc.Enabled = (mode == FormMode.Selected);
                MoKhoaNhapLieu(false);
                return;
            }

            btnKhoiPhuc.Visible = false;
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnLuu.Visible = true;
            btnBoQua.Visible = true;
            btnXoa.Visible = true;

            UIHelper.SetButtonState(mode, btnThem, btnSua, btnXoa, btnLuu, btnBoQua);

            switch (mode)
            {
                case FormMode.View:
                case FormMode.Selected:
                    MoKhoaNhapLieu(false);
                    break;
                case FormMode.Insert:
                case FormMode.Update:
                    MoKhoaNhapLieu(true);
                    break;
            }
        }

        private void MoKhoaNhapLieu(bool moKhoa)
        {
            txtTimNhanh.Enabled = moKhoa && currentMode == FormMode.Insert;
            btnTimNhanh.Enabled = moKhoa && currentMode == FormMode.Insert;
            cboKhachHang.Enabled = moKhoa && currentMode == FormMode.Insert;
            cboSoHDB.Enabled = moKhoa && currentMode == FormMode.Insert;
            cboHangHoa.Enabled = moKhoa && currentMode == FormMode.Insert;
            dtpNgayTiepNhan.Enabled = false;
            chkCoNgayHen.Enabled = moKhoa;
            dtpNgayHenTra.Enabled = moKhoa && chkCoNgayHen.Checked;
            chkCoNgayTra.Enabled = moKhoa;
            dtpNgayTraThucTe.Enabled = moKhoa && chkCoNgayTra.Checked;
            cboTrangThai.Enabled = moKhoa;
            txtChiPhi.ReadOnly = !moKhoa;
            txtMoTaLoi.ReadOnly = !moKhoa;
            txtBienPhapXuLy.ReadOnly = !moKhoa;
            txtGhiChu.ReadOnly = !moKhoa;
        }

        private void XoaTrang()
        {
            dangXuLyChon = true;
            try
            {
                txtMaPhieu.Clear();
                txtTimNhanh.Clear();
                cboKhachHang.SelectedIndex = -1;
                cboSoHDB.SelectedIndex = -1;
                cboHangHoa.DataSource = null;
                txtNhanVien.Clear();
                maKhachHienTai = string.Empty;
                maNVHienTai = string.Empty;
                dtpNgayTiepNhan.CustomFormat = " ";
                chkCoNgayHen.Checked = false;
                dtpNgayHenTra.CustomFormat = " ";
                dtpNgayHenTra.Enabled = false;
                chkCoNgayTra.Checked = false;
                dtpNgayTraThucTe.CustomFormat = " ";
                dtpNgayTraThucTe.Enabled = false;
                cboTrangThai.SelectedIndex = -1;
                txtChiPhi.Clear();
                txtMoTaLoi.Clear();
                txtBienPhapXuLy.Clear();
                txtGhiChu.Clear();
                lblTrangThaiHanBH.Text = string.Empty;
            }
            finally
            {
                dangXuLyChon = false;
            }
        }

        private void cboHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHangHoa.SelectedIndex == -1 || cboHangHoa.SelectedItem == null)
            {
                lblTrangThaiHanBH.Text = string.Empty;
                return;
            }

            DataRowView row = cboHangHoa.SelectedItem as DataRowView;
            if (row != null)
            {
                if (row.Row.Table.Columns.Contains("han_bao_hanh") && row["han_bao_hanh"] != DBNull.Value)
                {
                    DateTime hanBH = Convert.ToDateTime(row["han_bao_hanh"]);
                    bool conHan = Convert.ToInt32(row["con_han_bao_hanh"]) == 1;

                    if (conHan)
                    {
                        lblTrangThaiHanBH.ForeColor = Color.Green;
                        lblTrangThaiHanBH.Text = string.Format("✓ Còn hạn BH (đến {0:dd/MM/yyyy})", hanBH);
                        if (currentMode == FormMode.Insert && (string.IsNullOrWhiteSpace(txtChiPhi.Text) || txtChiPhi.Text == "0"))
                        {
                            txtBienPhapXuLy.Text = "Bảo hành tiêu chuẩn chính hãng";
                        }
                    }
                    else
                    {
                        lblTrangThaiHanBH.ForeColor = Color.Red;
                        lblTrangThaiHanBH.Text = string.Format("✗ Hết hạn BH (hết ngày {0:dd/MM/yyyy})", hanBH);
                        if (currentMode == FormMode.Insert)
                        {
                            txtBienPhapXuLy.Text = "Sửa chữa dịch vụ ngoài bảo hành";
                        }
                    }
                }
            }
        }

        private void chkCoNgayHen_CheckedChanged(object sender, EventArgs e)
        {
            bool choPhep = (currentMode == FormMode.Insert || currentMode == FormMode.Update) && chkCoNgayHen.Checked;
            dtpNgayHenTra.Enabled = choPhep;
            if (chkCoNgayHen.Checked)
            {
                dtpNgayHenTra.CustomFormat = "dd/MM/yyyy";
            }
            else
            {
                dtpNgayHenTra.CustomFormat = " ";
            }
        }

        private void chkCoNgayTra_CheckedChanged(object sender, EventArgs e)
        {
            bool choPhep = (currentMode == FormMode.Insert || currentMode == FormMode.Update) && chkCoNgayTra.Checked;
            dtpNgayTraThucTe.Enabled = choPhep;
            if (chkCoNgayTra.Checked)
            {
                dtpNgayTraThucTe.CustomFormat = "dd/MM/yyyy";
            }
            else
            {
                dtpNgayTraThucTe.CustomFormat = " ";
            }
        }

        private void dgvPhieuBaoHanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPhieuBaoHanh.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvPhieuBaoHanh.Rows[e.RowIndex];
            txtMaPhieu.Text = row.Cells["colMaPhieu"].Value != null ? row.Cells["colMaPhieu"].Value.ToString() : string.Empty;
            txtTimNhanh.Clear();

            string soHDB = row.Cells["colSoHDB"].Value != null ? row.Cells["colSoHDB"].Value.ToString() : string.Empty;

            dangXuLyChon = true;
            try
            {
                NapDanhSachKhachHang(dtTatCaHoaDon);
                NapDanhSachHoaDon(dtTatCaHoaDon);
                cboSoHDB.SelectedValue = soHDB;

                string maHang = string.Empty;
                if (row.DataBoundItem is DataRowView drv)
                {
                    maHang = drv["ma_hang"].ToString();
                    maKhachHienTai = drv["ma_khach"].ToString();
                    maNVHienTai = drv["ma_nhan_vien"].ToString();

                    cboKhachHang.SelectedValue = maKhachHienTai;

                    TaiDanhSachSanPham(soHDB);
                    cboHangHoa.SelectedValue = maHang;

                    txtNhanVien.Text = drv["ten_nhan_vien"].ToString();

                    dtpNgayTiepNhan.CustomFormat = "dd/MM/yyyy HH:mm";
                    if (drv["ngay_tiep_nhan"] != DBNull.Value)
                    {
                        dtpNgayTiepNhan.Value = Convert.ToDateTime(drv["ngay_tiep_nhan"]);
                    }

                    if (drv["ngay_hen_tra"] != DBNull.Value)
                    {
                        chkCoNgayHen.Checked = true;
                        dtpNgayHenTra.CustomFormat = "dd/MM/yyyy";
                        dtpNgayHenTra.Value = Convert.ToDateTime(drv["ngay_hen_tra"]);
                    }
                    else
                    {
                        chkCoNgayHen.Checked = false;
                        dtpNgayHenTra.CustomFormat = " ";
                        dtpNgayHenTra.Enabled = false;
                    }

                    if (drv["ngay_tra_thuc_te"] != DBNull.Value)
                    {
                        chkCoNgayTra.Checked = true;
                        dtpNgayTraThucTe.CustomFormat = "dd/MM/yyyy";
                        dtpNgayTraThucTe.Value = Convert.ToDateTime(drv["ngay_tra_thuc_te"]);
                    }
                    else
                    {
                        chkCoNgayTra.Checked = false;
                        dtpNgayTraThucTe.CustomFormat = " ";
                        dtpNgayTraThucTe.Enabled = false;
                    }

                    cboTrangThai.SelectedValue = drv["trang_thai"].ToString();
                    txtChiPhi.Text = Convert.ToDecimal(drv["chi_phi"]).ToString("N0");
                    txtMoTaLoi.Text = drv["mo_ta_loi"].ToString();
                    txtBienPhapXuLy.Text = drv["bien_phap_xu_ly"] != DBNull.Value ? drv["bien_phap_xu_ly"].ToString() : string.Empty;
                    txtGhiChu.Text = drv["ghi_chu"] != DBNull.Value ? drv["ghi_chu"].ToString() : string.Empty;

                    if (drv["han_bao_hanh"] != DBNull.Value)
                    {
                        DateTime hanBH = Convert.ToDateTime(drv["han_bao_hanh"]);
                        bool conHan = Convert.ToInt32(drv["con_han_bao_hanh"]) == 1;
                        if (conHan)
                        {
                            lblTrangThaiHanBH.ForeColor = Color.Green;
                            lblTrangThaiHanBH.Text = string.Format("✓ Còn hạn BH (đến {0:dd/MM/yyyy})", hanBH);
                        }
                        else
                        {
                            lblTrangThaiHanBH.ForeColor = Color.Red;
                            lblTrangThaiHanBH.Text = string.Format("✗ Hết hạn BH (hết ngày {0:dd/MM/yyyy})", hanBH);
                        }
                    }
                }
            }
            finally
            {
                dangXuLyChon = false;
            }

            ThietLapTrangThai(FormMode.Selected);
        }

        private void dgvPhieuBaoHanh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvPhieuBaoHanh.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                string val = e.Value.ToString();
                switch (val)
                {
                    case "TiepNhan":
                        e.Value = "Tiếp nhận";
                        e.FormattingApplied = true;
                        break;
                    case "DangXuLy":
                        e.Value = "Đang xử lý";
                        e.FormattingApplied = true;
                        break;
                    case "DaXong":
                        e.Value = "Đã sửa xong";
                        e.FormattingApplied = true;
                        break;
                    case "DaTra":
                        e.Value = "Đã trả khách";
                        e.FormattingApplied = true;
                        break;
                    case "TuChoi":
                        e.Value = "Từ chối";
                        e.FormattingApplied = true;
                        break;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaTrang();
            txtMaPhieu.Text = bll.SinhMaMoi();
            maNVHienTai = UserSession.MaNhanVien ?? "NV0001";
            txtNhanVien.Text = UserSession.TenNhanVien ?? "Quản trị viên";
            dtpNgayTiepNhan.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayTiepNhan.Value = DateTime.Now;
            chkCoNgayHen.Checked = true;
            dtpNgayHenTra.CustomFormat = "dd/MM/yyyy";
            dtpNgayHenTra.Value = DateTime.Now.AddDays(5);
            chkCoNgayTra.Checked = false;
            dtpNgayTraThucTe.CustomFormat = " ";
            cboTrangThai.SelectedValue = "TiepNhan";
            txtChiPhi.Text = "0";
            ThietLapTrangThai(FormMode.Insert);
            txtTimNhanh.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu bảo hành cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ThietLapTrangThai(FormMode.Update);
            txtMoTaLoi.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu bảo hành cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show(string.Format("Bạn có chắc chắn muốn xóa phiếu bảo hành '{0}' không?", txtMaPhieu.Text.Trim()), "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (bll.XoaMem(txtMaPhieu.Text.Trim()))
                    {
                        MessageBox.Show("Xóa phiếu bảo hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSach();
                        XoaTrang();
                        ThietLapTrangThai(FormMode.View);
                        UIHelper.XoaChonLuoi(dgvPhieuBaoHanh);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null || cboKhachHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhachHang.Focus();
                return;
            }

            if (cboSoHDB.SelectedValue == null || cboSoHDB.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn số hóa đơn bán hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDB.Focus();
                return;
            }

            if (cboHangHoa.SelectedValue == null || cboHangHoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần bảo hành!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHangHoa.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMoTaLoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả lỗi sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMoTaLoi.Focus();
                return;
            }

            decimal chiPhi = 0;
            string chiPhiText = txtChiPhi.Text.Replace(",", "").Replace(".", "").Trim();
            if (!string.IsNullOrWhiteSpace(chiPhiText) && !decimal.TryParse(chiPhiText, out chiPhi))
            {
                MessageBox.Show("Chi phí bảo hành không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChiPhi.Focus();
                return;
            }

            string trangThai = cboTrangThai.SelectedValue != null ? cboTrangThai.SelectedValue.ToString() : "TiepNhan";
            DateTime ngayTiepNhan = dtpNgayTiepNhan.CustomFormat != " " ? dtpNgayTiepNhan.Value : DateTime.Now;
            DateTime? ngayHenTra = chkCoNgayHen.Checked && dtpNgayHenTra.CustomFormat != " " ? (DateTime?)dtpNgayHenTra.Value.Date : null;
            DateTime? ngayTraThucTe = chkCoNgayTra.Checked && dtpNgayTraThucTe.CustomFormat != " " ? (DateTime?)dtpNgayTraThucTe.Value.Date : null;

            PhieuBaoHanhDTO dto = new PhieuBaoHanhDTO
            {
                MaPhieuBaoHanh = txtMaPhieu.Text.Trim(),
                SoHoaDonBan = cboSoHDB.SelectedValue.ToString(),
                MaHang = cboHangHoa.SelectedValue.ToString(),
                MaKhach = cboKhachHang.SelectedValue.ToString(),
                MaNhanVien = string.IsNullOrWhiteSpace(maNVHienTai) ? (UserSession.MaNhanVien ?? "NV0001") : maNVHienTai,
                NgayTiepNhan = ngayTiepNhan,
                NgayHenTra = ngayHenTra,
                NgayTraThucTe = ngayTraThucTe,
                MoTaLoi = txtMoTaLoi.Text.Trim(),
                BienPhapXuLy = txtBienPhapXuLy.Text.Trim(),
                ChiPhi = chiPhi,
                TrangThai = trangThai,
                GhiChu = txtGhiChu.Text.Trim()
            };

            try
            {
                if (currentMode == FormMode.Insert)
                {
                    if (bll.Them(dto))
                    {
                        MessageBox.Show("Tiếp nhận phiếu bảo hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSach();
                        XoaTrang();
                        ThietLapTrangThai(FormMode.View);
                        UIHelper.XoaChonLuoi(dgvPhieuBaoHanh);
                    }
                }
                else if (currentMode == FormMode.Update)
                {
                    if (bll.Sua(dto))
                    {
                        MessageBox.Show("Cập nhật phiếu bảo hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSach();
                        XoaTrang();
                        ThietLapTrangThai(FormMode.View);
                        UIHelper.XoaChonLuoi(dgvPhieuBaoHanh);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvPhieuBaoHanh);
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu bảo hành cần khôi phục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show(string.Format("Bạn có chắc chắn muốn khôi phục phiếu bảo hành '{0}' hoạt động trở lại không?", txtMaPhieu.Text.Trim()), "Xác nhận khôi phục", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (bll.KhoiPhuc(txtMaPhieu.Text.Trim()))
                    {
                        MessageBox.Show("Khôi phục phiếu bảo hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSach();
                        XoaTrang();
                        ThietLapTrangThai(FormMode.View);
                        UIHelper.XoaChonLuoi(dgvPhieuBaoHanh);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi khôi phục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSach();
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvPhieuBaoHanh);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucHienTimKiem();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ThucHienTimKiem()
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            bool xemDaXoa = cboLocTrangThai != null && cboLocTrangThai.SelectedIndex == 1;
            DataTable dt = bll.TimKiem(tuKhoa, string.Empty, xemDaXoa);
            dgvPhieuBaoHanh.DataSource = dt;
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvPhieuBaoHanh);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDanhSachHoaDon();
            LoadDanhSach();
            XoaTrang();
            ThietLapTrangThai(FormMode.View);
            UIHelper.XoaChonLuoi(dgvPhieuBaoHanh);
        }
    }
}
