using System;
using System.Collections.Generic;
using System.Data;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL.Interfaces
{
    public interface IHoaDonNhapDAL
    {
        DataTable LayDanhSachHoaDonNhap();
        DataTable LayDanhSachHoaDonNhap(DateTime? tuNgay, DateTime? denNgay);
        DataTable LayChiTietHoaDonNhap(string soHDN);
        DataTable LayHoaDonNhapTheoMa(string soHDN);
        bool KiemTraTonTai(string soHDN);
        bool LuuHoaDonNhap(HoaDonNhapDTO hdn, List<ChiTietHDNhapDTO> chiTietList);
        bool HuyHoaDonNhap(string soHDN);
        bool HuyHoaDonNhapKiemTraTon(string soHDN, string lyDoHuy = null);
    }
}
