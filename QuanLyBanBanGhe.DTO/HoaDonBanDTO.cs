using System;

namespace QuanLyBanBanGhe.DTO
{
    public class HoaDonBanDTO
    {
        public string SoHoaDonBan { get; set; }
        public DateTime ThoiGianBan { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThaiGiaoDich { get; set; }
        public string MaNhanVien { get; set; }
        public string MaKhach { get; set; }
        public string GhiChu { get; set; }

        public string TenNhanVien { get; set; }
        public string TenKhach { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }

        public string SoHDB
        {
            get => SoHoaDonBan;
            set => SoHoaDonBan = value;
        }

        public string TenKhachHang
        {
            get => TenKhach;
            set => TenKhach = value;
        }

        public HoaDonBanDTO()
        {
            ThoiGianBan = DateTime.Now;
            TongTien = 0;
            TrangThaiGiaoDich = "HoanThanh";
        }
    }
}
