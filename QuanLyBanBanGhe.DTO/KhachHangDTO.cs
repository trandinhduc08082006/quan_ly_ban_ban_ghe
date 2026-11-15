namespace QuanLyBanBanGhe.DTO
{
    public class KhachHangDTO : NguoiBaseDTO
    {
        public string MaKhach
        {
            get => MaDinhDanh;
            set => MaDinhDanh = value;
        }

        public string TenKhach
        {
            get => HoTen;
            set => HoTen = value;
        }

        public KhachHangDTO()
        {
            TrangThaiXoa = false;
        }
    }
}
