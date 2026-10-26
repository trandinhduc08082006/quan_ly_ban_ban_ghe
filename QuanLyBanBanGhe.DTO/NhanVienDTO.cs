using System;

namespace QuanLyBanBanGhe.DTO
{
    public class NhanVienDTO
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public bool TrangThaiXoa { get; set; }
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
