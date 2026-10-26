using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanBanGhe.DAL
{
    public class BaoCaoDAL
    {
        public DataTable BaoCaoTop10BanChay(int nam)
        {
            string sql = @"
SELECT TOP 10 
    h.ma_hang,
    h.ten_hang_hoa,
    SUM(ct.so_luong) AS tong_so_luong_ban,
    SUM(ct.thanh_tien) AS tong_doanh_thu
FROM dbo.chi_tiet_hoa_don_ban ct
INNER JOIN dbo.hoa_don_ban hd ON ct.so_hoa_don_ban = hd.so_hoa_don_ban
INNER JOIN dbo.hang_hoa h ON ct.ma_hang = h.ma_hang
WHERE YEAR(hd.thoi_gian_ban) = @nam 
  AND hd.trang_thai_giao_dich = N'HoanThanh'
GROUP BY h.ma_hang, h.ten_hang_hoa
ORDER BY SUM(ct.so_luong) DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nam", nam)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable BaoCaoNhapHang(int? thang, int? quy, int nam, string maNV)
        {
            string sql = @"
SELECT 
    hd.so_hoa_don_nhap,
    hd.thoi_gian_nhap,
    ncc.ten_nha_cung_cap,
    nv.ten_nhan_vien,
    hd.tong_tien
FROM dbo.hoa_don_nhap hd
INNER JOIN dbo.nha_cung_cap ncc ON hd.ma_nha_cung_cap = ncc.ma_nha_cung_cap
INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
WHERE (@ma_nhan_vien IS NULL OR @ma_nhan_vien = '' OR hd.ma_nhan_vien = @ma_nhan_vien)
  AND YEAR(hd.thoi_gian_nhap) = @nam
  AND (@thang IS NULL OR @thang = 0 OR MONTH(hd.thoi_gian_nhap) = @thang)
  AND (@quy IS NULL OR @quy = 0 OR DATEPART(QUARTER, hd.thoi_gian_nhap) = @quy)
  AND hd.trang_thai_giao_dich = N'HoanThanh'
ORDER BY hd.thoi_gian_nhap DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@thang", (object)thang ?? DBNull.Value),
                new SqlParameter("@quy", (object)quy ?? DBNull.Value),
                new SqlParameter("@nam", nam),
                new SqlParameter("@ma_nhan_vien", string.IsNullOrWhiteSpace(maNV) ? (object)DBNull.Value : maNV.Trim())
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable BaoCaoNhapHangTheoQuy(int quy, int nam, string maNV)
        {
            return BaoCaoNhapHang(null, quy, nam, maNV);
        }

        public DataTable BaoCaoBanHang(int? thang, int? quy, int nam, string maNV)
        {
            string sql = @"
SELECT 
    hd.so_hoa_don_ban,
    hd.thoi_gian_ban,
    kh.ten_khach,
    nv.ten_nhan_vien,
    hd.tong_tien
FROM dbo.hoa_don_ban hd
INNER JOIN dbo.khach_hang kh ON hd.ma_khach = kh.ma_khach
INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
WHERE (@ma_nhan_vien IS NULL OR @ma_nhan_vien = '' OR hd.ma_nhan_vien = @ma_nhan_vien)
  AND YEAR(hd.thoi_gian_ban) = @nam
  AND (@thang IS NULL OR @thang = 0 OR MONTH(hd.thoi_gian_ban) = @thang)
  AND (@quy IS NULL OR @quy = 0 OR DATEPART(QUARTER, hd.thoi_gian_ban) = @quy)
  AND hd.trang_thai_giao_dich = N'HoanThanh'
ORDER BY hd.thoi_gian_ban DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@thang", (object)thang ?? DBNull.Value),
                new SqlParameter("@quy", (object)quy ?? DBNull.Value),
                new SqlParameter("@nam", nam),
                new SqlParameter("@ma_nhan_vien", string.IsNullOrWhiteSpace(maNV) ? (object)DBNull.Value : maNV.Trim())
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable BaoCaoDoanhThuTheoThang(int thang, int nam)
        {
            return BaoCaoBanHang(thang, null, nam, null);
        }

        public DataTable BaoCaoNhanVienDoanhSo0(int nam)
        {
            string sql = @"
SELECT 
    nv.ma_nhan_vien,
    nv.ten_nhan_vien,
    cv.ten_cong_viec,
    nv.dien_thoai,
    0 AS so_hoa_don_da_ban,
    CAST(0.00 AS DECIMAL(18,2)) AS tong_doanh_thu
FROM dbo.nhan_vien nv
INNER JOIN dbo.cong_viec cv ON nv.ma_cong_viec = cv.ma_cong_viec
LEFT JOIN dbo.tai_khoan tk ON nv.ma_nhan_vien = tk.ma_nhan_vien
WHERE nv.trang_thai_xoa = 0
  AND (
      cv.ten_cong_viec LIKE N'%Bán hàng%' 
      OR cv.ten_cong_viec LIKE N'%Kinh doanh%'
      OR tk.quyen = N'BanHang'
  )
  AND ISNULL(tk.quyen, N'BanHang') = N'BanHang'
  AND nv.ma_nhan_vien NOT IN (
      SELECT DISTINCT hd.ma_nhan_vien 
      FROM dbo.hoa_don_ban hd 
      WHERE YEAR(hd.thoi_gian_ban) = @nam 
        AND hd.trang_thai_giao_dich = N'HoanThanh'
  )
ORDER BY nv.ma_nhan_vien ASC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nam", nam)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable BaoCaoTop10NhanVienDoanhSoThap(int nam)
        {
            string sql = @"
SELECT TOP 10 
    nv.ma_nhan_vien,
    nv.ten_nhan_vien,
    cv.ten_cong_viec,
    nv.dien_thoai,
    COUNT(hd.so_hoa_don_ban) AS so_hoa_don_da_ban,
    SUM(hd.tong_tien) AS tong_doanh_thu
FROM dbo.hoa_don_ban hd
INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
INNER JOIN dbo.cong_viec cv ON nv.ma_cong_viec = cv.ma_cong_viec
LEFT JOIN dbo.tai_khoan tk ON nv.ma_nhan_vien = tk.ma_nhan_vien
WHERE YEAR(hd.thoi_gian_ban) = @nam 
  AND hd.trang_thai_giao_dich = N'HoanThanh'
  AND nv.trang_thai_xoa = 0
  AND (
      cv.ten_cong_viec LIKE N'%Bán hàng%' 
      OR cv.ten_cong_viec LIKE N'%Kinh doanh%'
      OR tk.quyen = N'BanHang'
  )
  AND ISNULL(tk.quyen, N'BanHang') = N'BanHang'
GROUP BY nv.ma_nhan_vien, nv.ten_nhan_vien, cv.ten_cong_viec, nv.dien_thoai
ORDER BY SUM(hd.tong_tien) ASC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nam", nam)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }
    }
}
