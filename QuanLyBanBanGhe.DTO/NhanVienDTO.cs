using System;

namespace QuanLyBanBanGhe.DTO
{
    public class NhanVienDTO : NguoiBaseDTO
    {
        public string MaNhanVien
        {
            get => MaDinhDanh;
            set => MaDinhDanh = value;
        }

        public string TenNhanVien
        {
            get => HoTen;
            set => HoTen = value;
        }

        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string MaCongViec { get; set; }
        public string TenCongViec { get; set; }
        public decimal? MucLuong { get; set; }
        public string TenDangNhap { get; set; }
        public string Quyen { get; set; }
        public bool? TrangThaiTaiKhoan { get; set; }

        public NhanVienDTO()
        {
            TrangThaiXoa = false;
        }
    }
}
