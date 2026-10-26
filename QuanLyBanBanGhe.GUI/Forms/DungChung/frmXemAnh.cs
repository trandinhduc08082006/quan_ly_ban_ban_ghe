using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanBanGhe.GUI.Forms.DungChung
{
    public partial class frmXemAnh : Form
    {
        public frmXemAnh(Image anh, string tieuDe)
        {
            InitializeComponent();
            if (anh != null)
            {
                picAnh.Image = anh;
            }
            if (!string.IsNullOrWhiteSpace(tieuDe))
            {
                Text = tieuDe;
                lblTieuDe.Text = tieuDe;
            }
        }

        private void picAnh_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
