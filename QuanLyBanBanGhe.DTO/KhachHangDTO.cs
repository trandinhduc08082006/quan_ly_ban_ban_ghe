namespace QuanLyBanBanGhe.DTO
{
    public class KhachHangDTO
    {
        public string MaKhach { get; set; }
        public string TenKhach { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public bool TrangThaiXoa { get; set; }

        public KhachHangDTO()
        {
            TrangThaiXoa = false;
        }
    }
}
