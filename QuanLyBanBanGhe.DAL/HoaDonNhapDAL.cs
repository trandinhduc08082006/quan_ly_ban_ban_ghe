using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class HoaDonNhapDAL : BaseDAL, IHoaDonNhapDAL
    {
        public DataTable LayDanhSachHoaDonNhap()
        {
            return DatabaseHelper.ExecuteReaderSP("sp_HoaDonNhap_LayDanhSach");
        }

        public DataTable LayDanhSachHoaDonNhap(DateTime? tuNgay, DateTime? denNgay)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tu_ngay", (object)tuNgay ?? DBNull.Value),
                new SqlParameter("@den_ngay", (object)denNgay ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_HoaDonNhap_LayDanhSach", parameters);
        }

        public DataTable LayChiTietHoaDonNhap(string soHDN)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hoa_don_nhap", soHDN)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_HoaDonNhap_LayChiTiet", parameters);
        }

        public DataTable LayHoaDonNhapTheoMa(string soHDN)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hoa_don_nhap", soHDN)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_HoaDonNhap_LayTheoMa", parameters);
        }

        public bool KiemTraTonTai(string soHDN)
        {
            return base.KiemTraTonTai("hoa_don_nhap", "so_hoa_don_nhap", soHDN);
        }

        public bool HuyHoaDonNhapKiemTraTon(string soHDN, string lyDoHuy = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@so_hoa_don_nhap", soHDN),
                new SqlParameter("@ly_do_huy", (object)lyDoHuy ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_HoaDonNhap_HuyKiemTraTon", parameters) > 0;
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
                        SqlParameter[] pHDN = new SqlParameter[]
                        {
                            new SqlParameter("@so_hoa_don_nhap", hdn.SoHoaDonNhap),
                            new SqlParameter("@thoi_gian_nhap", hdn.ThoiGianNhap),
                            new SqlParameter("@tong_tien", hdn.TongTien),
                            new SqlParameter("@ma_nha_cung_cap", hdn.MaNhaCungCap),
                            new SqlParameter("@ma_nhan_vien", hdn.MaNhanVien)
                        };
                        DatabaseHelper.ExecuteNonQuerySP("sp_HoaDonNhap_Them", pHDN, trans);

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
                            DatabaseHelper.ExecuteNonQuerySP("sp_ChiTietHoaDonNhap_Them", pCT, trans);
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
            return HuyHoaDonNhapKiemTraTon(soHDN, null);
        }
    }
}
