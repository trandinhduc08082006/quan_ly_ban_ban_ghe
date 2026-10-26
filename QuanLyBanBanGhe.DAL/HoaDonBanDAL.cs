using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class HoaDonBanDAL
    {
        public DataTable LayDanhSachHoaDonBan()
        {
            string sql = @"
SELECT 
    hdb.so_hoa_don_ban, 
    hdb.thoi_gian_ban, 
    hdb.tong_tien, 
    hdb.trang_thai_giao_dich, 
    hdb.ma_khach, 
    kh.ten_khach, 
    kh.dien_thoai, 
    kh.dia_chi, 
    hdb.ma_nhan_vien, 
    nv.ten_nhan_vien
FROM dbo.hoa_don_ban hdb
LEFT JOIN dbo.khach_hang kh ON hdb.ma_khach = kh.ma_khach
LEFT JOIN dbo.nhan_vien nv ON hdb.ma_nhan_vien = nv.ma_nhan_vien
ORDER BY hdb.thoi_gian_ban DESC";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        public DataTable LayChiTietHoaDonBan(string soHDB)
        {
            string sql = @"
SELECT 
    ct.so_hoa_don_ban, 
    ct.ma_hang, 
    hh.ten_hang_hoa, 
    ct.so_luong, 
    ct.don_gia, 
    ct.giam_gia, 
    ct.thanh_tien
FROM dbo.chi_tiet_hoa_don_ban ct
LEFT JOIN dbo.hang_hoa hh ON ct.ma_hang = hh.ma_hang
WHERE ct.so_hoa_don_ban = @so_hdb
ORDER BY ct.ma_hang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hdb", soHDB)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable LayHoaDonBanTheoMa(string soHDB)
        {
            string sql = @"
SELECT 
    hdb.so_hoa_don_ban, 
    hdb.thoi_gian_ban, 
    hdb.tong_tien, 
    hdb.trang_thai_giao_dich, 
    hdb.ma_khach, 
    kh.ten_khach, 
    kh.dien_thoai, 
    kh.dia_chi, 
    hdb.ma_nhan_vien, 
    nv.ten_nhan_vien
FROM dbo.hoa_don_ban hdb
LEFT JOIN dbo.khach_hang kh ON hdb.ma_khach = kh.ma_khach
LEFT JOIN dbo.nhan_vien nv ON hdb.ma_nhan_vien = nv.ma_nhan_vien
WHERE hdb.so_hoa_don_ban = @so_hdb";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hdb", soHDB)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public bool KiemTraTonTai(string soHDB)
        {
            string sql = "SELECT COUNT(1) FROM dbo.hoa_don_ban WHERE so_hoa_don_ban = @so_hdb";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hdb", soHDB)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool LuuHoaDonBan(HoaDonBanDTO hdb, List<ChiTietHDBanDTO> chiTietList)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHDB = @"
INSERT INTO dbo.hoa_don_ban (so_hoa_don_ban, thoi_gian_ban, tong_tien, trang_thai_giao_dich, ma_nhan_vien, ma_khach)
VALUES (@so_hoa_don_ban, @thoi_gian_ban, @tong_tien, N'HoanThanh', @ma_nhan_vien, @ma_khach)";
                        SqlParameter[] pHDB = new SqlParameter[]
                        {
                            new SqlParameter("@so_hoa_don_ban", hdb.SoHoaDonBan),
                            new SqlParameter("@thoi_gian_ban", hdb.ThoiGianBan),
                            new SqlParameter("@tong_tien", hdb.TongTien),
                            new SqlParameter("@ma_nhan_vien", hdb.MaNhanVien),
                            new SqlParameter("@ma_khach", hdb.MaKhach)
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlHDB, pHDB, trans);

                        string sqlCT = @"
INSERT INTO dbo.chi_tiet_hoa_don_ban (so_hoa_don_ban, ma_hang, so_luong, don_gia, giam_gia, thanh_tien)
VALUES (@so_hoa_don_ban, @ma_hang, @so_luong, @don_gia, @giam_gia, @thanh_tien)";

                        string sqlHH = "UPDATE dbo.hang_hoa SET so_luong = so_luong - @so_luong WHERE ma_hang = @ma_hang";

                        foreach (ChiTietHDBanDTO ct in chiTietList)
                        {
                            SqlParameter[] pCT = new SqlParameter[]
                            {
                                new SqlParameter("@so_hoa_don_ban", hdb.SoHoaDonBan),
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

        public bool HuyHoaDonBan(string soHDB)
        {
            string sqlGetItems = "SELECT ma_hang, so_luong FROM dbo.chi_tiet_hoa_don_ban WHERE so_hoa_don_ban = @so_hdb";
            SqlParameter[] pGet = new SqlParameter[]
            {
                new SqlParameter("@so_hdb", soHDB)
            };
            DataTable dtItems = DatabaseHelper.ExecuteQuery(sqlGetItems, pGet);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlUpdateHDB = "UPDATE dbo.hoa_don_ban SET trang_thai_giao_dich = N'DaHuy' WHERE so_hoa_don_ban = @so_hdb";
                        SqlParameter[] pHDB = new SqlParameter[]
                        {
                            new SqlParameter("@so_hdb", soHDB)
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlUpdateHDB, pHDB, trans);

                        string sqlRefundStock = "UPDATE dbo.hang_hoa SET so_luong = so_luong + @so_luong WHERE ma_hang = @ma_hang";
                        foreach (DataRow r in dtItems.Rows)
                        {
                            string maHang = r["ma_hang"].ToString();
                            int soLuong = Convert.ToInt32(r["so_luong"]);

                            SqlParameter[] pStock = new SqlParameter[]
                            {
                                new SqlParameter("@so_luong", soLuong),
                                new SqlParameter("@ma_hang", maHang)
                            };
                            DatabaseHelper.ExecuteNonQuery(sqlRefundStock, pStock, trans);
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

        public int DemSoPhieuBaoHanh(string soHDB)
        {
            string sql = "SELECT COUNT(1) FROM dbo.phieu_bao_hanh WHERE so_hoa_don_ban = @so_hdb AND trang_thai_xoa = 0";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hdb", soHDB)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
        }
    }
}
