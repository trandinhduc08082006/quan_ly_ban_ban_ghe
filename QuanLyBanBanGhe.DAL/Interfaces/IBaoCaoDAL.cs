using System.Data;

namespace QuanLyBanBanGhe.DAL.Interfaces
{
    public interface IBaoCaoDAL
    {
        DataTable BaoCaoTop10BanChay(int nam);
        DataTable BaoCaoNhapHang(int? thang, int? quy, int nam, string maNV);
        DataTable BaoCaoNhapHangTheoQuy(int quy, int nam, string maNV);
        DataTable BaoCaoBanHang(int? thang, int? quy, int nam, string maNV);
        DataTable BaoCaoDoanhThuTheoThang(int thang, int nam);
        DataTable BaoCaoNhanVienDoanhSo0(int nam);
        DataTable BaoCaoTop10NhanVienDoanhSoThap(int nam);
        DataTable NhanVienBanItTienNhat(int nam, int cheDo = 1);
    }
}
