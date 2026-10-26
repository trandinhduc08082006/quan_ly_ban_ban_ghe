namespace QuanLyBanBanGhe.DTO
{
    public class ChiTietHDNhapDTO
    {
        public string SoHoaDonNhap { get; set; }
        public string MaHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }

        public string TenHangHoa { get; set; }

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
