using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL.Interfaces
{
    public interface IHangHoaDAL
    {
        DataTable LayTatCaHangHoa(bool chiLayDangHoatDong = true);
        HangHoaDTO LayHangHoaTheoMa(string maHang);
        bool KiemTraTonTai(string maHang);
        bool KiemTraTonKho(string maHang, int soLuongCan);
        bool ThemHangHoa(HangHoaDTO hh);
        bool CapNhatHangHoa(HangHoaDTO hh);
        bool XoaMemHangHoa(string maHang);
        bool KhoiPhucHangHoa(string maHang);
        bool CapNhatTonKhoVaGia(string maHang, int soLuongThayDoi, decimal giaNhapMoi, SqlTransaction trans = null);
        bool CapNhatGiaBanVaTonKho(string maHang, decimal donGiaNhap, int soLuongThem);
        int LayTonKho(string maHang, SqlTransaction trans = null);
        DataTable LayKichThuocTheoLoai(string maLoai);
        string SinhMaHangHoaMoi();
        DataTable TimKiemHangHoa(string maHang, string tenHang, string maLoai, string maKichThuoc, string maChatLieu, string maMau, string maNuocSX, string maHinhDang, string maNhaSX, string maCongDung, string maDacDiem, bool chiLayDangHoatDong = true);
    }
}
