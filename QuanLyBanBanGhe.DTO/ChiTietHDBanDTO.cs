namespace QuanLyBanBanGhe.DTO
{
    public class ChiTietHDBanDTO
    {
        public string SoHoaDonBan { get; set; }
        public string MaHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }

        public string TenHangHoa { get; set; }

        public string SoHDB
        {
            get => SoHoaDonBan;
            set => SoHoaDonBan = value;
        }

        public ChiTietHDBanDTO()
        {
            SoLuong = 0;
            DonGia = 0;
            GiamGia = 0;
            ThanhTien = 0;
        }
    }
}
