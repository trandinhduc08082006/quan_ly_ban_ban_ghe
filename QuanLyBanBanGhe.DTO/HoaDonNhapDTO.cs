using System;
using System.Collections.Generic;

namespace QuanLyBanBanGhe.DTO
{
    public class HoaDonNhapDTO : HoaDonBaseDTO
    {
        public string SoHoaDonNhap
        {
            get => SoHoaDon;
            set => SoHoaDon = value;
        }

        public DateTime ThoiGianNhap
        {
            get => ThoiGianGiaoDich;
            set => ThoiGianGiaoDich = value;
        }

        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }

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

        public List<ChiTietHDNhapDTO> ChiTietList { get; set; } = new List<ChiTietHDNhapDTO>();

        public HoaDonNhapDTO()
        {
            ThoiGianNhap = DateTime.Now;
            TongTien = 0;
            TrangThaiGiaoDich = "HoanThanh";
        }
    }
}
