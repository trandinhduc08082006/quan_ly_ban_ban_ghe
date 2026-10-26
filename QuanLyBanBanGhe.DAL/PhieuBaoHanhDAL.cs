using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class PhieuBaoHanhDAL
    {
        public DataTable LayTatCa(bool daXoa = false)
        {
            string sql = @"
SELECT 
    pbh.ma_phieu_bao_hanh,
    pbh.so_hoa_don_ban,
    pbh.ma_hang,
    hh.ten_hang_hoa,
    pbh.ma_khach,
    kh.ten_khach,
    kh.dien_thoai AS dien_thoai_khach,
    pbh.ma_nhan_vien,
    nv.ten_nhan_vien,
    pbh.ngay_tiep_nhan,
    pbh.ngay_hen_tra,
    pbh.ngay_tra_thuc_te,
    pbh.mo_ta_loi,
    pbh.bien_phap_xu_ly,
    pbh.chi_phi,
    pbh.trang_thai,
    pbh.ghi_chu,
    pbh.trang_thai_xoa,
    hdb.thoi_gian_ban,
    hdb.trang_thai_giao_dich AS trang_thai_hoa_don_ban,
    hh.thoi_gian_bao_hanh,
    DATEADD(MONTH, ISNULL(hh.thoi_gian_bao_hanh, 0), hdb.thoi_gian_ban) AS han_bao_hanh,
    CASE 
        WHEN pbh.ngay_tiep_nhan <= DATEADD(MONTH, ISNULL(hh.thoi_gian_bao_hanh, 0), hdb.thoi_gian_ban) THEN 1 
        ELSE 0 
    END AS con_han_bao_hanh
FROM dbo.phieu_bao_hanh pbh
LEFT JOIN dbo.hoa_don_ban hdb ON pbh.so_hoa_don_ban = hdb.so_hoa_don_ban
LEFT JOIN dbo.hang_hoa hh ON pbh.ma_hang = hh.ma_hang
LEFT JOIN dbo.khach_hang kh ON pbh.ma_khach = kh.ma_khach
LEFT JOIN dbo.nhan_vien nv ON pbh.ma_nhan_vien = nv.ma_nhan_vien
WHERE pbh.trang_thai_xoa = @trang_thai_xoa
ORDER BY pbh.ngay_tiep_nhan DESC;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", daXoa ? 1 : 0)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable LayTheoMa(string maPhieu)
        {
            string sql = @"
SELECT 
    pbh.ma_phieu_bao_hanh,
    pbh.so_hoa_don_ban,
    pbh.ma_hang,
    hh.ten_hang_hoa,
    pbh.ma_khach,
    kh.ten_khach,
    kh.dien_thoai AS dien_thoai_khach,
    pbh.ma_nhan_vien,
    nv.ten_nhan_vien,
    pbh.ngay_tiep_nhan,
    pbh.ngay_hen_tra,
    pbh.ngay_tra_thuc_te,
    pbh.mo_ta_loi,
    pbh.bien_phap_xu_ly,
    pbh.chi_phi,
    pbh.trang_thai,
    pbh.ghi_chu,
    pbh.trang_thai_xoa,
    hdb.thoi_gian_ban,
    hdb.trang_thai_giao_dich AS trang_thai_hoa_don_ban,
    hh.thoi_gian_bao_hanh,
    DATEADD(MONTH, ISNULL(hh.thoi_gian_bao_hanh, 0), hdb.thoi_gian_ban) AS han_bao_hanh,
    CASE 
        WHEN pbh.ngay_tiep_nhan <= DATEADD(MONTH, ISNULL(hh.thoi_gian_bao_hanh, 0), hdb.thoi_gian_ban) THEN 1 
        ELSE 0 
    END AS con_han_bao_hanh
FROM dbo.phieu_bao_hanh pbh
LEFT JOIN dbo.hoa_don_ban hdb ON pbh.so_hoa_don_ban = hdb.so_hoa_don_ban
LEFT JOIN dbo.hang_hoa hh ON pbh.ma_hang = hh.ma_hang
LEFT JOIN dbo.khach_hang kh ON pbh.ma_khach = kh.ma_khach
LEFT JOIN dbo.nhan_vien nv ON pbh.ma_nhan_vien = nv.ma_nhan_vien
WHERE pbh.ma_phieu_bao_hanh = @ma_phieu;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", maPhieu)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable LayDanhSachHangHoaTheoHoaDon(string soHDB)
        {
            string sql = @"
SELECT 
    ct.ma_hang,
    hh.ten_hang_hoa,
    hh.thoi_gian_bao_hanh,
    hdb.ma_khach,
    kh.ten_khach,
    kh.dien_thoai AS dien_thoai_khach,
    hdb.thoi_gian_ban,
    DATEADD(MONTH, ISNULL(hh.thoi_gian_bao_hanh, 0), hdb.thoi_gian_ban) AS han_bao_hanh,
    CASE 
        WHEN SYSDATETIME() <= DATEADD(MONTH, ISNULL(hh.thoi_gian_bao_hanh, 0), hdb.thoi_gian_ban) THEN 1 
        ELSE 0 
    END AS con_han_bao_hanh
FROM dbo.chi_tiet_hoa_don_ban ct
INNER JOIN dbo.hoa_don_ban hdb ON ct.so_hoa_don_ban = hdb.so_hoa_don_ban
INNER JOIN dbo.hang_hoa hh ON ct.ma_hang = hh.ma_hang
INNER JOIN dbo.khach_hang kh ON hdb.ma_khach = kh.ma_khach
WHERE ct.so_hoa_don_ban = @so_hdb AND hdb.trang_thai_giao_dich = N'HoanThanh'
ORDER BY ct.ma_hang;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hdb", soHDB)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable LayDanhSachHoaDonHopLe()
        {
            string sql = @"
SELECT 
    hdb.so_hoa_don_ban,
    hdb.thoi_gian_ban,
    hdb.ma_khach,
    kh.ten_khach,
    kh.dien_thoai
FROM dbo.hoa_don_ban hdb
INNER JOIN dbo.khach_hang kh ON hdb.ma_khach = kh.ma_khach
WHERE hdb.trang_thai_giao_dich = N'HoanThanh'
ORDER BY hdb.thoi_gian_ban DESC;";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        public bool KiemTraTonTai(string maPhieu)
        {
            string sql = "SELECT COUNT(1) FROM dbo.phieu_bao_hanh WHERE ma_phieu_bao_hanh = @ma_phieu";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", maPhieu)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool Them(PhieuBaoHanhDTO dto)
        {
            string sql = @"
INSERT INTO dbo.phieu_bao_hanh 
(ma_phieu_bao_hanh, so_hoa_don_ban, ma_hang, ma_khach, ma_nhan_vien, ngay_tiep_nhan, ngay_hen_tra, ngay_tra_thuc_te, mo_ta_loi, bien_phap_xu_ly, chi_phi, trang_thai, ghi_chu, trang_thai_xoa)
VALUES 
(@ma_phieu, @so_hdb, @ma_hang, @ma_khach, @ma_nv, @ngay_tiep_nhan, @ngay_hen_tra, @ngay_tra_thuc_te, @mo_ta_loi, @bien_phap_xu_ly, @chi_phi, @trang_thai, @ghi_chu, 0);";
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
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Sua(PhieuBaoHanhDTO dto)
        {
            string sql = @"
UPDATE dbo.phieu_bao_hanh 
SET 
    so_hoa_don_ban = @so_hdb,
    ma_hang = @ma_hang,
    ma_khach = @ma_khach,
    ma_nhan_vien = @ma_nv,
    ngay_hen_tra = @ngay_hen_tra,
    ngay_tra_thuc_te = @ngay_tra_thuc_te,
    mo_ta_loi = @mo_ta_loi,
    bien_phap_xu_ly = @bien_phap_xu_ly,
    chi_phi = @chi_phi,
    trang_thai = @trang_thai,
    ghi_chu = @ghi_chu
WHERE ma_phieu_bao_hanh = @ma_phieu;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", dto.MaPhieuBaoHanh),
                new SqlParameter("@so_hdb", dto.SoHoaDonBan),
                new SqlParameter("@ma_hang", dto.MaHang),
                new SqlParameter("@ma_khach", dto.MaKhach),
                new SqlParameter("@ma_nv", dto.MaNhanVien),
                new SqlParameter("@ngay_hen_tra", (object)dto.NgayHenTra ?? DBNull.Value),
                new SqlParameter("@ngay_tra_thuc_te", (object)dto.NgayTraThucTe ?? DBNull.Value),
                new SqlParameter("@mo_ta_loi", dto.MoTaLoi ?? string.Empty),
                new SqlParameter("@bien_phap_xu_ly", (object)dto.BienPhapXuLy ?? DBNull.Value),
                new SqlParameter("@chi_phi", dto.ChiPhi),
                new SqlParameter("@trang_thai", dto.TrangThai ?? "TiepNhan"),
                new SqlParameter("@ghi_chu", (object)dto.GhiChu ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool XoaMem(string maPhieu)
        {
            string sql = "UPDATE dbo.phieu_bao_hanh SET trang_thai_xoa = 1 WHERE ma_phieu_bao_hanh = @ma_phieu;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", maPhieu)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool KhoiPhuc(string maPhieu)
        {
            string sql = "UPDATE dbo.phieu_bao_hanh SET trang_thai_xoa = 0 WHERE ma_phieu_bao_hanh = @ma_phieu;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_phieu", maPhieu)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public DataTable TimKiem(string tuKhoa, string trangThai, bool daXoa = false)
        {
            string sql = @"
SELECT 
    pbh.ma_phieu_bao_hanh,
    pbh.so_hoa_don_ban,
    pbh.ma_hang,
    hh.ten_hang_hoa,
    pbh.ma_khach,
    kh.ten_khach,
    kh.dien_thoai AS dien_thoai_khach,
    pbh.ma_nhan_vien,
    nv.ten_nhan_vien,
    pbh.ngay_tiep_nhan,
    pbh.ngay_hen_tra,
    pbh.ngay_tra_thuc_te,
    pbh.mo_ta_loi,
    pbh.bien_phap_xu_ly,
    pbh.chi_phi,
    pbh.trang_thai,
    pbh.ghi_chu,
    pbh.trang_thai_xoa,
    hdb.thoi_gian_ban,
    hdb.trang_thai_giao_dich AS trang_thai_hoa_don_ban,
    hh.thoi_gian_bao_hanh,
    DATEADD(MONTH, ISNULL(hh.thoi_gian_bao_hanh, 0), hdb.thoi_gian_ban) AS han_bao_hanh,
    CASE 
        WHEN pbh.ngay_tiep_nhan <= DATEADD(MONTH, ISNULL(hh.thoi_gian_bao_hanh, 0), hdb.thoi_gian_ban) THEN 1 
        ELSE 0 
    END AS con_han_bao_hanh
FROM dbo.phieu_bao_hanh pbh
LEFT JOIN dbo.hoa_don_ban hdb ON pbh.so_hoa_don_ban = hdb.so_hoa_don_ban
LEFT JOIN dbo.hang_hoa hh ON pbh.ma_hang = hh.ma_hang
LEFT JOIN dbo.khach_hang kh ON pbh.ma_khach = kh.ma_khach
LEFT JOIN dbo.nhan_vien nv ON pbh.ma_nhan_vien = nv.ma_nhan_vien
WHERE pbh.trang_thai_xoa = @trang_thai_xoa
  AND (@tu_khoa = '' OR pbh.ma_phieu_bao_hanh LIKE @tu_khoa_like 
       OR pbh.so_hoa_don_ban LIKE @tu_khoa_like 
       OR kh.ten_khach LIKE @tu_khoa_like 
       OR kh.dien_thoai LIKE @tu_khoa_like 
       OR hh.ten_hang_hoa LIKE @tu_khoa_like)
  AND (@trang_thai = '' OR pbh.trang_thai = @trang_thai)
ORDER BY pbh.ngay_tiep_nhan DESC;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", daXoa ? 1 : 0),
                new SqlParameter("@tu_khoa", tuKhoa ?? string.Empty),
                new SqlParameter("@tu_khoa_like", "%" + (tuKhoa ?? string.Empty).Trim() + "%"),
                new SqlParameter("@trang_thai", trangThai ?? string.Empty)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public string SinhMaPhieuBaoHanhMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.phieu_bao_hanh", "ma_phieu_bao_hanh", "BH");
        }

        public string LayTrangThaiHoaDonBan(string soHDB)
        {
            string sql = "SELECT trang_thai_giao_dich FROM dbo.hoa_don_ban WHERE so_hoa_don_ban = @so_hdb";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hdb", soHDB)
            };
            object result = DatabaseHelper.ExecuteScalar(sql, parameters);
            return result != null && result != DBNull.Value ? result.ToString() : null;
        }
    }
}
