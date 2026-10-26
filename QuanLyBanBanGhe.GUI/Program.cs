using System;
using System.Windows.Forms;
using QuanLyBanBanGhe.GUI.Forms.HeThong;
using QuanLyBanBanGhe.GUI.Helpers;

namespace QuanLyBanBanGhe.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (frmDangNhap login = new frmDangNhap())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }

                using (frmMain main = new frmMain())
                {
                    Application.Run(main);
                }

                if (UserSession.IsLoggingOut)
                {
                    UserSession.IsLoggingOut = false;
                    continue;
                }

                break;
            }
        }
    }
}
