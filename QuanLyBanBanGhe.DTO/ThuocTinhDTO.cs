namespace QuanLyBanBanGhe.DTO
{
    public class ThuocTinhDTO
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MaLoai { get; set; }

        public ThuocTinhDTO()
        {
        }

        public ThuocTinhDTO(string ma, string ten, string maLoai = null)
        {
            Ma = ma;
            Ten = ten;
            MaLoai = maLoai;
        }
    }
}
