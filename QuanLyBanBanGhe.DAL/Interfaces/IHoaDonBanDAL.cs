using System;
using System.Collections.Generic;
using System.Data;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL.Interfaces
{
    public interface IHoaDonBanDAL
    {
        DataTable LayDanhSachHoaDonBan();
        DataTable LayDanhSachHoaDonBan(DateTime? tuNgay, DateTime? denNgay);
        DataTable LayChiTietHoaDonBan(string soHDB);
        DataTable LayHoaDonBanTheoMa(string soHDB);
        bool KiemTraTonTai(string soHDB);
        bool LuuHoaDonBan(HoaDonBanDTO hdb, List<ChiTietHDBanDTO> chiTietList);
        bool HuyHoaDonBan(string soHDB);
        bool HuyHoaDonBanHoanKho(string soHDB, string lyDoHuy = null);
        int DemSoPhieuBaoHanh(string soHDB);
    }
}
