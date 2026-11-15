namespace QuanLyBanBanGhe.DTO
{
    public class NhaCungCapDTO : NguoiBaseDTO
    {
        public string MaNhaCungCap
        {
            get => MaDinhDanh;
            set => MaDinhDanh = value;
        }

        public string TenNhaCungCap
        {
            get => HoTen;
            set => HoTen = value;
        }

        public NhaCungCapDTO()
        {
            TrangThaiXoa = false;
        }
    }
}
