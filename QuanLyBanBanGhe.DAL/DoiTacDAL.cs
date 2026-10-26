using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class DoiTacDAL
    {
        public DataTable LayDanhSachKhachHang(bool chiLayDangHoatDong = true)
        {
            string sql = @"
SELECT ma_khach, ten_khach, dia_chi, dien_thoai, trang_thai_xoa 
FROM dbo.khach_hang 
WHERE trang_thai_xoa = @trang_thai_xoa 
ORDER BY ma_khach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public bool KiemTraTonTaiKhachHang(string maKhach)
        {
            string sql = "SELECT COUNT(1) FROM dbo.khach_hang WHERE ma_khach = @ma_khach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", maKhach)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool ThemKhachHang(KhachHangDTO kh)
        {
            string sql = @"
INSERT INTO dbo.khach_hang (ma_khach, ten_khach, dia_chi, dien_thoai, trang_thai_xoa)
VALUES (@ma_khach, @ten_khach, @dia_chi, @dien_thoai, 0)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", kh.MaKhach),
                new SqlParameter("@ten_khach", kh.TenKhach),
                new SqlParameter("@dia_chi", (object)kh.DiaChi ?? DBNull.Value),
                new SqlParameter("@dien_thoai", (object)kh.DienThoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhatKhachHang(KhachHangDTO kh)
        {
            string sql = @"
UPDATE dbo.khach_hang 
SET ten_khach = @ten_khach, 
    dia_chi = @dia_chi, 
    dien_thoai = @dien_thoai 
WHERE ma_khach = @ma_khach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", kh.MaKhach),
                new SqlParameter("@ten_khach", kh.TenKhach),
                new SqlParameter("@dia_chi", (object)kh.DiaChi ?? DBNull.Value),
                new SqlParameter("@dien_thoai", (object)kh.DienThoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool XoaMemKhachHang(string maKhach)
        {
            string sql = "UPDATE dbo.khach_hang SET trang_thai_xoa = 1 WHERE ma_khach = @ma_khach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", maKhach)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool KhoiPhucKhachHang(string maKhach)
        {
            string sql = "UPDATE dbo.khach_hang SET trang_thai_xoa = 0 WHERE ma_khach = @ma_khach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", maKhach)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public DataTable LayDanhSachNhaCungCap(bool chiLayDangHoatDong = true)
        {
            string sql = @"
SELECT ma_nha_cung_cap, ten_nha_cung_cap, dia_chi, dien_thoai, trang_thai_xoa 
FROM dbo.nha_cung_cap 
WHERE trang_thai_xoa = @trang_thai_xoa 
ORDER BY ma_nha_cung_cap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public bool KiemTraTonTaiNhaCungCap(string maNCC)
        {
            string sql = "SELECT COUNT(1) FROM dbo.nha_cung_cap WHERE ma_nha_cung_cap = @ma_nha_cung_cap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nha_cung_cap", maNCC)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool ThemNhaCungCap(NhaCungCapDTO ncc)
        {
            string sql = @"
INSERT INTO dbo.nha_cung_cap (ma_nha_cung_cap, ten_nha_cung_cap, dia_chi, dien_thoai, trang_thai_xoa)
VALUES (@ma_nha_cung_cap, @ten_nha_cung_cap, @dia_chi, @dien_thoai, 0)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nha_cung_cap", ncc.MaNhaCungCap),
                new SqlParameter("@ten_nha_cung_cap", ncc.TenNhaCungCap),
                new SqlParameter("@dia_chi", (object)ncc.DiaChi ?? DBNull.Value),
                new SqlParameter("@dien_thoai", (object)ncc.DienThoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhatNhaCungCap(NhaCungCapDTO ncc)
        {
            string sql = @"
UPDATE dbo.nha_cung_cap 
SET ten_nha_cung_cap = @ten_nha_cung_cap, 
    dia_chi = @dia_chi, 
    dien_thoai = @dien_thoai 
WHERE ma_nha_cung_cap = @ma_nha_cung_cap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nha_cung_cap", ncc.MaNhaCungCap),
                new SqlParameter("@ten_nha_cung_cap", ncc.TenNhaCungCap),
                new SqlParameter("@dia_chi", (object)ncc.DiaChi ?? DBNull.Value),
                new SqlParameter("@dien_thoai", (object)ncc.DienThoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool XoaMemNhaCungCap(string maNCC)
        {
            string sql = "UPDATE dbo.nha_cung_cap SET trang_thai_xoa = 1 WHERE ma_nha_cung_cap = @ma_nha_cung_cap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nha_cung_cap", maNCC)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool KhoiPhucNhaCungCap(string maNCC)
        {
            string sql = "UPDATE dbo.nha_cung_cap SET trang_thai_xoa = 0 WHERE ma_nha_cung_cap = @ma_nha_cung_cap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nha_cung_cap", maNCC)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public string SinhMaKhachHangMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.khach_hang", "ma_khach", "KH");
        }

        public string SinhMaNhaCungCapMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.nha_cung_cap", "ma_nha_cung_cap", "NCC");
        }
    }
}
