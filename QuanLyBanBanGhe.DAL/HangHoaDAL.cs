using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class HangHoaDAL : BaseDAL, IHangHoaDAL
    {
        public DataTable LayTatCaHangHoa(bool chiLayDangHoatDong = true)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@chi_lay_hoat_dong", chiLayDangHoatDong)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_HangHoa_LayDanhSach", parameters);
        }

        public HangHoaDTO LayHangHoaTheoMa(string maHang)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang)
            };
            DataTable dt = DatabaseHelper.ExecuteReaderSP("sp_HangHoa_KiemTraTonKho", parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new HangHoaDTO
                {
                    MaHang = r["ma_hang"].ToString(),
                    TenHangHoa = r["ten_hang_hoa"].ToString(),
                    SoLuong = Convert.ToInt32(r["so_luong"]),
                    TrangThaiXoa = Convert.ToBoolean(r["trang_thai_xoa"])
                };
            }
            return null;
        }

        public bool KiemTraTonTai(string maHang)
        {
            return base.KiemTraTonTai("hang_hoa", "ma_hang", maHang);
        }

        public bool KiemTraTonKho(string maHang, int soLuongCan)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang)
            };
            DataTable dt = DatabaseHelper.ExecuteReaderSP("sp_HangHoa_KiemTraTonKho", parameters);
            if (dt.Rows.Count > 0)
            {
                int tonKho = Convert.ToInt32(dt.Rows[0]["so_luong"]);
                bool xoa = Convert.ToBoolean(dt.Rows[0]["trang_thai_xoa"]);
                return !xoa && tonKho >= soLuongCan;
            }
            return false;
        }

        public bool ThemHangHoa(HangHoaDTO hh)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", hh.MaHang),
                new SqlParameter("@ten_hang_hoa", hh.TenHangHoa),
                new SqlParameter("@so_luong", hh.SoLuong),
                new SqlParameter("@don_gia_ban", hh.DonGiaBan),
                new SqlParameter("@don_gia_nhap", hh.DonGiaNhap),
                new SqlParameter("@thoi_gian_bao_hanh", (object)hh.ThoiGianBaoHanh ?? DBNull.Value),
                new SqlParameter("@anh", (object)hh.Anh ?? DBNull.Value),
                new SqlParameter("@ghi_chu", (object)hh.GhiChu ?? DBNull.Value),
                new SqlParameter("@ma_loai", (object)hh.MaLoai ?? DBNull.Value),
                new SqlParameter("@ma_mau", (object)hh.MaMau ?? DBNull.Value),
                new SqlParameter("@ma_cong_dung", (object)hh.MaCongDung ?? DBNull.Value),
                new SqlParameter("@ma_chat_lieu", (object)hh.MaChatLieu ?? DBNull.Value),
                new SqlParameter("@ma_dac_diem", (object)hh.MaDacDiem ?? DBNull.Value),
                new SqlParameter("@ma_hinh_dang", (object)hh.MaHinhDang ?? DBNull.Value),
                new SqlParameter("@ma_kich_thuoc", (object)hh.MaKichThuoc ?? DBNull.Value),
                new SqlParameter("@ma_nha_san_xuat", (object)hh.MaNhaSanXuat ?? DBNull.Value),
                new SqlParameter("@ma_nuoc_san_xuat", (object)hh.MaNuocSanXuat ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuerySP("sp_HangHoa_Them", parameters) > 0;
        }

        public bool CapNhatHangHoa(HangHoaDTO hh)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", hh.MaHang),
                new SqlParameter("@ten_hang_hoa", hh.TenHangHoa),
                new SqlParameter("@don_gia_nhap", hh.DonGiaNhap),
                new SqlParameter("@don_gia_ban", hh.DonGiaBan),
                new SqlParameter("@thoi_gian_bao_hanh", (object)hh.ThoiGianBaoHanh ?? DBNull.Value),
                new SqlParameter("@anh", (object)hh.Anh ?? DBNull.Value),
                new SqlParameter("@ghi_chu", (object)hh.GhiChu ?? DBNull.Value),
                new SqlParameter("@ma_loai", (object)hh.MaLoai ?? DBNull.Value),
                new SqlParameter("@ma_mau", (object)hh.MaMau ?? DBNull.Value),
                new SqlParameter("@ma_cong_dung", (object)hh.MaCongDung ?? DBNull.Value),
                new SqlParameter("@ma_chat_lieu", (object)hh.MaChatLieu ?? DBNull.Value),
                new SqlParameter("@ma_dac_diem", (object)hh.MaDacDiem ?? DBNull.Value),
                new SqlParameter("@ma_hinh_dang", (object)hh.MaHinhDang ?? DBNull.Value),
                new SqlParameter("@ma_kich_thuoc", (object)hh.MaKichThuoc ?? DBNull.Value),
                new SqlParameter("@ma_nha_san_xuat", (object)hh.MaNhaSanXuat ?? DBNull.Value),
                new SqlParameter("@ma_nuoc_san_xuat", (object)hh.MaNuocSanXuat ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuerySP("sp_HangHoa_CapNhat", parameters) > 0;
        }

        public bool XoaMemHangHoa(string maHang)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_HangHoa_XoaMem", parameters) > 0;
        }

        public bool KhoiPhucHangHoa(string maHang)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_HangHoa_KhoiPhuc", parameters) > 0;
        }

        public bool CapNhatTonKhoVaGia(string maHang, int soLuongThayDoi, decimal giaNhapMoi, SqlTransaction trans = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang),
                new SqlParameter("@so_luong", soLuongThayDoi),
                new SqlParameter("@don_gia_nhap", giaNhapMoi)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_HangHoa_CapNhatTonKhoVaGia", parameters, trans) > 0;
        }

        public bool CapNhatGiaBanVaTonKho(string maHang, decimal donGiaNhap, int soLuongThem)
        {
            return CapNhatTonKhoVaGia(maHang, soLuongThem, donGiaNhap);
        }

        public int LayTonKho(string maHang, SqlTransaction trans = null)
        {
            SqlParameter[] spParams = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang)
            };
            DataTable dt = DatabaseHelper.ExecuteReaderSP("sp_HangHoa_KiemTraTonKho", spParams, trans);
            if (dt.Rows.Count > 0 && int.TryParse(dt.Rows[0]["so_luong"].ToString(), out int soLuong))
            {
                return soLuong;
            }
            return 0;
        }

        public DataTable LayKichThuocTheoLoai(string maLoai)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_loai", string.IsNullOrWhiteSpace(maLoai) ? (object)DBNull.Value : maLoai.Trim())
            };
            return DatabaseHelper.ExecuteReaderSP("sp_KichThuoc_LayTheoLoai", parameters);
        }

        public string SinhMaHangHoaMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.hang_hoa", "ma_hang", "HH");
        }

        public DataTable TimKiemHangHoa(
            string maHang,
            string tenHang,
            string maLoai,
            string maKichThuoc,
            string maChatLieu,
            string maMau,
            string maNuocSX,
            string maHinhDang,
            string maNhaSX,
            string maCongDung,
            string maDacDiem,
            bool chiLayDangHoatDong = true)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1),
                new SqlParameter("@ma_hang", string.IsNullOrWhiteSpace(maHang) ? (object)DBNull.Value : maHang.Trim()),
                new SqlParameter("@ten_hang", string.IsNullOrWhiteSpace(tenHang) ? (object)DBNull.Value : tenHang.Trim()),
                new SqlParameter("@ma_loai", string.IsNullOrWhiteSpace(maLoai) ? (object)DBNull.Value : maLoai.Trim()),
                new SqlParameter("@ma_kich_thuoc", string.IsNullOrWhiteSpace(maKichThuoc) ? (object)DBNull.Value : maKichThuoc.Trim()),
                new SqlParameter("@ma_chat_lieu", string.IsNullOrWhiteSpace(maChatLieu) ? (object)DBNull.Value : maChatLieu.Trim()),
                new SqlParameter("@ma_mau", string.IsNullOrWhiteSpace(maMau) ? (object)DBNull.Value : maMau.Trim()),
                new SqlParameter("@ma_nuoc_san_xuat", string.IsNullOrWhiteSpace(maNuocSX) ? (object)DBNull.Value : maNuocSX.Trim()),
                new SqlParameter("@ma_hinh_dang", string.IsNullOrWhiteSpace(maHinhDang) ? (object)DBNull.Value : maHinhDang.Trim()),
                new SqlParameter("@ma_nha_san_xuat", string.IsNullOrWhiteSpace(maNhaSX) ? (object)DBNull.Value : maNhaSX.Trim()),
                new SqlParameter("@ma_cong_dung", string.IsNullOrWhiteSpace(maCongDung) ? (object)DBNull.Value : maCongDung.Trim()),
                new SqlParameter("@ma_dac_diem", string.IsNullOrWhiteSpace(maDacDiem) ? (object)DBNull.Value : maDacDiem.Trim())
            };

            return DatabaseHelper.ExecuteReaderSP("sp_HangHoa_TimKiem", parameters);
        }
    }
}
