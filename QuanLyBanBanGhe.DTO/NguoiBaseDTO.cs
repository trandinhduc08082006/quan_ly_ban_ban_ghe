namespace QuanLyBanBanGhe.DTO
{
    public abstract class NguoiBaseDTO
    {
        public virtual string MaDinhDanh { get; set; }
        public virtual string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public bool TrangThaiXoa { get; set; }

        public NguoiBaseDTO()
        {
            TrangThaiXoa = false;
        }
    }
}
