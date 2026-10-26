using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanBanGhe.GUI.Forms.BaoCao;
using QuanLyBanBanGhe.GUI.Forms.DanhMuc;
using QuanLyBanBanGhe.GUI.Forms.NghiepVu;
using QuanLyBanBanGhe.GUI.Forms.TimKiem;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI.Forms.HeThong
{
    public partial class frmMain : Form
    {
        private Form currentChildForm;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            CapNhatThongTinNguoiDung();
            ApDungPhanQuyen();
            HienThiManHinhChaoMung();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        public void OpenChildForm(Form childForm, string pageTitle, Button navButton = null)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            childForm.ActiveControl = null;
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (childForm != null && !childForm.IsDisposed)
                {
                    childForm.ActiveControl = null;
                }
            });
            lblTitle.Text = pageTitle;
            DatNutDieuHuongHienTai(navButton);
        }

        private void HienThiManHinhChaoMung()
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm = null;
            }

            pnlContent.Controls.Clear();
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ";
            DatNutDieuHuongHienTai(null);

            Panel pnlWelcome = new Panel();
            pnlWelcome.Dock = DockStyle.Fill;
            pnlWelcome.AutoScroll = true;

            Panel pnlCenter = new Panel();
            pnlCenter.Width = 780;
            pnlCenter.Height = 540;
            pnlCenter.Location = new Point(Math.Max(20, (pnlContent.ClientSize.Width - 780) / 2), 20);

            pnlWelcome.Resize += (s, args) =>
            {
                if (!pnlCenter.IsDisposed)
                {
                    pnlCenter.Location = new Point(Math.Max(20, (pnlWelcome.ClientSize.Width - pnlCenter.Width) / 2), 20);
                }
            };

            Label lblHeader = new Label();
            lblHeader.Text = "CHÀO MỪNG ĐẾN VỚI HỆ THỐNG QUẢN LÝ BÁN BÀN GHẾ";
            lblHeader.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblHeader.ForeColor = Color.DarkBlue;
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblHeader.Size = new Size(780, 40);
            lblHeader.Location = new Point(0, 10);

            Label lblSubHeader = new Label();
            lblSubHeader.Text = "Ứng dụng Quản lý Bán hàng, Nhập kho và Báo cáo Thống kê";
            lblSubHeader.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubHeader.ForeColor = SystemColors.GrayText;
            lblSubHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblSubHeader.Size = new Size(780, 25);
            lblSubHeader.Location = new Point(0, 52);

            GroupBox grpUser = new GroupBox();
            grpUser.Text = "Thông tin phiên làm việc hiện tại";
            grpUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            grpUser.Location = new Point(20, 90);
            grpUser.Size = new Size(740, 150);

            string roleDisplay = UserSession.Quyen;
            if (string.Equals(UserSession.Quyen, "QuanLy", StringComparison.OrdinalIgnoreCase))
            {
                roleDisplay = "Quản lý (Toàn quyền hệ thống)";
            }
            else if (string.Equals(UserSession.Quyen, "BanHang", StringComparison.OrdinalIgnoreCase))
            {
                roleDisplay = "Nhân viên bán hàng";
            }
            else if (string.Equals(UserSession.Quyen, "ThuKho", StringComparison.OrdinalIgnoreCase))
            {
                roleDisplay = "Thủ kho";
            }

            Label lblUserGreeting = new Label();
            lblUserGreeting.Text = string.Format("Xin chào, {0}!", UserSession.TenNhanVien ?? "Người dùng");
            lblUserGreeting.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUserGreeting.ForeColor = Color.FromArgb(0, 71, 160);
            lblUserGreeting.Location = new Point(20, 28);
            lblUserGreeting.Size = new Size(700, 25);

            Label lblAccount = new Label();
            lblAccount.Text = string.Format("Tài khoản đăng nhập: {0}", UserSession.TenDangNhap ?? "admin");
            lblAccount.Location = new Point(20, 60);
            lblAccount.Size = new Size(340, 22);

            Label lblCode = new Label();
            lblCode.Text = string.Format("Mã nhân viên: {0}", UserSession.MaNhanVien ?? "NV0001");
            lblCode.Location = new Point(380, 60);
            lblCode.Size = new Size(340, 22);

            Label lblRole = new Label();
            lblRole.Text = string.Format("Quyền hạn: {0}", roleDisplay);
            lblRole.Location = new Point(20, 90);
            lblRole.Size = new Size(340, 22);

            Label lblTime = new Label();
            lblTime.Text = string.Format("Thời gian đăng nhập: {0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
            lblTime.Location = new Point(380, 90);
            lblTime.Size = new Size(340, 22);

            Label lblStatusText = new Label();
            lblStatusText.Text = "Trạng thái hệ thống: Sẵn sàng làm việc";
            lblStatusText.ForeColor = Color.DarkGreen;
            lblStatusText.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatusText.Location = new Point(20, 118);
            lblStatusText.Size = new Size(700, 22);

            grpUser.Controls.Add(lblUserGreeting);
            grpUser.Controls.Add(lblAccount);
            grpUser.Controls.Add(lblCode);
            grpUser.Controls.Add(lblRole);
            grpUser.Controls.Add(lblTime);
            grpUser.Controls.Add(lblStatusText);

            GroupBox grpGuide = new GroupBox();
            grpGuide.Text = "Hướng dẫn bắt đầu làm việc";
            grpGuide.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            grpGuide.Location = new Point(20, 255);
            grpGuide.Size = new Size(740, 250);

            Label lblGuideIntro = new Label();
            lblGuideIntro.Text = "Vui lòng chọn một chức năng từ thanh điều hướng bên trái để bắt đầu phiên làm việc:";
            lblGuideIntro.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblGuideIntro.Location = new Point(20, 28);
            lblGuideIntro.Size = new Size(700, 25);

            Label lblGuideDetails = new Label();
            if (string.Equals(UserSession.Quyen, "BanHang", StringComparison.OrdinalIgnoreCase))
            {
                lblGuideDetails.Text = "• Bán hàng: Lập hóa đơn bán bàn ghế cho khách hàng, tự động tính tổng tiền và in hóa đơn Excel.\n\n• Khách hàng: Quản lý danh bạ khách hàng, thêm mới hoặc cập nhật thông tin khách hàng.\n\n• Tìm kiếm & Tra cứu: Tra cứu thông tin hàng hóa và xem lại các hóa đơn bán hàng đã lập.";
            }
            else if (string.Equals(UserSession.Quyen, "ThuKho", StringComparison.OrdinalIgnoreCase))
            {
                lblGuideDetails.Text = "• Nhập hàng: Lập hóa đơn nhập hàng từ nhà cung cấp, tự động tăng tồn kho và cập nhật giá nhập.\n\n• Hàng hóa: Khai báo sản phẩm bàn ghế mới (hệ thống tự động tính giá bán = 110% giá nhập) và quản lý số lượng tồn.\n\n• Nhà cung cấp & Tìm kiếm: Quản lý danh sách nhà cung ứng và tra cứu hóa đơn nhập hàng.";
            }
            else
            {
                lblGuideDetails.Text = "• Bán hàng & Nhập hàng: Lập hóa đơn xuất bán, nhập kho, quản lý giao dịch và in phiếu hóa đơn Excel.\n\n• Quản lý danh mục & hàng hóa: Quản lý 9 bảng thuộc tính, hàng hóa, đối tác khách hàng và nhà cung cấp.\n\n• Quản trị & Báo cáo: Quản lý nhân sự, tài khoản phân quyền và xem 4 tab báo cáo thống kê doanh thu.";
            }
            lblGuideDetails.Location = new Point(20, 58);
            lblGuideDetails.Size = new Size(700, 115);

            Label lblNote = new Label();
            lblNote.Text = "(Lưu ý: Màn hình chào mừng này chỉ xuất hiện khi vừa đăng nhập hệ thống. Khi bạn bấm chọn bất kỳ chức năng nào từ thanh điều hướng bên trái, màn hình của chức năng đó sẽ xuất hiện và màn hình chào mừng sẽ tự động đóng lại).";
            lblNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNote.ForeColor = SystemColors.GrayText;
            lblNote.Location = new Point(20, 185);
            lblNote.Size = new Size(700, 50);

            grpGuide.Controls.Add(lblGuideIntro);
            grpGuide.Controls.Add(lblGuideDetails);
            grpGuide.Controls.Add(lblNote);

            pnlCenter.Controls.Add(lblHeader);
            pnlCenter.Controls.Add(lblSubHeader);
            pnlCenter.Controls.Add(grpUser);
            pnlCenter.Controls.Add(grpGuide);

            pnlWelcome.Controls.Add(pnlCenter);
            pnlContent.Controls.Add(pnlWelcome);
        }

        private void DatNutDieuHuongHienTai(Button btnActive)
        {
            foreach (Control c in flpSidebarMenu.Controls)
            {
                if (c is Button btn && btn != btnNavDangXuat)
                {
                    if (btn == btnActive)
                    {
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else
                    {
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    }
                }
            }
        }

        public void CapNhatThongTinNguoiDung()
        {
            if (UserSession.IsLoggedIn)
            {
                string roleDisplay = UserSession.Quyen;
                if (string.Equals(UserSession.Quyen, "QuanLy", StringComparison.OrdinalIgnoreCase))
                {
                    roleDisplay = "Quản lý";
                }
                else if (string.Equals(UserSession.Quyen, "BanHang", StringComparison.OrdinalIgnoreCase))
                {
                    roleDisplay = "Bán hàng";
                }
                else if (string.Equals(UserSession.Quyen, "ThuKho", StringComparison.OrdinalIgnoreCase))
                {
                    roleDisplay = "Thủ kho";
                }

                lblUserInfo.Text = string.Format("Người dùng: {0} | Quyền: {1}", UserSession.TenNhanVien, roleDisplay);
                lblSessionInfo.Text = string.Format("Phiên làm việc: {0} ({1})", UserSession.TenDangNhap, roleDisplay);
                lblStatus.Text = string.Format("Đang đăng nhập: {0} - {1}", UserSession.MaNhanVien, UserSession.TenNhanVien);
            }
            else
            {
                lblUserInfo.Text = "Người dùng: Chưa đăng nhập";
                lblSessionInfo.Text = "Phiên làm việc: Chưa đăng nhập";
                lblStatus.Text = "Trạng thái: Sẵn sàng";
            }
        }

        public void ApDungPhanQuyen()
        {
            btnNavBanHang.Visible = true;
            btnNavBaoHanh.Visible = true;
            btnNavNhapHang.Visible = true;
            btnNavHangHoa.Visible = true;
            btnNavDanhMucChung.Visible = true;
            btnNavKhachHang.Visible = true;
            btnNavNhaCungCap.Visible = true;
            btnNavNhanVien.Visible = true;
            btnNavTimKiemHangHoa.Visible = true;
            btnNavTimKiemHDBan.Visible = true;
            btnNavTimKiemHDNhap.Visible = true;
            btnNavBaoCao.Visible = true;
            btnNavDoiMatKhau.Visible = true;
            btnNavDangXuat.Visible = true;

            if (string.Equals(UserSession.Quyen, "BanHang", StringComparison.OrdinalIgnoreCase))
            {
                btnNavHangHoa.Visible = false;
                btnNavTimKiemHDNhap.Visible = false;
                btnNavNhapHang.Visible = false;
                btnNavNhaCungCap.Visible = false;
                btnNavNhanVien.Visible = false;
                btnNavDanhMucChung.Visible = false;
                btnNavBaoCao.Visible = false;
            }
            else if (string.Equals(UserSession.Quyen, "ThuKho", StringComparison.OrdinalIgnoreCase))
            {
                btnNavBanHang.Visible = false;
                btnNavBaoHanh.Visible = false;
                btnNavKhachHang.Visible = false;
                btnNavNhanVien.Visible = false;
                btnNavBaoCao.Visible = false;
                btnNavTimKiemHDBan.Visible = false;
            }
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnNavBanHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoaDonBan(), "LẬP HÓA ĐƠN BÁN HÀNG", btnNavBanHang);
        }

        private void btnNavBaoHanh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPhieuBaoHanh(), "QUẢN LÝ TIẾP NHẬN VÀ XỬ LÝ PHIẾU BẢO HÀNH", btnNavBaoHanh);
        }

        private void btnNavNhapHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoaDonNhap(), "LẬP HÓA ĐƠN NHẬP HÀNG", btnNavNhapHang);
        }

        private void btnNavHangHoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHangHoa(), "QUẢN LÝ HÀNG HÓA", btnNavHangHoa);
        }

        private void btnNavDanhMucChung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDanhMucChung(), "DANH MỤC THUỘC TÍNH DÙNG CHUNG", btnNavDanhMucChung);
        }

        private void btnNavKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang(), "QUẢN LÝ KHÁCH HÀNG", btnNavKhachHang);
        }

        private void btnNavNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaCungCap(), "QUẢN LÝ NHÀ CUNG CẤP", btnNavNhaCungCap);
        }

        private void btnNavNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien(), "QUẢN LÝ NHÂN SỰ VÀ TÀI KHOẢN", btnNavNhanVien);
        }

        private void btnNavTimKiemHangHoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimKiemHangHoa(), "TÌM KIẾM HÀNG HÓA", btnNavTimKiemHangHoa);
        }

        private void btnNavTimKiemHDBan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimKiemHDBan(), "TÌM KIẾM HÓA ĐƠN BÁN", btnNavTimKiemHDBan);
        }

        private void btnNavTimKiemHDNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimKiemHDNhap(), "TÌM KIẾM HÓA ĐƠN NHẬP", btnNavTimKiemHDNhap);
        }

        private void btnNavBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBaoCaoThongKe(), "BÁO CÁO THỐNG KÊ", btnNavBaoCao);
        }

        private void btnNavDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (frmDoiMatKhau form = new frmDoiMatKhau())
            {
                form.ShowDialog(this);
            }
        }

        private void btnNavDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                UserSession.IsLoggingOut = true;
                UserSession.Clear();
                Close();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!UserSession.IsLoggingOut)
            {
                UserSession.Clear();
            }
        }
    }
}
