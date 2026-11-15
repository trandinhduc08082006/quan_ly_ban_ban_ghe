using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class DoiTacDAL : BaseDAL, IDoiTacDAL
    {
        public DataTable LayDanhSachKhachHang(bool chiLayDangHoatDong = true)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_KhachHang_LayDanhSach", parameters);
        }

        public bool KiemTraTonTaiKhachHang(string maKhach)
        {
            return base.KiemTraTonTai("khach_hang", "ma_khach", maKhach);
        }

        public bool ThemKhachHang(KhachHangDTO kh)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", kh.MaKhach),
                new SqlParameter("@ten_khach", kh.TenKhach),
                new SqlParameter("@dia_chi", (object)kh.DiaChi ?? DBNull.Value),
                new SqlParameter("@dien_thoai", (object)kh.DienThoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_KhachHang_Them", parameters) > 0;
        }

        public bool CapNhatKhachHang(KhachHangDTO kh)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", kh.MaKhach),
                new SqlParameter("@ten_khach", kh.TenKhach),
                new SqlParameter("@dia_chi", (object)kh.DiaChi ?? DBNull.Value),
                new SqlParameter("@dien_thoai", (object)kh.DienThoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_KhachHang_CapNhat", parameters) > 0;
        }

        public bool XoaMemKhachHang(string maKhach)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", maKhach)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_KhachHang_XoaMem", parameters) > 0;
        }

        public int DemPhieuBaoHanhChuaHoanTat(string maKhach)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", maKhach)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalarSP("sp_KhachHang_DemPhieuBaoHanhChuaHoanTat", parameters));
        }

        public bool KhoiPhucKhachHang(string maKhach)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", maKhach)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_KhachHang_KhoiPhuc", parameters) > 0;
        }

        public bool KiemTraTrungSoDienThoaiKhachHang(string dienThoai, string maKhachBoQua = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@dien_thoai", dienThoai),
                new SqlParameter("@ma_khach", (object)maKhachBoQua ?? DBNull.Value)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalarSP("sp_KhachHang_KiemTraTrungSDT", parameters)) > 0;
        }

        public string LaySoDienThoaiKhachHang(string maKhach)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_khach", maKhach)
            };
            object result = DatabaseHelper.ExecuteScalarSP("sp_KhachHang_LaySDT", parameters);
            return result != null && result != DBNull.Value ? result.ToString().Trim() : string.Empty;
        }

        public DataTable LayDanhSachNhaCungCap(bool chiLayDangHoatDong = true)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_NhaCungCap_LayDanhSach", parameters);
        }

        public bool KiemTraTonTaiNhaCungCap(string maNCC)
        {
            return base.KiemTraTonTai("nha_cung_cap", "ma_nha_cung_cap", maNCC);
        }

        public bool ThemNhaCungCap(NhaCungCapDTO ncc)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nha_cung_cap", ncc.MaNhaCungCap),
                new SqlParameter("@ten_nha_cung_cap", ncc.TenNhaCungCap),
                new SqlParameter("@dia_chi", (object)ncc.DiaChi ?? DBNull.Value),
                new SqlParameter("@dien_thoai", (object)ncc.DienThoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_NhaCungCap_Them", parameters) > 0;
        }

        public bool CapNhatNhaCungCap(NhaCungCapDTO ncc)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nha_cung_cap", ncc.MaNhaCungCap),
                new SqlParameter("@ten_nha_cung_cap", ncc.TenNhaCungCap),
                new SqlParameter("@dia_chi", (object)ncc.DiaChi ?? DBNull.Value),
                new SqlParameter("@dien_thoai", (object)ncc.DienThoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_NhaCungCap_CapNhat", parameters) > 0;
        }

        public bool XoaMemNhaCungCap(string maNCC)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nha_cung_cap", maNCC)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_NhaCungCap_XoaMem", parameters) > 0;
        }

        public bool KhoiPhucNhaCungCap(string maNCC)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nha_cung_cap", maNCC)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_NhaCungCap_KhoiPhuc", parameters) > 0;
        }

        public string SinhMaKhachHangMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.khach_hang", "ma_khach", "KH");
        }

        public string SinhMaNhaCungCapMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.nha_cung_cap", "ma_nha_cung_cap", "NCC");
        }

        public DataTable TimKiemKhachHang(string maKhach, string tenKhach, string dienThoai, string diaChi, bool chiLayDangHoatDong = true)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1),
                new SqlParameter("@ma_khach", string.IsNullOrWhiteSpace(maKhach) ? (object)DBNull.Value : maKhach.Trim()),
                new SqlParameter("@ten_khach", string.IsNullOrWhiteSpace(tenKhach) ? (object)DBNull.Value : tenKhach.Trim()),
                new SqlParameter("@dien_thoai", string.IsNullOrWhiteSpace(dienThoai) ? (object)DBNull.Value : dienThoai.Trim()),
                new SqlParameter("@dia_chi", string.IsNullOrWhiteSpace(diaChi) ? (object)DBNull.Value : diaChi.Trim())
            };
            return DatabaseHelper.ExecuteReaderSP("sp_KhachHang_TimKiem", parameters);
        }

        public DataTable TimKiemNhaCungCap(string maNCC, string tenNCC, string dienThoai, string diaChi, bool chiLayDangHoatDong = true)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1),
                new SqlParameter("@ma_ncc", string.IsNullOrWhiteSpace(maNCC) ? (object)DBNull.Value : maNCC.Trim()),
                new SqlParameter("@ten_ncc", string.IsNullOrWhiteSpace(tenNCC) ? (object)DBNull.Value : tenNCC.Trim()),
                new SqlParameter("@dien_thoai", string.IsNullOrWhiteSpace(dienThoai) ? (object)DBNull.Value : dienThoai.Trim()),
                new SqlParameter("@dia_chi", string.IsNullOrWhiteSpace(diaChi) ? (object)DBNull.Value : diaChi.Trim())
            };
            return DatabaseHelper.ExecuteReaderSP("sp_NhaCungCap_TimKiem", parameters);
        }
    }
}
