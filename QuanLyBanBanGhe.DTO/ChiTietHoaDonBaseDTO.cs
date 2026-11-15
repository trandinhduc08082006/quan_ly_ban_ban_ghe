namespace QuanLyBanBanGhe.DTO
{
    public abstract class ChiTietHoaDonBaseDTO
    {
        public string MaHang { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }

        public ChiTietHoaDonBaseDTO()
        {
            SoLuong = 0;
            DonGia = 0;
            GiamGia = 0;
            ThanhTien = 0;
        }
    }
}
