using System.Data;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL.Interfaces
{
    public interface IDoiTacDAL
    {
        DataTable LayDanhSachKhachHang(bool chiLayDangHoatDong = true);
        bool KiemTraTonTaiKhachHang(string maKhach);
        bool ThemKhachHang(KhachHangDTO kh);
        bool CapNhatKhachHang(KhachHangDTO kh);
        bool XoaMemKhachHang(string maKhach);
        bool KhoiPhucKhachHang(string maKhach);
        int DemPhieuBaoHanhChuaHoanTat(string maKhach);
        bool KiemTraTrungSoDienThoaiKhachHang(string dienThoai, string maKhachBoQua = null);
        string LaySoDienThoaiKhachHang(string maKhach);
        string SinhMaKhachHangMoi();
        DataTable TimKiemKhachHang(string maKhach, string tenKhach, string dienThoai, string diaChi, bool chiLayDangHoatDong = true);
        DataTable LayDanhSachNhaCungCap(bool chiLayDangHoatDong = true);
        bool KiemTraTonTaiNhaCungCap(string maNCC);
        bool ThemNhaCungCap(NhaCungCapDTO ncc);
        bool CapNhatNhaCungCap(NhaCungCapDTO ncc);
        bool XoaMemNhaCungCap(string maNCC);
        bool KhoiPhucNhaCungCap(string maNCC);
        string SinhMaNhaCungCapMoi();
        DataTable TimKiemNhaCungCap(string maNCC, string tenNCC, string dienThoai, string diaChi, bool chiLayDangHoatDong = true);
    }
}
