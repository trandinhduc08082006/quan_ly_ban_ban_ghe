namespace QuanLyBanBanGhe.DTO
{
    public class ChiTietHDBanDTO : ChiTietHoaDonBaseDTO
    {
        public string SoHoaDonBan { get; set; }

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
