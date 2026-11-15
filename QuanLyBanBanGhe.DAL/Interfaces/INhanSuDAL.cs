using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL.Interfaces
{
    public interface INhanSuDAL
    {
        DataTable LayDanhSachCongViec(bool chiLayDangHoatDong = true);
        bool ThemCongViec(CongViecDTO cv);
        bool SuaCongViec(CongViecDTO cv);
        bool XoaMemCongViec(string maCongViec);
        bool KhoiPhucCongViec(string maCongViec);
        CongViecDTO LayCongViecTheoMa(string maCongViec);
        bool KiemTraTonTaiCongViec(string maCongViec);
        bool KiemTraCongViecDangDuocSuDung(string maCongViec);
        bool KiemTraTrungTenCongViec(string tenCongViec, string maCongViecLoaiTru = null);
        string SinhMaCongViecTuDong();
        string SinhMaCongViecMoi();
        DataTable LayDanhSachNhanVien(bool chiLayDangHoatDong = true);
        bool KiemTraTonTaiNhanVien(string maNV);
        NhanVienDTO LayNhanVienTheoMa(string maNV);
        bool ThemNhanVien(NhanVienDTO nv);
        bool ThemNhanVien(NhanVienDTO nv, SqlTransaction trans);
        bool SuaNhanVien(NhanVienDTO nv);
        bool CapNhatNhanVien(NhanVienDTO nv, SqlTransaction trans = null);
        bool XoaMemNhanVien(string maNV);
        bool KhoiPhucNhanVien(string maNV);
        bool KiemTraTonTaiTaiKhoan(string tenDangNhap);
        bool KiemTraNhanVienCoTaiKhoan(string maNV);
        string LayTenDangNhapTheoMaNV(string maNV);
        bool ThemTaiKhoan(TaiKhoanDTO tk, SqlTransaction trans = null);
        bool CapNhatQuyenVaTrangThaiTaiKhoan(string tenDangNhap, string quyen, bool hoatDong, SqlTransaction trans = null);
        bool DoiTrangThaiTaiKhoan(string tenDangNhap, bool hoatDong);
        bool ResetMatKhau(string tenDangNhap, string matKhauBam, SqlTransaction trans = null);
        DataTable LayThongTinDangNhap(string tenDangNhap);
        string SinhMaNhanVienMoi();
        TaiKhoanDTO DangNhap(string tenDangNhap, string matKhauPlain);
        bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi);
    }
}
