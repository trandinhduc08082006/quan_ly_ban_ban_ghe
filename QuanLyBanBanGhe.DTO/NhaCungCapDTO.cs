namespace QuanLyBanBanGhe.DTO
{
    public class NhaCungCapDTO
    {
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public bool TrangThaiXoa { get; set; }

        public NhaCungCapDTO()
        {
            TrangThaiXoa = false;
        }
    }
}
