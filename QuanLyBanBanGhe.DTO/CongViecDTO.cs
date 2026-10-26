namespace QuanLyBanBanGhe.DTO
{
    public class CongViecDTO
    {
        public string MaCongViec { get; set; }
        public string TenCongViec { get; set; }
        public decimal MucLuong { get; set; }
        public bool TrangThaiXoa { get; set; }

        public CongViecDTO()
        {
            MucLuong = 0;
            TrangThaiXoa = false;
        }
    }
}
