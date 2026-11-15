using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class HoaDonBanDAL : BaseDAL, IHoaDonBanDAL
    {
        public DataTable LayDanhSachHoaDonBan()
        {
            return DatabaseHelper.ExecuteReaderSP("sp_HoaDonBan_LayDanhSach");
        }

        public DataTable LayDanhSachHoaDonBan(DateTime? tuNgay, DateTime? denNgay)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tu_ngay", (object)tuNgay ?? DBNull.Value),
                new SqlParameter("@den_ngay", (object)denNgay ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_HoaDonBan_LayDanhSach", parameters);
        }

        public DataTable LayChiTietHoaDonBan(string soHDB)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hoa_don_ban", soHDB)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_HoaDonBan_LayChiTiet", parameters);
        }

        public DataTable LayHoaDonBanTheoMa(string soHDB)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hoa_don_ban", soHDB)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_HoaDonBan_LayTheoMa", parameters);
        }

        public bool KiemTraTonTai(string soHDB)
        {
            return base.KiemTraTonTai("hoa_don_ban", "so_hoa_don_ban", soHDB);
        }

        public bool HuyHoaDonBanHoanKho(string soHDB, string lyDoHuy = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hoa_don_ban", soHDB),
                new SqlParameter("@ly_do_huy", (object)lyDoHuy ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_HoaDonBan_HuyHoanKho", parameters) > 0;
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
                        SqlParameter[] pHDB = new SqlParameter[]
                        {
                            new SqlParameter("@so_hoa_don_ban", hdb.SoHoaDonBan),
                            new SqlParameter("@thoi_gian_ban", hdb.ThoiGianBan),
                            new SqlParameter("@tong_tien", hdb.TongTien),
                            new SqlParameter("@ma_nhan_vien", hdb.MaNhanVien),
                            new SqlParameter("@ma_khach", hdb.MaKhach)
                        };
                        DatabaseHelper.ExecuteNonQuerySP("sp_HoaDonBan_Them", pHDB, trans);

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
                            DatabaseHelper.ExecuteNonQuerySP("sp_ChiTietHoaDonBan_Them", pCT, trans);
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
            return HuyHoaDonBanHoanKho(soHDB, null);
        }

        public int DemSoPhieuBaoHanh(string soHDB)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hoa_don_ban", soHDB)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalarSP("sp_HoaDonBan_DemSoPhieuBaoHanh", parameters));
        }
    }
}
