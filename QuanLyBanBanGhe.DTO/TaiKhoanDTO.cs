namespace QuanLyBanBanGhe.DTO
{
    public class TaiKhoanDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; }
        public bool TrangThaiHoatDong { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }

        public TaiKhoanDTO()
        {
            TrangThaiHoatDong = true;
        }
    }
}
