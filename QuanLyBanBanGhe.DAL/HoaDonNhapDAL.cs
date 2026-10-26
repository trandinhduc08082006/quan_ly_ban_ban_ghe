using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class HoaDonNhapDAL
    {
        public DataTable LayDanhSachHoaDonNhap()
        {
            string sql = @"
SELECT 
    hdn.so_hoa_don_nhap, 
    hdn.thoi_gian_nhap, 
    hdn.tong_tien, 
    hdn.trang_thai_giao_dich, 
    hdn.ma_nha_cung_cap, 
    ncc.ten_nha_cung_cap, 
    ncc.dien_thoai, 
    ncc.dia_chi, 
    hdn.ma_nhan_vien, 
    nv.ten_nhan_vien
FROM dbo.hoa_don_nhap hdn
LEFT JOIN dbo.nha_cung_cap ncc ON hdn.ma_nha_cung_cap = ncc.ma_nha_cung_cap
LEFT JOIN dbo.nhan_vien nv ON hdn.ma_nhan_vien = nv.ma_nhan_vien
ORDER BY hdn.thoi_gian_nhap DESC";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        public DataTable LayChiTietHoaDonNhap(string soHDN)
        {
            string sql = @"
SELECT 
    ct.so_hoa_don_nhap, 
    ct.ma_hang, 
    hh.ten_hang_hoa, 
    ct.so_luong, 
    ct.don_gia, 
    ct.giam_gia, 
    ct.thanh_tien
FROM dbo.chi_tiet_hoa_don_nhap ct
LEFT JOIN dbo.hang_hoa hh ON ct.ma_hang = hh.ma_hang
WHERE ct.so_hoa_don_nhap = @so_hdn
ORDER BY ct.ma_hang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hdn", soHDN)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable LayHoaDonNhapTheoMa(string soHDN)
        {
            string sql = @"
SELECT 
    hdn.so_hoa_don_nhap, 
    hdn.thoi_gian_nhap, 
    hdn.tong_tien, 
    hdn.trang_thai_giao_dich, 
    hdn.ma_nha_cung_cap, 
    ncc.ten_nha_cung_cap, 
    ncc.dien_thoai, 
    ncc.dia_chi, 
    hdn.ma_nhan_vien, 
    nv.ten_nhan_vien
FROM dbo.hoa_don_nhap hdn
LEFT JOIN dbo.nha_cung_cap ncc ON hdn.ma_nha_cung_cap = ncc.ma_nha_cung_cap
LEFT JOIN dbo.nhan_vien nv ON hdn.ma_nhan_vien = nv.ma_nhan_vien
WHERE hdn.so_hoa_don_nhap = @so_hdn";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hdn", soHDN)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public bool KiemTraTonTai(string soHDN)
        {
            string sql = "SELECT COUNT(1) FROM dbo.hoa_don_nhap WHERE so_hoa_don_nhap = @so_hdn";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hdn", soHDN)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool LuuHoaDonNhap(HoaDonNhapDTO hdn, List<ChiTietHDNhapDTO> chiTietList)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHDN = @"
INSERT INTO dbo.hoa_don_nhap (so_hoa_don_nhap, thoi_gian_nhap, tong_tien, trang_thai_giao_dich, ma_nha_cung_cap, ma_nhan_vien)
VALUES (@so_hoa_don_nhap, @thoi_gian_nhap, @tong_tien, N'HoanThanh', @ma_nha_cung_cap, @ma_nhan_vien)";
                        SqlParameter[] pHDN = new SqlParameter[]
                        {
                            new SqlParameter("@so_hoa_don_nhap", hdn.SoHoaDonNhap),
                            new SqlParameter("@thoi_gian_nhap", hdn.ThoiGianNhap),
                            new SqlParameter("@tong_tien", hdn.TongTien),
                            new SqlParameter("@ma_nha_cung_cap", hdn.MaNhaCungCap),
                            new SqlParameter("@ma_nhan_vien", hdn.MaNhanVien)
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlHDN, pHDN, trans);

                        string sqlCT = @"
INSERT INTO dbo.chi_tiet_hoa_don_nhap (so_hoa_don_nhap, ma_hang, so_luong, don_gia, giam_gia, thanh_tien)
VALUES (@so_hoa_don_nhap, @ma_hang, @so_luong, @don_gia, @giam_gia, @thanh_tien)";

                        string sqlHH = @"
UPDATE dbo.hang_hoa 
SET so_luong = so_luong + @so_luong, 
    don_gia_nhap = @don_gia, 
    don_gia_ban = ROUND((@don_gia * 1.10) / 10000.0, 0) * 10000
WHERE ma_hang = @ma_hang";

                        foreach (ChiTietHDNhapDTO ct in chiTietList)
                        {
                            SqlParameter[] pCT = new SqlParameter[]
                            {
                                new SqlParameter("@so_hoa_don_nhap", hdn.SoHoaDonNhap),
                                new SqlParameter("@ma_hang", ct.MaHang),
                                new SqlParameter("@so_luong", ct.SoLuong),
                                new SqlParameter("@don_gia", ct.DonGia),
                                new SqlParameter("@giam_gia", ct.GiamGia),
                                new SqlParameter("@thanh_tien", ct.ThanhTien)
                            };
                            DatabaseHelper.ExecuteNonQuery(sqlCT, pCT, trans);

                            SqlParameter[] pHH = new SqlParameter[]
                            {
                                new SqlParameter("@so_luong", ct.SoLuong),
                                new SqlParameter("@don_gia", ct.DonGia),
                                new SqlParameter("@ma_hang", ct.MaHang)
                            };
                            DatabaseHelper.ExecuteNonQuery(sqlHH, pHH, trans);
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool HuyHoaDonNhap(string soHDN)
        {
            string sqlGetItems = "SELECT ma_hang, so_luong FROM dbo.chi_tiet_hoa_don_nhap WHERE so_hoa_don_nhap = @so_hdn";
            SqlParameter[] pGet = new SqlParameter[]
            {
                new SqlParameter("@so_hdn", soHDN)
            };
            DataTable dtItems = DatabaseHelper.ExecuteQuery(sqlGetItems, pGet);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlUpdateHDN = "UPDATE dbo.hoa_don_nhap SET trang_thai_giao_dich = N'DaHuy' WHERE so_hoa_don_nhap = @so_hdn";
                        SqlParameter[] pHDN = new SqlParameter[]
                        {
                            new SqlParameter("@so_hdn", soHDN)
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlUpdateHDN, pHDN, trans);

                        string sqlMinusStock = "UPDATE dbo.hang_hoa SET so_luong = so_luong - @so_luong WHERE ma_hang = @ma_hang";
                        string sqlGetLastPrice = @"
SELECT TOP 1 cthn.don_gia 
FROM dbo.chi_tiet_hoa_don_nhap cthn
INNER JOIN dbo.hoa_don_nhap hdn ON cthn.so_hoa_don_nhap = hdn.so_hoa_don_nhap
WHERE cthn.ma_hang = @ma_hang 
  AND hdn.trang_thai_giao_dich = N'HoanThanh' 
  AND hdn.so_hoa_don_nhap <> @so_hdn
ORDER BY hdn.thoi_gian_nhap DESC";

                        string sqlRestorePrice = @"
UPDATE dbo.hang_hoa 
SET don_gia_nhap = @don_gia_nhap,
    don_gia_ban = ROUND((@don_gia_nhap * 1.10) / 10000.0, 0) * 10000
WHERE ma_hang = @ma_hang";

                        foreach (DataRow r in dtItems.Rows)
                        {
                            string maHang = r["ma_hang"].ToString();
                            int soLuong = Convert.ToInt32(r["so_luong"]);

                            SqlParameter[] pStock = new SqlParameter[]
                            {
                                new SqlParameter("@so_luong", soLuong),
                                new SqlParameter("@ma_hang", maHang)
                            };
                            DatabaseHelper.ExecuteNonQuery(sqlMinusStock, pStock, trans);

                            SqlParameter[] pPriceQuery = new SqlParameter[]
                            {
                                new SqlParameter("@ma_hang", maHang),
                                new SqlParameter("@so_hdn", soHDN)
                            };
                            object objLastPrice = DatabaseHelper.ExecuteScalar(sqlGetLastPrice, pPriceQuery, trans);
                            if (objLastPrice != null && objLastPrice != DBNull.Value)
                            {
                                decimal giaNhapCu = Convert.ToDecimal(objLastPrice);
                                SqlParameter[] pRestore = new SqlParameter[]
                                {
                                    new SqlParameter("@don_gia_nhap", giaNhapCu),
                                    new SqlParameter("@ma_hang", maHang)
                                };
                                DatabaseHelper.ExecuteNonQuery(sqlRestorePrice, pRestore, trans);
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
