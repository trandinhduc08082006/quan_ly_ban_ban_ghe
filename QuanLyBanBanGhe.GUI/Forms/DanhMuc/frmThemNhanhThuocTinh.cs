using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.GUI.Forms.DanhMuc
{
    public partial class frmThemNhanhThuocTinh : Form
    {
        private readonly string tenBang;
        private readonly string tieuDeThuocTinh;
        private readonly string maLoaiCoDinh;
        private readonly string tenLoaiCoDinh;
        private readonly ThuocTinhBLL thuocTinhBLL;

        public string MaVuaThem { get; private set; }
        public string TenVuaThem { get; private set; }

        public frmThemNhanhThuocTinh(string tenBang, string tieuDeThuocTinh, string maLoaiCoDinh = null, string tenLoaiCoDinh = null)
        {
            InitializeComponent();
            this.tenBang = tenBang;
            this.tieuDeThuocTinh = tieuDeThuocTinh;
            this.maLoaiCoDinh = maLoaiCoDinh;
            this.tenLoaiCoDinh = tenLoaiCoDinh;
            thuocTinhBLL = new ThuocTinhBLL();
        }

        private void frmThemNhanhThuocTinh_Load(object sender, EventArgs e)
        {
            Text = string.Format("Thêm nhanh {0}", tieuDeThuocTinh);
            lblTieuDe.Text = string.Format("THÊM NHANH {0}", tieuDeThuocTinh.ToUpper());
            lblTieuDe.ForeColor = Color.Black;
            lblTen.Text = string.Format("Tên {0}:", tieuDeThuocTinh.ToLower());

            try
            {
                txtMa.Text = thuocTinhBLL.SinhMaThuocTinhMoi(tenBang);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sinh mã tự động: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (tenBang == "kich_thuoc")
            {
                lblLoai.Visible = true;
                txtLoai.Visible = true;
                txtLoai.Text = !string.IsNullOrWhiteSpace(tenLoaiCoDinh) ? tenLoaiCoDinh : maLoaiCoDinh;
                txtLoai.ReadOnly = true;
            }
            else
            {
                lblLoai.Visible = false;
                txtLoai.Visible = false;
                lblTen.Location = new Point(25, 95);
                txtTen.Location = new Point(140, 92);
                btnLuu.Location = new Point(140, 145);
                btnHuy.Location = new Point(260, 145);
                ClientSize = new Size(410, 200);
            }

            txtTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show(string.Format("Vui lòng nhập tên {0}!", tieuDeThuocTinh.ToLower()), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }

            string ma = txtMa.Text.Trim();
            string maLoai = (tenBang == "kich_thuoc") ? maLoaiCoDinh : null;

            if (tenBang == "kich_thuoc" && string.IsNullOrWhiteSpace(maLoai))
            {
                MessageBox.Show("Loại bàn ghế không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThuocTinhDTO item = new ThuocTinhDTO(ma, ten, maLoai);

            try
            {
                thuocTinhBLL.Them(tenBang, item);
                MaVuaThem = item.Ma;
                TenVuaThem = item.Ten;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
