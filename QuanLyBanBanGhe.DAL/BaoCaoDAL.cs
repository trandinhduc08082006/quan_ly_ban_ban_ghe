using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DAL.Interfaces;

namespace QuanLyBanBanGhe.DAL
{
    public class BaoCaoDAL : BaseDAL, IBaoCaoDAL
    {
        public DataTable BaoCaoTop10BanChay(int nam)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nam", nam)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_BaoCao_Top10BanChay", parameters);
        }

        public DataTable BaoCaoNhapHang(int? thang, int? quy, int nam, string maNV)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nam", nam),
                new SqlParameter("@thang", (object)thang ?? DBNull.Value),
                new SqlParameter("@quy", (object)quy ?? DBNull.Value),
                new SqlParameter("@ma_nhan_vien", string.IsNullOrWhiteSpace(maNV) ? (object)DBNull.Value : maNV.Trim())
            };
            return DatabaseHelper.ExecuteReaderSP("sp_BaoCao_NhapHangTheoThoiGian", parameters);
        }

        public DataTable BaoCaoNhapHangTheoQuy(int quy, int nam, string maNV)
        {
            return BaoCaoNhapHang(null, quy, nam, maNV);
        }

        public DataTable BaoCaoBanHang(int? thang, int? quy, int nam, string maNV)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nam", nam),
                new SqlParameter("@thang", (object)thang ?? DBNull.Value),
                new SqlParameter("@quy", (object)quy ?? DBNull.Value),
                new SqlParameter("@ma_nhan_vien", string.IsNullOrWhiteSpace(maNV) ? (object)DBNull.Value : maNV.Trim())
            };
            return DatabaseHelper.ExecuteReaderSP("sp_BaoCao_BanHangTheoThoiGian", parameters);
        }

        public DataTable BaoCaoDoanhThuTheoThang(int thang, int nam)
        {
            return BaoCaoBanHang(thang, null, nam, null);
        }

        public DataTable BaoCaoNhanVienDoanhSo0(int nam)
        {
            return NhanVienBanItTienNhat(nam, 1);
        }

        public DataTable BaoCaoTop10NhanVienDoanhSoThap(int nam)
        {
            return NhanVienBanItTienNhat(nam, 2);
        }

        public DataTable NhanVienBanItTienNhat(int nam, int cheDo = 1)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nam", nam),
                new SqlParameter("@che_do", cheDo)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_BaoCao_NhanVienBanItTienNhat", parameters);
        }
    }
}
