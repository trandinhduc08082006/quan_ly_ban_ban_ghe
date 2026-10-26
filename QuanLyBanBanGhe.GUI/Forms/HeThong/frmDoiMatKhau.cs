using System;
using System.Windows.Forms;
using QuanLyBanBanGhe.BLL;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.HeThong
{
    public partial class frmDoiMatKhau : Form
    {
        private readonly NhanSuBLL nhanSuBLL;

        public frmDoiMatKhau()
        {
            InitializeComponent();
            nhanSuBLL = new NhanSuBLL();
            txtMatKhauMoi.KeyPress += (s, ev) => UIHelper.KhongChoPhepKhoangTrang(ev);
            txtXacNhanMatKhau.KeyPress += (s, ev) => UIHelper.KhongChoPhepKhoangTrang(ev);
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            char ch = chkHienMatKhau.Checked ? '\0' : '*';
            txtMatKhauCu.PasswordChar = ch;
            txtMatKhauMoi.PasswordChar = ch;
            txtXacNhanMatKhau.PasswordChar = ch;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;

            if (string.IsNullOrEmpty(matKhauCu))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp với mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            try
            {
                nhanSuBLL.DoiMatKhau(UserSession.TenDangNhap, matKhauCu, matKhauMoi, xacNhanMatKhau);
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Clear();
                txtMatKhauMoi.Clear();
                txtXacNhanMatKhau.Clear();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.SelectAll();
                txtMatKhauMoi.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
