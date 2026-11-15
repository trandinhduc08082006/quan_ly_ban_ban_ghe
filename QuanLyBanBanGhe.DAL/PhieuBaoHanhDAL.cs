using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class PhieuBaoHanhDAL : BaseDAL, IBaoHanhDAL
    {
        public DataTable LayDanhSach(bool daXoa = false)
        {
            return LayTatCa(daXoa);
        }

        public DataTable LayDanhSachPhieuBaoHanh()
        {
            return LayTatCa(false);
        }

        public bool TiepNhanBaoHanh(PhieuBaoHanhDTO phieu)
        {
            return Them(phieu);
        }

        public bool CapNhatTrangThaiVaChiPhi(string maPhieu, string trangThaiMoi, decimal chiPhi, string ghiChu = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu_bao_hanh", maPhieu),
                new SqlParameter("@trang_thai_bao_hanh", trangThaiMoi),
                new SqlParameter("@chi_phi_sua_chua", chiPhi),
                new SqlParameter("@bien_phap_xu_ly", (object)ghiChu ?? DBNull.Value)
            };
            int rows = DatabaseHelper.ExecuteNonQuerySP("sp_BaoHanh_CapNhatTrangThai", parameters);
            return rows > 0 || rows == -1;
        }

        public DataTable LayTatCa(bool daXoa = false)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", daXoa ? 1 : 0)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_BaoHanh_LayTatCa", parameters);
        }

        public DataTable LayTheoMa(string maPhieu)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", maPhieu)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_BaoHanh_LayTheoMa", parameters);
        }

        public DataTable LayDanhSachHangHoaTheoHoaDon(string soHDB)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hoa_don_ban", soHDB)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_BaoHanh_LayDanhSachHangHoaTheoHoaDon", parameters);
        }

        public DataTable LayDanhSachHangHoaTheoHDB(string soHDB)
        {
            return LayDanhSachHangHoaTheoHoaDon(soHDB);
        }

        public DataTable LayDanhSachHoaDonHopLe()
        {
            return DatabaseHelper.ExecuteReaderSP("sp_BaoHanh_LayDanhSachHoaDonHopLe");
        }

        public DataTable LayDanhSachHoaDonBanHoanThanh()
        {
            return LayDanhSachHoaDonHopLe();
        }

        public bool KiemTraTonTai(string maPhieu)
        {
            return base.KiemTraTonTai("phieu_bao_hanh", "ma_phieu_bao_hanh", maPhieu);
        }

        public bool Them(PhieuBaoHanhDTO dto)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", dto.MaPhieuBaoHanh),
                new SqlParameter("@so_hdb", dto.SoHoaDonBan),
                new SqlParameter("@ma_hang", dto.MaHang),
                new SqlParameter("@ma_khach", dto.MaKhach),
                new SqlParameter("@ma_nv", dto.MaNhanVien),
                new SqlParameter("@ngay_tiep_nhan", dto.NgayTiepNhan),
                new SqlParameter("@ngay_hen_tra", (object)dto.NgayHenTra ?? DBNull.Value),
                new SqlParameter("@ngay_tra_thuc_te", (object)dto.NgayTraThucTe ?? DBNull.Value),
                new SqlParameter("@mo_ta_loi", dto.MoTaLoi ?? string.Empty),
                new SqlParameter("@bien_phap_xu_ly", (object)dto.BienPhapXuLy ?? DBNull.Value),
                new SqlParameter("@chi_phi", dto.ChiPhi),
                new SqlParameter("@trang_thai", dto.TrangThai ?? "TiepNhan"),
                new SqlParameter("@ghi_chu", (object)dto.GhiChu ?? DBNull.Value)
            };
            int rows = DatabaseHelper.ExecuteNonQuerySP("sp_BaoHanh_Them", parameters);
            return rows > 0 || rows == -1;
        }

        public bool Sua(PhieuBaoHanhDTO dto)
        {
            DateTime? ngayTra = dto.NgayTraThucTe;
            if (string.Equals(dto.TrangThai, "DaTra", StringComparison.OrdinalIgnoreCase) && !ngayTra.HasValue)
            {
                ngayTra = DateTime.Today;
            }

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", dto.MaPhieuBaoHanh),
                new SqlParameter("@so_hdb", dto.SoHoaDonBan),
                new SqlParameter("@ma_hang", dto.MaHang),
                new SqlParameter("@ma_khach", dto.MaKhach),
                new SqlParameter("@ma_nv", dto.MaNhanVien),
                new SqlParameter("@ngay_hen_tra", (object)dto.NgayHenTra ?? DBNull.Value),
                new SqlParameter("@ngay_tra_thuc_te", (object)ngayTra ?? DBNull.Value),
                new SqlParameter("@mo_ta_loi", dto.MoTaLoi ?? string.Empty),
                new SqlParameter("@bien_phap_xu_ly", (object)dto.BienPhapXuLy ?? DBNull.Value),
                new SqlParameter("@chi_phi", dto.ChiPhi),
                new SqlParameter("@trang_thai", dto.TrangThai ?? "TiepNhan"),
                new SqlParameter("@ghi_chu", (object)dto.GhiChu ?? DBNull.Value)
            };
            int rows = DatabaseHelper.ExecuteNonQuerySP("sp_BaoHanh_Sua", parameters);
            return rows > 0 || rows == -1;
        }

        public bool XoaMem(string maPhieu)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", maPhieu)
            };
            int rows = DatabaseHelper.ExecuteNonQuerySP("sp_BaoHanh_XoaMem", parameters);
            return rows > 0 || rows == -1;
        }

        public bool KhoiPhuc(string maPhieu)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", maPhieu)
            };
            int rows = DatabaseHelper.ExecuteNonQuerySP("sp_BaoHanh_KhoiPhuc", parameters);
            return rows > 0 || rows == -1;
        }

        public DataTable TimKiem(string tuKhoa, string trangThai, bool daXoa = false)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", daXoa ? 1 : 0),
                new SqlParameter("@tu_khoa", string.IsNullOrWhiteSpace(tuKhoa) ? (object)DBNull.Value : tuKhoa.Trim()),
                new SqlParameter("@trang_thai", string.IsNullOrWhiteSpace(trangThai) ? (object)DBNull.Value : trangThai.Trim())
            };
            return DatabaseHelper.ExecuteReaderSP("sp_BaoHanh_TimKiem", parameters);
        }

        public string SinhMaPhieuBaoHanhMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.phieu_bao_hanh", "ma_phieu_bao_hanh", "BH");
        }

        public string LayTrangThaiHoaDonBan(string soHDB)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hoa_don_ban", soHDB)
            };
            object result = DatabaseHelper.ExecuteScalarSP("sp_BaoHanh_LayTrangThaiHoaDonBan", parameters);
            return result != null && result != DBNull.Value ? result.ToString() : null;
        }
    }
}
