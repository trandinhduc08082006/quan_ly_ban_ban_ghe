using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanBanGhe.DAL
{
    public class TimKiemDAL
    {
        public DataTable TimKiemHangHoa(
            string tuKhoa,
            string maLoai,
            string maKichThuoc,
            string maHinhDang,
            string maChatLieu,
            string maNuocSX,
            string maMau,
            string maNhaSX,
            string maCongDung,
            string maDacDiem)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tu_khoa", string.IsNullOrWhiteSpace(tuKhoa) ? (object)DBNull.Value : tuKhoa.Trim()),
                new SqlParameter("@ma_loai", string.IsNullOrWhiteSpace(maLoai) ? (object)DBNull.Value : maLoai.Trim()),
                new SqlParameter("@ma_kich_thuoc", string.IsNullOrWhiteSpace(maKichThuoc) ? (object)DBNull.Value : maKichThuoc.Trim()),
                new SqlParameter("@ma_hinh_dang", string.IsNullOrWhiteSpace(maHinhDang) ? (object)DBNull.Value : maHinhDang.Trim()),
                new SqlParameter("@ma_chat_lieu", string.IsNullOrWhiteSpace(maChatLieu) ? (object)DBNull.Value : maChatLieu.Trim()),
                new SqlParameter("@ma_nuoc_san_xuat", string.IsNullOrWhiteSpace(maNuocSX) ? (object)DBNull.Value : maNuocSX.Trim()),
                new SqlParameter("@ma_mau", string.IsNullOrWhiteSpace(maMau) ? (object)DBNull.Value : maMau.Trim()),
                new SqlParameter("@ma_nha_san_xuat", string.IsNullOrWhiteSpace(maNhaSX) ? (object)DBNull.Value : maNhaSX.Trim()),
                new SqlParameter("@ma_cong_dung", string.IsNullOrWhiteSpace(maCongDung) ? (object)DBNull.Value : maCongDung.Trim()),
                new SqlParameter("@ma_dac_diem", string.IsNullOrWhiteSpace(maDacDiem) ? (object)DBNull.Value : maDacDiem.Trim())
            };

            return DatabaseHelper.ExecuteReaderSP("sp_TimKiem_HangHoa", parameters);
        }

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
