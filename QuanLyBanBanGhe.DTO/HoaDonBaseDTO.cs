using System;

namespace QuanLyBanBanGhe.DTO
{
    public abstract class HoaDonBaseDTO
    {
        public virtual string SoHoaDon { get; set; }
        public virtual DateTime ThoiGianGiaoDich { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThaiGiaoDich { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string GhiChu { get; set; }

        public HoaDonBaseDTO()
        {
            ThoiGianGiaoDich = DateTime.Now;
            TongTien = 0;
            TrangThaiGiaoDich = "HoanThanh";
        }
    }
}
