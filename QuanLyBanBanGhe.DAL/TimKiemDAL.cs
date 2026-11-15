using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DAL.Interfaces;

namespace QuanLyBanBanGhe.DAL
{
    public class TimKiemDAL : BaseDAL, ITimKiemDAL
    {
        public DataTable TimKiemHoaDonNhap(DateTime tuNgay, DateTime denNgay, string maNhanVien, string maNCC)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tu_ngay", SqlDbType.Date) { Value = tuNgay.Date },
                new SqlParameter("@den_ngay", SqlDbType.Date) { Value = denNgay.Date },
                new SqlParameter("@ma_nhan_vien", string.IsNullOrWhiteSpace(maNhanVien) ? (object)DBNull.Value : maNhanVien.Trim()),
                new SqlParameter("@ma_nha_cung_cap", string.IsNullOrWhiteSpace(maNCC) ? (object)DBNull.Value : maNCC.Trim())
            };

            return DatabaseHelper.ExecuteReaderSP("sp_TimKiem_HoaDonNhap", parameters);
        }

        public DataTable TimKiemHoaDonBan(DateTime tuNgay, DateTime denNgay, string maNhanVien, string maKhach)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tu_ngay", SqlDbType.Date) { Value = tuNgay.Date },
                new SqlParameter("@den_ngay", SqlDbType.Date) { Value = denNgay.Date },
                new SqlParameter("@ma_nhan_vien", string.IsNullOrWhiteSpace(maNhanVien) ? (object)DBNull.Value : maNhanVien.Trim()),
                new SqlParameter("@ma_khach", string.IsNullOrWhiteSpace(maKhach) ? (object)DBNull.Value : maKhach.Trim())
            };

            return DatabaseHelper.ExecuteReaderSP("sp_TimKiem_HoaDonBan", parameters);
        }
    }
}
