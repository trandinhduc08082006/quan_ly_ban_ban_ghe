namespace QuanLyBanBanGhe.GUI.Helpers
{
    public static class UserSession
    {
        public static string TenDangNhap { get; set; }
        public static string Quyen { get; set; }
        public static string MaNhanVien { get; set; }
        public static string TenNhanVien { get; set; }
        public static bool IsLoggingOut { get; set; }

        public static string MaNV
        {
            get => MaNhanVien;
            set => MaNhanVien = value;
        }

        public static string TenNV
        {
            get => TenNhanVien;
            set => TenNhanVien = value;
        }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(TenDangNhap);

        public static void Login(string tenDangNhap, string quyen, string maNV, string tenNV)
        {
            TenDangNhap = tenDangNhap;
            Quyen = quyen;
            MaNhanVien = maNV;
            TenNhanVien = tenNV;
        }

        public static void Clear()
        {
            TenDangNhap = null;
            Quyen = null;
            MaNhanVien = null;
            TenNhanVien = null;
        }
    }
}
