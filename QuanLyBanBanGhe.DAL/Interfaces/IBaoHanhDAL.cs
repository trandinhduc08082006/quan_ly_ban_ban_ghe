using System.Data;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL.Interfaces
{
    public interface IBaoHanhDAL
    {
        DataTable LayTatCa(bool daXoa = false);
        DataTable LayDanhSach(bool daXoa = false);
        DataTable LayDanhSachPhieuBaoHanh();
        DataTable LayTheoMa(string maPhieu);
        DataTable LayDanhSachHoaDonHopLe();
        DataTable LayDanhSachHoaDonBanHoanThanh();
        DataTable LayDanhSachHangHoaTheoHoaDon(string soHDB);
        DataTable LayDanhSachHangHoaTheoHDB(string soHDB);
        bool KiemTraTonTai(string maPhieu);
        bool Them(PhieuBaoHanhDTO dto);
        bool TiepNhanBaoHanh(PhieuBaoHanhDTO phieu);
        bool Sua(PhieuBaoHanhDTO dto);
        bool CapNhatTrangThaiVaChiPhi(string maPhieu, string trangThaiMoi, decimal chiPhi, string ghiChu = null);
        bool XoaMem(string maPhieu);
        bool KhoiPhuc(string maPhieu);
        DataTable TimKiem(string tuKhoa, string trangThai, bool daXoa = false);
        string SinhMaPhieuBaoHanhMoi();
        string LayTrangThaiHoaDonBan(string soHDB);
    }
}
