using System;
using System.Data.SqlClient;

namespace QuanLyBanBanGhe.DAL
{
    public abstract class BaseDAL
    {
        protected bool KiemTraTonTai(string tenBang, string tenCotKhoa, string giaTriKhoa)
        {
            string cleanTable = tenBang.Replace("dbo.", "");
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_bang", cleanTable),
                new SqlParameter("@ten_cot", tenCotKhoa),
                new SqlParameter("@gia_tri", giaTriKhoa)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalarSP("sp_TienIch_KiemTraTonTai", parameters)) > 0;
        }
    }
}
