namespace QuanLyBanBanGhe.DTO
{
    public class HangHoaDTO
    {
        public string MaHang { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal DonGiaNhap { get; set; }
        public int? ThoiGianBaoHanh { get; set; }
        public string Anh { get; set; }
        public string GhiChu { get; set; }
        public bool TrangThaiXoa { get; set; }
        public string MaLoai { get; set; }
        public string MaMau { get; set; }
        public string MaCongDung { get; set; }
        public string MaChatLieu { get; set; }
        public string MaDacDiem { get; set; }
        public string MaHinhDang { get; set; }
        public string MaKichThuoc { get; set; }
        public string MaNhaSanXuat { get; set; }
        public string MaNuocSanXuat { get; set; }

        public string TenLoai { get; set; }
        public string TenMau { get; set; }
        public string TenCongDung { get; set; }
        public string TenChatLieu { get; set; }
        public string TenDacDiem { get; set; }
        public string TenHinhDang { get; set; }
        public string TenKichThuoc { get; set; }
        public string TenNhaSanXuat { get; set; }
        public string TenNuocSanXuat { get; set; }

        public HangHoaDTO()
        {
            SoLuong = 0;
            DonGiaNhap = 0;
            DonGiaBan = 0;
            TrangThaiXoa = false;
        }
    }
}
