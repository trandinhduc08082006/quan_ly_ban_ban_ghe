using System.Data;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL.Interfaces
{
    public interface IThuocTinhDAL
    {
        string LayPrefix(string tenBang);
        string SinhMaThuocTinhMoi(string tenBang);
        DataTable LayDanhSach(string tenBang);
        bool KiemTraTonTai(string tenBang, string ma);
        bool KiemTraTrungTen(string tenBang, string ten, string maBoQua = null, string maLoai = null);
        bool KiemTraRangBuocKhoaNgoai(string tenBang, string ma);
        bool Them(string tenBang, ThuocTinhDTO item);
        bool Sua(string tenBang, ThuocTinhDTO item);
        bool Xoa(string tenBang, string ma);
        bool ThemThuocTinh(string tenBang, string ma, string ten, string maLoai = null);
        bool SuaThuocTinh(string tenBang, string ma, string ten, string maLoai = null);
        bool XoaThuocTinh(string tenBang, string ma);
    }
}
