using System;
using System.Collections.Generic;

namespace QuanLyBanBanGhe.DTO
{
    public class HoaDonBanDTO : HoaDonBaseDTO
    {
        public string SoHoaDonBan
        {
            get => SoHoaDon;
            set => SoHoaDon = value;
        }

        public DateTime ThoiGianBan
        {
            get => ThoiGianGiaoDich;
            set => ThoiGianGiaoDich = value;
        }

        public string MaKhach { get; set; }
        public string TenKhach { get; set; }

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

        public List<ChiTietHDBanDTO> ChiTietList { get; set; } = new List<ChiTietHDBanDTO>();

        public HoaDonBanDTO()
        {
            ThoiGianBan = DateTime.Now;
            TongTien = 0;
            TrangThaiGiaoDich = "HoanThanh";
        }
    }
}
