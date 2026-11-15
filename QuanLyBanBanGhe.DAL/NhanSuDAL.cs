using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class NhanSuDAL : BaseDAL, INhanSuDAL
    {
        public DataTable LayDanhSachCongViec(bool chiLayDangHoatDong = true)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_CongViec_LayDanhSach", parameters);
        }

        public bool ThemCongViec(CongViecDTO cv)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", cv.MaCongViec),
                new SqlParameter("@ten_cong_viec", cv.TenCongViec),
                new SqlParameter("@muc_luong", cv.MucLuong)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_CongViec_Them", parameters) > 0;
        }

        public bool SuaCongViec(CongViecDTO cv)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", cv.MaCongViec),
                new SqlParameter("@ten_cong_viec", cv.TenCongViec),
                new SqlParameter("@muc_luong", cv.MucLuong)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_CongViec_Sua", parameters) > 0;
        }

        public bool XoaMemCongViec(string maCongViec)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", maCongViec)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_CongViec_XoaMem", parameters) > 0;
        }

        public bool KhoiPhucCongViec(string maCongViec)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", maCongViec)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_CongViec_KhoiPhuc", parameters) > 0;
        }

        public CongViecDTO LayCongViecTheoMa(string maCongViec)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", maCongViec)
            };
            DataTable dt = DatabaseHelper.ExecuteReaderSP("sp_CongViec_LayTheoMa", parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new CongViecDTO
                {
                    MaCongViec = r["ma_cong_viec"].ToString(),
                    TenCongViec = r["ten_cong_viec"].ToString(),
                    MucLuong = r["muc_luong"] != DBNull.Value ? Convert.ToDecimal(r["muc_luong"]) : 0,
                    TrangThaiXoa = Convert.ToBoolean(r["trang_thai_xoa"])
                };
            }
            return null;
        }

        public bool KiemTraTonTaiCongViec(string maCongViec)
        {
            return base.KiemTraTonTai("cong_viec", "ma_cong_viec", maCongViec);
        }

        public bool KiemTraCongViecDangDuocSuDung(string maCongViec)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", maCongViec)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalarSP("sp_CongViec_KiemTraDangSuDung", parameters));
            return count > 0;
        }

        public bool KiemTraTrungTenCongViec(string tenCongViec, string maCongViecLoaiTru = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_cong_viec", tenCongViec.Trim()),
                new SqlParameter("@ma_cong_viec", string.IsNullOrEmpty(maCongViecLoaiTru) ? (object)DBNull.Value : maCongViecLoaiTru.Trim())
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalarSP("sp_CongViec_KiemTraTrungTen", parameters));
            return count > 0;
        }

        public string SinhMaCongViecTuDong()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.cong_viec", "ma_cong_viec", "CV");
        }

        public DataTable LayDanhSachNhanVien(bool chiLayDangHoatDong = true)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_NhanVien_LayDanhSach", parameters);
        }

        public bool KiemTraTonTaiNhanVien(string maNV)
        {
            return base.KiemTraTonTai("nhan_vien", "ma_nhan_vien", maNV);
        }

        public NhanVienDTO LayNhanVienTheoMa(string maNV)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", maNV)
            };
            DataTable dt = DatabaseHelper.ExecuteReaderSP("sp_NhanVien_LayTheoMa", parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new NhanVienDTO
                {
                    MaNhanVien = r["ma_nhan_vien"].ToString(),
                    TenNhanVien = r["ten_nhan_vien"].ToString(),
                    GioiTinh = r["gioi_tinh"] != DBNull.Value ? r["gioi_tinh"].ToString() : null,
                    NgaySinh = r["ngay_sinh"] != DBNull.Value ? Convert.ToDateTime(r["ngay_sinh"]) : (DateTime?)null,
                    DienThoai = r["dien_thoai"] != DBNull.Value ? r["dien_thoai"].ToString() : null,
                    DiaChi = r["dia_chi"] != DBNull.Value ? r["dia_chi"].ToString() : null,
                    TrangThaiXoa = Convert.ToBoolean(r["trang_thai_xoa"]),
                    MaCongViec = r["ma_cong_viec"] != DBNull.Value ? r["ma_cong_viec"].ToString() : null
                };
            }
            return null;
        }

        public bool ThemNhanVien(NhanVienDTO nv, SqlTransaction trans = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", nv.MaNhanVien),
                new SqlParameter("@ten_nhan_vien", nv.TenNhanVien),
                new SqlParameter("@gioi_tinh", (object)nv.GioiTinh ?? DBNull.Value),
                new SqlParameter("@ngay_sinh", nv.NgaySinh.HasValue ? (object)nv.NgaySinh.Value : DBNull.Value),
                new SqlParameter("@dien_thoai", (object)nv.DienThoai ?? DBNull.Value),
                new SqlParameter("@dia_chi", (object)nv.DiaChi ?? DBNull.Value),
                new SqlParameter("@ma_cong_viec", (object)nv.MaCongViec ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_NhanVien_Them", parameters, trans) > 0;
        }

        public bool CapNhatNhanVien(NhanVienDTO nv, SqlTransaction trans = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", nv.MaNhanVien),
                new SqlParameter("@ten_nhan_vien", nv.TenNhanVien),
                new SqlParameter("@gioi_tinh", (object)nv.GioiTinh ?? DBNull.Value),
                new SqlParameter("@ngay_sinh", nv.NgaySinh.HasValue ? (object)nv.NgaySinh.Value : DBNull.Value),
                new SqlParameter("@dien_thoai", (object)nv.DienThoai ?? DBNull.Value),
                new SqlParameter("@dia_chi", (object)nv.DiaChi ?? DBNull.Value),
                new SqlParameter("@ma_cong_viec", (object)nv.MaCongViec ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_NhanVien_CapNhat", parameters, trans) > 0;
        }

        public bool XoaMemNhanVien(string maNV)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", maNV)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_NhanVien_XoaMem", parameters) > 0;
        }

        public bool KhoiPhucNhanVien(string maNV)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", maNV)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_NhanVien_KhoiPhuc", parameters) > 0;
        }

        public bool KiemTraTonTaiTaiKhoan(string tenDangNhap)
        {
            return base.KiemTraTonTai("tai_khoan", "ten_dang_nhap", tenDangNhap);
        }

        public bool KiemTraNhanVienCoTaiKhoan(string maNV)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", maNV)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalarSP("sp_NhanVien_KiemTraCoTaiKhoan", parameters)) > 0;
        }

        public string LayTenDangNhapTheoMaNV(string maNV)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", maNV)
            };
            object result = DatabaseHelper.ExecuteScalarSP("sp_NhanVien_LayTenDangNhap", parameters);
            return result != null ? result.ToString().Trim() : string.Empty;
        }

        public bool ThemTaiKhoan(TaiKhoanDTO tk, SqlTransaction trans = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tk.TenDangNhap),
                new SqlParameter("@mat_khau", tk.MatKhau),
                new SqlParameter("@quyen", tk.Quyen),
                new SqlParameter("@trang_thai_hoat_dong", tk.TrangThaiHoatDong),
                new SqlParameter("@ma_nhan_vien", tk.MaNhanVien)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_TaiKhoan_Them", parameters, trans) > 0;
        }

        public bool CapNhatQuyenVaTrangThaiTaiKhoan(string tenDangNhap, string quyen, bool hoatDong, SqlTransaction trans = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tenDangNhap),
                new SqlParameter("@quyen", quyen),
                new SqlParameter("@trang_thai_hoat_dong", hoatDong)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_TaiKhoan_CapNhatQuyenVaTrangThai", parameters, trans) > 0;
        }

        public bool DoiTrangThaiTaiKhoan(string tenDangNhap, bool hoatDong)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tenDangNhap),
                new SqlParameter("@trang_thai_hoat_dong", hoatDong)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_TaiKhoan_DoiTrangThai", parameters) > 0;
        }

        public bool ResetMatKhau(string tenDangNhap, string matKhauBam, SqlTransaction trans = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tenDangNhap),
                new SqlParameter("@mat_khau", matKhauBam)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_TaiKhoan_ResetMatKhau", parameters, trans) > 0;
        }

        public DataTable LayThongTinDangNhap(string tenDangNhap)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tenDangNhap)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_TaiKhoan_LayThongTinDangNhap", parameters);
        }

        public string SinhMaNhanVienMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.nhan_vien", "ma_nhan_vien", "NV");
        }

        public bool ThemNhanVien(NhanVienDTO nv)
        {
            return ThemNhanVien(nv, null);
        }

        public bool SuaNhanVien(NhanVienDTO nv)
        {
            return CapNhatNhanVien(nv, null);
        }

        public string SinhMaCongViecMoi()
        {
            return SinhMaCongViecTuDong();
        }

        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhauPlain)
        {
            DataTable dt = LayThongTinDangNhap(tenDangNhap);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            string matKhauBamCSDL = row["mat_khau"]?.ToString() ?? string.Empty;
            string matKhauBamNhap = string.Empty;
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(matKhauPlain ?? string.Empty));
                var sb = new System.Text.StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                matKhauBamNhap = sb.ToString();
            }
            if (!string.Equals(matKhauBamCSDL, matKhauBamNhap, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            return new TaiKhoanDTO
            {
                TenDangNhap = row["ten_dang_nhap"]?.ToString(),
                Quyen = row["quyen"]?.ToString(),
                MaNhanVien = row["ma_nhan_vien"]?.ToString(),
                TenNhanVien = row["ten_nhan_vien"]?.ToString(),
                TrangThaiHoatDong = Convert.ToBoolean(row["trang_thai_hoat_dong"])
            };
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            DataTable dt = LayThongTinDangNhap(tenDangNhap);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            string matKhauBamCSDL = dt.Rows[0]["mat_khau"]?.ToString() ?? string.Empty;
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytesCu = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(matKhauCu ?? string.Empty));
                var sbCu = new System.Text.StringBuilder();
                foreach (byte b in bytesCu)
                {
                    sbCu.Append(b.ToString("x2"));
                }
                if (!string.Equals(matKhauBamCSDL, sbCu.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                byte[] bytesMoi = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(matKhauMoi ?? string.Empty));
                var sbMoi = new System.Text.StringBuilder();
                foreach (byte b in bytesMoi)
                {
                    sbMoi.Append(b.ToString("x2"));
                }
                return ResetMatKhau(tenDangNhap, sbMoi.ToString());
            }
        }
    }
}
