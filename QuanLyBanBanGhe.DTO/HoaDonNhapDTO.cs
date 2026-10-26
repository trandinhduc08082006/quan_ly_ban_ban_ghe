using System;

namespace QuanLyBanBanGhe.DTO
{
    public class HoaDonNhapDTO
    {
        public string SoHoaDonNhap { get; set; }
        public DateTime ThoiGianNhap { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThaiGiaoDich { get; set; }
        public string MaNhaCungCap { get; set; }
        public string MaNhanVien { get; set; }

        public string TenNhaCungCap { get; set; }
        public string TenNhanVien { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string GhiChu { get; set; }

        public string SoHDN
        {
            get => SoHoaDonNhap;
            set => SoHoaDonNhap = value;
        }

        public string MaNCC
        {
            get => MaNhaCungCap;
            set => MaNhaCungCap = value;
        }

        public string TenNCC
        {
            get => TenNhaCungCap;
            set => TenNhaCungCap = value;
        }

        public HoaDonNhapDTO()
        {
            ThoiGianNhap = DateTime.Now;
            TongTien = 0;
            TrangThaiGiaoDich = "HoanThanh";
        }
    }
}
