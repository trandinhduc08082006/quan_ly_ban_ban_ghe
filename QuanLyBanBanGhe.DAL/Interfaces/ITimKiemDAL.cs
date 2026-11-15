using System;
using System.Data;

namespace QuanLyBanBanGhe.DAL.Interfaces
{
    public interface ITimKiemDAL
    {
        DataTable TimKiemHoaDonNhap(DateTime tuNgay, DateTime denNgay, string maNhanVien, string maNCC);
        DataTable TimKiemHoaDonBan(DateTime tuNgay, DateTime denNgay, string maNhanVien, string maKhach);
    }
}
