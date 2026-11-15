namespace QuanLyBanBanGhe.DTO
{
    public class ChiTietHDNhapDTO : ChiTietHoaDonBaseDTO
    {
        public string SoHoaDonNhap { get; set; }

        public string SoHDN
        {
            get => SoHoaDonNhap;
            set => SoHoaDonNhap = value;
        }

        public ChiTietHDNhapDTO()
        {
            SoLuong = 0;
            DonGia = 0;
            GiamGia = 0;
            ThanhTien = 0;
        }
    }
}
